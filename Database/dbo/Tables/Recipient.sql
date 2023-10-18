CREATE TABLE [dbo].[Recipient] (
    [Id]          INT            IDENTITY (0, 1) NOT NULL,
    [GroupId]     INT            NULL,
    [Mail]        VARCHAR (50)   NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[RecipientGroup] ([Id]),
    UNIQUE NONCLUSTERED ([Mail] ASC)
);

