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
cd HelloWorldMinimalApi
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
cd CalculateAverageMinimalApi
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

