CREATE PROCEDURE spDeleteSmtpConfiguration
@Id INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        DELETE SmtpConfigurations
        WHERE Id = @Id
        
        SELECT @Id
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END