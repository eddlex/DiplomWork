CREATE    PROCEDURE [dbo].[spGetSubjectsSchedulesCalculations]
@RoleId INT,
@DepartmentId INT
AS
BEGIN
   SELECT [Id],
          DepartmentId,
          Semester,
          [Name],
          [Hours]
   FROM Schedule
   WHERE @RoleId = 2 OR (@RoleId < 2 AND DepartmentId = @DepartmentId)
END
go

