CREATE   PROCEDURE spGetPermission
    @PermissionId  int = null
AS
BEGIN
    SELECT *
    FROM [User]
END