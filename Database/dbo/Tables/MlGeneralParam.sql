CREATE TABLE MlGeneralParam
(
    Id              INT IDENTITY (0, 1) NOT NULL    PRIMARY KEY,
    DepartmentId    INT                 NOT NULL    FOREIGN KEY REFERENCES Department(Id),
    B               DECIMAL             NOT NULL,
    LastUpdateDate  DATETIME2(7)        NOT NULL    DEFAULT GETUTCDATE(),
    CreationDate    DATETIME2(7)        NOT NULL    DEFAULT GETUTCDATE()
)

GO
CREATE UNIQUE INDEX  MlGeneralParam_DepartmentId ON MlGeneralParam(DepartmentId)
