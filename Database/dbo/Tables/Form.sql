CREATE TABLE [dbo].[Form] (
    [Id]      INT IDENTITY (0, 1) NOT NULL,
    [Name]    NVARCHAR(50) NOT NULL UNIQUE,
    [DepartmentId] INT NOT NULL  REFERENCES [dbo].[Department],
    [GroupId] INT NULL,
    [Description] NVARCHAR(MAX)
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[RecipientGroup] ([Id])
);

