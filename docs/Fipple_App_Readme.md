---------------- Generating Context and entities ----------------

1) Install Microsoft.EntityFrameworkCore.Design
2) Install Npgsql.EntityFrameworkCore.PostgreSQL
3) Open Cli from path "\Fipple\src\Unviersalx.Fipple.App.DBmap" and run the following commmand:
  1. dotnet ef dbcontext scaffold "Host=localhost;Database=fipple;Username=postgres;Password=sa123" Npgsql.EntityFrameworkCore.PostgreSQL -c AppContext -o "AppEntities" --schema app -f
  2. dotnet ef dbcontext scaffold "Host=localhost;Database=fipple;Username=postgres;Password=sa123" Npgsql.EntityFrameworkCore.PostgreSQL -c CoreContext -o "CoreEntities" --schema core -f
   