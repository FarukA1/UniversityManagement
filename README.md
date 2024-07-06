# University Management API

This project is a University Management System built with ASP.NET Core, providing RESTful API endpoints for managing various university entities such as Courses, Departments, Instructors, Students, Enrollments, Class Schedules, and Classrooms. The application leverages Entity Framework Core for data access and supports Docker for containerization.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Database Configuration](#database-configuration)
- [Docker Support](#docker-support)
- [Model Definitions](#model-definitions)
- [Contributing](#contributing)
- [License](#license)

## Features

- Manage Courses, Departments, Instructors, Students, Enrollments, Class Schedules, and Classrooms
- RESTful API architecture
- Entity Framework Core for data access
- Docker support for containerized deployment

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Docker

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/get-started)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/FarukA1/UniversityManagement.git
   cd university-management

### Running the Application

1. Run the application:

   ```bash
   dotnet run


### API Endpoints


- **Courses**
  - `GET /api/courses`
  - `GET /api/courses/{id}`
  - `POST /api/courses`
  - `PUT /api/courses/{id}`
  - `DELETE /api/courses/{id}`

- **Departments**
  - `GET /api/departments`
  - `GET /api/departments/{id}`
  - `POST /api/departments`
  - `PUT /api/departments/{id}`
  - `DELETE /api/departments/{id}`

- **Instructors**
  - `GET /api/instructors`
  - `GET /api/instructors/{id}`
  - `POST /api/instructors`
  - `PUT /api/instructors/{id}`
  - `DELETE /api/instructors/{id}`

- **Students**
  - `GET /api/students`
  - `GET /api/students/{id}`
  - `POST /api/students`
  - `PUT /api/students/{id}`
  - `DELETE /api/students/{id}`

- **Enrollments**
  - `GET /api/enrollments`
  - `GET /api/enrollments/{id}`
  - `POST /api/enrollments`
  - `PUT /api/enrollments/{id}`
  - `DELETE /api/enrollments/{id}`

- **ClassSchedules**
  - `GET /api/classschedules`
  - `GET /api/classschedules/{id}`
  - `POST /api/classschedules`
  - `PUT /api/classschedules/{id}`
  - `DELETE /api/classschedules/{id}`

- **Classrooms**
  - `GET /api/classrooms`
  - `GET /api/classrooms/{id}`
  - `POST /api/classrooms`
  - `PUT /api/classrooms/{id}`
  - `DELETE /api/classrooms/{id}`



### Database Configuration

The database is configured using Entity Framework Core. Ensure your connection string is correctly set in the `appsettings.json` file. Run the following command to apply any pending migrations:

    ```bash
    dotnet ef database update


### Docker Support

#### Building the Docker Image

1. Build the Docker image:

   ```bash
   docker build -t university-management-api .




