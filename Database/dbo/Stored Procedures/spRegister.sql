CREATE   PROCEDURE spRegister
    @UserName  VARCHAR (50),
    @Email     VARCHAR (50),
    @Password NVARCHAR (500),
    @UniversityId INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Salt  NVARCHAR(MAX) = (SELECT ABS(CHECKSUM(NEWID())))
        INSERT INTO [User] (Username, Email, Phone, Password, Salt, UniversityId)
        VALUES (@UserName, @Email, '', HASHBYTES('SHA2_512', @Password + @Salt) , @Salt,  @UniversityId)

        INSERT INTO UserInfo (UserId)
        VALUES (@@IDENTITY)

        COMMIT
        SELECT 1
    END TRY
    BEGIN CATCH
        ROLLBACK;

        IF EXISTS(SELECT 1 FROM [User] WHERE UserName = @UserName)
            BEGIN
                THROW 50001, 'UserName already exits!', 1
            END
        ELSE IF EXISTS(SELECT 1 FROM [User] WHERE UserName = @UserName)
            BEGIN
                THROW 50002, 'Email already exits!', 1
            END
        ELSE
            BEGIN
                DECLARE @errorCode INT = ERROR_NUMBER();
                DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
                THROW @errorCode, @errorMessage, 1;
            END

    END CATCH;
END