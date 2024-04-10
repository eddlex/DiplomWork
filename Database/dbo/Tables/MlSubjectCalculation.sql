CREATE TABLE MlSubjectCalculation
(
    Id              INT IDENTITY (0, 1) NOT NULL    PRIMARY KEY,
    SubjectId       INT                 NOT NULL    FOREIGN KEY REFERENCES Subject(Id),
    Actual          DECIMAL             NOT NULL,
    Predicted       DECIMAL             NOT NULL,
    Action          NVARCHAR(200)       NOT NULL,
    CreationDate    DATETIME2(7)        NOT NULL    DEFAULT GETUTCDATE()
)
