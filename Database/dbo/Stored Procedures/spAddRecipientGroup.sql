CREATE or alter PROCEDURE spAddRecipientGroup
@Name NVARCHAR(50),
@Description NVARCHAR(MAX),
@DepartmentId INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        INSERT INTO  RecipientGroup (Name, Description, DepartmentId)
        VALUES (@Name, @Description, @DepartmentId)


        SELECT [Id],
               [Name],
               [Description],
               [DepartmentId]
        FROM RecipientGroup
        WHERE Id = @@IDENTITY
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END
