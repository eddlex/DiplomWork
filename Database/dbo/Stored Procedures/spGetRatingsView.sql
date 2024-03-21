CREATE  PROCEDURE  spGetRatingsView
@Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT fi.Id,
           fi.FormId,
           fr.Id FormRowId,
           s.Title,
           s.Outcome
    FROM FormIdentification fi JOIN FormRow fr ON fr.FormId = fi.FormId AND fi.GuId = @Id AND fi.Status = 0
         JOIN Subject s ON s.Id = fr.SubjectId
END
