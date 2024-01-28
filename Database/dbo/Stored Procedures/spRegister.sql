CREATE or alter  PROCEDURE spRegister
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
            INSERT INTO [User] (Username, Email, Phone, Password, Salt, UniversityId)
            VALUES (@UserName, @Email, @Phone, HASHBYTES('SHA2_512', @Password + @Salt) , @Salt, @UniversityId)

--          INSERT INTO UsersInfo (UserId)
--             VALUES (@@IDENTITY)
            RETURN 1
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;

        IF EXISTS(SELECT 1 FROM [User] WHERE UserName = @UserName)
        BEGIN
            THROW 50001, 'UserName already exits!', 1
        END
        ELSE IF EXISTS(SELECT 1 FROM [User] WHERE UserName = @UserName)
        BEGIN
              THROW 50001, 'Email already exits!', 1
        END
--         ELSE
--         BEGIN
--          THROW ERROR_NUMBER(), ERROR_MESSAGE(), 1
--         END

    END CATCH;
END