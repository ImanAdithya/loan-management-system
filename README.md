# Loan Application Management System

## Project Overview
This is a simple Loan Application Management System developed using ASP.NET Core MVC and SQL Server. It allows users to manage loan applications with functionalities such as submitting new applications, viewing all applications, editing loan status, and viewing details.

## Technologies Used
- **Frontend:** ASP.NET Core MVC  
- **Backend:** ASP.NET Core MVC (No separate API project)  
- **Database:** Microsoft SQL Server  
- **Data Access:** ADO.NET (No Entity Framework)  
- **Version Control:** Git (Repository available at [your repo URL]) 


## Figma Design
https://www.figma.com/design/wPGdpU1qoyqMfI5uDrSrlq/Untitled?node-id=0-1&t=MHF7f0ByJFzMc7ER-1

## Prerequisites
[.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
[SQL Server Express or higher](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  
[Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or VS Code with C# extensions

  
## Pacakages
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Microsoft.Extensions.Configuration.FileExtensions
dotnet add package Microsoft.Data.SqlClient

## System Login Cred
Username : admin
password : 123

## Features

- **Login Page**  
  Hardcoded login to authenticate users before accessing the system.

- **Dashboard**  
  Displays a list of all loan applications.

- **Add Loan Application**  
  A form to submit new loan applications with the following fields:  
  - Customer Name  
  - NIC/Passport Number  
  - Loan Type (Personal, Housing, Vehicle)  
  - Interest Rate (auto-filled based on Loan Type)  
  - Loan Amount  
  - Duration (Months)  
  - Status (New, Approved, Rejected)

- **Edit Loan Application**  
  Allows updating the status of a loan application.

- **View Details**  
  View full details of a selected loan application.

- **Validation**  
  Input validation for required fields and valid numeric values.
