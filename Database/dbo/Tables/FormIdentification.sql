CREATE TABLE FormIdentification
(
    Id             INT PRIMARY KEY IDENTITY (0, 1) NOT NULL,
    GuId           UNIQUEIDENTIFIER DEFAULT NEWID(),
    FormId         INT NOT NULL,
    GroupId        INT NOT NULL,
    RecipientId    INT NOT NULL,
    Status         INT NOT NULL,
    ExpirationTime DATETIME2(7) NOT NULL,
    LastUpdateTime DATETIME2(7) NOT NULL,
    CreationTime   DATETIME2(7) DEFAULT  GETUTCDATE(),
);





