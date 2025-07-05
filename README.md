# plataform-ai

**PlataformAI** is an intelligent chatbot platform powered by AI, capable of understanding user intents in natural language and orchestrating actions like calling public APIs, sending webhooks, and automating tasks — all through a modular, extensible, and modern architecture.

## Features
- Natural language chatbot powered by Azure OpenAI GPT
- Calls public APIs (weather, news, currency rates, etc.) through prompts
- Sends custom webhooks on user request
- Automated tasks (summarize text, checklist creation, etc.)
- Extensible catalog of integrations (MCP Server)
- Clean Architecture, modular projects
- Automated tests and Swagger documentation

## Technologies
- OpenAI GPT
- Semantic Kernel
- ASP.NET Core (.NET 8)
- MediatR
- Repository Pattern
- Swagger/OpenAPI
- Docker
- xUnit
- MCP

## System Design

Monolithic solution structured in separate projects (Gateway, Orchestrator, Action/MCP Server), following Clean Architecture principles, with CQRS and extensible catalog for dynamic integrations.

-TODO - Diagram

## How it works

1. User sends a prompt via Gateway API.
2. Gateway routes request to Orchestrator.
3. Orchestrator (Semantic Kernel + LLM) analyzes the message and determines the required action.
4. Action API (MCP Server) executes the integration and returns the result.
5. Response is sent back to the user.

## How to Run

-TODO

## Roadmap

### MVP
- [x] Initial project structure using Clean Architecture and separation into projects (Gateway, Orchestrator, Action/MCP Server)
- [ ] Implementation of the Gateway API (unified entry point for messages)
- [x] Orchestrator API integrated with Semantic Kernel and OpenAI
- [ ] Definition of the MCP catalog in the Action API
- [ ] Initial integration with a public weather forecast API
- [ ] Documentation via Swagger/OpenAPI
- [ ] Basic prompt example interacting with the weather API
- [ ] Setup of automated tests (xUnit)

### Essential Features
- [ ] Integration with additional public APIs (e.g., news, currency)
- [ ] Sending custom webhooks (e.g., webhook.site)
- [ ] Simple automated actions (e.g., text summarization, checklist creation)
- [ ] Support for conversation context (short-term memory via Orchestrator/Semantic Kernel)
- [ ] Conversation history and logs

### Quality and DevOps
- [ ] Automated test coverage for main flows
- [ ] Project dockerization (Dockerfile and docker-compose)
- [ ] Basic CI/CD pipeline with GitHub Actions
- [ ] Templates for Issues and Pull Requests

### Expansion and Customization
- [ ] Easy addition of new integrations via the MCP catalog (plug-and-play)
- [ ] Multi-language support (messages and prompts)
- [ ] Dynamic catalog browsable by endpoint
- [ ] AI plugins for sentiment analysis and automatic translation

### Future/Optional
- [ ] Integration with real chat channels (Telegram, WhatsApp, Web)
- [ ] Admin panel to visualize interactions and logs
- [ ] Automated cloud deployment (Azure, AWS, GCP)

## Contribution

PRs are welcome!
