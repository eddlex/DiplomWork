CREATE   PROCEDURE spGetPermission
    @PermissionId  int = null
AS
BEGIN
    SELECT pr.Permission
    FROM Users us JOIN Permission pr ON us.PermissionId = pr.Id AND us.PermissionId = @PermissionId
END