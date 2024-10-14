# Simple CRUD Product API with Dapper and .NET Core

This project is a simple API for CRUD products using Dapper in ASP.NET Core. Dapper is a micro ORM (Object-Relational Mapper) that offers high performance and ease of use for database operations.

## Technologies Used

- **ASP.NET Core**: A framework for building fast and responsive web applications and APIs.
- **Dapper**: A micro ORM for .NET that allows high-performance data access without the overhead of larger ORMs like Entity Framework (EF).
- **SQL Server**: A relational database for storing product data.

## Why Choose Dapper?

- **High Performance**: Dapper is designed for speed. It avoids the overhead often associated with larger ORMs, allowing for quick and efficient CRUD operations.
- **Simplicity and Lightweight**: With just a few lines of code, you can execute SQL queries without extensive configurations or complex concepts.
- **Full Control Over SQL**: Dapper allows you to write optimized queries tailored to your application’s needs, enabling manual performance tuning when necessary.
- **Compatibility with Existing SQL**: You can use existing SQL directly without converting it into object models, making it ideal for integrating with existing databases.
- **Support for Custom Data Types**: Dapper simplifies handling complex data by allowing easy mapping of query results to custom data types.

## Project Structure

- **Models**: Contains data models for products.
- **Repository**: Contains logic for data access using Dapper, separating data access logic from controllers.
- **Controllers**: Contains API endpoints for managing products.

## API Endpoints

### 1. Get All Products

- **URL**: `GET /api/product`
- **Response Body**:
  ```json
  [
    {
        "id": 1,
        "name": "Product Name",
        "price": 99.99
    },
    ...
  ]
  ```
### 2. Add Product

- **URL**: `POST /api/product`
- **Request Body**:
  ```json
  {
      "name": "Product Name",
      "price": 99.99
  }
  ```

### 3. Update Product

- **URL**: `PUT /api/product`
- **Request Body**:
  ```json
  {
    "id": 1,
    "name": "Updated Product Name",
    "price": 79.99
  }
  ```

### 4. Get Product by ID

- **URL**: `GET /api/product/{id}`
- **Response Body**:
  ```json
  {
    "id": 1,
    "name": "Product Name",
    "price": 99.99
  }
  ```


### 5. Delete Product

- **URL**: `DELETE /api/product/{id}`
- **Response Body**:
  ```
  No content on success (HTTP status 204)
  ```
