# job-helper-api

the api to help with job applications and stuff. The backend will support the app and let users register and login. A user will submit information about their job applications and be able to track statuses, answers, resume versions. 

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
### Project Architecture

Code is organized around business capabilities, separating HTTP handling, business rules, and database operations.
I have implemented a feature based architecture.

#### Backend request lifecycle

1. Controller (HTTP Layer): Receives request, validates, returns HTTP response
2. Service (Business Logic Layer): Applies business rules, handles application logic, coordinates operations.
3. DbContext (Data Access Layer): Uses Entity Framework Core to query and modify PostgreSQL.
4. PostgreSQL (Database Layer): Persists data.

### Endpoints

### Endpoints

Base URL: `http://localhost:<port>/api`

Auth: 🔒 = requires `Authorization: Bearer <token>`

#### Overview

| Feature | Method | Route                  | Auth | Description                  | Status  |
|---------|--------|------------------------|------|------------------------------|---------|
| Auth    | POST   | `/auth/register`       |      | Create a new user account    | 🚧 WIP  |
| Auth    | POST   | `/auth/login`          |      | Log in, returns a token      | 📝 Plan |
| Jobs    | GET    | `/jobs`                | 🔒   | List the user's applications | 📝 Plan |
| Jobs    | GET    | `/jobs/{id}`           | 🔒   | Get one application          | 📝 Plan |
| Jobs    | POST   | `/jobs`                | 🔒   | Create an application        | 📝 Plan |
| Jobs    | PUT    | `/jobs/{id}`           | 🔒   | Update an application        | 📝 Plan |
| Jobs    | DELETE | `/jobs/{id}`           | 🔒   | Delete an application        | 📝 Plan |

Status key: 📝 Plan · 🚧 WIP · ✅ Done

---

#### Auth

##### `POST /auth/register`

Create a new user account.

- **Auth:** None
- **Controller → Service:** `AuthController.Register` → `AuthService.RegisterAsync`
- **Request DTO:** `UserRegisterRequest`
- **Validator:** `UserRegisterRequestValidator`

**Request body**

```json
{
  "email": "user@example.com",
  "password": "string"
}
```

**Validation rules**

| Field    | Rules                         |
|----------|-------------------------------|
| email    | required, valid email format  |
| password | required, min 8 chars         |

**Responses**

| Code | Meaning              | Body                     |
|------|----------------------|--------------------------|
| 201  | Created              | `{ "id": "...", "email": "..." }` |
| 400  | Validation failed    | `ProblemDetails` / errors |
| 409  | Email already in use | error message            |

---

##### `METHOD /route/{param}`  <!-- copy this block for each new endpoint -->

Short description.

- **Auth:** None / 🔒
- **Controller → Service:** `XController.Method` → `XService.MethodAsync`
- **Request DTO:** `...`
- **Validator:** `...`

**Route / query params**

| Name | In    | Type | Required | Description |
|------|-------|------|----------|-------------|
| id   | route | int  | yes      | ...         |

**Request body**

```json
{}
```

**Responses**

| Code | Meaning | Body |
|------|---------|------|
| 200  | OK      | ...  |