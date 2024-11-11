Use master
go
Create database StatusTurbo
go
Use StatusTurbo
go

Create table TarefaStatus(
 IdStatus int identity(1,1) primary key not null,
 DescricaoStatus varchar(250) not null,
)
go
Create table Usuario(
 IdUsuario int identity(1,1) primary key not null,
 LoginUsuario varchar(200) not null,
 SenhaUsuario varchar(max) not null
)
go
Create table Tarefa(
 IdTarefa int identity(1,1) primary key not null,
 DescricaoTarefa varchar(250) not null,
 DataTarefa datetime not null,
 IdStatus int,
 IdUsuario int,

 Constraint FK_StatusTarefa foreign key (IdStatus) references TarefaStatus(IdStatus),
 Constraint FK_UsuarioTarefa foreign key (IdUsuario) references Usuario(IdUsuario)
)

