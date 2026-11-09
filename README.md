# job-helper-api

the api to help with job applications and stuff.

### Dependencies

dotnet EF Core CLI tool for handing migrations.

```powershell
dotnet tool install --global dotnet-ef

```

### CLI Commands

```powershell
# Run
dotnet run
dotnet watch run  # With HMR feature
```

```powershell
# Database Migrations
dotnet ef migrations add	# Generate a migration from model changes
dotnet ef database update	# Apply migrations to your database
dotnet ef migrations list   # List migrations in your project
```

### what next

Understand the request lifecycle: Program.cs → controller → response.
Create your first controller with a simple GET endpoint.
Learn dependency injection and move business logic into a service.
Add Entity Framework Core to connect to a database.
Introduce DTOs and validation so your API doesn't expose database entities directly.
Add authentication, testing, and pagination once the basic API is working.

### Project Architecture

Code is organized around business capabilities, separating HTTP handling, business rules, and database operations.
I have implemented a feature based architecture.

#### Backend request lifecycle

1. Controller (HTTP Layer): Receives request, validates, returns HTTP response
2. Service (Business Logic Layer): Applies business rules, handles application logic, coordinates operations.
3. DbContext (Data Access Layer): Uses Entity Framework Core to query and modify PostgreSQL.
4. PostgreSQL (Database Layer): Persists data.

### Work Timeline

- [x] Server Hosting
- [x] CORS configuration: HTTP Communication
- [x] Docker Container configuration: compose files, volumes, PostgreSQL server hosting
- [x] Create PostgreSQL tables: pgAdmin, SQL queries, define database schemas
- [ ] Setup database operations: Entity Framework
- [ ] Create Authentication feature: DTOs, Validation, JWTs
- [ ] Create Job applications feature: CRUD, pagination
