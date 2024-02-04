CREATE PROCEDURE  spGetUsers
@RoleId INT,
@UniversityId INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;
        SELECT Id,
               UserName,
               Email,
               UniversityId,
               RoleId,
               CreationDate,
               UpdateDate
        FROM [User] u
        WHERE (@RoleId in (0, 1) AND u.UniversityId = @UniversityId) OR @RoleId = 2
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
END
