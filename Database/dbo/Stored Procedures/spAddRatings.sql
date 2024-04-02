CREATE PROCEDURE [dbo].[spAddRatings]
    @FormIdentificationId INT,
    @Ratings RatingType READONLY
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

            DECLARE @CurrentDate DATETIME2(7) = GETUTCDATE()
            
            INSERT INTO Rating(FormIdentificationId, FormRowId , Value, LastUpdateDate, CreationDate)
            SELECT @FormIdentificationId, r.FormRowId, r.Value, @CurrentDate, @CurrentDate
            FROM @Ratings r where r.Id = -1

            UPDATE r
            SET r.Value = tmp.Value
            FROM Rating r JOIN @Ratings tmp ON r.Id = tmp.Id AND r.Id <> -1
            
            If @@ROWCOUNT > 0 OR @@IDENTITY > 0
                SELECT 1
            ELSE
                SELECT 0

        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
        DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
        THROW 500000, @errorMessage, 1
    END CATCH
END