CREATE PROCEDURE spEditSubject
    @Id INT,
    @Title NVARCHAR(200),
    @Outcome NVARCHAR(500),
    @OutcomeTypeId INT,
    @DepartmentId INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

            UPDATE  Subject
            SET Title = @Title,
                Outcome = @Outcome,
                OutcomeTypeId = @OutcomeTypeId,
                DepartmentId = @DepartmentId
            WHERE Id = @Id
        COMMIT

        SELECT Id,
               Title,
               Outcome,
               OutcomeTypeId,
               DepartmentId
        FROM Subject WHERE Id = @Id

    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
        THROW 500000, @errorMessage, 1;
    END CATCH;
END