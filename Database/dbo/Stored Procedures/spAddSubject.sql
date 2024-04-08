CREATE  PROCEDURE  spAddSubject
    @Title NVARCHAR(200),
    @Outcome NVARCHAR(500),
    @OutcomeTypeId INT,
    @DepartmentId INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        INSERT INTO  Subject (Title, Outcome, OutcomeTypeId, DepartmentId)
        VALUES (@Title, @Outcome, @OutcomeTypeId, @DepartmentId)
        COMMIT

        SELECT Id,
               Title,
               Outcome,
               OutcomeTypeId,
               DepartmentId
        FROM Subject WHERE Id = @@IDENTITY
    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END
