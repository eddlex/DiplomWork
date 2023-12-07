CREATE PROCEDURE spRegister
    @UserName  VARCHAR (50),
    @Email     VARCHAR (50),
    @Phone     VARCHAR (50),
    @Password NVARCHAR (500),
    @UniversityId INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

            DECLARE @Salt  NVARCHAR(MAX) = (SELECT ABS(CHECKSUM(NEWID())))
            INSERT INTO Users (Username, Email, Phone, Password, Salt, UniversityId)
            VALUES (@UserName, @Email, @Phone, HASHBYTES('SHA2_512', @Password + @Salt) , @Salt, @UniversityId)

--             INSERT INTO UsersInfo (UserId)
--             VALUES (@@IDENTITY)
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END