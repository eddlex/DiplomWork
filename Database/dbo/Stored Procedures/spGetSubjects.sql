CREATE  PROCEDURE  spGetSubjects
@RoleId INT,
@DepartmentId INT
AS
BEGIN
    SELECT Id
          ,Title
          ,Outcome
          ,OutcomeTypeId
          ,DepartmentId
    FROM [Subject]
    WHERE DepartmentId = @DepartmentId
 --   WHERE  @RoleId = 2 OR (@RoleId IN (0, 1) AND DepartmentId = @DepartmentId)
END
