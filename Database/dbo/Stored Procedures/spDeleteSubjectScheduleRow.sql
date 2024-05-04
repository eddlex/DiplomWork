CREATE   PROCEDURE [dbo].[spDeleteSubjectScheduleRow]
@ScheduleId INT,
@SubjectId INT
AS
BEGIN

    DELETE ScheduleRow
    WHERE ScheduleId = @ScheduleId AND SubjectId = @SubjectId

    SELECT @@ROWCOUNT
END
go
