# AddressBook
AddressBook .NET Core Web API project with SignalR and PostgreSQL database. 

This project provides functionality of an address book, with contacts and their telephone numbers. 
The notification for every controller action is sent to connected users via SignalR. 

## Postman requests testing
Postman requests and appropriate headers and bodies of a request are listed in `SolutionItems/postman_requests_test.txt` file. 

## PostgreSQL database
PostgreSQL database table creation script file is located in `SolutionItems/address_book_create_table_data.sql` file. 
The rest of the database data is located in `appsettings.json` file. 
