CREATE TABLE  [Admin].[UserUserRole] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[UserId] uniqueidentifier NOT NULL
	FOREIGN KEY ([UserId]) REFERENCES [Client].[User] ([Id]),
[UserRoleId] uniqueidentifier NOT NULL
	FOREIGN KEY ([UserRoleId]) REFERENCES [Admin].[UserRole] ([Id]),
)