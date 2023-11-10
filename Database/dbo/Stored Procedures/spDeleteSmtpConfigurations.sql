CREATE PROCEDURE [dbo].[spDeleteSmtpConfigurations]
    @Id INT
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
			DELETE FROM
				SmtpConfigurations
			WHERE
				Id = @Id
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END