CREATE PROCEDURE [dbo].[spAddFormRow]
@FormId       INT,
@SubjectId    INT,
@Order        BIT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        IF NOT  EXISTS(SELECT 1 FROM FormRow WHERE @FormId = FormId AND @SubjectId = SubjectId)
        BEGIN
            INSERT  INTO FormRow(FormId, SubjectId, [Order])
            VALUES (@FormId, @SubjectId, @Order)

            SELECT Id,
                   FormId,
                   SubjectId,
                   [Order]
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


