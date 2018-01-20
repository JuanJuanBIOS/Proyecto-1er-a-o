use master
go

alter database Hoteles set single_user with rollback immediate
go

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
idHotel int identity(1,1) not null primary key,
nombre varchar(50)not null unique,
calle varchar(30),
numpuerta varchar(6),
ciudad varchar(30),
telefono varchar(15),
fax varchar(15),
playa bit,
piscina bit,
estrellas char
-- FALTA LA FOTO
)
go

-- Se crea la tabla de Habitaciones
create table Habitaciones(
idHabitacion int identity(1,1) not null primary key,
numero int not null,
idHotel int not null foreign key references Hoteles(idHotel),
piso varchar(3),
descripcion varchar(100),
huespedes varchar(3),
costodiario float,
constraint U_Habitaciones unique(numero, idHotel)
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
idUsuario int identity(1,1) not null primary key,
nomusu varchar(10) not null,
pass varchar(20) not null,
nombre varchar(50),
tipo int not null foreign key references Tipo_Usuario(idTipo),
)
go

-- Se crea la tabla de Clientes
create table Clientes(
idCliente int not null unique,
tarjeta varchar(16) unique,
calle varchar(30),
numpuerta varchar(6),
ciudad varchar(30),
)
go

-- Se crea la tabla de Telefonos
create table Telefonos(
idCliente int foreign key references Clientes(idCliente),
telefono varchar(15),
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
idAdministrador int not null unique,
cargo int not null foreign key references Cargos(idCargo),
)
go

-- Se crea la tabla Estados y se cargan los valores
create table Estados(
idEstado int not null primary key,
descripcion varchar(15),
)
go
INSERT INTO Estados VALUES
(0, 'Activa'),
(1, 'Cancelada'),
(2, 'Finalizada')
go

-- Se crea la tabla de Reservas
create table Reservas(
idReserva int identity(1,1) not null primary key,
idCliente int not null foreign key references Clientes(idCliente),
idHabitacion int not null foreign key references Habitaciones(idHabitacion),
fechaini datetime not null,
fechafin datetime not null,
estado int not null foreign key references Estados(idEstado)
)
go

-- -----------------------------------------------------------------------------------------------
-- CARGA DE DATOS INICIALES PARA PRUEBAS
-- -----------------------------------------------------------------------------------------------

-- Se agregan datos a la tabla Hoteles
INSERT INTO Hoteles VALUES
('Hotel 1','Calle 1','1111','Montevideo','59811111111','59811111110',0,1,'3'),
('Hotel 2','Calle 2','2222','Buenos Aires','5422222222','5422222220',0,0,'4'),
('Hotel 3','Calle 3','3333','Rio de Janeiro','5533333333','5533333330',1,0,'4'),
('Hotel 4','Calle 4','4444','Madrid','3444444444','3444444440',0,0,'5'),
('Hotel 5','Calle 5','5555','Barcelona','3455555555','3455555550',1,1,'4'),
('Hotel 6','Calle 6','6666','New York','166666666','166666660',0,1,'5'),
('Hotel 7','Calle 7','7777','Santiago de Chile','5677777777','5677777770',0,1,'3'),
('Hotel 8','Calle 8','8888','Sydney','6188888888','6188888880',1,0,'2'),
('Hotel 9','Calle 9','9999','Moscu','799999999','799999990',0,1,'1')
go

-- Se agregan datos a la tabla Habitaciones
INSERT INTO Habitaciones VALUES
(1,1,1,'Habitacion 1 del Hotel 1','4',30),
(2,1,2,'Habitacion 2 del Hotel 1','2',20),
(3,1,3,'Habitacion 3 del Hotel 1','6',40),
(1,2,1,'Habitacion 1 del Hotel 2','1',30),
(2,2,2,'Habitacion 2 del Hotel 2','4',20),
(3,2,3,'Habitacion 3 del Hotel 2','5',40),
(1,3,1,'Habitacion 1 del Hotel 3','2',30),
(2,3,2,'Habitacion 2 del Hotel 3','2',20),
(3,3,3,'Habitacion 3 del Hotel 3','4',40),
(1,4,1,'Habitacion 1 del Hotel 4','1',30),
(2,4,2,'Habitacion 2 del Hotel 4','2',20),
(3,4,3,'Habitacion 3 del Hotel 4','4',40),
(1,5,1,'Habitacion 1 del Hotel 5','4',30),
(2,5,2,'Habitacion 2 del Hotel 5','4',20),
(3,5,3,'Habitacion 3 del Hotel 5','2',40),
(1,6,1,'Habitacion 1 del Hotel 6','2',30),
(2,6,2,'Habitacion 2 del Hotel 6','5',20),
(3,6,3,'Habitacion 3 del Hotel 6','6',40),
(1,7,1,'Habitacion 1 del Hotel 7','1',30),
(2,7,2,'Habitacion 2 del Hotel 7','2',20),
(3,7,3,'Habitacion 3 del Hotel 7','2',40),
(1,8,1,'Habitacion 1 del Hotel 8','3',30),
(2,8,2,'Habitacion 2 del Hotel 8','3',20),
(3,8,3,'Habitacion 3 del Hotel 8','4',40),
(1,9,1,'Habitacion 1 del Hotel 9','4',30),
(2,9,2,'Habitacion 2 del Hotel 9','4',20),
(3,9,3,'Habitacion 3 del Hotel 9','8',40)
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
(1,'3256987452156985','Street 1','1111','Bogota'),
(4,'6548753214586987','Street 4','4444','Lima'),
(5,'6658745215896547','Street 5','5555','Paris'),
(6,'3332545896541258','Street 6','6666','Roma')
go

-- Se agregan datos a la tabla Telefonos
INSERT INTO Telefonos VALUES
(1,'5765412589'),
(4,'5135485475'),
(4,'5136985248'),
(5,'3398654125'),
(6,'3965987541'),
(6,'3911658648')
go

-- Se agregan datos a la tabla Administradores
INSERT INTO Administradores VALUES
(2,0),
(3,1)
go

-- Se agregan datos a la tabla Reservas
INSERT INTO Reservas VALUES
(1, 1, '01/15/2018', '01/30/2018',0),
(4, 2, '03/15/2018', '03/30/2018',0),
(5, 3, '03/15/2018', '03/30/2018',1),
(6, 4, '05/15/2018', '05/30/2018',0),
(4, 5, '08/15/2018', '08/30/2018',0),
(6, 2, '10/15/2018', '10/30/2018',2),
(6, 7, '12/15/2018', '12/30/2018',0),
(1, 8, '11/15/2018', '11/30/2018',2),
(1, 9, '11/15/2018', '11/30/2018',1),
(1, 1, '02/15/2018', '02/28/2018',0)
go


-- -----------------------------------------------------------------------------------------------
-- CREACIÓN DE STORED PROCEDURES
-- -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- HOTELES
-- ***********************************************************************************************
-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA BUSCAR HOTEL
create procedure Buscar_Hotel
@nombre varchar(50)
as
begin
if not exists(select * from Hoteles where nombre = @nombre)
	return -1
else
	select * from Hoteles where (nombre = @nombre)
end
go
-- Prueba Buscar_Hotel 'Hotel 2'
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CREAR HOTEL
create procedure Crear_Hotel
@nombre varchar(50), 
@calle varchar(30), 
@numpuerta varchar(6), 
@ciudad varchar(30),
@telefono varchar(15), 
@fax varchar(15), 
@playa bit,
@piscina bit, 
@estrellas char
as
begin
if exists (select * from Hoteles where nombre = @nombre)
	return -1

insert into Hoteles values (@nombre, @calle, @numpuerta, @ciudad, @telefono, @fax, @playa, @piscina, @estrellas)

if @@ERROR<>0
		return -2
else
	return 1
end
go
-- Prueba Crear_Hotel 'Hotel 10','Calle 10','1010','Las Vegas','110101010','110101000',0,1,'5'
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA MODIFICAR HOTEL
create procedure Modificar_Hotel
@idHotel int, 
@nombre varchar(50), 
@calle varchar(30), 
@numpuerta varchar(6), 
@ciudad varchar(30),
@telefono varchar(15), 
@fax varchar(15), 
@playa bit,
@piscina bit, 
@estrellas char
as
begin
if not exists (select * from Hoteles where idHotel = @idHotel)
	return -1

update Hoteles
set nombre = @nombre, calle = @calle, numpuerta = @numpuerta, ciudad = @ciudad, 
telefono = @telefono, fax = @fax, playa = @playa, piscina = @piscina, estrellas = @estrellas 
where idHotel = @idHotel

if @@ERROR<>0
	return -2
else
	return 1
end
go
-- Prueba Modificar_Hotel 10, 'Hotel 10','Calle 1010','0101','San Francisco','110101010','110101000',0,1,'5'
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA ELIMINAR HOTEL
create procedure Eliminar_Hotel
@idHotel int
as
begin
if not exists(select * from Hoteles where idHotel = @idHotel)
	return -1

begin transaction
	delete from Reservas where Reservas.idHabitacion in 
				(select idHabitacion from Habitaciones where Habitaciones.idHotel = @idHotel)
	delete from Habitaciones where Habitaciones.idHotel = @idHotel
	delete from Hoteles where Hoteles.idHotel = @idHotel
if @@ERROR<>0
	begin
		rollback transaction
		return -2
	end
else
	begin
		commit transaction
		return 1
	end
end
go
 -- Prueba Eliminar_Hotel 1
 -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- HABITACIONES
-- ***********************************************************************************************

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA BUSCAR HABITACION
create procedure Buscar_Habitacion
@numero int, 
@idHotel int
as
begin
if not exists(select * from Habitaciones where (numero = @numero and idHotel  = @idHotel))
	return -1
else
	select * from Habitaciones where (numero = @numero and idHotel  = @idHotel)
end
go
-- Prueba Buscar_Habitacion 3, 2

-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CREAR HABITACION
create procedure Crear_Habitacion
@numero int, 
@idHotel int, 
@piso varchar(3), 
@descripcion varchar(100),
@huespedes varchar(3), 
@costodiario float
as
begin
if exists (select * from Habitaciones where (numero = @numero and idHotel  = @idHotel))
	return -1

insert into Habitaciones values (@numero, @idHotel, @piso, @descripcion, @huespedes, @costodiario)

if @@ERROR<>0
	return -2
else
	return 1
end
go
-- Prueba Crear_Habitacion 15,2,'10','Habitacion 1015','10',60.35
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA MODIFICAR HABITACION
create procedure Modificar_Habitacion
@numero int, 
@idHotel int, 
@piso varchar(3), 
@descripcion varchar(100),
@huespedes varchar(3), 
@costodiario float
as
begin
if not exists (select * from Habitaciones where (numero = @numero and idHotel  = @idHotel))
	return -1
	
update Habitaciones
set numero = @numero, idHotel = @idHotel, piso = @piso, descripcion = @descripcion, 
huespedes = @huespedes, costodiario = @costodiario 
where (numero = @numero and idHotel  = @idHotel)

if @@ERROR<>0
	return -2
else
	return 1
end
go
-- Prueba Modificar_Habitacion 15,2,'10','Habitacion 1015','8',48.35
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA ELIMINAR HABITACION
create procedure Eliminar_Habitacion
@idHabitacion int
as
begin
if not exists(select * from Habitaciones where idHabitacion = @idHabitacion)
	return -1

begin transaction
	delete from Reservas where (Reservas.idHabitacion = @idHabitacion)
	delete from Habitaciones where (idHabitacion = @idHabitacion)
if @@ERROR<>0
	begin
		rollback transaction
		return -2
	end
else
	begin
		commit transaction
		return 1
	end
end
go
-- Prueba Eliminar_Habitacion 15
-- -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- ADMINISTRADORES
-- ***********************************************************************************************

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA BUSCAR ADMINISTRADOR
create procedure Buscar_Administrador
@nomusu varchar(10)
as
begin
if not exists(select * from Usuarios where nomusu = @nomusu)
	return -1
else
	begin
	declare @idUsuario int
	select @idUsuario = Usuarios.idUsuario from Usuarios where Usuarios.nomusu = @nomusu
	if not exists(select * from Administradores where idAdministrador = @idUsuario)
		return -2
	if exists(select * from Clientes where idCliente = @idUsuario)
		return -3
	select Usuarios.*, Administradores.cargo from Usuarios, Administradores
	where (Usuarios.idUsuario = @idUsuario and Usuarios.idUsuario = Administradores.idAdministrador)
	end
end
go
-- Prueba Buscar_Administrador 'usu2'
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CREAR ADMINISTRADOR
create procedure Crear_Administrador
@nomusu varchar(10), 
@pass varchar(20), 
@nombre varchar(50),
@tipo int, 
@cargo int
as
begin
if exists(select * from Usuarios where nomusu = @nomusu)
	return -1

begin transaction
insert into Usuarios values (@nomusu, @pass, @nombre, @tipo)
declare @idAdministrador int
select @idAdministrador = Usuarios.idUsuario from Usuarios where Usuarios.nomusu = @nomusu
insert into Administradores values (@idAdministrador, @cargo)

if @@ERROR<>0
	begin
		rollback transaction
		return -2
	end
else
	begin
		commit transaction
		return 1
	end
end
go
-- Prueba Crear_Administrador 'usu 7', 'usu 7', 'Usuario 7', 0, 2
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA MODIFICAR ADMINISTRADOR
create procedure Modificar_Administrador
@idAdministrador int, 
@nomusu varchar(10), 
@pass varchar(20), 
@nombre varchar(50), 
@tipo int, 
@cargo int
as
begin
if not exists(select * from Usuarios where idUsuario = @idAdministrador)
	return -1
else if not exists(select * from Administradores where idAdministrador = @idAdministrador)
	return -2
else if exists(select * from Clientes where idCliente = @idAdministrador)
	return -3
	
begin transaction
update Usuarios
set pass = @pass, nombre = @nombre, tipo = @tipo
where (idUsuario = @idAdministrador)

update Administradores
set cargo = @cargo
where (idAdministrador = @idAdministrador)

if @@ERROR<>0
	begin
		rollback transaction
		return -4
	end
else
	begin
		commit transaction
		return 1
	end
end
go
-- Prueba Modificar_Administrador 7, 'usu 7', 'usu 7', 'Usuario 77', 0, 1
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA ELIMINAR ADMINISTRADOR
create procedure Eliminar_Administrador
@idAdministrador int
as
begin
if not exists(select * from Usuarios where idUsuario = @idAdministrador)
	return -1
else if not exists(select * from Administradores where idAdministrador = @idAdministrador)
	return -2
else if exists(select * from Clientes where idCliente = @idAdministrador)
	return -3

begin transaction
	delete from Administradores where (idAdministrador = @idAdministrador)
	delete from Usuarios where (idUsuario = @idAdministrador)
if @@ERROR<>0
	begin
		rollback transaction
		return -4
	end
else
	begin
		commit transaction
		return 1
	end
end
go
-- Prueba Eliminar_Administrador 3
-- -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- RESERVAS
-- ***********************************************************************************************

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA FINALIZAR RESERVA
create procedure Finalizar_Reserva
@idReserva int
as
begin
if not exists(select * from Reservas where idReserva = @idReserva)
	return -1
if exists(select * from Reservas where (idReserva = @idReserva and estado = 1))
	return -2
if exists(select * from Reservas where (idReserva = @idReserva and estado = 2))
	return -3

update Reservas
set estado = 2
where (idReserva = @idReserva and estado = 0)

if @@ERROR<>0
	return -4
else
	return 1
end
go
-- Prueba Finalizar_Reserva 9
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CONSULTAR RESERVA
create procedure Consultar_Reserva
@idCliente int, 
@idHabitacion int, 
@fechaini datetime, 
@fechafin datetime
as
begin
if not exists(select * from Clientes where idCliente = @idCliente)
	return -1
if not exists(select * from Habitaciones where idHabitacion = @idHabitacion)
	return -2
if (@fechaini < convert(date,GETDATE()))
	return -3
if (@fechaini >= @fechafin)
	return -4
if	exists (select * from Reservas where (idHabitacion=@idHabitacion and @fechafin<=fechafin and @fechafin>=fechaini)) or
	exists (select * from Reservas where (idHabitacion=@idHabitacion and @fechaini<=fechafin and @fechaini>=fechaini)) or
	exists (select * from Reservas where (idHabitacion=@idHabitacion and @fechaini<=fechaini and @fechafin>=fechafin))
	return -5
else
	return 1
end
go
-- Prueba Consultar_Reserva 
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CONFIRMAR RESERVA
create procedure Confirmar_Reserva
@idCliente int, 
@idHabitacion int, 
@fechaini datetime, 
@fechafin datetime,
@estado int
as
begin
if not exists(select * from Clientes where idCliente = @idCliente)
	return -1
if not exists(select * from Habitaciones where idHabitacion = @idHabitacion)
	return -2
if (@fechaini < convert(date,GETDATE()))
	return -3
if (@fechaini >= @fechafin)
	return -4
if	exists (select * from Reservas where (idHabitacion=@idHabitacion and @fechafin<=fechafin and @fechafin>=fechaini)) or
	exists (select * from Reservas where (idHabitacion=@idHabitacion and @fechaini<=fechafin and @fechaini>=fechaini)) or
	exists (select * from Reservas where (idHabitacion=@idHabitacion and @fechaini<=fechaini and @fechafin>=fechafin))
	return -5
else
	begin
	insert into Reservas values(@idCliente, @idHabitacion, @fechaini, @fechafin, @estado)
	if @@ERROR<>0
		begin
			return -6
		end
	end
end
go
-- Prueba Confirmar_Reserva 1, 1, '02/01/2018', '02/12/2018', 0
-- -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- LISTADOS
-- ***********************************************************************************************

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA LISTAR RESERVAS POR HABITACION
create procedure Reservas_por_Habitacion
@idHabitacion int
as

select * from Reservas where (idHabitacion = @idHabitacion)
go
-- Prueba Reservas_por_Habitacion 4
-- -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- CLIENTES
-- ***********************************************************************************************

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CREAR CLIENTE
create procedure Crear_Cliente
@nomusu varchar(10), 
@pass varchar(20), 
@nombre varchar(50), 
@tipo int, 
@tarjeta varchar(16), 
@calle varchar (30), 
@numpuerta varchar(6), 
@ciudad varchar(30)
as
begin
if exists(select * from Usuarios where nomusu = @nomusu)
	return -1

begin transaction
insert into Usuarios values (@nomusu, @pass, @nombre, @tipo)
declare @idCliente int
select @idCliente = Usuarios.idUsuario from Usuarios where Usuarios.nomusu = @nomusu
insert into Clientes values (@idCliente, @tarjeta, @calle, @numpuerta, @ciudad)

if @@ERROR<>0
	begin
		rollback transaction
		return -4
	end
else
	begin
		commit transaction
		return 1
	end
end
go
-- Prueba Crear_Cliente 'usu 8', 'usu 8', 'Usuario 8', 1, '1254856985478569', 'Calle 8', '8888', 'La Paz'
-- -----------------------------------------------------------------------------------------------
