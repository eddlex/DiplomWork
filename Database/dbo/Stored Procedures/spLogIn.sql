CREATE PROCEDURE spLogIn
    @LogIn  VARCHAR (50),
    @Password NVARCHAR (500)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS(SELECT *
                  FROM Users u
                  WHERE @LogIn In (u.Username, u.Phone, u.Email) AND u.Password = HASHBYTES('SHA2_512', @Password + u.Salt))
        BEGIN
            SELECT  1
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