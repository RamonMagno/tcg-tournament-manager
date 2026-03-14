# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

TCG Tournament Manager is a .NET 10 solution for managing competitive TCG (Trading Card Games) events.

## Commands

```bash
# Build the solution
dotnet build

# Run the Web API
dotnet run --project src/tcg-tournament-manager.presentation.webapi

# Run all tests
dotnet test

# Run tests for a specific project
dotnet test tests/tcg-tournament-manager.application.tests
dotnet test tests/tcg-tournament-manager.domain.tests
dotnet test tests/tcg-tournament-manager.presentation.webapi.tests

# Run a specific test by name
dotnet test --filter "FullyQualifiedName~TestClassName"
```

## Architecture

The solution follows **Clean Architecture** with a custom **CQRS** pattern (no MediatR — uses a home-built dispatcher).

### Project Layers (dependency flow: webapi → application + infra.data → domain)

| Project | Location | Purpose |
|---|---|---|
| `domain` | `src/tcg-tournament-manager.domain/` | Entities, interfaces, value objects, enums, abstracts. Zero external dependencies. |
| `application` | `src/tcg-tournament-manager.application/` | Command/query handlers, DTOs, validators (FluentValidation), converter extensions. |
| `infrastructure.data` | `tcg_tournament_manager.infrastructure.data/` | Repository implementations. Located at repo root (not under `src/`). |
| `presentation.webapi` | `src/tcg-tournament-manager.presentation.webapi/` | ASP.NET Core controllers. Wires up DI for repositories and calls `AddApplication()`. |

There is also a placeholder `src/tcg-tournament-manager.infra.data.postgresql/` for a PostgreSQL-specific infra layer (not yet implemented).

### Custom CQRS / Mediator

The application layer implements its own mediator without third-party libraries:

- **`ICommand` / `ICommand<TResult>`** — marker interfaces for commands (in `Shared/Commands/ICommand.cs`)
- **`ICommandHandler<TCommand>` / `ICommandHandler<TCommand, TResult>`** — handler contracts
- **`IQuery<TResult>` / `IQueryHandler<TQuery, TResult>`** — query contracts
- **`IDispatcher`** — resolved via DI; routes commands/queries to their handlers
- **`MediatorConfiguration.AddMediator()`** — auto-registers all handlers in the application assembly by scanning for `ICommandHandler<>` and `IQueryHandler<,>` implementations

Register the application layer by calling `builder.Services.AddApplication()` in `Program.cs`.

### Adding a New Feature

Follow the Training feature as the reference implementation:

1. **Domain**: Define the entity in `domain/Entities/` and the repository interface in `domain/Interfaces/`
2. **Application**: Create `Commands/`, `Dto/`, `Handlers/`, `Validators/`, `Converters/` under a feature folder (e.g., `application/Training/`)
3. **Infrastructure**: Implement the repository interface in `tcg_tournament_manager.infrastructure.data/Repositories/`
4. **WebAPI**: Register the repository in `Program.cs` and add a controller in `presentation.webapi/Controllers/`

### Namespaces

Despite hyphenated project/folder names, all namespaces use underscores: `tcg_tournament_manager.*`.
