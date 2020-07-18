CREATE TABLE [Manager].[Restaurant] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[Name] nvarchar(100) NOT NULL,
[City] nvarchar(30) NOT NULL,
[Address] nvarchar(100),
[Description] nvarchar(500),
[Telephone] nvarchar(30) NOT NULL,
[Email] nvarchar(50) NOT NULL,
[WebsiteLink] nvarchar(100),
[MenuLink] nvarchar(100),
[OpeningTime] time NOT NULL, 
[CloseTime] time NOT NULL
)