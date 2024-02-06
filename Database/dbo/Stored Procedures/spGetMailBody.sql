CREATE    PROCEDURE spGetMailBody
@DepartmentId INT
AS
BEGIN
    SELECT Id           [Id],
           Name         [Name],
           Subject      [Subject],
           Body         [Body],
           DepartmentId [DepartmentId]
    FROM MailBody WITH (NOLOCK)
    WHERE (@DepartmentId = 0 OR DepartmentId = @DepartmentId)
END