CREATE TABLE [dbo].[MailBody] (
    [Id]           INT            IDENTITY (0, 1) NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Subject]      NVARCHAR (150) NULL,
    [Body]         NVARCHAR (MAX) NULL,
    [DepartmentId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([Id]),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

