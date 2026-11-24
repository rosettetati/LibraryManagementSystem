
using Milestone04_Database.Models;
using Milestone04_Database.Repositories;
using Milestone04_Database.Security;

namespace Milestone04_Database.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService()
    {
        _userRepository = new UserRepository();
    }

    public bool RegisterUser(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
            return false;

        if (string.IsNullOrWhiteSpace(password))
            return false;

        if (password.Length < 6)
            return false;

        if (_userRepository.UsernameExists(username))
            return false;

        string passwordHash = PasswordHasher.HashPassword(password);

        User user = new User
        {
            Username = username.Trim(),
            PasswordHash = passwordHash
        };

        _userRepository.Add(user);
        return true;
    }

    public User? Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password))
            return null;

        User? user = _userRepository.GetByUsername(username);

        if (user == null)
            return null;

        bool passwordValid = PasswordHasher.VerifyPassword(
            password,
            user.PasswordHash);

        return passwordValid ? user : null;
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public User? GetUserById(int id)
    {
        return _userRepository.GetById(id);
    }

    public bool DeleteUser(int id)
    {
        if (_userRepository.GetById(id) == null)
            return false;

        _userRepository.Delete(id);
        return true;
    }
}
