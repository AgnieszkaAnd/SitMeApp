USE [SitMeScriptCreated]

-- USER ROLE - definition of some kind of 'access groups'
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Admin' 
                 AND  TABLE_NAME = 'UserRole'))
CREATE TABLE  [Admin].[UserRole] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[Name] nvarchar(20) UNIQUE,
)


-- USER: main data needed to login
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Client' 
                 AND  TABLE_NAME = 'User'))
CREATE TABLE [Client].[User] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[Nick] nvarchar(100),
[Email] nvarchar(100),
[Password] nvarchar(100),
[FirstName] nvarchar(30),
[LastName] nvarchar(50),
[TelephoneNumber] nvarchar(30)
)


-- USER - USER ROLE - future-proof concept allowing user to have > 1 role assigned
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Admin' 
                 AND  TABLE_NAME = 'UserUserRole'))
CREATE TABLE  [Admin].[UserUserRole] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[UserId] uniqueidentifier NOT NULL
	FOREIGN KEY ([UserId]) REFERENCES [Client].[User] ([Id]),
[UserRoleId] uniqueidentifier NOT NULL
	FOREIGN KEY ([UserRoleId]) REFERENCES [Admin].[UserRole] ([Id]),
)


-- RESERVATION
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Client' 
                 AND  TABLE_NAME = 'Reservation'))
CREATE TABLE [Client].[Reservation] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[UserId] uniqueidentifier NOT NULL
	FOREIGN KEY ([UserId]) REFERENCES [Client].[User] ([Id]),
[StartDateTime] smalldatetime NOT NULL,
[EndDateTime] smalldatetime NOT NULL,
[NumberOfPeople] tinyint NOT NULL,
[CustomerSpecialRequest] nvarchar(300),
[IsConfirmed] bit NOT NULL,
[CustomerArrived] bit
)


-- RESTAURANT
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Manager' 
                 AND  TABLE_NAME = 'Restaurant'))
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


-- TABLE TYPE
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Manager' 
                 AND  TABLE_NAME = 'TableType'))
CREATE TABLE [Manager].[TableType] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[Name] nvarchar(30) NOT NULL
)


-- TABLE
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Manager' 
                 AND  TABLE_NAME = 'Table'))
CREATE TABLE [Manager].[Table] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[Name] nvarchar(50),
[TableTypeId] uniqueidentifier NOT NULL
	FOREIGN KEY ([TableTypeId]) REFERENCES [Manager].[TableType] ([Id]),
[MaxNumberOfSeats] tinyint NOT NULL,
[Picture] image,
[LocationInRestaurant] nvarchar(50) NOT NULL,
[IsVisibleForUsers] bit NOT NULL,
[RestaurantId] uniqueidentifier NOT NULL
	FOREIGN KEY ([RestaurantId]) REFERENCES [Manager].[Restaurant] ([Id]),
)

-- RESERVATION-TABLE: relation many to many btw Reservations and Tables
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Client' 
                 AND  TABLE_NAME = 'ReservationTable'))
CREATE TABLE [Client].[ReservationTable] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[ReservationId] uniqueidentifier NOT NULL
	FOREIGN KEY ([ReservationId]) REFERENCES [Client].[Reservation] ([Id]),
[TableId] uniqueidentifier NOT NULL
	FOREIGN KEY ([TableId]) REFERENCES [Manager].[Table] ([Id])
)


-- USER-RESTAURANT: relation many to many btw Users and Restaurants (represents user's favourite restaurants)
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Client' 
                 AND  TABLE_NAME = 'UserRestaurant'))
CREATE TABLE [Client].[UserRestaurant] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[UserId] uniqueidentifier NOT NULL
	FOREIGN KEY ([UserId]) REFERENCES [Client].[User] ([Id]),
[RestaurantId] uniqueidentifier NOT NULL
	FOREIGN KEY ([RestaurantId]) REFERENCES [Manager].[Restaurant] ([Id]),
)


-- TAG GROUP - for purposes of grouping tags to help searching/filtering restaurants
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Manager' 
                 AND  TABLE_NAME = 'TagGroup'))
CREATE TABLE [Manager].[TagGroup] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[Name] nvarchar(30) NOT NULL
)


-- TAG
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Manager' 
                 AND  TABLE_NAME = 'Tag'))
CREATE TABLE [Manager].[Tag] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[Name] nvarchar(30) NOT NULL,
[TagGroupId] uniqueidentifier NOT NULL
	FOREIGN KEY ([TagGroupId]) REFERENCES [Manager].[TagGroup] ([Id]),
)


-- RESTAURANT-TAG: relation many to many btw Restaurants and pre-defined Tags (eg. animal friendly, kids friendly etc.)
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'Manager' 
                 AND  TABLE_NAME = 'RestaurantTag'))
CREATE TABLE [Manager].[RestaurantTag] (
[Id] uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
[RestaurantId] uniqueidentifier NOT NULL
	FOREIGN KEY ([RestaurantId]) REFERENCES [Manager].[Restaurant] ([Id]),
[TagId] uniqueidentifier NOT NULL
	FOREIGN KEY ([TagId]) REFERENCES [Manager].[Tag] ([Id]),
)


---INSERT INTO [Admin].[UserRole] ([Id] , [Name])
---VALUES	(NEWID() , 'Admin'),
---		(NEWID() , 'Client'),
---		(NEWID() , 'RestaurantManager')


