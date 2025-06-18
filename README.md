# 📝 ToDo API Project

---

## 🚀 Project Overview

This project is a **RESTful API** built with **ASP.NET Core** to manage **Categories** and **Todo tasks**.  
It supports **user authentication** via **JWT tokens**, allowing users to register, login, and securely manage their todo lists.

---

## 🛠️ Tools & Packages Used

| Tool / Package                  | Purpose                           |
|-------------------------------|---------------------------------|
| ASP.NET Core 7.0               | Web API framework                |
| Entity Framework Core          | Database ORM                    |
| Microsoft.AspNetCore.Identity  | User authentication & management|
| JWT Bearer Authentication      | Token-based security (JSON Web Tokens)            |
| Swagger / OpenAPI              | API documentation & testing UI  |
| SQL Server                    | Database backend                |

---

![ToDo API Screenshot](https://b.top4top.io/p_34567i8n71.png)


---
## 📂 API Controllers

### 🔐 `AuthController.cs`

- Handles user authentication.
- **Endpoints:**
  - `POST /api/Auth/register` → Register a new user
  - `POST /api/Auth/login` → Login and receive JWT token

---

### 🗂️ `CategoryController.cs`

- Manages task categories.
- **JWT Protected:** ✅ Yes
- **Endpoints:**
  - `GET /api/Category` → Get all categories
  - `POST /api/Category` → Create new category
  - `PUT /api/Category/{id}` → Update category
  - `DELETE /api/Category/{id}` → Delete category

---

### ✅ `TodoController.cs`

- Manages todo items.
- **JWT Protected:** ✅ Yes
- **Endpoints:**
  - `GET /api/Todo` → Get all todos
  - `POST /api/Todo` → Create new todo
  - `PUT /api/Todo/{id}` → Update todo
  - `DELETE /api/Todo/{id}` → Delete todo

---
---

## 📚 What is JWT?

**JWT (JSON Web Token)** is a compact, URL-safe way to securely transmit information between client and server as a JSON object.  
It is commonly used for authentication:

- After logging in, the server creates a JWT signed token.
- The client stores this token (usually in memory or local storage).
- For every protected request, the client sends the JWT in the Authorization header.
- The server validates the token to authorize the user without needing to check credentials every time.

JWT helps to build stateless, scalable APIs by avoiding server-side session storage.

---

## 📦 What is DTO?

**DTO (Data Transfer Object)** is a simple object used to transfer data between layers, especially between the client and server.

- It contains only the data needed for communication.
- It helps to **separate internal data models** from what is exposed externally.
- Makes the API more secure and maintainable by **hiding unnecessary fields**.
- Improves performance by sending only required data.

---

## ⚙️ How to Use

### 1. Clone the repository
```bash
git clone https://github.com/yourusername/todo-api.git
```
### 2. Dont forget to do (update-migration) to make the project work and dont forget to check json file for database location !!!! 


