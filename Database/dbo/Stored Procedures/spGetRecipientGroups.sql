CREATE   PROCEDURE spGetRecipientGroups
    @DepartmentId INT,
    @RoleId INT,
    @Id INT = NULL
AS
BEGIN
    SELECT  Id [Id],
            Name [Name],
            DepartmentId [DepartmentId],
            Description [Description]
    FROM RecipientGroup
    WHERE (@Id IS NULL OR Id = @Id)
        AND @RoleId = 2 OR (RecipientGroup.DepartmentId = @DepartmentId)
END
go