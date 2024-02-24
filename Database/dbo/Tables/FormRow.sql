CREATE TABLE [dbo].[FormRow] (
    [Id]        INT             IDENTITY (0, 1) NOT NULL,
    [FormId]    INT             NULL,
    [Query]     NVARCHAR (150)  NOT NULL,
    [Required]  BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id])
);

