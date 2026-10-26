# Manga API

[![.NET](https://github.com/TheProdigy161/manga-api/actions/workflows/dotnet.yml/badge.svg)](https://github.com/TheProdigy161/manga-api/actions/workflows/dotnet.yml)

ASP.NET Core Web API for cataloguing manga series and their authors. It is the backend for [manga-frontend](https://github.com/TheProdigy161/manga-frontend).

## Features

- CRUD endpoints for **manga** and **authors**, with each manga linked to its author
- Paginated listing (`page` / `pageSize`, capped at 50 per page)
- Account registration and login via ASP.NET Core Identity bearer tokens
- Email delivery through Azure Communication Services
- Entity Framework Core with SQL Server; migrations apply automatically on startup
- Swagger UI in development
- CI/CD with GitHub Actions, deploying to Azure App Service

## Tech Stack

| Area | Technology |
|---|---|
| Framework | .NET 8, ASP.NET Core |
| Data | Entity Framework Core 8, SQL Server |
| Auth | ASP.NET Core Identity (bearer tokens) |
| Mapping | AutoMapper |
| Hosting | Azure App Service |

## API

| Method | Route | Auth | Description |
|---|---|---|---|
| `GET` | `/manga/paginated?page=1&pageSize=20` | – | Paginated list of manga |
| `GET` | `/manga/{id}` | – | Single manga |
| `GET` | `/manga?authorId={id}` | ✔ | All manga, optionally filtered by author |
| `POST` | `/manga` | ✔ | Create a manga |
| `PUT` | `/manga` | ✔ | Update a manga |
| `GET` | `/author/paginated` | ✔ | Paginated list of authors |
| `GET` | `/author/{id}` | ✔ | Single author |
| `GET` | `/author` | ✔ | All authors |
| `POST` | `/author` | ✔ | Create an author |
| `PUT` | `/author` | ✔ | Update an author |
| `POST` | `/auth/register`, `/auth/login`, … | – | Identity endpoints |
| `GET` | `/health` | – | Health check |

Protected routes expect an `Authorization: Bearer <token>` header from `/auth/login`.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Docker (for a local SQL Server)

### Run locally

```bash
# Start a local SQL Server container (port 1433)
./loadDb.sh

# Set the connection string in appsettings.Development.json, then:
ASPNETCORE_ENVIRONMENT=Development dotnet run
```

Swagger UI is then available at `/swagger`.

### Configuration

Settings are read from `appsettings.{Environment}.json`:

| Key | Purpose |
|---|---|
| `Database:ConnectionString` | SQL Server connection string |
| `EmailOptions:SenderAddress` / `ConnectionString` | Azure Communication Services email |
| `OriginUrls` | Allowed CORS origins (for example the frontend URL) |

## Database Migrations

```bash
# Add a migration
dotnet ef migrations add <MigrationName> -o ./Database/Migrations -v

# Remove the last migration
dotnet ef migrations remove -v
```

## Project Structure

```
Controllers/   API endpoints
Database/      DbContext, entity configs, migrations and seeding
Models/        Entities, DTOs and interfaces
Mappings/      AutoMapper profiles
Services/      Business logic and email
```
