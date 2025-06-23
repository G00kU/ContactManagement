USE ContactsApp
Go
CREATE TABLE dbo.Contact (
    ContactId     int  NOT NULL  IDENTITY(1,1) CONSTRAINT PK_Contact PRIMARY KEY,
    FirstName     NVARCHAR(50)     NOT NULL,
    LastName      NVARCHAR(50)     NOT NULL,
    Email         NVARCHAR(100)    NOT NULL UNIQUE,
    PhoneNumber   NVARCHAR(20)     NULL,
    Address       NVARCHAR(200)    NULL,
    City          NVARCHAR(100)    NULL,
    State         NVARCHAR(100)    NULL,
    Country       NVARCHAR(100)    NULL,
    PostalCode    NVARCHAR(20)     NULL,
    CreatedAt     DATETIME2        NOT NULL DEFAULT SYSUTCDATETIME(),
    ModifiedAt    DATETIME2        NOT NULL DEFAULT SYSUTCDATETIME()
);
