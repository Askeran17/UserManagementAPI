# UserManagementAPI

## User Management API
- The User Management API is a back-end project developed to manage users with features like creating, updating, retrieving, and deleting user data. This API includes robust middleware implementations for logging, error handling, and authentication, ensuring reliability, security, and maintainability.

### Features
- CRUD operations: Create, Read, Update, and Delete user data.

#### Middleware for logging:

- Logs all incoming HTTP requests with method and path.

- Logs all outgoing responses with status codes.

#### Middleware for error handling:

- Handles unhandled exceptions.

- Provides consistent error responses in JSON format.

#### Middleware for authentication:

- Validates tokens from incoming requests.

- Blocks unauthorized users with 401 Unauthorized responses.

#### Validation:

- Ensures user data includes required fields such as name and email.

- Validates email format and ensures non-nullable properties are properly populated.

- Used Postman

### Technologies Used
- ASP.NET Core 8: Framework for building the API.

- C#: Primary programming language.

- System.IdentityModel.Tokens.Jwt: For token validation in authentication middleware.