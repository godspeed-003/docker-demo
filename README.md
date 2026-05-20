# docker-demo / DockerTestApp

This repository contains a small ASP.NET Core demo app (People & Notes) and a dockerized setup (SQL Server + web). The README below combines the original repo README and the local project instructions.

Quick start (recommended: Docker Compose)
1. Copy `.env.example` to `.env` and edit `MSSQL_SA_PASSWORD` to a strong password. Do NOT commit `.env` to source control.

2. Start the stack:

```powershell
docker compose up -d --build
```

3. Open the app in your browser (this project maps web -> host port 5005 by default):

- http://localhost:5005/
- http://localhost:5005/People
- http://localhost:5005/Notes

4. Seed sample data (optional):

```
http://localhost:5005/Home/SeedIndia
```

Run locally (without Docker)

```powershell
dotnet restore
dotnet run --project .\DockerTestApp.csproj
```

The app will print the URL it listens on (usually http://localhost:5000).

Security notes
- DO NOT commit `.env` or any file that contains secrets. This project uses `MSSQL_SA_PASSWORD` from `.env` and passes it to the SQL Server container. The SA password is used inside the container and is not tied to your GitHub account.
- If you expose the app publicly for a demo, use a short-lived tunnel (ngrok or localtunnel). I started a temporary localtunnel container earlier; to stop the tunnel remove the container:

```powershell
docker rm -f localtunnel
```

Repository notes
- The `docker-compose.yml` exposes SQL Server on host port 1433 and maps the web app to 5005 by default.
- The following items are excluded by `.gitignore`: `bin/`, `obj/`, local SQL Server data directory `sql-data/`, and `.env`.

Next steps
- (Optional) Reserve an ngrok subdomain for persistent public demos (requires an ngrok account).
- Add EF Core migrations and a migration-based seeding step for a more production-like workflow.
