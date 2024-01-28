CREATE or alter  PROCEDURE spRegister
    @UserName  VARCHAR (50),
    @Email     VARCHAR (50),
    @Password NVARCHAR (500),
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

            DECLARE @Salt  NVARCHAR(MAX) = (SELECT ABS(CHECKSUM(NEWID())))
            INSERT INTO [User] (Username, Email, Phone, Password, Salt, UniversityId)
            VALUES (@UserName, @Email, '', HASHBYTES('SHA2_512', @Password + @Salt) , @Salt, 0)

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