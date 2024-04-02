CREATE  PROCEDURE  spEditDepartment
    @Id INT,
    @Name NVARCHAR(50),
    @Description NVARCHAR(100) = NULL
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE  Department 
        SET Name = @Name,
            Description = @Description
        WHERE Id = @Id
        COMMIT
        
        IF @@ROWCOUNT = 1
            BEGIN
            SELECT Id,
                   Name,
                   Description
            FROM Department WHERE Id = @Id
        END
        END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END
