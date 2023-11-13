CREATE PROCEDURE spLogIn
    @LogIn  VARCHAR (50),
    @Password NVARCHAR (500)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        SELECT u.Id,
               u.UserName,
               u.Email,
               u.Phone,
               u.UniversityId,
               uf.FirstName,
               uf.LastName,
               uf.BirthDate,
               uf.EmailIsVerified,
               uf.PhoneIsVerified
        FROM Users u JOIN UserInfo uf on u.Id = uf.UserId
        WHERE @LogIn In (u.Username, u.Phone, u.Email)
            AND u.Password = HASHBYTES('SHA2_512', @Password + u.Salt)

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END