CREATE PROCEDURE [dbo].[spDelWeight]
@Id INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;
        DELETE Weight
        WHERE Id = @Id

        SELECT @Id
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    --IF EXISTS (SELECT 1 FROM Recipient WHERE WeightId = @Id)
    --BEGIN
    --    THROW 50014, '', 1;
    --END
    --ELSE
    --BEGIN
    --     DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    --     THROW 50000, @errorMessage, 1;
    --END
END CATCH;
END