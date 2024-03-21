CREATE PROCEDURE [dbo].[spAddFormIdentification]
@FormId INT,
@GroupId INT,
@RecipientId INT,
@ExpirationTime DATETIME2(7)
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;
        DECLARE @GuId UNIQUEIDENTIFIER = NEWID()
        INSERT INTO  FormIdentification (GuId, FormId, GroupId, RecipientId, Status, ExpirationTime, LastUpdateTime)
        OUTPUT GuId
        VALUES (@GuId, @FormId, @GroupId, @RecipientId, 0, @ExpirationTime, GETUTCDATE())
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END