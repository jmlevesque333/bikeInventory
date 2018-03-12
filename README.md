# bikeInventory
Bike inventory web app using asp.net core

Functionalities:
- Create new listings
- Edit listing
- Delete listings
- View listings
  - Sort listings
  - Filter listings

How to use:
before starting, make sure IIS is enabled on the computer. If not, follow the instructions here: https://stackoverflow.com/questions/30901434/iis-manager-in-windows-10
1. Download Zip of the repository
2. Extract
3. Install Visual Studio 2017 with the C# .Net Frameworks included
4. Run the BikeInventory1.sln with Visual Studio
5. Make sure these packages are installed with NuGet Package Manager (Project -> Manage NuGet Packages)
   - Microsoft.AspNetCore.All
   - Microsoft.EntityFrameworkCore.Tools
   - Microsoft.NETCore.App
   - Microsoft.VisualStudio.Web.CodeGenerating.Design
6. Open package manager console (Tools -> NuGet Package Manager -> Package Manager Console)
7. Run the command Install-Package Microsoft.EntityFrameworkCore.Tools
8. Run the command add-migration Initial
9. Run the command Update-Database
10. Run the Program (CTRL + F5)
