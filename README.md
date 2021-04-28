# AddressBook
AddressBook .NET Core Web API project with SignalR and PostgreSQL database. 

This project provides functionality of an address book, with contacts and their telephone numbers. 
The notification for every controller action is sent to connected users via SignalR hub. 

## PostgreSQL database
This project is done with database-first approach. 

PostgreSQL database table creation script file is located in `SolutionItems/address_book_create_table_data.sql` file. 

The rest of the database data is located in `appsettings.json` file. 

Reverse engineering model creation is done with EntityFramework scaffolding. The scrips needed to generate the model are located in `dotnet_packages_install.txt` file. 

# SignalR
When started, application opens a browser on the starting page. Upon making a request, the relevant information will appear on the page. 

## NuGet packages
NuGet packages used in this solution: 
- Microsoft.EntityFrameworkCore.Design
- Microsoft.NETCore.App
- Npgsql.EntityFrameworkCore.PostgreSQL
- Npgsql.EntityFrameworkCore.PostgreSQL.Design


## Postman requests
Postman requests with appropriate header and body values of the requests for testing are listed in `SolutionItems/postman_requests_test.txt` file. 
