CREATE PROCEDURE spEditSmtpConfiguration
@Id INT,
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

        UPDATE SmtpConfigurations
        SET DepartmentId = @DepartmentId,
            SmtpServer = @SmtpServer, 
            Port = @Port, 
            UserName = @UserName,
            Password = @Password ,
            EnableSSL = @EnableSSL
        WHERE Id = @Id
    
        SELECT  [Id],
                [DepartmentId],
                [SmtpServer],
                [Port],
                [UserName],   
                [Password], 
                [EnableSSL]
        FROM SmtpConfigurations
        WHERE Id = @Id
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
    THROW 500000, @errorMessage, 1;
END CATCH;
END