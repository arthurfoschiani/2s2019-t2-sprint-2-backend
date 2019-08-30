create database M_Ekips
use M_Ekips

-- DDL
create table Usuarios (
	IdUsuario int primary key identity,
	Email varchar (255) unique not null,
	Senha varchar (255) not null,
	Permissao varchar (255)
);
create table Departamentos (
	IdDepartamento int primary key identity,
	Nome varchar (255) unique
);
create table Cargos (
	IdCargo int primary key identity,
	Nome varchar (255) unique,
	Ativo bit default (1)
);
create table Funcionarios (
	IdFuncionario int primary key identity,
	Nome varchar (255),
	CPF char (14),
	DataNascimento Date,
	Salario smallmoney,
	IdDepartamento int foreign key references Departamentos (IdDepartamento),
	IdCargo int foreign key references Cargos (IdCargo),
	IdUsuario int foreign key references Usuarios (IdUsuario) unique
);

--DML
insert into Usuarios (Email, Senha, Permissao)
values ('comum@email.com', '123456', 'COMUM'),
('admin@email.com', '123456', 'ADMINISTRADOR'),
('usuario1@email.com', '123456', 'COMUM')

insert into Departamentos (Nome)
values ('Tecnologia'), ('Ciancias Naturais')

insert into Cargos (Nome)
values ('Desenvolvedor de sistemas'), ('Técnico em pacotes office'), ('Guarda de segurança ambiental')

insert into Funcionarios (Nome, CPF, DataNascimento, Salario, IdDepartamento, IdCargo, IdUsuario)
values ('Arthur', '555.555.555-55', '2003-12-21', 2000, 1, 1, 1),
('Admin', '111.111.111-11', '1999-07-08', 9000, 1, 2, 2)

--DQL
select IdUsuario,Email,Senha, Permissao from Usuarios

select IdDepartamento, Nome from Departamentos

select IdCargo, Nome, Ativo from Cargos

select f.IdFuncionario, f.Nome, f.CPF, f.DataNascimento, f.Salario, f.IdDepartamento, f.IdCargo, f.IdUsuario, u.Email, u.Senha, u.Permissao, d.Nome, c.Nome, c.Ativo from Funcionarios f inner join Usuarios u on f.IdUsuario = u.IdUsuario inner join Departamentos d on f.IdDepartamento = d.IdDepartamento inner join Cargos c on f.IdCargo = c.IdCargo 