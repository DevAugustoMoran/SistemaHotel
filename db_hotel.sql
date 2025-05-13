CREATE DATABASE db_hotel;

CREATE TABLE tbl_huespedes
(
	CodigoHuesped INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(50),
	Nit VARCHAR(20),
	Telefono VARCHAR(15),
	Tipo VARCHAR(50),
	Estado VARCHAR(20),
	UsuarioSistema VARCHAR(50),
	FechaSistema DATETIME
);

SELECT * FROM tbl_huespedes;

Insert into tbl_huespedes(Nombre, Nit, Telefono, Tipo, Estado, UsuarioSistema, FechaSistema) values (@Nombre, @Nit, @Telefono, @Tipo, @Estado, @UsuarioSistema, @FechaSistema);