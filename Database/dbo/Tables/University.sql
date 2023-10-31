﻿CREATE TABLE [dbo].[University] (
    [Id]          BIGINT         NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);
