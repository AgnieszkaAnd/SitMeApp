CREATE TABLE [Manager].[RestaurantTag] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[RestaurantId] uniqueidentifier NOT NULL
	FOREIGN KEY ([RestaurantId]) REFERENCES [Manager].[Restaurant] ([Id]),
[TagId] uniqueidentifier NOT NULL
	FOREIGN KEY ([TagId]) REFERENCES [Manager].[Tag] ([Id]),
)