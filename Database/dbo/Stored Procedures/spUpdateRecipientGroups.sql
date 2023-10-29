CREATE PROCEDURE spUpdateRecipientGroups
@Groups dbo.IntStringStringTriple READONLY
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

    IF ((SELECT COUNT(*) FROM @Groups g) = (SELECT COUNT(*)
                                             FROM RecipientGroup rg JOIN
                                             @Groups g ON rg.Id = g.Item1))

    BEGIN
        UPDATE rg
        SET rg.Name = g.Item2,
            rg.Description = g.Item3
        FROM RecipientGroup rg JOIN @Groups g ON rg.Id = g.Item1
    END
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
END