CREATE PROCEDURE [dbo].[spDeleteSmtpConfigurations]
    @ConfigId INT
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
			DELETE FROM
				SmtpConfigurations
			WHERE
				Id = @ConfigId
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END