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

## 6. Planned Milestones

### Milestone 03 — Layered Multi-user Console Application

Planned improvements:

- Presentation layer
- Service layer
- Repository/data access layer
- User registration
- Login and logout
- Current user
- Validation
- User-specific data ownership

### Milestone 04 — Database Application

Planned improvements:

- Relational database
- SQL tables
- Primary and foreign keys
- Relationships between users, books, and borrowing records
- Dapper database access
- SQL CRUD operations

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
