CREATE TABLE [Manager].[Tag] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[Name] nvarchar(30) NOT NULL,
[TagGroupId] uniqueidentifier NOT NULL
	FOREIGN KEY ([TagGroupId]) REFERENCES [Manager].[TagGroup] ([Id]),
)