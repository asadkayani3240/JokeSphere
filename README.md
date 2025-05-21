# JokeSphere (ASP.NET Core MVC)

A lighthearted joke delivery web app built with C# on .NET 8, featuring inline punchline reveals and a random joke generator backed by SQL Server and Entity Framework Core.

---

## 📝 Requirements

- .NET 8 SDK
- SQL Server (local or remote)
- Visual Studio 2022+ or VS Code
- Git
- (Optional) EF Core CLI: `dotnet tool install --global dotnet-ef`

---

## 📁 Project Structure

```
JokeSphere/
├── Controllers/
│   └── JokesController.cs           # Random, Index, Details endpoints
├── Data/
│   ├── ApplicationDbContext.cs      # EF Core DbContext
│   ├── ApplicationDbContextFactory.cs # Design-time factory for Migrations
│   └── SeedData.cs                  # JSON seeding on startup
├── Models/
│   └── Joke.cs                      # Entity model
├── Services/
│   ├── IJokeRepository.cs           # Repository interface
│   └── EfJokeRepository.cs          # EF Core implementation
├── DBScript/
│   └── CreateJokeSphereDb.sql       # SQL fallback script for DB setup
├── Views/
│   ├── Home/Index.cshtml            # Hero landing page
│   ├── Jokes/Index.cshtml           # All jokes list view
│   ├── Jokes/Random.cshtml          # Random joke with inline reveal
│   └── Shared/_Layout.cshtml        # Tailwind + daisyUI layout, nav, footer
├── wwwroot/data/
│   └── jokes.json                   # Seed data file
├── appsettings.json                 # ConnectionStrings config
├── JokeSphere.csproj
└── Program.cs                        # Configure services & middleware
```

---

## ⚙️ Configure the Database

1. **Connection String**
   Edit `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=JokeSphereDb;User Id=YOUR_USER;Password=YOUR_PASS;Trusted_Connection=True;"
     }
   }
   ```

2. **Run EF Core Migrations**
   ```bash
   dotnet ef database update
   ```

3. **SQL Fallback**
   If migrations fail, run the script manually:
   ```bash
   sqlcmd -S <server> -d master -i DBScript/CreateJokeSphereDb.sql
   ```

---

## 🚀 Run the Application

```bash
dotnet restore
dotnet build
dotnet run
```

Navigate to `https://localhost:{PORT}` to view the app.

---

## 💻 Technology Choices

- **.NET 8**: Latest C# features & LTS support
- **Entity Framework Core**: Code-first models & migrations
- **Tailwind CSS + daisyUI**: Rapid styling & prebuilt components
- **Alpine.js**: Lightweight interactivity for inline punchline reveal
- **SQL Server**: Reliable relational storage

---

## 🔮 Future Enhancements

- **Authentication/Authorization**: JWT or cookie-based login
- **Pagination & Filtering**: Query parameters for joke categories
- **Integration Testing**: End-to-end tests via WebApplicationFactory
- **Docker Support**: Containerize API + SQL Server
- **REST API**: Expose endpoints for mobile clients

---

## 🤝 Contributing

Contributions welcome! Please fork, add features or fixes, and submit a PR.

---

© 2025 – JokeSphere
