CREATE  PROCEDURE spEditRecipientGroup
    @Id INT,
    @Name NVARCHAR(50),
    @DepartmentId INT,
    @Description NVARCHAR(MAX)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE  RecipientGroup
        SET Name = @Name,
            DepartmentId = @DepartmentId,
            Description = @Description
        WHERE Id = @Id
        COMMIT;

        SELECT [Id],
               [Name],
               [DepartmentId],
               [Description]
        FROM RecipientGroup
        WHERE Id = @Id

    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
        THROW 500000, @errorMessage, 1;
    END CATCH;
END