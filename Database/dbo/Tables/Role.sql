CREATE TABLE [dbo].[Role]
(
    [Id]      INT IDENTITY (0, 1) NOT NULL,
    [Name]    VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

-- 
-- INSERT INTO Role ( Name)
-- VALUES ('User')
-- INSERT INTO Role ( Name)
-- VALUES ('Admin')
-- INSERT INTO Role ( Name)
-- VALUES ('SupperAdmin')