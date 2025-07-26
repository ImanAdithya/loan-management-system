USE [LoanSystem]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==========================================
-- Author      : Iman Adithya
-- Create Date : 2025/07/25
-- Description : Select all loan applications
-- ==========================================

CREATE PROCEDURE SelectLoanApplications
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT 
		LA.Id,
		LA.CustomerName,
		LA.DurationMonths,
		LA.InterestRate,
		LA.NIC_PassportNumber,
		LA.MonthlyPayment,
		LA.LoanAmount,
		LA.Status,
		LT.Type AS LoanType
		FROM [dbo].[LoanApplications] LA
		INNER JOIN [dbo].[LoanTypes] LT ON LA.LoanTypeId=LT.Id;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO
