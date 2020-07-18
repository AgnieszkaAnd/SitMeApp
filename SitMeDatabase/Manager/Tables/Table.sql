CREATE TABLE [Manager].[Table] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[Name] nvarchar(50),
[TableTypeId] uniqueidentifier NOT NULL
	FOREIGN KEY ([TableTypeId]) REFERENCES [Manager].[TableType] ([Id]),
[MaxNbOfSeats] tinyint NOT NULL,
[Picture] image,
[LocationInRestaurant] nvarchar(50) NOT NULL,
[IsVisibleForUsers] bit NOT NULL,
[RestaurantId] uniqueidentifier NOT NULL
	FOREIGN KEY ([RestaurantId]) REFERENCES [Manager].[Restaurant] ([Id]),
)