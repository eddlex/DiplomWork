CREATE PROCEDURE [dbo].[spAddForm]
@GroupId INT,
@Name NVARCHAR(50),
@DepartmentId INT,
@Description NVARCHAR(MAX)
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        INSERT INTO  Form (GroupId, Name, DepartmentId, Description)
        VALUES (@GroupId, @Name, @DepartmentId, @Description)
        
        SELECT [Id],
               [GroupId],
               [Name],
               [DepartmentId],
               [Description]
        FROM Form
        WHERE Id = @@IDENTITY
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END
BEGIN
END