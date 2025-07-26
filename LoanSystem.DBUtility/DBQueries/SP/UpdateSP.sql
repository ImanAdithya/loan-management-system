USE [LoanSystem]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--==========================================
-- Author      : Iman Adithya
-- Create Date : 2025/07/25
-- Description : Update Loan Application Status by Id
--==========================================

CREATE PROCEDURE UpdateLoanStatus
(
    @Id INT,
    @Status VARCHAR(20)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [dbo].[LoanApplications]
        SET Status = @Status
        WHERE Id = @Id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END
