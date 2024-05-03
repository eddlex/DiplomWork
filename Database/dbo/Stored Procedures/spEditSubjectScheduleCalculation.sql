 CREATE    PROCEDURE [dbo].[spEditSubjectScheduleCalculation]
 @Id INT,
 @DepartmentId INT,
 @Semester TINYINT,
 @Hours    DECIMAL,
 @Name     NVARCHAR(50)
 AS
 BEGIN
    UPDATE  Schedule
    SET DepartmentId = @DepartmentId,
        Semester = @Semester,
        [Hours] = @Hours,
        [Name] = @Name,
        LastUpdateDate = GETUTCDATE() 
     WHERE Id = @Id
 
     SELECT Id,
            DepartmentId,
            Semester,
            [Hours],
            [Name],
            LastUpdateDate,
            CreationDate
     FROM Schedule
     WHERE Id = @Id
 END
 go
