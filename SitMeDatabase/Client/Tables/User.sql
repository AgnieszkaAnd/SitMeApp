CREATE TABLE [Client].[User] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[Nick] nvarchar(100),
[Email] nvarchar(100),
[Password] nvarchar(100),
[FirstName] nvarchar(30),
[LastName] nvarchar(50),
[TelephoneNb] nvarchar(30)
)