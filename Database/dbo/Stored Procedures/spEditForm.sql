CREATE PROCEDURE [dbo].[spEditForm]
@Id INT,
@GroupId INT,
@Name NVARCHAR(50),
@DepartmentId INT,
@Description NVARCHAR(MAX)
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        UPDATE Form 
        SET GroupId = @GroupId, 
            Name = @Name,
            DepartmentId = @DepartmentId,
            Description = @Description
        WHERE Id = @Id
        
        SELECT [Id],
               [GroupId],
               [Name],
               [DepartmentId],
               [Description]
        FROM Form
        WHERE Id = @Id
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END
