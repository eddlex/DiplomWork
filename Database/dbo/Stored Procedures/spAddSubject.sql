CREATE  PROCEDURE  spAddSubject
    @Title NVARCHAR(200),
    @Outcome NVARCHAR(500),
    @OutcomeTypeId INT,
    @DepartmentId INT,
    @HoursPerSem INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        INSERT INTO  Subject (Title, Outcome, OutcomeTypeId, DepartmentId, HoursPerSem)
        VALUES (@Title, @Outcome, @OutcomeTypeId, @DepartmentId, @HoursPerSem)
        COMMIT

        SELECT Id,
               Title,
               Outcome,
               OutcomeTypeId,
               DepartmentId,
               HoursPerSem,
               SuggestedHours
        FROM Subject WHERE Id = @@IDENTITY
    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END
go

