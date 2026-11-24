using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Milestone03_LayeredConsole.Models;

namespace Milestone03_LayeredConsole.Repositories
{
    public class BookRepository
    {
        private readonly string filePath;

        private readonly JsonSerializerOptions jsonOptions =
            new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };

        public BookRepository()
        {
            string dataFolder = Path.Combine(
                AppContext.BaseDirectory,
                "Data"
            );

            Directory.CreateDirectory(dataFolder);

            filePath = Path.Combine(dataFolder, "books.json");
        }

        public List<Book> GetAll()
        {
            if (!File.Exists(filePath))
            {
                return new List<Book>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Book>();
            }

            return JsonSerializer.Deserialize<List<Book>>(
                json, jsonOptions
            ) ?? new List<Book>();
        }

        public void SaveAll(List<Book> books)
        {
            string json = JsonSerializer.Serialize(
                books, jsonOptions
            );

            File.WriteAllText(filePath, json);
        }

        public Book? GetById(int id)
        {
            return GetAll().FirstOrDefault(book => book.Id == id);
        }

        public List<Book> GetByOwnerId(int ownerUserId)
        {
            return GetAll()
                .Where(book => book.OwnerUserId == ownerUserId)
                .ToList();
        }
    }
}