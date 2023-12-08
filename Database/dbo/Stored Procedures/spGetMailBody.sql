CREATE    PROCEDURE spGetMailBody
@UniversityId INT
AS
BEGIN
    SELECT Id           [Id],
           Name         [Name],
           Subject      [Subject],
           Body         [Body],
           UniversityId [UniversityId]
    FROM MailBody WITH (NOLOCK)
    WHERE (@UniversityId = 0 OR UniversityId = @UniversityId)
END