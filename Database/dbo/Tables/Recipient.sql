CREATE TABLE [dbo].[Recipient] (
    [Id]           INT            IDENTITY (0, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [Mail]         VARCHAR (50)   NOT NULL,
    [GroupId]      INT            NOT NULL,
    [DepartmentId] INT            NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [WeightId] INT
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[RecipientGroup] ([Id]),
    CONSTRAINT [Recipient__Department_fk] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([Id]),
    UNIQUE NONCLUSTERED ([Mail] ASC),
    CONSTRAINT [Recipient_pk] UNIQUE NONCLUSTERED ([Name] ASC),
    CONSTRAINT [Recipient__Weight_fk] FOREIGN KEY ([WeightId]) REFERENCES [dbo].[Weight] ([Id])
);


--ALTER TABLE Recipient
--ADD WeightId INT;

--ALTER TABLE Recipient
--ADD CONSTRAINT [Recipient__Weight_fk] FOREIGN KEY ([WeightId]) REFERENCES [dbo].[Weight] ([Id])


