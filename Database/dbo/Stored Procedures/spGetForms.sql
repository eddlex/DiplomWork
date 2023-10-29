CREATE PROCEDURE [dbo].[spGetForms]
@GroupId  int = null
AS
BEGIN
    SELECT f.Id Id,
           f.GroupId GroupId,
           fr.Id RowId,
           fr.Name RowName,
           fr.Value RowValue
    FROM FormRow fr JOIN Form f ON f.Id = fr.FormId AND @GroupId IS NULL OR f.GroupId = @GroupId
END