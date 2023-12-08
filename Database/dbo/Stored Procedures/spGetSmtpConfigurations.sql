CREATE PROCEDURE [dbo].[spGetSmtpConfigurations]
	@UniversityId INT
AS
BEGIN
    SELECT
        [SmtpServer],
        [Port],
        [UserName],
        [Password],
        [EnableSSL]
    FROM
        SmtpConfigurations
	WHERE
		(UniversityId = @UniversityId OR @UniversityId = 0)
END