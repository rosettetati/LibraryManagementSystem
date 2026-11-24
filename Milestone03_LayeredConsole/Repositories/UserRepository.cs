using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Milestone03_LayeredConsole.Models;

namespace Milestone03_LayeredConsole.Repositories
{
    public class UserRepository
    {
        private readonly string filePath;

        private readonly JsonSerializerOptions jsonOptions =
            new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };

        public UserRepository()
        {
            string dataFolder = Path.Combine(
                AppContext.BaseDirectory,
                "Data"
            );

            Directory.CreateDirectory(dataFolder);

            filePath = Path.Combine(dataFolder, "users.json");
        }

        public List<User> GetAll()
        {
            if (!File.Exists(filePath))
            {
                return new List<User>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<User>();
            }

            return JsonSerializer.Deserialize<List<User>>(
                json, jsonOptions
            ) ?? new List<User>();
        }

        public void SaveAll(List<User> users)
        {
            string json = JsonSerializer.Serialize(
                users, jsonOptions
            );

            File.WriteAllText(filePath, json);
        }

        public User? FindByUsername(string username)
        {
            return GetAll().FirstOrDefault(
                user => user.Username.Equals(
                    username,
                    StringComparison.OrdinalIgnoreCase
                )
            );
        }

        public User? GetById(int id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }
    }
}