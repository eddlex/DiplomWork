CREATE TABLE [dbo].[FormRow] (
    [Id]     INT            IDENTITY (0, 1) NOT NULL,
    [FormId] INT            NULL,
    [Name]   NVARCHAR (150) NOT NULL,
    [Value]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id])
);

