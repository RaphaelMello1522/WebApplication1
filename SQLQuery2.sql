create table Usuario(
Id int primary key identity,
nome varchar(250) not null,
setor varchar(250) not null,
Id_computador int foreign key references Computadores(Id_computador)
)