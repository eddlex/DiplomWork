CREATE    PROCEDURE  spAddDepartment
    @Name NVARCHAR(50),
    @Description NVARCHAR(100) = NULL
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

            --DECLARE @Id BIGINT = POWER(2, (SELECT COUNT(*) - 1 FROM University))

--             INSERT INTO  University (Id, Name, Description)
--             VALUES (@Id, @Name, @Description)
               INSERT INTO  Department (Name, Description)
               VALUES (@Name, @Description)

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END