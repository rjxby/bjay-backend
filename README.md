# Bjay API

## Prerequisites

- .NET SDK 9.0 or higher
- Docker
- Make
- Git

## Quick Start

### Run the application for Local Development

```bash
make dev
```

### Docker Development

Run the application in Docker:

```bash
make docker-run
```

## Database Migrations

### Add a New Migration

```bash
make db-add name=YourMigrationName
```

### Apply Migrations

```bash
make db-migrate
```

### Apply Migrations in Docker

```bash
docker run -e APPLY_MIGRATIONS=true [other-options] bjay-dev:latest
```

## Build

### Build Docker Image

```bash
make docker-build
```

## Project Structure

```
Backend/
├── Api/
│   ├── Host/                 # API host application
│   ├── Services/
│   │   └── Implementation/   # Service implementations
│   └── Repositories/
│       └── Implementation/   # Repository implementations
└── Makefile                # Build and deployment scripts
```

## Available Make Commands

- `make dev` - Run the application locally
- `make db-migrate` - Apply database migrations
- `make db-add name=MigrationName` - Create a new migration
- `make docker-build` - Build Docker image
- `make docker-run` - Run Docker container locally

## Development Guidelines

### CI/CD

- Drone CI automatically builds and tests all branches
- Version tags are automatically generated
- Deployments are automated for main/master branch

## Troubleshooting

### Common Issues

1. **Migration Failures**
   - Ensure database is accessible
   - Check connection strings
   - Verify current migration state

2. **Docker Issues**
   - Check Docker daemon is running
   - Verify port 7070 is available
   - Ensure sufficient permissions
