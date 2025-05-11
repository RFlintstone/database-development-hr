# database-development-hr

A containerized development environment for working with PostgreSQL and pgAdmin, designed for the Database Development course at Hogeschool Rotterdam.

## Features

- **PostgreSQL**: Custom-configured instance with extended connection limits.
- **pgAdmin**: Web-based GUI for managing and querying your database.
- **ASP.NET Core App**: Backend service connected via Docker network.
- **Volume Persistence**: Data and pgAdmin settings persist across restarts.

## Getting Started

### Prerequisites

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

### Running the Project

```sh
docker-compose up --build
```

### pgAdmin
pgAdmin is exposed at http://localhost:8081 with the following credentials:

```
Email: admin@admin.com
Password: admin
```
The PostgreSQL server will be pre-configured with:
```
Host: postgres
Database: ruben
Username: postgres
Password: password
```
