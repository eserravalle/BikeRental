# BikeRental
Esta es una librería de clases C# con pruebas unitarias


# DOTNET HELP

How to build both projects:
dotnet build BikeRental
dotnet build BikeRentalTests

>>> How to run the tests:
dotnet test BikeRentalTests/BikeRentalTests.csproj

How to add a project reference:
dotnet add BikeRentalTests/BikeRentalTests.csproj reference BikeRental/BikeRental.csproj

How to create a new MSTest project:
dotnet new mstest -lang c# -o 

How to create a new class library project:
dotnet new classlib -lang c# -o BikeRental


# NOTAS PARA FDV

Para cada una de los conceptos del dominio creé una clase: Bike, Person, Rental

Creé un repository, RentalRepository, para que contenga las instancias de Rental que se creen y provea los métodos para administrar el ABM de los alquileres. Este repository sería utilizado para encapsular la lógica de acceso a base de datos, llegado el caso de que la aplicación evolucione.

Para el cálculo del valor de un alquiler, decidí encapsular la lógica en RentalChargeService.

Procuré seguir la práctica de TDD lo más fielmente posible, escribiendo primero el test que describe un determinado comportamiento del código y luego agregando el código necesario para que el test pase.

