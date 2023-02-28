IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Coaches] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    CONSTRAINT [PK_Coaches] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Grounds] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(20) NOT NULL,
    CONSTRAINT [PK_Grounds] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Regions] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(20) NOT NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [RugbyUnions] (
    [RugbyUnionId] int NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    CONSTRAINT [PK_RugbyUnions] PRIMARY KEY ([RugbyUnionId])
);
GO

CREATE TABLE [Teams] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(20) NOT NULL,
    [GroundId] int NOT NULL,
    [CoachId] int NOT NULL,
    [FoundedYear] int NOT NULL,
    [RegionId] int NOT NULL,
    [RugbyUnionId] int NOT NULL,
    CONSTRAINT [PK_Teams] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Teams_Coaches_CoachId] FOREIGN KEY ([CoachId]) REFERENCES [Coaches] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Teams_Grounds_GroundId] FOREIGN KEY ([GroundId]) REFERENCES [Grounds] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Teams_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Teams_RugbyUnions_RugbyUnionId] FOREIGN KEY ([RugbyUnionId]) REFERENCES [RugbyUnions] ([RugbyUnionId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Players] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    [Height] decimal(6,2) NULL,
    [Weight] decimal(6,2) NULL,
    [PlaceOfBirth] nvarchar(max) NOT NULL,
    [TeamId] int NOT NULL,
    [Active] bit NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Players_Teams_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Teams] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Players_TeamId] ON [Players] ([TeamId]);
GO

CREATE INDEX [IX_Teams_CoachId] ON [Teams] ([CoachId]);
GO

CREATE INDEX [IX_Teams_GroundId] ON [Teams] ([GroundId]);
GO

CREATE INDEX [IX_Teams_RegionId] ON [Teams] ([RegionId]);
GO

CREATE INDEX [IX_Teams_RugbyUnionId] ON [Teams] ([RugbyUnionId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230227160508_initial', N'6.0.9');
GO

COMMIT;
GO

