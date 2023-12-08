﻿CREATE PROCEDURE spDelMailBody
@Id INT
AS
BEGIN
   BEGIN TRY
    BEGIN TRANSACTION;
        DELETE MailBody
        WHERE  Id = @Id
    COMMIT;
   END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
END