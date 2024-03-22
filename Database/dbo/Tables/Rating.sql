CREATE TABLE Rating (
    [Id] INT PRIMARY KEY IDENTITY(0,1),
    [FormIdentificationId] INT NOT NULL,
    [FormRowId] INT NOT NULL,
	[Value] DECIMAL NOT NULL,
    [LastUpdateDate] DATETIME2(7) NOT NULL,
    [CreationDate] DATETIME2(7) NOT NULL,
	FOREIGN KEY ([FormIdentificationId]) REFERENCES FormIdentification([Id])
)
GO

create unique index Rating_FormIdentificationId_uindex
    on Rating (FormIdentificationId)
go


