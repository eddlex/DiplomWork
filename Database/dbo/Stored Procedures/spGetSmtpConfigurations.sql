CREATE PROCEDURE [dbo].[spGetSmtpConfigurations]
@DepartmentId INT
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
		(DepartmentId = @DepartmentId OR @DepartmentId = 0)
END