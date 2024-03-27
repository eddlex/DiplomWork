CREATE PROCEDURE [dbo].[spAddFormIdentification]
@FormId INT,
@GroupId INT,
@RecipientId INT,
@ExpirationTime DATETIME2(7)
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;
        INSERT INTO  FormIdentification (FormId, GroupId, RecipientId, Status, ExpirationTime, LastUpdateTime)
        VALUES (@FormId, @GroupId, @RecipientId, 0, @ExpirationTime, GETUTCDATE())

        SELECT GuId FROM FormIdentification WHERE Id = @@IDENTITY
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END