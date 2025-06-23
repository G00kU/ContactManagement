DROP PROCEDURE IF EXISTS dbo.usp_GetAllContacts;
GO
CREATE PROCEDURE dbo.usp_GetAllContacts
AS
BEGIN
    SET NOCOUNT ON;
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
    FROM dbo.Contact;
END;
GO
