# razor-pharmacy

Asp.Net Razor MVC Web App for self-study purposes

## Run locally

- Create Postgres container: `docker run --name pg -e POSTGRES_USER=guest -e POSTGRES_PASSWORD=guest -d -p 5432:5432 postgres` 
- Run the webb app: `dotnet run --project Razor.Pharmacy.WebUI`
