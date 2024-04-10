CREATE TABLE MlParamB
(
    Id                INT IDENTITY (0, 1) NOT NULL    PRIMARY KEY,
    MlGeneralParamId  INT                 NOT NULL    FOREIGN KEY REFERENCES MlGeneralParam(Id),
    B                 DECIMAL             NOT NULL,
    LastUpdateDate    DATETIME2(7)        NOT NULL    DEFAULT GETUTCDATE(),
    CreationDate      DATETIME2(7)        NOT NULL    DEFAULT GETUTCDATE()
)
GO
CREATE UNIQUE INDEX  MlParamB_MlGeneralParamId ON MlParamB(MlGeneralParamId)
go