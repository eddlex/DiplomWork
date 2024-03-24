CREATE PROCEDURE  spGetRatingsView
@Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT fi.FormId,
           fr.Id FormRowId,
           s.Title,
           s.Outcome,
           ISNULL(r.Id, 0) RatingId,
           ISNULL(r.Value, 0) RatingValue
    FROM FormIdentification fi JOIN FormRow fr ON fr.FormId = fi.FormId AND fi.GuId = @Id AND fi.Status = 0
         JOIN Subject s ON s.Id = fr.SubjectId
         LEFT JOIN Rating r ON r.FormRowId = fr.Id
END


