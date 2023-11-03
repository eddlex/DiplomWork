--Creating configs table
go
CREATE TABLE [dbo].[SmtpConfigurations] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [SmtpServer] NVARCHAR(255) NOT NULL,
    [Port] INT NOT NULL,
    [Username] NVARCHAR(100) NOT NULL,
    [Password] NVARCHAR(100) NOT NULL,
    [EnableSSL] BIT NOT NULL
FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
)


select * from SmtpConfigurations where Id = 1