CREATE TABLE Subject(
	[Id] INT PRIMARY KEY IDENTITY(0,1),
	[Title] NVARCHAR(200),
	[Outcome] NVARCHAR(500),
	[OutcomeTypeId] INT,
	[DepartmentId] INT,
	[HoursPerSem] INT NULL, 
    [SuggestedHours] FLOAT NULL, 
    FOREIGN KEY ([OutcomeTypeId]) REFERENCES OutcomeTypes([Id]),
	FOREIGN KEY ([DepartmentId]) REFERENCES Department([Id])
)