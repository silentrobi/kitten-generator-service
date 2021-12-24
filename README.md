# Kitten Image Generator

## Setup steps
1. Run the following commands: `docker-compose -f ./service-infrastructure.yml up -d`.
 This will install all the required services along with the **kittenservice**. 
The server will run with port `8000` on `http` server.

2. If you want to run from local machine then set The following `env` variable:  
`CONNECTION_STRING="Server=localhost;Port=5432;Database=identitydb;User ID=postgres;Password=123456;"`

## Features
- .NET 5
- Onion Architecture
- CQRS pattern with MediatR library
- Entity Framework Core - Code First
- Repository Pattern - Generic
- DDD
- MediatR Pipeline & Validation
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
In order to get generated cat, user need to authenticate using `POST /api/users/authenticate` route. This will return JWT that includes user claims. I tried to implement RBAC to api routes. There are two roles available: `admin` and `user`. 

Steps to follow:
1. Create user (admin/user)
2. Authenticate user with username and password that returns JWT
3. Add `Bearer` token to header with subsequent requests.

**Some Notes**
1. If auto migration doesn't work then update database manually using this command: 
        - Visual Studio: `Update-database`
        - CLI: `dotnet ef database update`
2. Project is tested manually. No test automation (like Unit test, Integration test etc.) included in the project.
