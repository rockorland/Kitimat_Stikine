**COMP3800**

Team 9: Kyung Min Song, Jerry Hu, Guang Yang, Kwanyong Jo

Project: Database for Regional District Kitimat-Stikine.

Edition Date: 2022-05-27


**Release Notes**
1. Introduction

This document lists the new features and changes in this release of the RDKS Database Design project. It also documents the known issues, problems and workarounds.

2. About this release

This is the first release of the application, which demonstrates the use of a database to perform CRUD operations and search/filter records. There is a limited number of features and is initialized with a small number of mock data that resembles the actual data. All of the functions have been thoroughly tested and limitations have been identified.

3. New Features 
1) Create a new record
2) Search record by keyword, time or time period.
3) Easy navigation items
4) Display records with related records from referenced tables
5) Edit record
6) Delete record
7) Sort by date 

4. Known Bugs, Issues and Limitations
1) Data still needs to be input one by one. Don’t have a function to input data by spreadsheet.
2) Don’t have an output function (like print or output to spreadsheet) on each page.
3) The application and database are not hosted online.
4) Sort function only works on some pages, but can be implemented on all other pages.
5) For automatically generated PK, if a record is deleted, the other PK would not change accordingly. For example, the pk 1, 2, 3 for three separate records, if 2 is deleted, the record 3 will not be changed to 2 automatically.
6) Database does not include all of the tables from the provided resources.


**Deployment Notes**
1. Introduction

This document lists the installation requirements to launch the RDKS Database Web App.
Installation Requirements

2. MicroSoft Visual Studio 2019 or higher
1) .NET 6.0
2) ASP.Net and Web Development 
3) .Net Desktop Development
4) Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore 6.0.5
5) Microsoft.EntityFrameworkCore.SqlServer 6.0.5
6) Microsoft.EntityFrameworkCore.Tools 6.0.5

3. Configurations 

1) Use default settings to run the application
2) Before running the code do the following in NuGet Package Manager:
	  a) Add-Migration <migration-file-name>
	  b) Update-Database <migration-file-name>
3) To rebuild the database:
	  a) Drop-Database
	  b) Add-Migration <migration-file-name>
	  c) Update-Database <migration-file-name>

4. Final Code 

https://github.com/Jerry-Hyf/COMP3800.git
