CREATE  PROCEDURE  spAddDepartment
    @Name NVARCHAR(50),
    @Description NVARCHAR(100) = NULL
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        INSERT INTO  Department (Name, Description)
        VALUES (@Name, @Description)
        COMMIT
        
        SELECT Id,
               Name,
               Description
        FROM Department WHERE Id = @@IDENTITY
    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END
