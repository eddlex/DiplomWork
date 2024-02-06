CREATE TABLE [dbo].[SmtpConfigurations] (
    [Id]           INT            IDENTITY (0, 1) NOT NULL,
    [DepartmentId] INT            NULL,
    [SmtpServer]   NVARCHAR (255) NOT NULL,
    [Port]         INT            NOT NULL,
    [UserName]     NVARCHAR (100) NOT NULL,
    [Password]     NVARCHAR (100) NOT NULL,
    [EnableSSL]    BIT            DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([Id])
);