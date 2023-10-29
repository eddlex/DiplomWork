CREATE PROCEDURE spAddRecipientGroups
@Items dbo.StringTuple READONLY
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO RecipientGroup (Name, Description)
    SELECT i.Item1, i.Item2
    FROM @Items i
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
END