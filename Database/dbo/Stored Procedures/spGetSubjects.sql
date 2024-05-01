CREATE PROCEDURE  spGetSubjects
    @RoleId INT,
    @DepartmentId INT
AS
BEGIN
    SELECT Id
         ,Title
         ,Outcome
         ,OutcomeTypeId
         ,DepartmentId
         ,HoursPerSem
         ,SuggestedHours
    FROM [Subject]
    WHERE (DepartmentId = @DepartmentId) OR @DepartmentId IS NULL
END


