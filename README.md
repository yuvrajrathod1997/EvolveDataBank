# Evolve DataBank (ASP.NET Core 8 MVC)

Static-content redesign of evolvedatabank.com. Data lives in memory (`Data/ReportStore.cs`); no database.

## Run
- Visual Studio 2022: File > Open > Project/Solution > `EvolveDataBank.csproj`, then press F5.
- CLI: `dotnet run` (opens http://localhost:5080).

## Edit
- Add or change reports, categories, prices: `Data/ReportStore.cs`
- Pages: `Views/Home`, `Views/Reports`, shared layout in `Views/Shared/_Layout.cshtml`
- Styles and script: `wwwroot/css/style.css`, `wwwroot/js/main.js`

## Before deploying
- Copy the logo into `wwwroot/images` and update `Site.LogoUrl` in `Models/Models.cs`.
- Search the code for `CONFIRM` to find copy that needs client approval.
