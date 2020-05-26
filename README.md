# Avaliacao
Avaliação C# (Locadora de Filmes em MVC)

### caso use DB
se quiser usar banco de dados use o mariaDb pois esta aplicação foi feita com "base" nele, configure suas credenciais em  `Repositories/Repository.cs`
e instale:
1. `dotnet tool install dotnet-ef -g --version 3.1.1`
2. `dotnet add package Pomelo.EntityFrameworkCore.MySql`
3. `dotnet add package Pomelo.EntityFrameworkCore.MySql.Desing`
4. `dotnet add package Microsoft.EntityFrameworkCore`
5. `dotnet add package Microsoft.EntityFrameworkCore.Desing`
6. `dotnet ef migrations add InitialDB`
7. `dotnet ef database update`
