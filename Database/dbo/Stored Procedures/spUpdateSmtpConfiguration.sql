CREATE PROCEDURE [dbo].[spUpdateSmtpConfiguration]
    @Id INT,
    @DepartmentId INT,
    @SmtpServer NVARCHAR(255),
    @Port INT,
    @UserName NVARCHAR(100),
    @Password NVARCHAR(100),
    @EnableSSL BIT
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
			UPDATE SmtpConfigurations
			SET
				[SmtpServer] = @SmtpServer,
				[DepartmentId] = @DepartmentId,
				[Port] = @Port,
				[UserName] = @UserName,
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