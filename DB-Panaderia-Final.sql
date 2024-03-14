create database DBPanaderia;
go
use DBPanaderia;
go

/*
Select * From Panes
Select * From Bocaditos
Select * From Tortas
Select * From Usuarios
*/

-- Panes
create table Panes (
	idPanes 		Int Identity(1,1) Not null,
	codigoP			Int,
    	marcaP			Varchar(25) not null,
    	nombreP 		Varchar(50) not null,
    	descripcionP 		Varchar(200) null,
    	costoP			decimal not null,
    	fechaCreacionP 		Date,
    	fechaVencimiP 		Date,
	stockP			Int not null,
	imagenP			Varchar(200),
    	constraint pk_Panes Primary key(idPanes)
);
go

-- Procedimientos Panes almacenados
Select * from Panes
go
go
Create Procedure sp_ListarPanes
As
Begin
    Select * From Panes 
End
go

Create Procedure sp_ObtenerPanes(
    @idPanes    int
)
AS
Begin
    Select * From Panes Where idPanes = @idPanes
End
go

Create Procedure sp_GuardarPanes(
    @marcaP         Varchar(25),
    @nombreP        Varchar(50),
    @descripcionP   Varchar(200),
    @costoP         decimal,
    @fechaCreacionP Date,
    @fechaVencimiP  Date,
    @stockP	    Int,
    @imagenP	    Varchar(200)
)
As
Begin
    Insert Into Panes(marcaP,nombreP,descripcionP,costoP,fechaCreacionP,fechaVencimiP,stockP,imagenP) 
    Values(@marcaP,@nombreP,@descripcionP,@costoP,@fechaCreacionP,@fechaVencimiP,@stockP,@imagenP)
End
go

Create Procedure sp_EditarPanes(
    @idPanes        int,
    @marcaP         Varchar(25),
    @nombreP        Varchar(50),
    @descripcionP   Varchar(200),
    @costoP         decimal,
    @fechaCreacionP Date,
    @fechaVencimiP  Date,
    @stockP         Int,
    @imagenP	    Varchar(200)
)
As
Begin
	Update Panes Set marcaP = @marcaP, nombreP = @nombreP, descripcionP = @descripcionP,
    costoP = @costoP, fechaCreacionP = @fechaCreacionP, fechaVencimiP = @fechaVencimiP, stockP = @stockP, 
	imagenP = @imagenP Where idPanes = @idPanes
End
go

Create Procedure sp_EliminarPanes(
    @idPanes    int
)
AS
Begin
    Delete From Panes Where idPanes = @idPanes
End
go

-- Bocaditos
create table Bocaditos (
	idBocaditos 	Int Identity(1,1) Not null,
	codigoP			Int,
    marcaB			Varchar(25) not null,
    nombreB 		Varchar(50) not null,
    descripcionB 	Varchar(200) null,
    costoB			decimal not null,
    fechaCreacionB 	Date,
    fechaVencimiB 	Date,
	stockB			Int not null,
	imagenB			Varchar(200),
    constraint pk_Bocad Primary key(idBocaditos)
);
go

-- Procedimientos Bocaditos almacenados
Create Procedure sp_ListarBocaditos
As
Begin
    Select * From Bocaditos 
End
go

Create Procedure sp_ObtenerBocaditos(
    @idBocaditos    int
)
AS
Begin
    Select * From Bocaditos Where idBocaditos = @idBocaditos
End
go

Create Procedure sp_GuardarBocaditos(
    @marcaB         Varchar(25),
    @nombreB        Varchar(50),
    @descripcionB   Varchar(200),
    @costoB         decimal,
    @fechaCreacionB Date,
    @fechaVencimiB  Date,
	@stockB			Int,
	@imagenB		Varchar(200)
)
As
Begin
    Insert Into Bocaditos(marcaB,nombreB,descripcionB,costoB,fechaCreacionB,fechaVencimiB,stockB,imagenB) 
    Values(@marcaB,@nombreB,@descripcionB,@costoB,@fechaCreacionB,@fechaVencimiB,@stockB,@imagenB)
End
go

Create Procedure sp_EditarBocaditos(
    @idBocaditos    int,
    @marcaB         Varchar(25),
    @nombreB        Varchar(50),
    @descripcionB   Varchar(200),
    @costoB         decimal,
    @fechaCreacionB Date,
    @fechaVencimiB  Date,
	@stockB			Int,
	@imagenB		Varchar(200)
)
As
Begin
    Update Bocaditos Set marcaB = @marcaB, nombreB = @nombreB, descripcionB = @descripcionB,
    costoB = @costoB, fechaCreacionB = @fechaCreacionB, fechaVencimiB = @fechaVencimiB, stockB = @stockB, imagenB = @imagenB
    Where idBocaditos = @idBocaditos
End
go

Create Procedure sp_EliminarBocaditos(
    @idBocaditos    int
)
AS
Begin
    Delete From Bocaditos Where idBocaditos = @idBocaditos
End
go

-- Pasteles
create table Tortas (
	idTortas		Int Identity(1,1) Not null,
	codigoP			Int,
    marcaB			Varchar(25) not null,
    nombreT			Varchar(50) not null,
    descripcionT 	Varchar(200) null,
    costoT			decimal not null,
    fechaCreacionT 	Date,
    fechaVencimi 	Date,
	stockT			Int not null,
	imagenT			Varchar(200),
    constraint pk_Tortas Primary key(idTortas)
);
go

-- Procedimientos Tortas almacenados
Create Procedure sp_ListarTortas
As
Begin
    Select * From Tortas 
End
go

Create Procedure sp_ObtenerTortas(
    @idTortas    int
)
AS
Begin
    Select * From Tortas Where idTortas = @idTortas
End
go

Create Procedure sp_GuardarTortas(
    @marcaB         Varchar(25),
    @nombreT        Varchar(50),
    @descripcionT   Varchar(200),
    @costoT         decimal,
    @fechaCreacionT Date,
    @fechaVencimi   Date,
	@stockT			Int,
	@imagenT		Varchar(200)
)
As
Begin
    Insert Into Tortas(marcaB,nombreT,descripcionT,costoT,fechaCreacionT,fechaVencimi,stockT,imagenT) 
    Values(@marcaB,@nombreT,@descripcionT,@costoT,@fechaCreacionT,@fechaVencimi,@stockT,@imagenT)
End
go

Create Procedure sp_EditarTortas(
    @idTortas       int,
    @marcaB         Varchar(25),
    @nombreT        Varchar(50),
    @descripcionT   Varchar(200),
    @costoT         decimal,
    @fechaCreacionT Date,
    @fechaVencimi   Date,
	@stockT			Int,
	@imagenT		Varchar(200)
)
As
Begin
    Update Tortas Set marcaB = @marcaB, nombreT = @nombreT, descripcionT = @descripcionT,
    costoT = @costoT, fechaCreacionT = @fechaCreacionT, fechaVencimi = @fechaVencimi, stockT = @stockT, imagenT = @imagenT
    Where idTortas = @idTortas
End
go

Create Procedure sp_EliminarTortas(
    @idTortas    int
)
AS
Begin
    Delete From Tortas Where idTortas = @idTortas
End
go


-- USUARIOS
create table Usuarios (
	idUsuario	Int Identity(1,1) Not null,
	dni			Char(8),
	ruc			Char(11),
	usuario		Varchar(50) Not null,
	correo		Varchar(50) Not null,
	clave		Varchar(50) Not null,
	rol		Varchar(30) Not null,
    constraint pk_Usuarios Primary key(idUsuario)
);
go

Insert Into Usuarios Values('admin', 'admin@gmail.com', '123', 'ADMIN');
Insert Into Usuarios Values('user', 'user@gmail.com', '123', 'USER');
go

Create Procedure sp_ListarUsuarios
As
Begin
    Select * From Usuarios 
End
go

Create Procedure sp_ObtenerUsuarios(
    @idUsuario    int
)
AS
Begin
    Select * From Usuarios Where idUsuario = @idUsuario
End
go

Create Procedure sp_GuardarUsuarios(
	@usuario		Varchar(50),
	@correo		Varchar(50),
	@clave		Varchar(50),
	@rol		Varchar(30)
)
As
Begin
    Insert Into Usuarios(usuario,correo,clave,rol) 
    Values(@usuario,@correo,@clave,@rol)
End
go

Create Procedure sp_EditarUsuarios(
    @idUsuario   int,
    @usuario	Varchar(50),
	@correo		Varchar(50),
	@clave		Varchar(50),
	@rol		Varchar(30)
)
As
Begin
    Update Usuarios Set usuario = @usuario, correo = @correo, clave = @clave, rol = @rol
    Where idUsuario = @idUsuario
End
go

Create Procedure sp_EliminarUsuarios(
    @idUsuario    int
)
AS
Begin
    Delete From Usuarios Where idUsuario = @idUsuario
End

--- Factura
CREATE TABLE Facturas(
	idFactura Int Primary Key,
	idUsuario INT FOREIGN KEY REFERENCES usuarios(idUsuario),
	fechaCompra Date,
	cantProductos int,
	precioTotal Int,
);

--- Agregar Panes
INSERT INTO Panes (marcaP, nombreP, descripcionP, costoP, fechaCreacionP, fechaVencimiP, stockP, imagenP)
VALUES ('Artesanal', 'Pan Chiabata', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2022/12/Pan-Baguette-300x300.png'),
('Artesanal', 'Pan Baguet', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2022/12/CIABATTA_BLANCO-1-300x300.jpg'),
('Artesanal', 'Pan Integral', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2022/12/YEMA_PAN-1-300x300.jpg'),
('Artesanal', 'Pan Yema', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2022/12/CHANCAY_GRANDE-1-300x300.jpg'),
('Artesanal', 'Pan Model', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2022/12/MOLDE_BLANCO-1-300x300.jpg');

--- Agregar Bocaditos
INSERT INTO Bocaditos (marcaB, nombreB, descripcionB, costoB, fechaCreacionB, fechaVencimiB, stockB, imagenB)
VALUES ('Artesanal', 'Milohojas', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2022/12/MILHOJAS_GRANDE-1-300x300.jpg'),
('Artesanal', 'Zambito', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2022/12/ZAMBITO_CHOCOLATE-1-300x300.jpg'),
('Artesanal', 'Alfajor', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2023/10/A749713-300x300.png'),
('Artesanal', 'Prueba', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2023/10/A7407797-300x300.png'),
('Artesanal', '7 Sabores', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2023/10/SIETE_SABORES-1-300x300.jpg');

--- Agregar Panaderia
INSERT INTO Tortas (marcaB, nombreT, descripcionT, costoT, fechaCreacionT, fechaVencimi, stockT, imagenT)
VALUES ('Artesanal', 'Pastel de fresas', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2023/10/Mini-Torta-clasica-de-fresas-300x300.png'),
('Artesanal', 'Pastel de Zanahorias', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2023/10/Mini-Torta-de-Zanahoria-300x300.png'),
('Artesanal', 'Pastel Merengue', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2023/10/Mini-torta-merengado-de-chirimoya-300x300.png'),
('Artesanal', 'Pastel Tres Leches', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2022/12/Torta_Tres_Leches-300x300.png'),
('Artesanal', 'Pastel Arcoiris', 'Pan elaborado con granos enteros', 2.50, '2024-03-14', '2024-04-13', 10, 'https://pasteleriasanantonio.com/programados/wp-content/uploads/2022/12/arcoiris_toppers_novedades-300x300.png');

