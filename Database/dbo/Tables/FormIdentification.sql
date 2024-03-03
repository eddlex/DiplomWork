﻿CREATE TABLE FormIdentification
(
    Id             UNIQUEIDENTIFIER DEFAULT NEWID(),
    FormId         INT NOT NULL,
    GroupId        INT NOT NULL,
    RecipientId    INT NOT NULL,
    Status         INT NOT NULL,
    LastUpdateTime DATETIME2(7) NOT NULL,
    CreationTime   DATETIME2(7) DEFAULT  GETUTCDATE(),
);





