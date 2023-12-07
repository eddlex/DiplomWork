CREATE    PROCEDURE  spGetRecipientsByGroupId
@GroupId INT,
@UniversityId INT
AS
BEGIN
    SELECT Id           [Id],
           Groupid      [Groupid],
           Mail         [Mail],
           Name         [Name],
           Description  [Description],
           UniversityId [UniversityId]
    FROM Recipient
    WHERE  GroupId = @GroupId AND UniversityId = @UniversityId
END