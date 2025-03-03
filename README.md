# EconomicsTrackerApi

EconomicsTrackerApi is a .NET Core Web API designed to track and manage economic data along with their associated indicators, regions, and source. It provides a structured way to store, retrieve, and analyse economic information.

## Features
- User authentication and authorisation using JWT.
- CRUD operations for economic indicators, news, and data.
- Secure API with role-based access control.
- Rate limiting to prevent abuse.
- CORS support for cross-origin requests.
- Refresh tokens for session management.
- CI/CD pipeline with GitHub Actions.
- Deployment on Azure.

## Technologies Used
- **.NET Core 9.0.1**
- **Entity Framework Core** for database management
- **SQL Server** for data storage
- **JWT Authentication** for security
- **Azure App Service** for deployment
- **GitHub Actions** for CI/CD
- **Docker** for containerisation

## Setup Instructions

### Prerequisites
- .NET SDK (9.0.1)
- SQL Server or a cloud database
- Docker (optional, for containerization)
- Azure account (if deploying to Azure)

### Installation
1. Clone the repository
2. Set up the database
   - Update the connection string in `appsettings.json` or use Azure App Configuration.
   - Apply migrations
3. Configure environment variables
4. Run the application:

### API Endpoints
| Method | Endpoint | Description |
|--------|---------|-------------|
| `POST` | `/api/auth/login` | User login and token generation |
| `POST` | `/api/auth/register` | User registration |
| `GET` | `/api/indicators` | Retrieve all economic indicators |
| `POST` | `/api/indicators` | Create a new economic indicator |
| `GET` | `/api/source/1` | Retrieve source by id |

### Authentication
- The API uses JWT for authentication.
- Include the token in the `Authorization` header: `Bearer <token>`

### Rate Limiting
- Implemented using `Middleware`.
- Default settings limit requests per minute.

### CORS Configuration
- Configured in `Program.cs`:

### Deployment to Azure
1. Set up an **Azure App Service**.
2. Configure **app settings** in Azure.
3. Use **GitHub Actions** for CI/CD.
4. Deploy

## License
This project is licensed under the MIT License.


