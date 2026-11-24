
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Milestone03_LayeredConsole.Models;
using Milestone03_LayeredConsole.Repositories;

namespace Milestone03_LayeredConsole.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;

        public User? CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // Register a new user
        public bool Register(
            string username,
            string password,
            out string message)
        {
            username = username.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                message = "Username cannot be empty.";
                return false;
            }

            if (username.Length < 3 || username.Length > 20)
            {
                message = "Username must be 3-20 characters long.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                message = "Password must be at least 8 characters long.";
                return false;
            }

            if (userRepository.FindByUsername(username) != null)
            {
                message = "Username already exists.";
                return false;
            }

            List<User> users = userRepository.GetAll();

            int newId = users.Count == 0
                ? 1
                : users.Max(user => user.Id) + 1;

            string passwordHash = HashPassword(password);

            User newUser = new User(
                newId,
                username,
                passwordHash
            );

            users.Add(newUser);
            userRepository.SaveAll(users);

            message = "Registration successful!";
            return true;
        }

        // Login an existing user
        public bool Login(
            string username,
            string password,
            out string message)
        {
            User? user = userRepository.FindByUsername(username.Trim());

            if (user == null)
            {
                message = "User not found.";
                return false;
            }

            if (!VerifyPassword(password, user.PasswordHash))
            {
                message = "Incorrect password.";
                return false;
            }

            CurrentUser = user;

            message = $"Welcome, {user.Username}!";
            return true;
        }

        // Logout current user
        public void Logout()
        {
            CurrentUser = null;
        }

        // Hash password securely with PBKDF2
        private string HashPassword(string password)
        {
            const int iterations = 100000;
            const int hashSize = 32;

            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256,
                hashSize
            );

            return $"PBKDF2${iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
        }

        // Verify password
        private bool VerifyPassword(
            string password,
            string storedHash)
        {
            try
            {
                string[] parts = storedHash.Split('$');

                if (parts.Length != 4 || parts[0] != "PBKDF2")
                {
                    return false;
                }

                int iterations = int.Parse(parts[1]);

                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] expectedHash = Convert.FromBase64String(parts[3]);

                byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    iterations,
                    HashAlgorithmName.SHA256,
                    expectedHash.Length
                );

                return CryptographicOperations.FixedTimeEquals(
                    actualHash,
                    expectedHash
                );
            }
            catch
            {
                return false;
            }
        }
    }
}
