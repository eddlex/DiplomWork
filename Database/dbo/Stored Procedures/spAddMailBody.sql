CREATE PROCEDURE spAddMailBody
@Name NVARCHAR(100),
@Subject NVARCHAR(150),
@Body    NVARCHAR(MAX),
@DepartmentId INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        INSERT INTO  MailBody (Name, Subject, Body, DepartmentId)
        VALUES (@Name, @Subject, @Body, @DepartmentId)

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
END