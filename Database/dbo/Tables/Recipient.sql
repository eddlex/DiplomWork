CREATE TABLE [dbo].[Recipient] (
    [Id]           INT            IDENTITY (0, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [Mail]         VARCHAR (50)   NOT NULL,
    [GroupId]      INT            NOT NULL,
    [DepartmentId] INT            NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[RecipientGroup] ([Id]),
    CONSTRAINT [Recipient__Department_fk] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([Id]),
    UNIQUE NONCLUSTERED ([Mail] ASC),
    CONSTRAINT [Recipient_pk] UNIQUE NONCLUSTERED ([Name] ASC)
);





