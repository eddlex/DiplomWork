CREATE TABLE [dbo].[UserInfo] (
    [Id]              INT           IDENTITY (0, 1) NOT NULL,
    [UserId]          INT           NULL,
    [FirstName]       NVARCHAR (50) NULL,
    [LastName]        NVARCHAR (50) NULL,
    [BirthDate]       DATETIME2 (2) NULL,
    [EmailIsVerified] BIT           DEFAULT ((0)) NULL,
    [PhoneIsVerified] BIT           DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

