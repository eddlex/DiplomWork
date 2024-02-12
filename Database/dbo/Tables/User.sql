CREATE TABLE [dbo].[User] (
[Id]           INT            IDENTITY (0, 1) NOT NULL,
[UserName]     VARCHAR (50)   NOT NULL,
[Email]        VARCHAR (100)  NOT NULL,
[Phone]        VARCHAR (100)  NULL,
[Password]     NVARCHAR (500) NOT NULL,
[Salt]         NVARCHAR (50)  NOT NULL,
[DepartmentId] INT            NOT NULL,
[RoleId]       INT            DEFAULT ((0)) NOT NULL,
[CreationDate] DATETIME2 (7)  DEFAULT (getutcdate()) NULL,
[UpdateDate]   DATETIME2 (7)  DEFAULT (getutcdate()) NULL,
PRIMARY KEY CLUSTERED ([Id] ASC),
CONSTRAINT [User_DepartmentId__fk] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([Id]),
CONSTRAINT [User_RoleId__fk] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]),
UNIQUE NONCLUSTERED ([Email] ASC),
UNIQUE NONCLUSTERED ([UserName] ASC)
);
GO

