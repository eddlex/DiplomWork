CREATE PROCEDURE [dbo].[spDeleteRecipientGroup]
@Id INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        DELETE RecipientGroup
        WHERE Id = @Id

        SELECT @Id
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;

    IF EXISTS (SELECT 1 FROM Recipient WHERE GroupId = @Id)
    BEGIN
        THROW 50011, '', 1;
    END
    ELSE
    BEGIN
         DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
         THROW 50000, @errorMessage, 1;
    END


END CATCH;
END
