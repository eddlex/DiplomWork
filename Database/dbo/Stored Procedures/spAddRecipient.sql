﻿CREATE PROCEDURE spAddRecipient
@Name NVARCHAR(50),
@Mail NVARCHAR(50),
@GroupId INT,
@DepartmentId INT,
@Description NVARCHAR(MAX),
@WeightId INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        INSERT INTO  Recipient (Name, Mail, GroupId, DepartmentId, Description, WeightId)
        VALUES (@Name, @Mail, @GroupId, @DepartmentId, @Description, @WeightId)
        
        
        SELECT [Id], 
               [Name],
               [Mail],
               [GroupId],
               [DepartmentId], 
               [Description],
               [WeightId]
        FROM Recipient
        WHERE Id = @@IDENTITY
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END