CREATE   PROCEDURE spGetRecipientGroups
    @Id INT = NULL
AS
BEGIN
    SELECT  Id Id,
            Name Name,
            Description Description
    FROM RecipientGroup
    WHERE @Id IS NULL OR Id = @Id
END