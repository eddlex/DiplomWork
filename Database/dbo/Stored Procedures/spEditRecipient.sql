CREATE PROCEDURE spEditRecipient
    @Id INT,
    @Name NVARCHAR(50),
    @Mail NVARCHAR(50),
    @GroupId INT,
    @DepartmentId INT,
    @Description NVARCHAR(MAX),
    @WeightId INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        UPDATE  Recipient
        SET Name = @Name,
            Mail = @Mail,
            GroupId = @GroupId,
            DepartmentId = @DepartmentId,
            Description = @Description,
            WeightId = @WeightId
        WHERE Id = @Id
        COMMIT;

        SELECT [Id],
               [Name],
               [Mail],
               [GroupId],
               [DepartmentId],
               [Description],
               [WeightId]
        FROM Recipient
        WHERE Id = @Id

    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
        THROW 500000, @errorMessage, 1;
    END CATCH;
END