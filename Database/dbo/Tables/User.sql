CREATE TABLE [dbo].[User] (
    [Id]           INT            IDENTITY (0, 1) NOT NULL,
    [UserName]     VARCHAR (50)   NOT NULL,
    [Email]        VARCHAR (100)  NOT NULL,
    [Phone]        VARCHAR (100)  NULL,
    [Password]     NVARCHAR (500) NOT NULL,
    [Salt]         NVARCHAR (50)  NOT NULL,
    [UniversityId] INT            NULL,
    [RoleId]       INT            NOT NULL DEFAULT (0),
    [CreationDate] DATETIME2 (7)  DEFAULT (getutcdate()) NULL,   
    [UpdateDate]   DATETIME2 (7)  DEFAULT (getutcdate()) NULL,   
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [User_RoleId__fk]       FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]),
    CONSTRAINT [User_UniversityId__fk] FOREIGN KEY ([UniversityId]) REFERENCES [dbo].[University] ([Id]),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([UserName] ASC)
);