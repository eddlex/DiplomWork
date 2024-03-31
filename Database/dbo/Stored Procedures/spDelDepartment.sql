CREATE   PROCEDURE  spDelDepartment
    @Id BIGINT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

            DELETE u
            FROM Department u
            WHERE u.Id = @Id
            IF(@@ROWCOUNT IS NOT NULL AND  @@ROWCOUNT != 0)
            BEGIN
                SELECT 1
            END
            ELSE
            BEGIN
                SELECT 0
            END
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END