# 🛒 E-Commerce Backend API

This is a full-featured **E-Commerce Backend** built with **ASP.NET Core Web API** following a clean architecture with the Repository → Service → Controller pattern. The API handles products, orders, users, reviews, wishlist, shipping, and authentication using JWT.

---

## 📦 Features

- 🔐 **JWT Authentication & Authorization**
- 🛍️ **Product, Category, and SubCategory Management**
- 📦 **Order Processing and Tracking**
- 📝 **Review System**
- ❤️ **Wishlist Management**
- 🚚 **Shipping Service**
- 📦 **AWS S3 Integration** for image storage
- 🧩 **Clean Architecture**: Repository → Service → Controller
- 🔄 **Background Services** for shipping status updates
- 🌐 **CORS** enabled for cross-origin frontend communication

---

## 🛠️ Tech Stack

- ASP.NET Core 8 Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- AWS S3 (Amazon Simple Storage Service)
- AutoMapper
- Swagger (optional)
- Hosted Services
- Dependency Injection

---

## 🧱 Project Structure

```bash
ECommerce/
├── Controllers/
├── Data/
│   └── ApplicationDbContext.cs
├── Domain/
│   └── Models/
├── Infrastructure/
│   ├── Interfaces/
│   └── Repositories/
├── Application/
│   ├── Interfaces/
│   └── Services/
├── Program.cs
└── appsettings.json
