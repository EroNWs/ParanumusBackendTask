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


---------





# CalculateAverage Minimal API

The CalculateAverage Minimal API is a simple yet powerful .NET 6 web application designed to demonstrate a clean and efficient implementation of a web service that calculates the average value of a series of integers. It showcases error handling, input validation, and the elegance of Minimal APIs in ASP.NET Core.

## Features

- Minimal API endpoint to calculate the average of integers.
- Robust error handling for null or empty inputs and incorrect input formats.
- User-friendly error messages to facilitate debugging and correct usage.

## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

- .NET 6 SDK

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

## Usage
To use the CalculateAverage API, send a GET request to the endpoint with a query parameter numbers containing a comma-separated list of integers. For example:
https://localhost:5001/calculateaverage?numbers=10,20,30,40

The service will respond with the average of the provided numbers.

------
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

- .NET 6 SDK

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
curl -k -X POST https://localhost:5002/products -H "Content-Type: application/json" -d "{\"Id\": 2, \"Name\": \"Ürün Adı\", \"Description\": \"Ürün Açıklaması\", \"Price\": 100}"
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
curl -X DELETE https://localhost:5002/products/2
```
