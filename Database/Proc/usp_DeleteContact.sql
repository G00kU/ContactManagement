USE ContactsApp;
GO
DROP PROCEDURE IF EXISTS dbo.usp_DeleteContact;
GO
CREATE PROCEDURE dbo.usp_DeleteContact
    @ContactId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM dbo.Contact
        WHERE ContactId = @ContactId;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO
