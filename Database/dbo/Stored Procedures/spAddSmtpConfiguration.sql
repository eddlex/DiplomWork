CREATE PROCEDURE spAddSmtpConfiguration
@DepartmentId INT,
@SmtpServer NVARCHAR(225),
@Port INT,
@UserName NVARCHAR(100),
@Password NVARCHAR(100),
@EnableSSL BIT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;

        INSERT INTO  SmtpConfigurations (DepartmentId, SmtpServer, Port, UserName, Password, EnableSSL)
        VALUES (@DepartmentId, @SmtpServer, @Port, @UserName, @Password, @EnableSSL)
    
        SELECT  [Id],
                [DepartmentId],
                [SmtpServer],
                [Port],
                [UserName],   
                [Password], 
                [EnableSSL]
        FROM SmtpConfigurations
        WHERE Id = @@IDENTITY
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END