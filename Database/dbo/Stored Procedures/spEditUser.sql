CREATE    PROCEDURE spEditUser
    @Id INT,
    @UserName VARCHAR(50),
    @Email VARCHAR(100),
    @DepartmentId INT,
    @RoleId INT,
    @CreationDate datetime2,
    @UpdateDate datetime2

AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        UPDATE  [User]
        SET UserName = @UserName,
            Email = @Email,
            DepartmentId = @DepartmentId,
            RoleId = @RoleId,
            CreationDate = @CreationDate,
            UpdateDate = @UpdateDate
        WHERE Id = @Id
        COMMIT;

        SELECT [Id],
               [UserName],
               [Email],
               [DepartmentId],
               [RoleId],
               [CreationDate],
               [UpdateDate]
        FROM [User]
        WHERE Id = @Id

    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @errorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
        THROW 500000, @errorMessage, 1;
    END CATCH;
END

