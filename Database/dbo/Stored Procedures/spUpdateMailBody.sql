CREATE PROCEDURE spUpdateMailBody
@Id INT,
@Name NVARCHAR(100),
@Subject NVARCHAR(150),
@Body    NVARCHAR(MAX),
@DepartmentId INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;
        UPDATE MailBody
        SET Name = @Name,
            Subject = @Subject,
            Body = @Body,
            DepartmentId = @DepartmentId
        WHERE Id = @Id
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
END