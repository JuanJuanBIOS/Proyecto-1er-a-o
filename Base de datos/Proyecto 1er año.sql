use master
go

--------------------------
if exists(select * from sysdatabases where name = 'Hoteles')
begin
	drop database Hoteles
end
go

--Se crea la base de datos
create database Hoteles
go


--Se selecciona la base de datos
use Hoteles
go

-- ------------------------------------------------------------------------------------------------
-- CREACIÓN DE TABLAS 
-- ------------------------------------------------------------------------------------------------

-- Se crea la tabla de Hoteles
create table Hoteles(
nombre varchar(50)not null primary key,
calle varchar(30),
numpuerta int,
ciudad varchar(30),
telefono bigint,
fax bigint,
playa bit,
estrellas int,
-- FALTA LA FOTO
)
go

-- Se crea la tabla de Habitaciones
create table Habitaciones(
numero int not null,
hotel varchar(50) not null foreign key references Hoteles(nombre),
piso int,
descripcion varchar(100),
huespedes int,
costodiario float,
constraint PK_Habitaciones primary key (numero, hotel),
)
go

-- Se crea la tabla Tipo de usuario y se cargan los valores
create table Tipo_Usuario(
idTipo int not null primary key,
descripcion varchar(15),
)
go
INSERT INTO Tipo_Usuario VALUES
(0, 'Administrador'),
(1, 'Cliente')
go

-- Se crea la tabla de Usuarios
create table Usuarios(
nomusu varchar(10) not null primary key,
pass varchar(20),
nombre varchar(50),
tipo int not null foreign key references Tipo_Usuario(idTipo),
)
go

-- Se crea la tabla de Clientes
create table Clientes(
nomusu varchar(10)not null foreign key references Usuarios(nomusu),
tarjeta bigint unique,
calle varchar(30),
numpuerta int,
ciudad varchar(30),
)
go

-- Se crea la tabla de Telefonos
create table Telefonos(
nomusu varchar(10) foreign key references Usuarios(nomusu),
telefono bigint,
)
go

-- Se crea la tabla Cargos y se cargan los valores
create table Cargos(
idCargo int not null primary key,
descripcion varchar(15),
)
go
INSERT INTO Cargos VALUES
(0, 'Gerente'),
(1, 'Jefe'),
(2, 'Administrativo')
go

-- Se crea la tabla de Administradores
create table Administradores(
nomusu varchar(10) not null foreign key references Usuarios(nomusu),
cargo int not null foreign key references Cargos(idCargo),
)
go

-- Se crea la tabla de Reservas
create table Reservas(
idReserva int identity(1,1) not null primary key,
cliente varchar(10) not null foreign key references Usuarios(nomusu),
numhab int not null,
nomhot varchar(50) not null,
fechaini datetime not null,
fechafin datetime not null,
estado int,
constraint FK_Reservas foreign key (numhab, nomhot) references Habitaciones(numero, hotel),
)
go

-- -----------------------------------------------------------------------------------------------
-- CARGA DE DATOS INICIALES PARA PRUEBAS
-- -----------------------------------------------------------------------------------------------

-- Se agregan datos a la tabla Hoteles
INSERT INTO Hoteles VALUES
('Hotel 1','Calle 1',1111,'Montevideo',59811111111,59811111110,0,3),
('Hotel 2','Calle 2',2222,'Buenos Aires',5422222222,5422222220,0,4),
('Hotel 3','Calle 3',3333,'Rio de Janeiro',5533333333,5533333330,1,4),
('Hotel 4','Calle 4',4444,'Madrid',3444444444,3444444440,0,5),
('Hotel 5','Calle 5',5555,'Barcelona',3455555555,3455555550,1,4),
('Hotel 6','Calle 6',6666,'New York',166666666,166666660,0,5),
('Hotel 7','Calle 7',7777,'Santiago de Chile',5677777777,5677777770,0,3),
('Hotel 8','Calle 8',8888,'Sydney',6188888888,6188888880,1,2),
('Hotel 9','Calle 9',9999,'Moscu',799999999,79999990,0,1)
go

-- Se agregan datos a la tabla Habitaciones
INSERT INTO Habitaciones VALUES
(1,'Hotel 1',1,'Habitacion 1 del Hotel 1',4,30),
(2,'Hotel 1',2,'Habitacion 2 del Hotel 1',2,20),
(3,'Hotel 1',3,'Habitacion 3 del Hotel 1',6,40),
(1,'Hotel 2',1,'Habitacion 1 del Hotel 2',1,30),
(2,'Hotel 2',2,'Habitacion 2 del Hotel 2',4,20),
(3,'Hotel 2',3,'Habitacion 3 del Hotel 2',5,40),
(1,'Hotel 3',1,'Habitacion 1 del Hotel 3',2,30),
(2,'Hotel 3',2,'Habitacion 2 del Hotel 3',2,20),
(3,'Hotel 3',3,'Habitacion 3 del Hotel 3',4,40),
(1,'Hotel 4',1,'Habitacion 1 del Hotel 4',1,30),
(2,'Hotel 4',2,'Habitacion 2 del Hotel 4',2,20),
(3,'Hotel 4',3,'Habitacion 3 del Hotel 4',4,40),
(1,'Hotel 5',1,'Habitacion 1 del Hotel 5',4,30),
(2,'Hotel 5',2,'Habitacion 2 del Hotel 5',4,20),
(3,'Hotel 5',3,'Habitacion 3 del Hotel 5',2,40),
(1,'Hotel 6',1,'Habitacion 1 del Hotel 6',2,30),
(2,'Hotel 6',2,'Habitacion 2 del Hotel 6',5,20),
(3,'Hotel 6',3,'Habitacion 3 del Hotel 6',6,40),
(1,'Hotel 7',1,'Habitacion 1 del Hotel 7',1,30),
(2,'Hotel 7',2,'Habitacion 2 del Hotel 7',2,20),
(3,'Hotel 7',3,'Habitacion 3 del Hotel 7',2,40),
(1,'Hotel 8',1,'Habitacion 1 del Hotel 8',3,30),
(2,'Hotel 8',2,'Habitacion 2 del Hotel 8',3,20),
(3,'Hotel 8',3,'Habitacion 3 del Hotel 8',4,40),
(1,'Hotel 9',1,'Habitacion 1 del Hotel 9',4,30),
(2,'Hotel 9',2,'Habitacion 2 del Hotel 9',4,20),
(3,'Hotel 9',3,'Habitacion 3 del Hotel 9',8,40)
go

-- Se agregan datos a la tabla Usuarios
INSERT INTO Usuarios VALUES
('usu1','usu1','Usuario 1',1),
('usu2','usu2','Usuario 2',0),
('usu3','usu3','Usuario 3',0),
('usu4','usu4','Usuario 4',1),
('usu5','usu5','Usuario 5',1),
('usu6','usu6','Usuario 6',1)
go


-- Se agregan datos a la tabla Clientes
INSERT INTO Clientes VALUES
('usu1',3256987452156985,'Street 1',1111,'Bogota'),
('usu4',6548753214586987,'Street 4',4444,'Lima'),
('usu5',6658745215896547,'Street 5',5555,'Paris'),
('usu6',3332545896541258,'Street 6',6666,'Roma')
go

-- Se agregan datos a la tabla Telefonos
INSERT INTO Telefonos VALUES
('usu1',5765412589),
('usu4',5135485475),
('usu4',5136985248),
('usu5',3398654125),
('usu6',3965987541),
('usu6',3911658648)
go

-- Se agregan datos a la tabla Administradores
INSERT INTO Administradores VALUES
('usu2',0),
('usu3',1)
go

-- Se agregan datos a la tabla Reservas
INSERT INTO Reservas VALUES
('usu1', 2, 'Hotel 1', '01/15/2018', '01/30/2018',0),
('usu4', 1, 'Hotel 2', '03/15/2018', '03/30/2018',0),
('usu5', 3, 'Hotel 3', '03/15/2018', '03/30/2018',0),
('usu6', 3, 'Hotel 4', '05/15/2018', '05/30/2018',0),
('usu4', 2, 'Hotel 5', '08/15/2018', '08/30/2018',0),
('usu6', 2, 'Hotel 6', '10/15/2018', '10/30/2018',0),
('usu6', 1, 'Hotel 7', '12/15/2018', '12/30/2018',0),
('usu1', 1, 'Hotel 8', '11/15/2018', '11/30/2018',0),
('usu1', 1, 'Hotel 9', '11/15/2018', '11/30/2018',0),
('usu1', 2, 'Hotel 1', '02/15/2018', '02/28/2018',0)
go


-- -----------------------------------------------------------------------------------------------
-- CREACIÓN DE STORED PROCEDURES
-- -----------------------------------------------------------------------------------------------
