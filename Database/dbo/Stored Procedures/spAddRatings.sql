CREATE PROCEDURE [dbo].[spAddRatings]
    @FormIdentificationId INT,
    @Ratings RatingType READONLY
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

            DECLARE @CurrentDate DATETIME2(7) = GETUTCDATE()

            IF (SELECT ISNULL(COUNT(*), 0)
                FROM @Ratings r
                WHERE r.Id <> 0) =  0
                BEGIN
                    INSERT INTO Rating(FormIdentificationId, FormRowId , Value, LastUpdateDate, CreationDate)
                    SELECT @FormIdentificationId, r.FormRowId, r.Value, @CurrentDate, @CurrentDate
                    FROM @Ratings r where r.Id <> 0
                END
            ELSE
                BEGIN
                    UPDATE r
                    SET r.Value = tmp.Value
                    FROM Rating r JOIN @Ratings tmp ON r.Id = tmp.Id
                END
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
        DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
        THROW 500000, @errorMessage, 1
    END CATCH
END