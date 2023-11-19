CREATE TABLE [dbo].[Permission] (
    [Id]         INT            IDENTITY (0, 1) NOT NULL,
    [Permission] INT            NOT NULL,
    [Name]       NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

