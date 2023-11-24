# Assignment
# Overview
This project utilizes .NET Core Web API 6.1 along with the principles of Clean Architecture to organize the codebase into distinct layers for scalability, maintainability, and separation of concerns.

# Project Structure
The project is structured into four main layers:

# 1. Domain
Purpose: Contains the core business logic, entity models, enums.
# Folders:
Entities: Contains domain-specific models representing core business entities.
Enums: Houses enumerations that define specific types or states within the domain.
# 2. Application
Purpose: Orchestrates interactions between different layers, contains use cases, and encapsulates application logic.
# Folders:
Services: Houses services implementing application-specific logic.
Wrappers: Wrappers contains the Response wrappers
Interfaces: Respository Interfaces are added here
#
# 3. Infrastructure
Purpose: Holds implementation details, external dependencies, and infrastructure-specific code.
Folders:
Repositories: Implements data access logic and interacts with databases or external data sources.
DbContexts: Contains database context configurations or ORM setups.

# 4. Presentation
Purpose: Contains the user interface and communication with clients.
Folders:
Controllers: Holds API endpoints and their corresponding actions.
Middlewares: Error handling Middleware in added here.

# Here’s a step-by-step breakdown:
# Incoming Request:
The request is received by the controller in the Presentation layer.
# Controller Action:
The controller validates the request data and performs any necessary transformation of the incoming data into a format suitable for the application layer.
# Application Layer Processing:
The Application layer receives the request and delegates the operation to the relevant service or use case.
# Domain Layer Interaction:
The Application layer interacts with the Domain layer to execute business logic.
# Infrastructure Layer Interaction:
data storage is perform in Infrastructure Layer.using Entity Framework core & SQLSERVER for data storage.
Response Flow:
The flow reverses back through the layers, with data/results moving from the Domain layer to the Application layer, then back to the Presentation layer.
The response data is transformed into an appropriate format and an HTTP response is sent back to the client.
This flow maintains a clear separation of concerns, allowing each layer to focus on specific responsibilities while promoting testability and flexibility in the application.

