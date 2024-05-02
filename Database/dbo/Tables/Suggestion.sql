create table Suggestion
(
    Id int identity (0, 1)  primary key,
    FormIdentificationId int not null references FormIdentification,
    Value nvarchar(250)
)
