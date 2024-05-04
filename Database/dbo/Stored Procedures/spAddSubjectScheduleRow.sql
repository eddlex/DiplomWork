CREATE   PROCEDURE [dbo].[spAddSubjectScheduleRow]
@ScheduleId INT,
@SubjectId INT
AS
BEGIN

    INSERT INTO  ScheduleRow(ScheduleId, SubjectId)
    VALUES (@ScheduleId, @SubjectId)

    SELECT  Id,
            ScheduleId,
            SubjectId,
            CalculatedHours
    FROM ScheduleRow WHERE Id = @@IDENTITY
END
go
