CREATE PROCEDURE [dbo].[spUpdateSmtpConfiguration]
    @Id INT,
    @UniversityId INT,
    @SmtpServer NVARCHAR(255),
    @Port INT,
    @Username NVARCHAR(100),
    @Password NVARCHAR(100),
    @EnableSSL BIT
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
			UPDATE SmtpConfigurations
			SET
				[SmtpServer] = @SmtpServer,
				[UniversityId] = @UniversityId,
				[Port] = @Port,
				[Username] = @Username,
				[Password] = @Password,
				[EnableSSL] = @EnableSSL
			WHERE
				Id = @Id
		COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END