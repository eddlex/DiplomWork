CREATE PROCEDURE spAddMailBody
@Name NVARCHAR(100),
@Subject NVARCHAR(150),
@Body    NVARCHAR(MAX),
@UniversityId INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        INSERT INTO  MailBody (Name, Subject, Body, UniversityId)
        VALUES (@Name, @Subject, @Body, @UniversityId)

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
END