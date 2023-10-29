CREATE PROCEDURE spDelRecipientGroups
@Ides dbo.Ides READONLY
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

    IF ((SELECT COUNT(*) FROM @Ides ides) = (SELECT COUNT(*)
                                             FROM RecipientGroup rg JOIN
                                             @Ides ides ON rg.Id = ides.Id))

    BEGIN
        DELETE rg
        FROM RecipientGroup rg JOIN @Ides ides ON rg.Id = ides.Id
    END
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
END