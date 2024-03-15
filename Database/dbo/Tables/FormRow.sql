CREATE TABLE [dbo].[FormRow] (
    [Id]         INT             IDENTITY (0, 1) NOT NULL,
    [FormId]     INT             NULL,
    [SubjectId]  INT             NOT NULL,
    [Order]      INT             NOT NULL,
    CreationDate DATETIME2(7)    NOT NULL DEFAULT  GETDATE()
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id]),
    FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subject] ([Id])
);