-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------
   Starting AspNetCoreIdentity migrations:

First Set as Startup project the 'Universalx.Fipple.Identity.Api'

1. From Package Manger Console:
   Default Project: UniversalxIdentity.DBMap
   Pm: Add-Migration InitialApplicationContext -Context ApplicationContext -o Data/Migrations/ApplicationDb

2. From Package Manger Console:
   Default project: UniversalxIdentity.DBMap
   PM: Update-Database -Context ApplicationContext