CREATE PROCEDURE  spGetUniversities
AS
BEGIN
    SELECT u.Id Id,
           u.Name Name,
           u.Description Description
    FROM University u
END