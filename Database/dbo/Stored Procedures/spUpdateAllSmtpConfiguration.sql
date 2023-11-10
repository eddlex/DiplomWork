CREATE PROCEDURE [dbo].[spUpdateAllSmtpConfiguration]
    @ConfigId INT,
    @NewSmtpServer NVARCHAR(255),
    @NewPort INT,
    @NewUsername NVARCHAR(100),
    @NewPassword NVARCHAR(100),
    @NewEnableSSL BIT
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
			UPDATE SmtpConfigurations
			SET
				[SmtpServer] = @NewSmtpServer,
				[Port] = @NewPort,
				[Username] = @NewUsername,
				[Password] = @NewPassword,
				[EnableSSL] = @NewEnableSSL
			WHERE
				Id = @ConfigId
		COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END