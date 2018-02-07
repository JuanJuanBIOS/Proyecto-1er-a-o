use master
go

if exists(select * from sysdatabases where name = 'Hoteles')
begin
	alter database Hoteles set single_user with rollback immediate
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
nombre varchar(50) not null primary key,
calle varchar(30) not null,
numpuerta varchar(6) not null,
ciudad varchar(30) not null,
telefono varchar(15) not null,
fax varchar(15) not null,
playa bit not null,
piscina bit not null,
estrellas char not null,
foto varchar(100) not null
)
go

-- Se crea la tabla de Habitaciones
create table Habitaciones(
numero int not null,
hotel varchar(50) not null foreign key references Hoteles(nombre),
piso varchar(3),
descripcion varchar(100),
huespedes varchar(3),
costodiario float,
constraint PK_Habitaciones primary key (hotel, numero)
)
go

-- Se crea la tabla de Usuarios
create table Usuarios(
nomusu varchar(10) not null primary key,
pass varchar(20) not null,
nombre varchar(50)
)
go

-- Se crea la tabla de Clientes
create table Clientes(
nomusu varchar(10) not null primary key,
tarjeta varchar(16) not null unique,
direccion varchar(50) not null,
constraint FK_Clientes foreign key (nomusu) references Usuarios(nomusu)
)
go

-- Se crea la tabla de Telefonos
create table Telefonos(
nomusu varchar(10) not null foreign key references Clientes(nomusu),
telefono varchar(15)
)
go


-- Se crea la tabla de Administradores
create table Administradores(
nomusu varchar(10) not null primary key,
cargo varchar(20) not null
)
go

-- Se crea la tabla de Reservas
create table Reservas(
idReserva int identity(1,1) not null primary key,
nomusu varchar(10) not null foreign key references Clientes(nomusu),
habitacion int not null,
hotel varchar(50) not null,
constraint FK_Reserva foreign key(hotel, habitacion) references Habitaciones(hotel, numero),
fechaini datetime not null,
fechafin datetime not null,
estado varchar(20) not null
)
go

-- -----------------------------------------------------------------------------------------------
-- CARGA DE DATOS INICIALES PARA PRUEBAS
-- -----------------------------------------------------------------------------------------------

-- Se agregan datos a la tabla Hoteles
INSERT INTO Hoteles VALUES
('Hotel 1','Calle 1','1111','Montevideo','59811111111','59811111110',0,1,'3',''),
('Hotel 2','Calle 2','2222','Buenos Aires','5422222222','5422222220',0,0,'4',''),
('Hotel 3','Calle 3','3333','Rio de Janeiro','5533333333','5533333330',1,0,'4',''),
('Hotel 4','Calle 4','4444','Madrid','3444444444','3444444440',0,0,'5',''),
('Hotel 5','Calle 5','5555','Barcelona','3455555555','3455555550',1,1,'4',''),
('Hotel 6','Calle 6','6666','New York','166666666','166666660',0,1,'5',''),
('Hotel 7','Calle 7','7777','Santiago de Chile','5677777777','5677777770',0,1,'3',''),
('Hotel 8','Calle 8','8888','Sydney','6188888888','6188888880',1,0,'2',''),
('Hotel 9','Calle 9','9999','Moscu','799999999','799999990',0,1,'1','')
go

-- Se agregan datos a la tabla Habitaciones
INSERT INTO Habitaciones VALUES
(101,'Hotel 1','1','Habitacion 101 del Hotel 1','4',30),
(201,'Hotel 1','2','Habitacion 201 del Hotel 1','2',20),
(301,'Hotel 1','3','Habitacion 301 del Hotel 1','6',40),
(101,'Hotel 2','1','Habitacion 101 del Hotel 2','1',30),
(201,'Hotel 2','2','Habitacion 201 del Hotel 2','4',20),
(301,'Hotel 2','3','Habitacion 301 del Hotel 2','5',40),
(101,'Hotel 3','1','Habitacion 101 del Hotel 3','2',30),
(201,'Hotel 3','2','Habitacion 201 del Hotel 3','2',20),
(301,'Hotel 3','3','Habitacion 301 del Hotel 3','4',40),
(101,'Hotel 4','1','Habitacion 101 del Hotel 4','1',30),
(201,'Hotel 4','2','Habitacion 201 del Hotel 4','2',20),
(301,'Hotel 4','3','Habitacion 301 del Hotel 4','4',40),
(101,'Hotel 5','1','Habitacion 101 del Hotel 5','4',30),
(201,'Hotel 5','2','Habitacion 201 del Hotel 5','4',20),
(301,'Hotel 5','3','Habitacion 301 del Hotel 5','2',40),
(101,'Hotel 6','1','Habitacion 101 del Hotel 6','2',30),
(201,'Hotel 6','2','Habitacion 201 del Hotel 6','5',20),
(301,'Hotel 6','3','Habitacion 301 del Hotel 6','6',40),
(101,'Hotel 7','1','Habitacion 101 del Hotel 7','1',30),
(201,'Hotel 7','2','Habitacion 201 del Hotel 7','2',20),
(301,'Hotel 7','3','Habitacion 301 del Hotel 7','2',40),
(101,'Hotel 8','1','Habitacion 101 del Hotel 8','3',30),
(201,'Hotel 8','2','Habitacion 201 del Hotel 8','3',20),
(301,'Hotel 8','3','Habitacion 301 del Hotel 8','4',40),
(101,'Hotel 9','1','Habitacion 101 del Hotel 9','4',30),
(201,'Hotel 9','2','Habitacion 201 del Hotel 9','4',20),
(301,'Hotel 9','3','Habitacion 301 del Hotel 9','8',40)
go

-- Se agregan datos a la tabla Usuarios
INSERT INTO Usuarios VALUES
('usu1','usu1','Usuario 1'),
('usu2','usu2','Usuario 2'),
('usu3','usu3','Usuario 3'),
('usu4','usu4','Usuario 4'),
('usu5','usu5','Usuario 5'),
('usu6','usu6','Usuario 6')
go


-- Se agregan datos a la tabla Clientes
INSERT INTO Clientes VALUES
('usu1','3256987452156985','Street 1 1111'),
('usu4','6548753214586987','Street 4 4444'),
('usu5','6658745215896547','Street 5 5555'),
('usu6','3332545896541258','Street 6 6666')
go

-- Se agregan datos a la tabla Telefonos
INSERT INTO Telefonos VALUES
('usu1','5765412589'),
('usu4','5135485475'),
('usu4','5136985248'),
('usu5','3398654125'),
('usu6','3965987541'),
('usu6','3911658648')
go

-- Se agregan datos a la tabla Administradores
INSERT INTO Administradores VALUES
('usu2','Gerente'),
('usu3','Recepcionista')
go

-- Se agregan datos a la tabla Reservas
INSERT INTO Reservas VALUES
('usu1', 101, 'Hotel 1', '01/15/2018', '01/30/2018','Activa'),
('usu4', 201, 'Hotel 3', '03/15/2018', '03/30/2018','Activa'),
('usu5', 301, 'Hotel 5', '03/15/2018', '03/30/2018','Finalizada'),
('usu6', 101, 'Hotel 2', '05/15/2018', '05/30/2018','Activa'),
('usu4', 301, 'Hotel 8', '08/15/2018', '08/30/2018','Activa'),
('usu1', 201, 'Hotel 9', '10/15/2018', '10/30/2018','Cancelada'),
('usu1', 101, 'Hotel 1', '12/15/2018', '12/30/2018','Activa'),
('usu1', 101, 'Hotel 1', '11/15/2018', '11/30/2018','Cancelada'),
('usu1', 301, 'Hotel 2', '11/15/2018', '11/30/2018','Finalizada'),
('usu1', 201, 'Hotel 2', '02/15/2018', '02/28/2018','Activa')
go


-- -----------------------------------------------------------------------------------------------
-- CREACIÓN DE STORED PROCEDURES
-- -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- USUARIOS
-- ***********************************************************************************************

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA LOGIN
create procedure Login_Usuario
@nomusu varchar(10),
@pass varchar(20)
as
begin
if exists(select * from Clientes where nomusu = @nomusu)
begin
	select *, 1 as tipo from Usuarios inner join Clientes on Usuarios.nomusu = Clientes.nomusu
	where (Usuarios.nomusu = @nomusu and pass = @pass)
end

if exists(select * from Administradores where nomusu = @nomusu)
begin
	select *, 2 as tipo  from Usuarios inner join Administradores on Usuarios.nomusu = Administradores.nomusu 
	where (Usuarios.nomusu = @nomusu and pass = @pass)
end
end
go
-- Prueba Login_Usuario 'usu2', 'usu2'

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
@estrellas char,
@foto varchar(100)
as
begin
if exists (select * from Hoteles where nombre = @nombre)
	return -1

insert into Hoteles values (@nombre, @calle, @numpuerta, @ciudad, @telefono, @fax, @playa, @piscina, @estrellas, @foto)

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
@nombre varchar(50), 
@calle varchar(30), 
@numpuerta varchar(6), 
@ciudad varchar(30),
@telefono varchar(15), 
@fax varchar(15), 
@playa bit,
@piscina bit, 
@estrellas char,
@foto varchar(100)
as
begin
if not exists (select * from Hoteles where nombre = @nombre)
	return -1

update Hoteles
set calle = @calle, numpuerta = @numpuerta, ciudad = @ciudad, telefono = @telefono, 
	fax = @fax, playa = @playa, piscina = @piscina, estrellas = @estrellas, foto=@foto 
where nombre = @nombre

if @@ERROR<>0
	return -2
else
	return 1
end
go
-- Prueba Modificar_Hotel 'Hotel 10','Calle 1010','0101','San Francisco','110101010','110101000',0,1,'5'
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA ELIMINAR HOTEL
create procedure Eliminar_Hotel
@nombre varchar(50)
as
begin
if not exists(select * from Hoteles where nombre = @nombre)
	return -1

begin transaction
	delete from Reservas where Reservas.hotel = @nombre
	delete from Habitaciones where Habitaciones.hotel = @nombre
	delete from Hoteles where Hoteles.nombre = @nombre
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
 -- Prueba Eliminar_Hotel 'Hotel 1'
 -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- HABITACIONES
-- ***********************************************************************************************

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA BUSCAR HABITACION
create procedure Buscar_Habitacion
@numero int, 
@hotel varchar(50)
as
begin
if not exists(select * from Hoteles where nombre = @hotel)
	return -1
else if not exists(select * from Habitaciones where (numero = @numero and hotel  = @hotel))
	return -2
else
	select * from Habitaciones where (numero = @numero and hotel  = @hotel)
end
go
-- Prueba Buscar_Habitacion 301, 'Hotel 2'

-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CREAR HABITACION
create procedure Crear_Habitacion
@numero int, 
@hotel varchar(50), 
@piso varchar(3), 
@descripcion varchar(100),
@huespedes varchar(3), 
@costodiario float
as
begin
if exists (select * from Habitaciones where (numero = @numero and hotel  = @hotel))
	return -1

insert into Habitaciones values (@numero, @hotel, @piso, @descripcion, @huespedes, @costodiario)

if @@ERROR<>0
	return -2
else
	return 1
end
go
-- Prueba Crear_Habitacion 401,'Hotel 2','4','Habitacion 401 del Hotel 2','10',60.35
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA MODIFICAR HABITACION
create procedure Modificar_Habitacion
@numero int, 
@hotel varchar(50), 
@piso varchar(3), 
@descripcion varchar(100),
@huespedes varchar(3), 
@costodiario float
as
begin
if not exists (select * from Habitaciones where (numero = @numero and hotel  = @hotel))
	return -1
	
update Habitaciones
set piso = @piso, descripcion = @descripcion, huespedes = @huespedes, costodiario = @costodiario 
where (numero = @numero and hotel  = @hotel)

if @@ERROR<>0
	return -2
else
	return 1
end
go
-- Prueba Modificar_Habitacion 401,'Hotel 2','4','Habitacion 401 del Hotel 2','8',48.35
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA ELIMINAR HABITACION
create procedure Eliminar_Habitacion
@numero int,
@hotel varchar(50)
as
begin
if not exists(select * from Habitaciones where (numero = @numero and hotel  = @hotel))
	return -1

begin transaction
	delete from Reservas where ((Reservas.habitacion = @numero and Reservas.hotel  = @hotel))
	delete from Habitaciones where (numero = @numero and hotel  = @hotel)
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
-- Prueba Eliminar_Habitacion 401, 'Hotel 2'
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
if exists (select * from Clientes where nomusu = @nomusu)
	return -1
if not exists(select * from Administradores where nomusu = @nomusu)
	return -2
else
	select * from Usuarios, Administradores where (Usuarios.nomusu = @nomusu
		 and Usuarios.nomusu = Administradores.nomusu)
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
@cargo varchar(20)
as
begin
if exists(select * from Usuarios where nomusu = @nomusu)
	return -1

begin transaction
	insert into Usuarios values (@nomusu, @pass, @nombre)
	insert into Administradores values (@nomusu, @cargo)

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
-- Prueba Crear_Administrador 'usu 7', 'usu 7', 'Usuario 7', 'Recepcionista'
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA MODIFICAR ADMINISTRADOR
create procedure Modificar_Administrador
@nomusu varchar(10), 
@pass varchar(20), 
@nombre varchar(50),
@cargo varchar(20)
as
begin
if not exists(select * from Usuarios where nomusu = @nomusu)
	return -1
else if not exists(select * from Administradores where nomusu = @nomusu)
	return -2
else if exists(select * from Clientes where nomusu = @nomusu)
	return -3
	
begin transaction
update Usuarios
set pass = @pass, nombre = @nombre
where (nomusu = @nomusu)

update Administradores
set cargo = @cargo
where (nomusu = @nomusu)

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
-- Prueba Modificar_Administrador 'usu 7', 'usu 7', 'Usuario 77', 'Recepcionista ' 
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA ELIMINAR ADMINISTRADOR
create procedure Eliminar_Administrador
@nomusu varchar(10)
as
begin
if not exists(select * from Usuarios where nomusu = @nomusu)
	return -1
else if not exists(select * from Administradores where nomusu = @nomusu)
	return -2
else if exists(select * from Clientes where nomusu = @nomusu)
	return -3

begin transaction
	delete from Administradores where (nomusu = @nomusu)
	delete from Usuarios where (nomusu = @nomusu)
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
-- Prueba Eliminar_Administrador 'usu3'
-- -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- RESERVAS
-- ***********************************************************************************************

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CONFIRMAR USO DE RESERVA
create procedure Confirmar_uso_reserva
@idReserva int
as
begin
if not exists(select * from Reservas where idReserva = @idReserva)
	return -1
if exists(select * from Reservas where (idReserva = @idReserva and estado = 'Cancelada'))
	return -2
if exists(select * from Reservas where (idReserva = @idReserva and estado = 'Finalizada'))
	return -3

update Reservas
set estado = 'Finalizada' where (idReserva = @idReserva and estado = 'Activa')

if @@ERROR<>0
	return -4
else
	return 1
end
go
-- Prueba Confirmar_uso_reserva 10
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA REALIZAR RESERVA
create procedure Realizar_Reserva
@nomusu varchar(10), 
@habitacion int,
@hotel varchar(50),
@fechaini datetime, 
@fechafin datetime
as
begin
if not exists(select * from Clientes where nomusu = @nomusu)
	return -1
if not exists(select * from Habitaciones where (numero = @habitacion and hotel = @hotel))
	return -2
if not exists(select * from Hoteles where nombre = @hotel)
	return -3
if (@fechaini < convert(date,GETDATE()))
	return -4
if (@fechaini >= @fechafin)
	return -5
if	exists (select * from Reservas where (habitacion = @habitacion and hotel = @hotel and @fechafin<=fechafin and @fechafin>=fechaini)) or
	exists (select * from Reservas where (habitacion = @habitacion and hotel = @hotel and @fechaini<=fechafin and @fechaini>=fechaini)) or
	exists (select * from Reservas where (habitacion = @habitacion and hotel = @hotel and @fechaini<=fechaini and @fechafin>=fechafin))
	return -6
else
	begin
	insert into Reservas values(@nomusu, @habitacion, @hotel, @fechaini, @fechafin, 'Activa')
	if @@ERROR<>0
		begin
			return -7
		end
	end
end
go
-- Prueba Realizar_Reserva 'usu1', 301, 'Hotel 1', '02/01/2018', '02/12/2018'
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CANCELAR USO DE RESERVA
create procedure Cancelar_Reserva
@idReserva int
as
begin
if not exists(select * from Reservas where idReserva = @idReserva)
	return -1
if exists(select * from Reservas where (idReserva = @idReserva and estado = 'Finalizada'))
	return -2

update Reservas
set estado = 'Cancelada' where (idReserva = @idReserva and estado = 'Activa')

if @@ERROR<>0
	return -3
else
	return 1
end
go
-- Prueba Cancelar_Reserva 10
-- -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- LISTADOS
-- ***********************************************************************************************

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA LISTAR RESERVAS ACTIVAS
create procedure Reservas_Activas
as
begin

select * from Reservas where (estado = 'Activa')
end
go
-- Prueba Reservas_Activas
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA LISTAR RESERVAS POR HABITACION
create procedure Reservas_por_Habitacion
@habitacion int, 
@hotel varchar(50)
as

select * from Reservas where (habitacion = @habitacion and hotel = @hotel)
go
-- Prueba Reservas_por_Habitacion 101, 'Hotel 1'
-- -----------------------------------------------------------------------------------------------


-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA LISTAR RESERVAS ACTIVAS POR USUARIO
create procedure Reservas_Activas_por_Usuario
@nomusu varchar(10)
as

select * from Reservas where (nomusu = @nomusu and estado = 'Activa')
go
-- Prueba Reservas_Activas_por_Usuario 'usu1'
-- -----------------------------------------------------------------------------------------------


-- ***********************************************************************************************
-- CLIENTES
-- ***********************************************************************************************

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA BUSCAR CLIENTE
create procedure Buscar_CLIENTE
@nomusu varchar(10)
as
begin
if exists (select * from Administradores where nomusu = @nomusu)
	return -1
if not exists(select * from Clientes where nomusu = @nomusu)
	return -2
else
	select * from Usuarios, Clientes where (Usuarios.nomusu = @nomusu
		 and Usuarios.nomusu = Clientes.nomusu)
end
go
-- Prueba Buscar_Cliente 'usu1'
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CREAR CLIENTE
create procedure Crear_Cliente
@nomusu varchar(10), 
@pass varchar(20), 
@nombre varchar(50), 
@tarjeta varchar(16), 
@direccion varchar (50)
as
begin
if exists(select * from Usuarios where nomusu = @nomusu)
	return -1

begin transaction
insert into Usuarios values (@nomusu, @pass, @nombre)
insert into Clientes values (@nomusu, @tarjeta, @direccion)

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
-- Prueba Crear_Cliente 'usu 8', 'usu 8', 'Usuario 8', '1254856985478569', 'Calle 8 8888'
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA MODIFICAR CLIENTE
create procedure Modificar_Cliente
@nomusu varchar(10), 
@pass varchar(20), 
@nombre varchar(50), 
@tarjeta varchar(16), 
@direccion varchar (50)
as
begin
if not exists(select * from Usuarios where nomusu = @nomusu)
	return -1
else if not exists(select * from Clientes where nomusu = @nomusu)
	return -2
else if exists(select * from Administradores where nomusu = @nomusu)
	return -3
	
begin transaction
update Usuarios
set pass = @pass, nombre = @nombre
where (nomusu = @nomusu)

update Clientes
set tarjeta = @tarjeta, direccion = @direccion
where (nomusu = @nomusu)

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
-- Prueba Modificar_Cliente 'usu5', 'usu5', 'Usuario 56', '65487532145869898', 'Street 4 4444' 
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA ELIMINAR CLIENTE
create procedure Eliminar_Cliente
@nomusu varchar(10)
as
begin
if not exists(select * from Usuarios where nomusu = @nomusu)
	return -1
else if not exists(select * from Clientes where nomusu = @nomusu)
	return -2
else if exists(select * from Administradores where nomusu = @nomusu)
	return -3

begin transaction
	delete from Telefonos where (nomusu = @nomusu)
	delete from Reservas where (nomusu = @nomusu)
	delete from Clientes where (nomusu = @nomusu)
	delete from Usuarios where (nomusu = @nomusu)

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
-- Prueba Eliminar_Cliente 'usu5'
-- -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- TELEFONOS
-- ***********************************************************************************************
-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA CREAR TELEFONO
create procedure Crear_Telefono
@nomusu varchar(10), 
@telefono varchar(15)
as
begin
if exists(select * from Telefonos where (nomusu = @nomusu and telefono = @telefono))
	return -1

else
insert into Telefonos values (@nomusu, @telefono)
end

go
-- Prueba Crear_Telefono 'usu1', '0993185643532'
-- -----------------------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA BUSCAR TELEFONO
create procedure Buscar_Telefonos
@nomusu varchar(10)

as
begin
if not exists(select * from Telefonos where nomusu = @nomusu)
	return -1
else
	select * from Telefonos where nomusu = @nomusu
end

go
-- Prueba Buscar_Telefonos 'usu1'
-- -----------------------------------------------------------------------------------------------
-- -----------------------------------------------------------------------------------------------
-- SE CREA PROCEDIMIENTO PARA ELIMINAR TELEFONO
create procedure Eliminar_Telefono
@nomusu varchar(10), 
@telefono varchar(15)
as
begin
if not exists(select * from Telefonos where (nomusu = @nomusu and telefono = @telefono))
	return -1

else
delete from Telefonos where (nomusu = @nomusu and telefono = @telefono)
end

go
-- Prueba Eliminar_Telefono 'usu1', '099318562'
-- -----------------------------------------------------------------------------------------------
