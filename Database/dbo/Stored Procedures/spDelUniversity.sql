CREATE   PROCEDURE  spDelUniversity
    @Id BIGINT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

            DELETE u
            FROM University u
            WHERE u.Id = @Id
            IF(@@ROWCOUNT IS NOT NULL AND  @@ROWCOUNT != 0)
            BEGIN
                UPDATE University
                SET Id = Id / 2
                WHERE  @Id < Id
            END
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END