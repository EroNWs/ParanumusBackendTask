# HelloWorldMinimalApi

HelloWorldMinimalApi is a simple .NET project demonstrating how to set up a minimal API that responds with "Hello World" to HTTP GET requests at https://localhost:5000.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them:

- .NET 6.0 SDK or later

### Installing

A step-by-step series of examples that tell you how to get a development environment running:

1. Clone the repository to your local machine:

```bash
git clone https://github.com/EroNWs/ParanumusBackendTask.git
```
---------

## Navigate to the project directory:
```bash
cd HelloWorldMinimalApi projects location
```

## Run the project:
```bash
dotnet run
```

This will start the application on https://localhost:5000. You can access the application via a web browser or using a tool like curl:

```bash
curl https://localhost:5000
```

## You should see the response:
Hello World


-------------------------------------------------------------------------------------------------------------------------------------------------------------



# CalculateAverage Minimal API

The CalculateAverage Minimal API is a simple yet powerful .NET 6 web application designed to demonstrate a clean and efficient implementation of a web service that calculates the average value of a series of integers. It showcases error handling, input validation, and the elegance of Minimal APIs in ASP.NET Core.

## Features

- Minimal API endpoint to calculate the average of integers.
- Robust error handling for null or empty inputs and incorrect input formats.
- User-friendly error messages to facilitate debugging and correct usage.

## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

- .NET 6 SDK or later

### Installation

1. Clone the repository:
```bash
git clone https://github.com/EroNWs/ParanumusBackendTask.git
```

## Navigate to the project directory:
```bash
cd CalculateAverageMinimalApi projects location
```

## Run the application:
```bash
dotnet run
```

## Access the application:
Access the web service by navigating to https://localhost:5001/calculateaverage?numbers=1,2,3 in your web browser or using a tool like curl or Postman, replacing 1,2,3 with your series of integers.
```bash
curl https://localhost:5001/calculateaverage?numbers=1,2,3
```

## Usage
To use the CalculateAverage API, send a GET request to the endpoint with a query parameter numbers containing a comma-separated list of integers. For example:
https://localhost:5001/calculateaverage?numbers=10,20,30,40

The service will respond with the average of the provided numbers.


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------


# In-Memory CRUD Operations for Product Resource with Minimal API

This project demonstrates a simple yet effective way to implement CRUD operations for a Product resource using ASP.NET Core's Minimal API feature. It utilizes an in-memory list to store product data, making it a great starting point for understanding how to work with Minimal APIs.

## Features

- Create, Read, Update, and Delete operations for Product resource.
- In-memory data storage.
- Error handling for null or empty inputs and incorrect formats.
- User-friendly error messages.

## Getting Started

Follow these instructions to get the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 6 SDK or later

### Installation

1. Clone the repository:
```bash
git clone https://github.com/EroNWs/ParanumusBackendTask.git
```

## Navigate to the project directory:
```bash
cd ProductCatalogApi project location
```

## Run the application:
```bash
dotnet run
```

Usage
Once the application is running, you can perform CRUD operations on the Product resource using the following endpoints:

### Create a Product: POST /products
Body: {"Id": 1, "Name": "Product Name", "Description": "Product Description", "Price": 100}
```bash
curl -k -X POST https://localhost:5002/products -H "Content-Type: application/json" -d "{\"Id\": 1, \"Name\": \"Ürün Adı\", \"Description\": \"Ürün Açıklaması\", \"Price\": 100}"
```
### Read All Products: GET /products
```bash
curl https://localhost:5002/products
```
### Read a Product by ID: GET /products/{id}
```bash
curl https://localhost:5002/products/1
```
### Update a Product: PUT /products/{id}
Body: {"Id": 1, "Name": "Updated Product Name", "Description": "Updated Product Description", "Price": 150}
```bash
curl -X PUT https://localhost:5002/products/1 -H "Content-Type: application/json" -d "{\"Id\": 1, \"Name\": \"Yeni Ürün Adı\", \"Description\": \"Yeni Ürün Açıklaması\", \"Price\": 150}"
```
### Delete a Product: DELETE /products/{id}
```bash
curl -X DELETE https://localhost:5002/products/1
```


--------------------------------------------------------------------------------------------------------------------------------------------------------------------


# ProductCatalogAsyncMinimalApi

A demonstration of using asynchronous programming in a Minimal API setup with .NET. This project showcases how to implement async CRUD operations for a simple product catalog, improving response times, resource utilization, and scalability.

## Features

- Asynchronous CRUD operations for a Product resource.
- Enhanced response times by non-blocking I/O operations.
- Improved resource utilization and scalability.
- Optimized thread usage in I/O-bound operations.
- Enhanced user experience in multi-user environments.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 6 SDK or later

### Running the Application

1. Clone the repository:
```bash
git clone https://github.com/EroNWs/ParanumusBackendTask.git
```

## Navigate to the project directory:
```bash
cd ProductCatalogAsyncMinimalApi project location
```

## Start the application:
```bash
dotnet run
```

The application will be available at https://localhost:5003.

Usage
The API supports the following asynchronous operations:

### Adding a Product: Send a POST request to /products with the product data in the request body.
```bash
curl -k -X POST https://localhost:5003/products -H "Content-Type: application/json" -d "{\"Id\": 1, \"Name\": \"Ürün Adı\", \"Description\": \"Ürün Açıklaması\", \"Price\": 100}"
```
### Listing Products: Send a GET request to /products to retrieve a list of all products.
```bash
curl https://localhost:5003/products
```
### Getting One Product: Send a GET request to /products/{id} with the product's ID.
```bash
curl https://localhost:5003/products/1
```
### Updating a Product: Send a PUT request to /products/{id} with the updated product data.
```bash
curl -X PUT https://localhost:5003/products/1 -H "Content-Type: application/json" -d "{\"Id\": 1, \"Name\": \"Yeni Ürün Adı\", \"Description\": \"Yeni Ürün Açıklaması\", \"Price\": 150}"
```
### Deleting a Product: Send a DELETE request to /products/{id} with the product's ID.
```bash
curl -X DELETE https://localhost:5003/products/1
```


-----------------------------------------------------------------------------------------------------------------------------------------------------------------
# ProductCatalogAsyncWithSql API

The `ProductCatalogAsyncWithSql` API is an advanced ASP.NET Core Web Application demonstrating seamless integration with SQL Server for robust data persistence. Designed to replace an in-memory data store, this project leverages the power of asynchronous operations and a layered architecture to provide a scalable, maintainable, and efficient web API for product management.

## Architecture Overview

This project adopts a clean layered architecture to enhance separation of concerns, comprising:

- **Models**: Entity representations for database tables.
- **WebApi**: Controllers handling API endpoints.
- **DAL (Data Access Layer)**: Direct database interaction layer.
- **Infrastructure**: Implements repository patterns for database operations abstraction.
- **Infrastructure.Interface**: Interface definitions for repositories, promoting inversion of control and dependency injection.

## Key Features

- Asynchronous CRUD (Create, Read, Update, Delete) operations.
- Persistent data storage with SQL Server.
- Clean RESTful API design.
- Repository pattern implementation.
- Swagger for API documentation and exploration.

## Getting Started

### Prerequisites

- .NET 6 SDK
- SQL Server (LocalDB, Express, or any suitable edition)

### Installation

1. **Clone the repository:**

```bash
git clone https://github.com/EroNWs/ParanumusBackendTask.git
```

## API Usage with Postman

This project includes comprehensive Postman documentation to simplify interacting with the API, making it easier to test authentication, CRUD operations, and other functionalities.

### Accessing the Postman Collection

1. Download and install [Postman](https://www.postman.com/downloads/) if you haven't already.
2. Access our Postman documentation and collection via the following link:
  https://api.postman.com/collections/28694420-7f99e19e-87cd-4fce-98db-b26bb3ed14fd?access_key=PMAT-01HS826TDX9KEN7052DKVRRCC5
3. Import the collection into Postman using the **Import** button.

### Using the Collection

The Postman collection is organized into folders representing different aspects of the API, such as Authentication, Products CRUD, etc. Each request is pre-configured with the necessary HTTP method, request URL, headers, and body format.

#### Authentication

To perform operations that require authentication:

1. Start with the `Login` request to authenticate. You'll need to enter valid credentials in the request body.
2. Upon a successful login, you'll receive a JWT token in the response.
3. For subsequent requests, add this JWT token to the `Authorization` header as a Bearer token.


### Testing Best Practices

- Regularly refresh your JWT token to ensure it hasn't expired.
- Validate the response status and data for each request to ensure the API behaves as expected.
- Utilize environment variables in Postman to store and easily update the API base URL, credentials, and tokens.






--------------------------------------------------------------------------------------------------------------------------------------------------------------


# JWT Authentication Integration in ProductCatalogAsyncWithSql API

This enhancement introduces JWT (JSON Web Token) based authentication to the `ProductCatalogAsyncWithSql` project, leveraging ASP.NET Core Identity to secure the web API. This update restricts write operations (Create, Update, Delete) to authenticated users, aligning the project with modern web application security practices.

## Executive Summary

The `ProductCatalogAsyncWithSql` project has been enhanced with JWT-based authentication to secure CRUD operations, necessitating JWT tokens for access. This approach ensures that sensitive operations are safeguarded, providing a solid foundation for user management and authentication strategies within ASP.NET Core web applications.

## Features

- **Secure CRUD Operations**: Limits Create, Update, and Delete actions to authenticated users.
- **ASP.NET Core Identity**: Utilizes ASP.NET Core Identity for robust user management, including user registration and login.
- **JWT Token Security**: Employs JWT tokens to secure API endpoints, facilitating stateless authentication.
- **Role-Based Authorization**: Implements role-based authorization to ensure that only users with the appropriate roles can perform specific operations.
- **Public Access for Read Operations**: Maintains the accessibility of GET requests to the public, ensuring data availability.

## Getting Started

Follow these instructions to integrate JWT Authentication into your ASP.NET Core project:

### Prerequisites

- ASP.NET Core 6 SDK or later


### Installation

1. Clone the repository to your local machine:
```bash
git clone https://github.com/EroNWs/ParanumusBackendTask.git
 ```


## API Usage with Postman

This project includes comprehensive Postman documentation to simplify interacting with the API, making it easier to test authentication, CRUD operations, and other functionalities.

### Accessing the Postman Collection

1. Download and install [Postman](https://www.postman.com/downloads/) if you haven't already.
2. Access our Postman documentation and collection via the following link:
  https://api.postman.com/collections/28694420-7f99e19e-87cd-4fce-98db-b26bb3ed14fd?access_key=PMAT-01HS826TDX9KEN7052DKVRRCC5
3. Import the collection into Postman using the **Import** button.

### Using the Collection

The Postman collection is organized into folders representing different aspects of the API, such as Authentication, Products CRUD, etc. Each request is pre-configured with the necessary HTTP method, request URL, headers, and body format.

#### Authentication

To perform operations that require authentication:

1. Start with the `Login` request to authenticate. You'll need to enter valid credentials in the request body.
2. Upon a successful login, you'll receive a JWT token in the response.
3. For subsequent requests, add this JWT token to the `Authorization` header as a Bearer token.


### Testing Best Practices

- Regularly refresh your JWT token to ensure it hasn't expired.
- Validate the response status and data for each request to ensure the API behaves as expected.
- Utilize environment variables in Postman to store and easily update the API base URL, credentials, and tokens.



------------------------------------------------------------------------------------------------------------------------


# Advanced Error Handling and Logging in ProductCatalogAsyncWithSql API

This document outlines the enhancements made to the `ProductCatalogAsyncWithSql` API to introduce advanced error handling and logging mechanisms. By leveraging the NLog library, the project has significantly improved its capability to manage errors and log information effectively, thereby enhancing overall robustness and maintainability.

## Executive Summary

The `ProductCatalogAsyncWithSql` project now features a comprehensive approach to error handling and logging, ensuring that exceptions are not only caught and logged with detailed information but also that user-friendly error messages are returned to API consumers. This enhancement facilitates improved debugging, monitoring, and user experience.

## Features

- **Global Error Handling**: A mechanism that captures unhandled exceptions across the API, ensuring they are handled gracefully.
- **NLog Integration**: Utilizes NLog for versatile and comprehensive logging of exceptions and application events, enhancing the ability to debug and monitor the application's health.
- **User-Friendly Error Messages**: Errors returned to the client are standardized and crafted to be clear and helpful, aiding in the resolution of issues.
- **Refined Architecture**: Incorporates an Application layer and refines existing layers (DAL, DTOs, Infrastructure, etc.) to support advanced error handling and logging strategies.

## Getting Started

To integrate these enhancements into your project, follow these steps:

### Prerequisites

- .NET 6 SDK or later
- Visual Studio 2019 or newer (recommended)

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/ProductCatalogAsyncWithSql.git
    ```


## API Usage with Postman

This project includes comprehensive Postman documentation to simplify interacting with the API, making it easier to test authentication, CRUD operations, and other functionalities.

### Accessing the Postman Collection

1. Download and install [Postman](https://www.postman.com/downloads/) if you haven't already.
2. Access our Postman documentation and collection via the following link:
  https://api.postman.com/collections/28694420-7f99e19e-87cd-4fce-98db-b26bb3ed14fd?access_key=PMAT-01HS826TDX9KEN7052DKVRRCC5
3. Import the collection into Postman using the **Import** button.

### Using the Collection

The Postman collection is organized into folders representing different aspects of the API, such as Authentication, Products CRUD, etc. Each request is pre-configured with the necessary HTTP method, request URL, headers, and body format.

#### Authentication

To perform operations that require authentication:

1. Start with the `Login` request to authenticate. You'll need to enter valid credentials in the request body.
2. Upon a successful login, you'll receive a JWT token in the response.
3. For subsequent requests, add this JWT token to the `Authorization` header as a Bearer token.


### Testing Best Practices

- Regularly refresh your JWT token to ensure it hasn't expired.
- Validate the response status and data for each request to ensure the API behaves as expected.
- Utilize environment variables in Postman to store and easily update the API base URL, credentials, and tokens.



---------------------------------------------------------------------------------------------------------------------------------



# Performance Optimization Through Response Caching in ProductCatalogAsyncWithSql API

This README details the enhancement of the `ProductCatalogAsyncWithSql` API through the integration of response caching, employing the Marvin.Cache.Headers library. This optimization significantly improves the API's performance, scalability, and user experience by efficiently caching responses.

## Executive Summary

The implementation of response caching in the `ProductCatalogAsyncWithSql` project aims to optimize API performance. Utilizing the Marvin.Cache.Headers library, the API now caches responses for frequently accessed data, reducing database load and enhancing response times.

## Introduction

Performance optimization is crucial for maintaining a responsive and scalable web API. Response caching achieves this by storing the output of requests, thus minimizing repeated database queries for subsequent identical requests. This enhancement is particularly effective for data that doesn't change often, making it a perfect fit for many RESTful API scenarios.

## Objectives

- **Reduce Database Load**: Minimize duplicate queries by caching the responses of identical requests.
- **Improve Response Times**: Serve cached data to drastically cut down on response times for frequently accessed endpoints.
- **Scalable and Efficient Caching**: Leverage the Marvin.Cache.Headers library to implement a sophisticated caching strategy that adapts to varying data freshness requirements.
- **Maintain API Responsiveness**: Ensure the API can handle increased loads without compromising on performance.

## How It Works

### Marvin.Cache.Headers Integration

1. The Marvin.Cache.Headers library is configured within the ASP.NET Core pipeline to introduce response caching capabilities.
2. Caching policies are defined per endpoint, considering data freshness and access frequency.

### Cache Policy Application

- Caching middleware intercepts API responses, applying the defined caching policies.
- Cached data is served for subsequent requests, bypassing the need for database access if the data remains valid.

## Benefits

- **Enhanced Performance**: Significantly reduces response times by serving cached responses.
- **Decreased Server Load**: Lowers the burden on the database by reducing the frequency of queries.
- **Improved Scalability**: Facilitates handling a higher number of requests without a linear increase in resource usage.
- **Superior User Experience**: Users experience faster interactions with the API, leading to higher satisfaction.

## Getting Started

To integrate these enhancements into your project, follow these steps:

### Prerequisites

- .NET 6 SDK or later
- Visual Studio 2019 or newer (recommended)

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/ProductCatalogAsyncWithSql.git
    ```


## API Usage with Postman

This project includes comprehensive Postman documentation to simplify interacting with the API, making it easier to test authentication, CRUD operations, and other functionalities.

### Accessing the Postman Collection

1. Download and install [Postman](https://www.postman.com/downloads/) if you haven't already.
2. Access our Postman documentation and collection via the following link:
  https://api.postman.com/collections/28694420-7f99e19e-87cd-4fce-98db-b26bb3ed14fd?access_key=PMAT-01HS826TDX9KEN7052DKVRRCC5
3. Import the collection into Postman using the **Import** button.

### Using the Collection

The Postman collection is organized into folders representing different aspects of the API, such as Authentication, Products CRUD, etc. Each request is pre-configured with the necessary HTTP method, request URL, headers, and body format.

#### Authentication

To perform operations that require authentication:

1. Start with the `Login` request to authenticate. You'll need to enter valid credentials in the request body.
2. Upon a successful login, you'll receive a JWT token in the response.
3. For subsequent requests, add this JWT token to the `Authorization` header as a Bearer token.


### Testing Best Practices

- Regularly refresh your JWT token to ensure it hasn't expired.
- Validate the response status and data for each request to ensure the API behaves as expected.
- Utilize environment variables in Postman to store and easily update the API base URL, credentials, and tokens.



---------------------------------------------------------------------------------------------------------------

## Part 4: Business Scenario Implementation

The bookstore API includes a loyalty program with discounts for different types of customers and requires the implementation of customer classification, purchase processing, discount application, and record-keeping.

### Features

- **Customer Classification:** Dynamically categorize customers based on their purchase history and apply appropriate discounts.
- **Purchase Processing:** Implement an endpoint to process book purchases, including customer information and book quantities.
- **Discount Application:** Apply discounts based on customer classification during the purchase process.
- **Record Keeping:** Maintain a record of all purchases for future customer classification and analysis.

### Getting Started

1. **Clone the Project:**

```bash
git clone https://github.com/EroNWs/ParanumusBackendTask.git
```

2. **Navigate to the Bookstore API Directory:**

```bash
cd ParanumusBackendTask/BookstoreApi project location
```

3. **Run the Application:**

```bash
dotnet run
```

### API Endpoints

- **Purchase Books:** POST `/api/purchase/make-purchase`
- **List All Books:** GET `/api/books`
- **Get Book by ID:** GET `/api/books/{id}`
- **Create a Book:** POST `/api/books`
- **Update a Book:** PUT `/api/books/{id}`
- **Delete a Book:** DELETE `/api/books/{id}`

## Part 5: Advanced C# and Software Design

This part delves into advanced C# features and software design patterns to enhance the project's architecture, maintainability, and testability. Key areas include dependency injection, unit testing, and integrating services.

### Highlights

- **Dependency Injection:** Refactor the project to use dependency injection for better scalability and decoupling.
- **Unit Testing:** Implement unit tests for critical components to ensure reliability and functionality.
- **Service Integration:** Develop and integrate services for functionalities like email notification, payment processing, etc.

### Running Tests

1. **Navigate to the Test Directory:**

```bash
cd ParanumusBackendTask/Tests project location
```

2. **Execute the Tests:**

```bash
dotnet test
```


