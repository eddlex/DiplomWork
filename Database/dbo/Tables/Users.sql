CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (0, 1) NOT NULL,
    [Username]     VARCHAR (50)   NOT NULL,
    [Email]        VARCHAR (100)  NOT NULL,
    [Phone]        VARCHAR (100)  NOT NULL,
    [Password]     NVARCHAR (500) NOT NULL,
    [Salt]         NVARCHAR (50)  NOT NULL,
    [CreationDate] DATETIME2 (7)  DEFAULT (getutcdate()) NULL,
    [UniversityId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Users_UniversityId__fk] FOREIGN KEY ([UniversityId]) REFERENCES [dbo].[University] ([Id]),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([Phone] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);





