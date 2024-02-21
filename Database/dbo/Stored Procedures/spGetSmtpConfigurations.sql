CREATE PROCEDURE [dbo].[spGetSmtpConfigurations]
    @RoleId INT,
    @DepartmentId INT
AS
BEGIN
    SELECT [Id],
           [DepartmentId],
           [SmtpServer],
           [Port],
           [UserName],
           [Password],
           [EnableSSL]
    FROM SmtpConfigurations
    WHERE @RoleId = 2 OR (@RoleId < 2 AND @DepartmentId = DepartmentId)
END
go

