CREATE PROCEDURE spAddRecipient
@Name NVARCHAR(50),
@Mail NVARCHAR(50),
@GroupId INT,
@DepartmentId INT,
@Description NVARCHAR(MAX)
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        INSERT INTO  Recipient (Name, Mail, GroupId, DepartmentId, Description)
        VALUES (@Name, @Mail, @GroupId, @DepartmentId, @Description)
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END