CREATE TABLE [Client].[ReservationTable] (
    [Id]            UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [ReservationId] UNIQUEIDENTIFIER NOT NULL,
    [TableId]       UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ReservationId]) REFERENCES [Client].[Reservation] ([Id]),
    CONSTRAINT [FK_Resetvati_Table] FOREIGN KEY ([TableId]) REFERENCES [Manager].[Table] ([Id])
);

