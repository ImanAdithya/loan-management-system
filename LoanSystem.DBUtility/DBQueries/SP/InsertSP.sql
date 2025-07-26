USE [LoanSystem]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--==========================================
--Author      : Iman Adithya
--Create Date : 2025/07/25
--Description : Insert Loan Details
--==========================================

CREATE PROCEDURE InsertApplicationLoanDetails
(
    @CustomerName VARCHAR(100),
    @NIC_PassportNumber VARCHAR(50),
    @LoanTypeId INT,
    @InterestRate DECIMAL(5,2),
    @LoanAmount DECIMAL(18,2),
	@MonthlyPayment  DECIMAL(18,2),
    @DurationMonths INT,
    @Status VARCHAR(20)
)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

            INSERT INTO [dbo].[LoanApplications]
            (CustomerName, NIC_PassportNumber, LoanTypeId, InterestRate, LoanAmount, DurationMonths, Status,MonthlyPayment)
            VALUES
            (@CustomerName, @NIC_PassportNumber, @LoanTypeId, @InterestRate, @LoanAmount, @DurationMonths, @Status,@MonthlyPayment);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END
