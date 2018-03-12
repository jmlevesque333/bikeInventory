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
1. Download Zip of the repository
2. Extract
3. Install Visual Studio 2017 with the C# .Net Frameworks included
3. Run the BikeInventory1.sln with Visual Studio
4. Make sure these packages are installed with NuGet Package Manager (Project -> NuGet Package Manager)
   - Microsoft.AspNetCore.All
   - Microsoft.EntityFrameworkCore.Tools
   - Microsoft.NETCore.App
   - Microsoft.VisualStudio.Web.CodeGenerating.Design
5. Open package manager console (Tools -> NuGet Package Manager -> Package Manager Console)
6. Run the command Install-Package Microsoft.EntityFrameworkCore.Tools
7. Run the command add-migration Initial
8. Run the command Update-Database
9. Run the Program (CTRL + F5)
