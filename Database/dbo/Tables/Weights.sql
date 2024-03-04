CREATE TABLE Weights (
    [Id] INT PRIMARY KEY IDENTITY(0,1),
    [GroupId] INT not null,
	[Weight] FLOAT
	FOREIGN KEY ([groupId]) REFERENCES RecipientGroup([Id])
)