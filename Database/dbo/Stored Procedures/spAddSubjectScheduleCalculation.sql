CREATE    PROCEDURE [dbo].[spAddSubjectScheduleCalculation]
@DepartmentId INT,
@Semester TINYINT,
@Hours    DECIMAL,
@Name     NVARCHAR(50)
AS
BEGIN
   INSERT INTO Schedule(DepartmentId, Semester, Hours, Name) 
    VALUES (@DepartmentId, @Semester, @Hours, @Name)

    SELECT Id,
           DepartmentId,
           Semester,
           Hours,
           Name,
           LastUpdateDate,
           CreationDate
    FROM Schedule
    WHERE Id = @@IDENTITY
END
go
