CREATE   PROCEDURE [dbo].[spGetSubjectScheduleRows]
@Id INT
AS
BEGIN
   SELECT Id,
          ScheduleId,
          SubjectId,
          CalculatedHours
   FROM ScheduleRow
   WHERE ScheduleId = @Id
END
go