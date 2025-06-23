use ContactsApp
GO
DROP PROCEDURE IF EXISTS dbo.usp_GetContactById;
GO

CREATE PROCEDURE dbo.usp_GetContactById
    @ContactId INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        SELECT 
            ContactId,
            FirstName,
            LastName,
            Email,
            PhoneNumber,
            Address,
            City,
            State,
            Country,
            PostalCode,
            CreatedAt,
            ModifiedAt
        FROM dbo.Contact
        WHERE ContactId = @ContactId;

    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
