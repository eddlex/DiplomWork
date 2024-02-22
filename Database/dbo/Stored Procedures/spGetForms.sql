CREATE PROCEDURE [dbo].[spGetForms]
@RoleId INT,
@DepartmentId INT
AS
BEGIN
   SELECT [Id],
          [GroupId],
          [Name],
          [DepartmentId],
          [Description]
   FROM Form
   WHERE @RoleId = 2 OR (@RoleId < 2 AND DepartmentId = @DepartmentId)
END

--     SELECT f.Id Id,
--            f.GroupId GroupId,
--            fr.Id RowId,
--            fr.Name RowName,
--            fr.Value RowValue
--     FROM FormRow fr JOIN Form f ON f.Id = fr.FormId AND @GroupId IS NULL OR f.GroupId = @GroupId