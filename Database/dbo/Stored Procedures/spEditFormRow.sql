CREATE PROCEDURE [dbo].[spEditFormRow]
@Id       INT,
@FormId   INT,
@Query    NVARCHAR(150),
@Required BIT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        IF EXISTS(SELECT 1 FROM FormRow WHERE Id = @Id AND @FormId = FormId)
        BEGIN
            UPDATE FormRow
            SET Query = @Query,
                Required = @Required
            WHERE Id = @Id AND @FormId = FormId

            SELECT Id,
                   FormId,
                   Query,
                   Required
            FROM FormRow
            WHERE Id = @Id AND @FormId = FormId

        END
        ELSE
        BEGIN
            INSERT  INTO FormRow(FormId, Query, Required)
            VALUES (@FormId, @Query, @Required)

            SELECT Id,
                   FormId,
                   Query,
                   Required
            FROM FormRow
            WHERE Id = @@IDENTITY AND @FormId = FormId
        END

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END


select  *
from FormRow