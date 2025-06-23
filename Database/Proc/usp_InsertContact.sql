USE ContactsApp
GO
DROP PROCEDURE IF EXISTS dbo.usp_InsertorUpdateContact;
GO

CREATE PROCEDURE dbo.usp_InsertorUpdateContact
    @ContactId INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(20) = NULL,
    @Address NVARCHAR(200) = NULL,
    @City NVARCHAR(100) = NULL,
    @State NVARCHAR(100) = NULL,
    @Country NVARCHAR(100) = NULL,
    @PostalCode NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF (@ContactId = 0)
        BEGIN
            INSERT INTO dbo.Contact 
                (FirstName, LastName, Email, PhoneNumber, Address, City, State, Country, PostalCode, CreatedAt, ModifiedAt)
            VALUES 
                (@FirstName, @LastName, @Email, @PhoneNumber, @Address, @City, @State, @Country, @PostalCode, SYSUTCDATETIME(), SYSUTCDATETIME());
            SELECT SCOPE_IDENTITY() AS NewContactId;
        END
        ELSE 
        BEGIN
            UPDATE dbo.Contact 
            SET 
                FirstName = @FirstName, 
                LastName = @LastName, 
                Email = @Email, 
                PhoneNumber = @PhoneNumber, 
                Address = @Address, 
                City = @City, 
                State = @State, 
                Country = @Country, 
                PostalCode = @PostalCode, 
                ModifiedAt = SYSUTCDATETIME()
            WHERE ContactId = @ContactId;

            SELECT @ContactId AS NewContactId;
        END
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
