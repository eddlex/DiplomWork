CREATE PROCEDURE  spGetDepartments
AS
BEGIN
    SELECT d.Id Id,
           d.Name [Name],
           d.Description [Description]
    FROM Department d
END