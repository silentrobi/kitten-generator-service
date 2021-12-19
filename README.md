# Kitten Image Generator

**Migration Command**
- Visual Studio: `Update-database`
- CLI: `dotnet ef database update`

## Features
- Onion Architecture
- CQRS pattern with MediatR library
- Entity Framework Core - Code First
- Repository Pattern - Generic
- DDD
- MediatR Pipeline Logging & Validation
- Swagger UI
- PostgreSQL
- Fluent Validation
- JWT Authentication + Authorization
- Role based Authorization


## API routes

**User Service**

***Protected Routes***

- Get user list: `GET /api/users/`
- Update an user: `PUT /api/users/:id`
- Delete an user: `DELETE /api/users/:id`

***Unprotected Routes***
- Create an user: `POST /api/users`
- Authenticate an user: `POST /api/users/authenticate`

**Image Generator Service**

***Protected Routes***
- Generate a cat image: `GET /api/cat`


## Description
In order to get generated cat, user need to authenticate using `POST /api/users/authenticate` route. This will return JWT that includes user claims. I tried to implement RBAC to api routes. There are two roles avilable: `admin` and `user`. 

Steps to follow:
1. Create user (admin/user)
2. Authenticate user with username and password that returns JWT
3. Add `Bearer` token to header with subsequent requests.

**Some Notes**
1. If auto migration doesn't work then update database manually using this command: 
        - Visual Studio: `Update-database`
        - CLI: `dotnet ef database update`
2. Project is tested manually. No test automation (like Unit test, Integration test etc.) included in the project.
