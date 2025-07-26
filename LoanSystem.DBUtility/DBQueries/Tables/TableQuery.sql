CREATE DATABASE LoanSystem;

USE LoanSystem;
GO

CREATE TABLE LoanTypes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Type VARCHAR(50) NOT NULL,
    Rate DECIMAL(5,2) NOT NULL  
);

CREATE TABLE LoanApplications (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    CustomerName VARCHAR(100) NOT NULL,
    NIC_PassportNumber VARCHAR(50) NOT NULL,
    LoanTypeId INT NOT NULL,
    InterestRate DECIMAL(5,2) NOT NULL,
    LoanAmount DECIMAL(18,2) NOT NULL,
    DurationMonths INT NOT NULL,
    Status VARCHAR(20) NOT NULL CHECK (Status IN ('New', 'Approved', 'Rejected')),
	MonthlyPayment DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_LoanApplications_LoanTypes 
        FOREIGN KEY (LoanTypeId) REFERENCES LoanTypes(Id)
);

INSERT INTO LoanTypes (Type, Rate)
VALUES 
('Personal', 10.50),
('Housing', 6.75),
('Vehicle', 8.25);


