using Microsoft.EntityFrameworkCore;
using Milestone04_Database.Data;
using Milestone04_Database.Models;

namespace Milestone04_Database.Repositories;

public class UserRepository
{
    public void Add(User user)
    {
        using LibraryDbContext db = new();

        db.Users.Add(user);
        db.SaveChanges();
    }

    public List<User> GetAll()
    {
        using LibraryDbContext db = new();

        return db.Users.ToList();
    }

    public User? GetById(int id)
    {
        using LibraryDbContext db = new();

        return db.Users.FirstOrDefault(u => u.Id == id);
    }

    public User? GetByUsername(string username)
    {
        using LibraryDbContext db = new();

        return db.Users.FirstOrDefault(
            u => u.Username.ToLower() == username.ToLower());
    }

    public bool UsernameExists(string username)
    {
        using LibraryDbContext db = new();

        return db.Users.Any(
            u => u.Username.ToLower() == username.ToLower());
    }

    public void Delete(int id)
    {
        using LibraryDbContext db = new();

        User? user = db.Users.Find(id);

        if (user != null)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}