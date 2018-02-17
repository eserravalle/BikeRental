# BikeRental
Esta es una librería de clases C# con pruebas unitarias

# DOTNET HELP

How to build both projects:
dotnet build BikeRental
dotnet build BikeRentalTests

How to run the tests:
dotnet test BikeRentalTests/BikeRentalTests.csproj

How to add a project reference:
dotnet add BikeRentalTests/BikeRentalTests.csproj reference BikeRental/BikeRental.csproj

How to create a new MSTest project:
dotnet new mstest -lang c# -o 

How to create a new class library project:
dotnet new classlib -lang c# -o BikeRental
