# ReplyFlow

ReplyFlow is an open-source C# ASP.NET Core application that provides phone-number-based authentication and password reset flows backed by MediatR and Entity Framework Core. It includes a simple MVC-based account system (register, login, logout, forgot/reset password) and follows a CQRS-style pattern using command handlers and factories.

## Features

- Phone-number based registration and login
- Cookie-based authentication (ASP.NET Core)
- Forgot-password flow with 6-digit reset code and expiry
- Clean command/handler separation using MediatR
- EF Core-backed persistence (ReplyFlowDbContext)

## Quick start

Prerequisites

- .NET SDK 7.0+ (or the version used by the project)
- SQL Server / SQLite or another EF Core provider configured in appsettings

Run locally

1. Clone the repository:

   git clone https://github.com/ahmed01114790265/ReplyFlow-AI.git
   cd ReplyFlow-AI

2. Update configuration

   - Configure your connection string in `appsettings.Development.json` or secrets.
   - Ensure any required settings (SMS provider, if used) are configured.

3. Apply EF Core migrations (if the project includes migrations):

   dotnet ef database update

4. Run the app:

   dotnet run --project <YourWebProject>.csproj

5. Open a browser and navigate to `https://localhost:5001` (or the configured URL).

## Project structure (high level)

- Features/Auth/EndPoints - MVC controllers and views for account flows
- Features/Auth/Handlers - MediatR handlers (e.g., ForgotPasswordHandler)
- Features/Auth/Factories - Factory helpers to create command objects from view models
- Features/Auth/ViewModels - ViewModel types for forms and views
- Shared - Common utilities, exceptions, persistence and result wrapper types


## Contributing

Please read [CONTRIBUTING.md](./CONTRIBUTING.md) for PR style, testing guidance, and contribution workflow.

## License

This project currently has no license file. Add a LICENSE file (e.g., MIT) if you want to open-source the project under a specific license.
