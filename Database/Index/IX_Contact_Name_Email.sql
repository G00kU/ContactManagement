USE ContactsApp
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Contact_Name_Email' AND object_id = OBJECT_ID('dbo.Contact'))
BEGIN
 DROP INDEX IX_Contact_Email ON dbo.Contact;
END
CREATE INDEX IX_Contact_Name_Email ON dbo.Contact (FirstName, Email);


