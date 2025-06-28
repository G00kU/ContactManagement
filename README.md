# .NET Core and React.js Authentication System

This project demonstrates the implementation of a simple authentication system using **.NET Core** (Backend) and **React.js** (Frontend). It includes the following features:

- **JWT Authentication** for secure API access
- **Mocking** of services using **Moq**
- **Unit Testing** with **xUnit**
- **Dependency Injection** for better testability and decoupling
- Responsive **React.js** frontend with Bootstrap components

---

## Features

- **Backend** (ASP.NET Core):
  - JWT-based authentication system
  - Hardcoded `admin` username and password for login (for demonstration purposes)
  - Dependency Injection for services
  - API secured with JWT tokens (all API calls require a valid token)

- **Frontend** (React.js):
  - Simple **login screen** to accept user credentials
  - **Bootstrap components** for responsive design
  - **JWT Token** passed in the header of API requests to authorize them

---

## Requirements

- **.NET 8.0** (for backend)
- **React.js** and **Bootstrap** for frontend UI
- **SQL Server** (or replace with your preferred database for local setup)

---

## Setup

### 1. **Backend Setup** (.NET Core)

1. **Clone the repository:**

   ```bash
   git clone https://github.com/G00kU/ContactManagement
