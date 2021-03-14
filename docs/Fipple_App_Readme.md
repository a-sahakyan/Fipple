---------------- Generating Context and entities ----------------

1) Install Microsoft.EntityFrameworkCore.Design
2) Install Npgsql.EntityFrameworkCore.PostgreSQL
3) Open Cli from path "\Fipple\src\Unviersalx.Fipple.App.DBmap" and run the following commmand:
   "dotnet ef dbcontext scaffold "Host=localhost;Database=fipple;Username=postgres;Password=sa123" Npgsql.EntityFrameworkCore.PostgreSQL -c FippleContext -o "FippleEntities" -f"