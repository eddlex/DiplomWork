CREATE PROCEDURE [dbo].[spGetFormRows]
@Id INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;
    SELECT [Id],
           [FormId],
           [SubjectId],
           [Order]
    FROM FormRow
    WHERE FormId = @Id
    ORDER BY [Order] ASC, CreationDate DESC    
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END