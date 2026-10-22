# Smart Parking Admin module
Blazor Web App (.NET 8) with C# API client. Implements the Admin UI for user account management, parking price management, and parking spot management as described in Plan.pdf.

## Run
Install the .NET 8 SDK, then run:
```bash
dotnet restore
dotnet run
```

## Important integration notes
- This is a standalone starter scaffold, not code extracted from Wenshi Cai's existing repository.
- API endpoints are assumptions: `GET api/users`, `PATCH api/users/{id}/status`, CRUD `api/prices`, and CRUD `api/parking-spots`.
- Change the URLs in `appsettings.json` to your team's actual service URLs.
- Confirm DTOs and routes with the Driver/Staff backend owners before integration.
- Add administrator authentication/authorization before real deployment.
- Admin should use service APIs rather than direct database access.
