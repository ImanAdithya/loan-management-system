USE [LoanSystem]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==========================================
-- Author      : Iman Adithya
-- Create Date : 2025/07/25
-- Description : Select all loan types
-- ==========================================

CREATE PROCEDURE SelectLoanType
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * FROM [dbo].[LoanTypes];
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO
