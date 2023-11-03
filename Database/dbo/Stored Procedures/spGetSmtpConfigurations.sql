--Creating sp to get config by ID
go
CREATE PROCEDURE [dbo].[spGetSmtpConfigurations]
	@ConfigId INT
AS
BEGIN
    SELECT
        [SmtpServer],
        [Port],
        [Username],
        [Password],
        [EnableSSL]
    FROM
        SmtpConfigurations
	WHERE
		Id = @ConfigId
END