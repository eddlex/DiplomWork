CREATE TABLE [dbo].[RecipientGroup] (
    [Id]          INT            IDENTITY (0, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

