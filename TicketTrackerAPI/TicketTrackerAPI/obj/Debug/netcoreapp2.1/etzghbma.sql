IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Ticketmaster] (
    [TicketId] int NOT NULL IDENTITY,
    [ClientName] nvarchar(50) NULL,
    [DeveloperName] nvarchar(50) NULL,
    [Module] nvarchar(50) NULL,
    [DEscription] nvarchar(500) NULL,
    [ShortNotes] nvarchar(50) NULL,
    [priority] int NULL,
    CONSTRAINT [PK_Ticketmaster] PRIMARY KEY ([TicketId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190320062716_MyFirstMigration', N'2.1.8-servicing-32085');

GO

