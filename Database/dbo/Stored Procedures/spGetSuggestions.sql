CREATE PROCEDURE  spGetSuggestions
AS
BEGIN
    SELECT s.Id,
           s.FormIdentificationId,
           s.Value
    FROM Suggestion s
END


