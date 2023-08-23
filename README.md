# Fullstack Afiliados

O objetivo desse teste é avaliar as suas habilidades em programação.

>  This is a challenge by [Coodesh](https://coodesh.com/)

<!-- TOC start -->

- [Results](#results)
- [Running](#running)
- [Infrastructure](#infrastructure)
- [Backend](#backend)
  * [Architecture](#architecture)
  * [Libraries](#libraries)
- [Frontend](#frontend)
  * [Structure](#structure)
  * [Libraries](#libraries-1)
- [Tests](#tests)
  * [Postman](#postman)

<!-- TOC end -->

# Results

For this project, I chose the Clean Architecture for the backend and Atomic Design for the frontend. In both cases, the choice is not only related to familiarity and a positive past experience with these architectures, but also due to their significant advantages in terms of implementation speed.

When I hear about an urgent demand, I believe that things not only can, but should change considerably over time. Therefore, creating an application that is easily adaptable to new requirements becomes essential. Another aspect considered in this scenario is the data input. Since we are using a specific model, we have an isolated use case outside the application layer. Consequently, if we switch to CSV, XSLX, or even an API call in the future, the application should be capable of receiving this information without a revision of the entire domain layer.

The infrastructure is set up using Docker Compose, and the database in use is PostgresSQL. This relational database is fast and performant, offering numerous additional functions and native support for BSON and JSON objects. This feature proves to be highly advantageous in many cases.

Integration testing has been carried out utilizing Postman, which is the most suitable choice given the available time for constructing the application.

It's worth highlighting that the project details can be found in the [PROJECT.md](./PROJECT.md) file.

# Running

To run the application is very simple, just run the command:

```
docker-compose --env-file .env.example -f docker-compose.yml up
```

And the applications ran on the following URLs:

- Backend: [http://localhost:5001/swagger](http://localhost:5001/swagger)
- Frontend: [http://localhost:4173/login](http://localhost:4173/login)

At the frontend login, your username should be: SYSTEM_USERNAME and the password SYSTEM_PASSWORD added to the .env

# Infrastructure

Docker Compose is a tool that allows you to define and run applications composed of multiple Docker containers. It simplifies the process of orchestrating and managing these containers, allowing you to describe the configuration of all your application's services in a single YAML file.

To start an application using Docker Compose, follow these steps:

1. **Open the Terminal:**
   - Open the terminal in the directory where the `docker-compose.yml` file is located (at the root of the project).

2. **Execute the Command:**
   - Use the command `docker-compose up` to start all the containers defined in the file. Docker Compose will download the necessary images, configure the containers, and run them.

3. **Monitor the Log:**
   - The terminal will display the startup log of the containers. You'll be able to see the status and messages of each service.

4. **Access the Application:**
   - Once the application is fully started, you can access it through a web browser or other tools: front-end: http://localhost:3000/ and back-end: http://localhost:5001/swagger/

5. **Finish Execution:**
   - To stop the execution of the containers, press `Ctrl + C` in the terminal. If you wish to remove the containers after execution, use the `docker-compose down` command.


# Backend

## Architecture

For this project, the .NET framework was used, and the structure of the presented solution follows the principles of Clean Architecture, an architectural pattern that aims to separate concerns and maintain independence between different layers of an application. Clean Architecture is characterized by an organization into concentric layers, where the inner layers represent the core of the application, and the outer layers represent infrastructure details.

In this pattern, the layers are organized as follows:

1. **Domain Layer:**
   - Represents the core of the application, containing business rules, entities, and application use cases. This layer is independent of technical details and can be tested and reused without relying on external frameworks or libraries.

2. **Application Layer:**
   - Contains application logic, including use case orchestration and service implementation. This layer interacts directly with the domain layer and coordinates the execution of application workflows.

3. **Interfaces Layer (Presentation and API):**
   - Represents the user interface or external communication interfaces (APIs). This layer does not contain business logic but only directs user requests to the appropriate use cases in the application layer.

4. **Infrastructure Layer (Infra, Data, CrossCutting):**
   - Contains implementation details, such as database access, external services, Dependency Injection configuration, and other infrastructure components. This layer is kept separate from the domain and application layers to ensure the independence and testability of the core application.

By organizing different parts of the application into well-defined layers with clear separation of responsibilities, maintenance, evolution, and testing of the application are facilitated, while promoting a robust and scalable architecture.

## Libraries

Here's a list of the libraries used and their importance in the project context:

1. **xUnit:**
   - xUnit is a unit testing framework for .NET. It facilitates the creation and execution of automated tests, ensuring code quality and reliability throughout development.

2. **MediatR:**
   - MediatR is a message mediation library that helps implement patterns like CQRS (Command Query Responsibility Segregation) and the Mediator Pattern. It promotes decoupling between application components by allowing messages (commands and queries) to be transmitted and handled without direct coupling.

3. **Entity Framework:**
   - Entity Framework is an Object-Relational Mapping (ORM) framework that simplifies access to and manipulation of relational databases. It maps application objects to database tables, allowing developers to interact with data through objects and LINQ queries.

4. **Serilog:**
   - Serilog is a flexible and extensible logging library. It enables the creation of structured and customizable logs, aiding in debugging, monitoring, and issue analysis within the application.

5. **Swagger:**
   - Swagger is an automatic API documentation generation tool. It creates interactive and user-friendly documentation for application APIs, making it easier for developers and external teams to understand and consume.

6. **AutoMapper:**
   - AutoMapper is a library that simplifies object-to-object conversion. It automates the mapping of properties between objects, especially useful when converting Data Transfer Objects (DTOs) to domain entities and vice versa.

7. **Npgsql:**
   - Npgsql is a PostgreSQL database driver for .NET. It allows the application to connect to a PostgreSQL database and perform operations such as queries, inserts, updates, and deletions.

8. **Moq:**
   - Moq is a mocking library for .NET. It facilitates the creation of simulated objects (mocks) for testing, allowing isolation of components and simulating behaviors to ensure effective unit testing.

# Frontend

## Structure

This structure follows the concepts of Atomic Design, enabling modularity, reusability, and efficient code maintenance. It's an organized way to develop scalable user interfaces:

1. **App.tsx:** Main entry file of your application, where you likely set up routing and the overall structure.

2. **assets:** Folder to store static assets, such as images.

3. **components:** Central folder for reusable components, organized into three subfolders:
   - **atoms:** Simple and indivisible components like buttons and input fields.
   - **molecules:** More complex components composed of atoms, such as an input field with a label.
   - **organisms:** Even more complex components that can contain multiple molecules and atoms, like a complete form.

4. **core:** Folder containing the core logic of the application:
   - **constants:** Constants used throughout the application.
   - **contexts:** React contexts for managing global state.
   - **hooks:** Custom hooks for reusing logic.
   - **services:** Logic related to external services, such as API calls.
   - **utils:** Helper functions used across various parts of the application.

5. **langs:** Folder for internationalization (i18n), containing translation files.

6. **pages:** Organization of main pages, like "dashboard" and "login".

7. **theme:** Files related to the visual theme of the application.

8. **types:** Custom type definitions, including React-related types, internationalization types, and user types.

9. **vite-env.d.ts:** Environment declaration file for Vite, if it's in use.


## Libraries

Here's a brief overview of the chosen libraries and their relevance in the project:

**Dependencies:**

1. **@emotion/react** and **@emotion/styled**: The project employs the Emotion library, a CSS-in-JS solution that facilitates writing expressive styles within React components.

2. **@mui/icons-material** and **@mui/material**: Material-UI (MUI) is utilized as a comprehensive component library adhering to Google's Material Design principles. It provides predefined components and styling for a consistent and visually appealing user interface.

4. **axios**: The project makes use of the axios library, which employs promises to create HTTP clients for making network requests, commonly employed for interactions with APIs.

5. **i18next** and **react-i18next**: These libraries are harnessed for internationalization support, streamlining the management of translations and facilitating language switching within the application.

7. **react-router-dom**: Facilitating navigation and routing within the React application.

8. **jest**: Jest enhances the testing capabilities of the project. It provides a robust testing framework that simplifies writing unit tests, integration tests, and more.

**DevDependencies:**

1. **@typescript-eslint/eslint-plugin** and **@typescript-eslint/parser**: The project integrates TypeScript into the ESLint environment through these packages, augmenting code quality and consistency through type-checking.

2. **@vitejs/plugin-react**: The integration of React with Vite's rapid development server is achieved using the @vitejs/plugin-react package.

3. **eslint** and **eslint-plugin-react**: For code linting, ESLint is employed, and the eslint-plugin-react package enhances it with rules specific to React development.

4. **typescript**: TypeScript, a typed superset of JavaScript, is embraced within the project to heighten code quality and improve the development experience.

5. **vite**: Vite, serving as a rapid and minimalist build tool and development server, contributes to modern web development practices in the project, particularly beneficial for React applications.

6. **@testing-library/react** and **@testing-library/jest-dom**: These libraries, along with **@testing-library/user-event**, empower the project with user-centric testing approaches. They enable testing React components in a way that simulates user interactions and behavior.

# Tests

## Postman

Postman is a widely used tool by developers and testing teams for testing APIs (Application Programming Interfaces). It provides a user-friendly graphical interface that allows you to create, send, and test HTTP requests to APIs, as well as enable test automation, including integration testing.

Integration tests are a crucial part of software development as they ensure that different components or systems interact correctly with each other. When it comes to APIs, integration tests help verify if the API endpoints are responding as expected, if data is being handled correctly, and if communication between your application and the API is functioning smoothly.

You can access the tests using Postman at the following link:

https://www.postman.com/arthurgregorioleal/workspace/testes-afiliados/overview
