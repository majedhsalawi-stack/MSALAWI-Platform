# MSALAWI Platform

Saudi enterprise operating platform for the nonprofit sector.

## Technology baseline
- Backend: .NET 10 / ASP.NET Core
- Frontend: React + TypeScript + Vite
- Database: PostgreSQL
- Containers: Docker Compose

## Quick start

### Backend
```bash
dotnet restore MSALAWI.Platform.slnx
dotnet build MSALAWI.Platform.slnx --configuration Release
dotnet test MSALAWI.Platform.slnx --configuration Release
dotnet run --project source/Presentation/Api/MSALAWI.Presentation.Api.csproj
```

### Frontend
```bash
cd source/Presentation/Web
npm ci
npm run build
npm run dev
```

### Full local stack
```bash
docker compose -f deployment/docker-compose.yml up --build
```
