CREATE TABLE [Client].[UserRestaurant] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[UserId] uniqueidentifier NOT NULL
	FOREIGN KEY ([UserId]) REFERENCES [Client].[User] ([Id]),
[RestaurantId] uniqueidentifier NOT NULL
	FOREIGN KEY ([RestaurantId]) REFERENCES [Manager].[Restaurant] ([Id]),
)