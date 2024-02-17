CREATE  PROCEDURE  spGetRecipients
@RoleId INT,
@DepartmentId INT
AS
BEGIN
    SELECT Id           [Id],
           GroupId      [Groupid],
           Mail         [Mail],
           Name         [Name],
           Description  [Description],
           DepartmentId [DepartmentId]
    FROM Recipient
    WHERE  @RoleId = 2 OR (@RoleId IN (0, 1) AND DepartmentId = @DepartmentId)
END