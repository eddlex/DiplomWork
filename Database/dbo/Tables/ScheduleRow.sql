CREATE TABLE ScheduleRow
(
    Id INT IDENTITY(0, 1) PRIMARY KEY  NOT NULl,
    ScheduleId INT FOREIGN KEY REFERENCES Schedule(Id),
    SubjectId INT FOREIGN KEY REFERENCES  Subject(Id),
    CalculatedHours DECIMAL NULL,
    CreationDate DATETIME2(7) DEFAULT  GETUTCDATE(),
)

GO 
CREATE INDEX UNIQUE_INDEX_ScheduleRow__ScheduleId__SubjectId
    ON ScheduleRow (ScheduleId, SubjectId)
GO