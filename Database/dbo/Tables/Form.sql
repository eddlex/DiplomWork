CREATE TABLE [dbo].[Form] (
    [Id]      INT IDENTITY (0, 1) NOT NULL,
    [GroupId] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[RecipientGroup] ([Id])
);

