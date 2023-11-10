CREATE PROCEDURE [dbo].[spGetSmtpConfigurations]
	@Id INT
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
		Id = @Id
END