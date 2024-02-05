CREATE  PROCEDURE  spGetUsers
@RoleId INT,
@DepartmentId INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;
        SELECT Id,
               UserName,
               Email,
               DepartmentId,
               RoleId,
               CreationDate,
               UpdateDate
        FROM [User] u
        WHERE (@RoleId in (0, 1) AND u.DepartmentId = @DepartmentId) OR @RoleId = 2
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
END
