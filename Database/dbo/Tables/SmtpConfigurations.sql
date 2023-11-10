CREATE TABLE [dbo].[SmtpConfigurations] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [UniversityId] INT            NULL,
    [SmtpServer]   NVARCHAR (255) NOT NULL,
    [Port]         INT            NOT NULL,
    [Username]     NVARCHAR (100) NOT NULL,
    [Password]     NVARCHAR (100) NOT NULL,
    [EnableSSL]    BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UniversityId]) REFERENCES [dbo].[University] ([Id])
);



