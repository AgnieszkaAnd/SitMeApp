CREATE TABLE [Client].[Reservation] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[UserId] uniqueidentifier NOT NULL
	FOREIGN KEY ([UserId]) REFERENCES [Client].[User] ([Id]),
[StartDateTime] smalldatetime NOT NULL,
[EndDateTime] smalldatetime NOT NULL,
[NbOfPeople] tinyint NOT NULL,
[CustomerSpecialRequest] nvarchar(300),
[IsConfirmed] bit NOT NULL,
[CustomerArrived] bit
)