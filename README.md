
# CRUD Mini Project

Overview

This project is a simple, clean-architecture CRUD (Create, Read, Update, Delete) application built using ASP.NET Core MVC and Entity Framework Core. It is designed to manage essential laboratory reference data entities (Analyse, Parameter, Method, and SampleType) while demonstrating best practices in application security, data integrity, and separation of concerns.


Technology Stack

| Category    | Technology                      | Version / Type                    |
| Framework   | ASP.NET Core                    | MVC                               |
| Language**  | C#                              | .NET                              |
| Data Access | Entity Framework Core (EF Core) | ORM                               |
| Database    | SQL Server                      | (Configured via appsettings.json) |
| Mapping     | AutoMapper                      | Dependency Injection              |

------------------------------

- Key Features & Architectural Extensions

This project implements several critical architectural features to ensure maintainability and data integrity:

1. Separation of Concerns (View Models)

We utilize **View Models (DTOs)** for entity (AnalyseViewModel) to decouple the database models (Entities) from the presentation layer (Views).

Benefit: This prevents over-posting attacks and allows the presentation layer to work with simplified, tailored data structures.

2. AutoMapper Integration

AutoMapper is used to seamlessly handle the conversion of data between the EF Core Entities and the View Models.

Feature: Includes custom mapping logic for complex entities like Analyse to automatically map Foreign Key IDs (parameter_id) into human-readable strings (ParameterCode) for display in the Index views.

3. Safe Update Pattern (Data Integrity)

All Edit actions implement the **Fetch-and-Update** pattern using TryUpdateModelAsync or IMapper.Map() after fetching the original entity.

Feature: This ensures that sensitive **Audit Fields** (CreatedOn, CreatedById, IsActive) are **preserved** and are not overwritten or reset to default values during an update operation.

4. Audit Fields

All base entities inherit audit fields to track history and state:

* CreatedOn, CreatedById
* LastUpdateDate, LastUpdateById
* IsActive (Soft Delete flag)


-----------------------------------
 Setup and Configuration

Prerequisites

* .NET SDK (compatible with your project's target framework)
* SQL Server instance
* Visual Studio or VS Code

1. Database Configuration

Update the connection string in **appsettings.json** to point to your local or remote SQL Server instance.

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YourProjectDb;Trusted_Connection=True;MultipleActiveResultSets=true"
} 

2. Run migration
dotnet ef database update --context ApplicationDbContext

3. Run the application
dotnet run
