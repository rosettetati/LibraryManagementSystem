# Library Management System

## Project Overview

The Library Management System is a C# and .NET application developed throughout the semester. It demonstrates the gradual evolution of a basic console program into a database-backed RESTful Web API.

The system manages library books and user accounts, introducing programming, software architecture, persistence, and backend development concepts across five milestones.

## Project Structure

```text
LibraryManagementSystem/
├── Milestone01_BasicConsole/
├── Milestone02_OOP/
├── Milestone03_LayeredConsole/
├── Milestone04_Database/
├── Milestone05_WebAPI/
└── README.md
```

## Development Milestones

### Milestone 01 – Basic Console Application
Introduces the fundamental functionality of the library system.

- Console menu and user interaction
- Basic CRUD operations for books
- Variables, conditions, loops, methods, and collections
- JSON file persistence

### Milestone 02 – Object-Oriented Programming
Improves the initial application through object-oriented design.

- Classes, objects, properties, and constructors
- Encapsulation
- Structured domain models
- JSON serialization and deserialization

### Milestone 03 – Layered Multi-user Application
Introduces a more maintainable architecture and user management.

- Presentation, service, and repository layers
- User registration, login, and logout
- Input validation and business logic
- Owner-specific book management
- JSON-based persistence

### Milestone 04 – Database Application
Replaces file-based persistence with relational database storage.

- SQLite database
- Entity Framework Core
- Users and Books tables
- One-to-many relationship
- Database queries and persistent storage

### Milestone 05 – ASP.NET Core Web API
Transforms the application into a RESTful backend service.

- ASP.NET Core Web API
- CRUD endpoints for books
- User registration and login endpoints
- Data Transfer Objects (DTOs)
- Input and business validation
- HTTP status codes
- Swagger/OpenAPI documentation
- SQLite and Entity Framework Core

## Technologies

- **Language:** C#
- **Framework:** .NET
- **IDE:** Visual Studio
- **Persistence:** JSON and SQLite
- **ORM:** Entity Framework Core
- **API:** ASP.NET Core Web API
- **Documentation:** Swagger/OpenAPI

## Running the Projects

Each milestone is maintained as a separate project.

1. Open the corresponding milestone folder in Visual Studio.
2. Select its project as the startup project.
3. Build and run the application.

For Milestone 05, run the Web API and open Swagger:

`https://localhost:7146/swagger`

The port may vary depending on the launch settings.

## Project Evolution

The project demonstrates the gradual introduction of backend development concepts:

| Milestone | Main Focus |
|---|---|
| 01 | Programming fundamentals |
| 02 | Object-oriented programming |
| 03 | Layered architecture and multi-user management |
| 04 | Relational databases and persistence |
| 05 | RESTful Web API development |

## Conclusion

The project demonstrates the development of a consistent application through five stages, progressing from basic programming concepts to structured backend architecture, relational database integration, and RESTful API development.