CREATE PROCEDURE [dbo].[spGetForms]
	@GroupId  int = 0
AS
BEGIN
	SELECT f.Id Id,
		   f.GroupId GroupId,
		   fr.Id RowId,
		   fr.Name RowName,
		   fr.Value RowValue
	FROM FormRow fr JOIN Form f ON f.Id = fr.FormId AND f.GroupId = @GroupId
END

