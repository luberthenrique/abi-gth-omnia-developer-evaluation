# Developer Evaluation Project

`READ CAREFULLY`

# Running with Docker Compose

## Overview

This project consists of a backend built with .NET Core and a frontend built with Angular 18. Docker Compose is used to easily orchestrate and run the containers for both the backend and frontend services along with other required services such as the database and caching systems.

## Prerequisites

Before running the project with Docker Compose, ensure you have the following installed:

- [Docker](https://www.docker.com/get-started) (including Docker Compose)

## Setting Up

1. **Clone the repository**

   If you haven't already, clone the repository to your local machine:

   ```bash
   git clone https://github.com/luberthenrique/abi-gth-omnia-developer-evaluation.git
   cd your-folder/abi-gth-omnia-developer-evaluation/template/backend
2. **Running the Project with Docker Compose**
   Build the Docker images for both the backend and frontend services using the command
   ```bash
   docker-compose up --build

3. **Access the Application**
   After the containers are up and running, you can access the following:

   * Frontend (Angular): Open your browser and navigate to http://localhost:4200.
   * API (Swagger UI): Open your browser and navigate to https://localhost:8081/swagger.
   
## Instructions
**The test below will have up to 7 calendar days to be delivered from the date of receipt of this manual.**

- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed
- Upload this template to your repository and start working from it
- Read the instructions carefully and make sure all requirements are being addressed
- The repository must provide instructions on how to configure, execute and test the project
- Documentation and overall organization will also be taken into consideration

## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**

As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.

Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.

### Business Rules

* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount

These business rules define quantity-based discounting tiers and limitations:

1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount

2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items

## Overview
This section provides a high-level overview of the project and the various skills and competencies it aims to assess for developer candidates. 

See [Overview](/.doc/overview.md)

## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components. 

See [Tech Stack](/.doc/tech-stack.md)

## Frameworks
This section outlines the frameworks and libraries that are leveraged in the project to enhance development productivity and maintainability. 

See [Frameworks](/.doc/frameworks.md)

<!-- 
## API Structure
This section includes links to the detailed documentation for the different API resources:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Project Structure
This section describes the overall structure and organization of the project files and directories. 

See [Project Structure](/.doc/project-structure.md)
