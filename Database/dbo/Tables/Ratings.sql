CREATE TABLE Ratings (
    [Id] INT PRIMARY KEY IDENTITY(0,1),
    [SubjectId] INT NOT NULL,
	[Rating] FLOAT NOT NULL,
	[GroupWeight] INT NOT NULL,
	FOREIGN KEY ([SubjectId]) REFERENCES Subjects([Id]),
	FOREIGN KEY ([GroupWeight]) REFERENCES Weights([Id])
)
