#  Campus Management Enterprise API (.NET 8 Clean Architecture)

A production-grade RESTful API built with **.NET 8**, adhering strictly to **Clean Architecture** (Onion Architecture), Domain-Driven Design (DDD) principles, and the **Repository Pattern** using **EF Core & Dapper**.

---

###  Architecture Layers
- **`college_Domain`**: Core Enterprise Entities, Value Objects, and Domain DTOs (Zero external dependencies).
- **`college_Application`**: Business Logic, Abstraction Interfaces (`ICourseService`, etc.), and Service Implementations.
- **`college_Infrastructure`**: EF Core Context, **Dapper ORM Integration**, and Database Access Repositories.
- **`college_Controllers`**: Web API Layer, Dependency Injection Root, CORS configuration, and OpenAPI / Swagger Specifications.

---

###  Tech Stack & Tools
![.NET 8](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)

---

### Key Features
- **Clean Architecture & Separation of Concerns**: Strict layer encapsulation ensuring high maintainability and testability.
- **High-Performance Data Access**: Dual ORM setup using Entity Framework Core alongside **Dapper** for optimized query execution.
- **Full CRUD Support**: Complete operational lifecycle for Courses, Departments, Students, and Enrollments.
- **API Documentation**: Interactive OpenAPI 3.0 / Swagger UI interface for live endpoint testing.

---

### Getting Started

#### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (SSMS)

#### Local Setup & Execution
1. **Clone Repository:**
   ```bash
   git clone [https://github.com/abdulmuqsit1299/CollegeManagement.CleanArchitecture.git](https://github.com/abdulmuqsit1299/CollegeManagement.CleanArchitecture.git)
