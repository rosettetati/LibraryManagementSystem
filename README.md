# Library Management System

## 1. Project Description

The Library Management System is a C# application developed during the semester to demonstrate the gradual evolution of a software project while learning programming, object-oriented programming, backend development, and database concepts.

The application allows users to manage library books. The main functionality includes adding books, displaying books, searching for books, and deleting books.

The project is developed in several milestones. Each milestone builds upon the same project idea while introducing new programming concepts and technologies.

## 2. Technologies Used

- C#
- .NET
- Visual Studio
- JSON file persistence
- Object-Oriented Programming
- LINQ

Technologies for later milestones will be added as the project evolves.

## 3. Project Structure

```text
LibraryManagementSystem/
│
├── Milestone01_BasicConsole/
│   └── Program.cs
│
├── Milestone02_OOP/
│   ├── Program.cs
│   ├── Book.cs
│   └── books.json
│
├── Milestone03_LayeredConsole/ (planned)
├── Milestone04_Database/ (planned)
├── Milestone05_WebAPI/ (planned)
│
└── README.md
```

## 4. Milestone 01 — Basic Console Application

### Description

The first version of the application was created as a basic console program. It provides a menu that allows the user to add, list, find, and delete books.

Books were stored as strings in a collection. The application used JSON file persistence to save book information so that data could remain available after restarting the program.

### Features

- Console menu
- Add books
- List books
- Find books
- Delete books
- Input handling
- Collection-based data storage
- JSON file persistence

### Concepts Demonstrated

- Variables and basic data types
- Conditions
- Loops
- Methods
- Collections
- Basic CRUD operations
- JSON serialization and deserialization
- File operations

### How to Run

1. Open the `LibraryManagementSystem` solution in Visual Studio.
2. Set `Milestone01_BasicConsole` as the startup project.
3. Run the application using Ctrl + F5.
4. Select an option from the console menu.

## 5. Milestone 02 — OOP and Persistence

### Description

The second version improved the structure of the application by introducing object-oriented programming.

Instead of storing books as strings, the application now uses a `Book` class. Each book is represented as an object with its own properties and behavior.

JSON persistence was retained and updated to store structured book objects.

### Book Model

Each book contains:

- Id
- Title
- Author
- Genre
- PublicationYear
- IsAvailable

### Features

- Add books as objects
- List book objects
- Search books by title or author
- Delete books using their IDs
- Save book objects to JSON
- Load book objects from JSON
- Display book information through a class method

### Concepts Demonstrated

- Classes
- Objects
- Constructors
- Properties
- Encapsulation
- Object methods
- Collections of objects
- LINQ
- JSON serialization and deserialization
- Persistence

### Changes from Milestone 01

In Milestone 01, book information was stored as strings. This made the data less structured and difficult to manage.

In Milestone 02, a `Book` class was introduced to organize book information into separate properties. Objects are created using a constructor, and the application uses a `List<Book>` collection.

Book IDs were introduced to identify books when deleting them. LINQ was used for searching and finding books. JSON persistence was updated to store complete book objects instead of strings.

This milestone made the application more organized and prepared it for future development using services, repositories, and a database.

### How to Run

1. Open the `LibraryManagementSystem` solution in Visual Studio.
2. Set `Milestone02_OOP` as the startup project.
3. Run the application using Ctrl + F5.
4. Use the console menu to manage books.
5. The application saves its data in the `books.json` file.

## Milestone 03 – Layered Console Application

### Overview
The Library Management System was refactored into a layered architecture to improve maintainability, separation of concerns, and support for multiple users.

### Architecture
- **Models:** Defines User and Book entities.
- **Repositories:** Handles JSON file storage and data retrieval.
- **Services:** Contains business logic, validation, authentication, and ownership checks.
- **Presentation:** Provides console menus and user interaction.

### Features
- User registration and login
- Secure password hashing
- Logout and current-user tracking
- Personal book libraries
- Add, list, search, and delete books
- Borrow and return books
- User-specific data access and ownership validation
- JSON persistence

### Testing
Successfully tested registration, login, book operations, borrowing and returning, multi-user isolation, and unauthorized deletion protection.

### Technologies
- C#
- .NET 10
- JSON
- Object-Oriented Programming
- Layered Architecture


### Milestone 04 – Database Integration

**Status: Completed**

Milestone 04 upgrades the Library Management System from JSON file storage to a relational SQLite database using Entity Framework Core.

#### Technologies
- C#
- .NET 10
- Entity Framework Core 10
- SQLite

#### Database Structure

The application uses two main database tables:

**Users**
- `Id` – Primary key
- `Username` – Unique username
- `PasswordHash` – Securely hashed password

**Books**
- `Id` – Primary key
- `Title` – Book title
- `Author` – Book author
- `Genre` – Book genre
- `PublicationYear` – Year of publication
- `IsAvailable` – Borrowing status
- `UserId` – Foreign key referencing `Users.Id`

The relationship between the tables is one-to-many: one user can own multiple books, and each book belongs to one user.

#### Database Features
- SQLite database creation and initialization using Entity Framework Core.
- Entity classes mapped to relational database tables.
- Unique username constraint.
- Required fields for book title and author.
- Foreign key relationship between users and books.
- Cascade deletion of a user's books when that user is deleted.
- Repository classes for database operations.
- LINQ queries for retrieving, searching, and filtering records.
- User-specific book access and ownership checks.
- Password hashing using PBKDF2 with SHA-256.

#### SQL and Database Concepts

Entity Framework Core translates LINQ queries into SQL statements executed by SQLite.

Examples of the equivalent SQL operations include:

```sql
-- Retrieve books belonging to a user
SELECT * FROM Books
WHERE UserId = 1;

-- Search books by title or author
SELECT * FROM Books
WHERE UserId = 1
AND (Title LIKE '%Hobbit%'
     OR Author LIKE '%Hobbit%');

-- Update a book's availability
UPDATE Books
SET IsAvailable = 0
WHERE Id = 1 AND UserId = 1;

-- Delete a user's book
DELETE FROM Books
WHERE Id = 1 AND UserId = 1;
```

These examples illustrate the SQL operations represented by the application's Entity Framework queries.

#### Testing
The following functionality was tested successfully:
- Database initialization.
- User registration and login.
- Adding and listing books.
- Searching by title and author.
- Borrowing and returning books.
- Deleting books.
- Persistent storage in SQLite.
- Isolation of books between different users.
- Prevention of unauthorized access to another user's books.

**Result:** Milestone 04 successfully introduces relational database storage and Entity Framework Core into the Library Management System.

### Milestone 05 — Basic Web API

Planned improvements:

- ASP.NET Core Web API
- HTTP endpoints
- GET, POST, PUT, and DELETE
- DTOs
- Validation
- HTTP status codes
- Swagger/OpenAPI

## 7. Project Evolution

The project evolves from a simple console application using collections and JSON into an object-oriented application, then into a layered multi-user application, a database-connected application, and finally a Web API.

Each milestone introduces new concepts while keeping the same Library Management System project idea.
