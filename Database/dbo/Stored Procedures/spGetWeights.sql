CREATE PROCEDURE  spGetWeights
AS
BEGIN
    SELECT w.Id Id,
           w.Name [Name],
           w.Weight [Weight]
    FROM Weight w
END