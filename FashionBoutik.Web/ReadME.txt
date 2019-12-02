ASP.NET MVC 6 Core 2.2 site
Before start in VS 2017-2019
- check in file appsettings.json under ConnectionStrings "DBConnection" value to your SQL Server 2017-2019 (where DB will be located)
- In VS package "manager console" call the next command (to create DB)
PM> update-database -project FashionBoutik.EF
 -that will create DB with name 'FashionBoutikDB' 
 If you need to change DB schema, just: 
 PM>  add-migration NewXDBMigration -project FashionBoutik.EF
then
 PM> update-database -project FashionBoutik.EF

