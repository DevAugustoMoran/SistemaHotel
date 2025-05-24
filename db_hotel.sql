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

CREATE TABLE tbl_Pagos
(
	CodigoPago INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CodigoReserva INT,	
	Monto DECIMAL(10,2),
	Propina DECIMAL(10,2),
	Impuesto DECIMAL(10,2),
	Descuento DECIMAL(10,2),
	TotalPago DECIMAL(10,2),
	FechaPago DATETIME,
	MetodoPago VARCHAR(50),
	UsuarioSistema VARCHAR(50),
	FechaSistema DATETIME,
	Foreign key (CodigoReserva) references tbl_Reservaciones(CodigoReserva)
);

SELECT * FROM tbl_Pagos;

Insert into tbl_Pagos(CodigoReserva, Monto, Propina, Impuesto, Descuento, TotalPago, FechaPago, MetodoPago, UsuarioSistema, FechaSistema) values (@CodigoReserva, @Monto, @Propina, @Impuesto, @Descuento, @TotalPago, @FechaPago, @MetodoPago, @UsuarioSistema, @FechaSistema);

Update tbl_Pagos
set CodigoReserva = @CodigoReserva, 
Monto = @Monto,
Propina = @Propina, 
Impuesto = @Impuesto, 
Descuento = @Descuento,
TotalPago = @TotalPago,
FechaPago = @FechaPago,
MetodoPago = @MetodoPago,
UsuarioSistema = @UsuarioSistema, 
FechaSistema = @FechaSistema where CodigoPago = @CodigoPago;

CREATE TABLE tbl_Reservaciones
(
	CodigoReserva INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CodigoHuesped INT,
	CodigoHabitacion INT,
	FechaEntrada DATETIME,
	FechaSalida DATETIME,
	Total DECIMAL(10,2),
	UsuarioSistema VARCHAR(50),
	FechaSistema DATETIME,
	Foreign key (CodigoHuesped) references tbl_huespedes(CodigoHuesped),
	Foreign key (CodigoHabitacion) references tbl_Habitaciones(CodigoHabitacion)
);

SELECT * FROM tbl_Reservaciones;

Insert into tbl_Reservaciones(CodigoHuesped, CodigoHabitacion, FechaEntrada, FechaSalida, Total, UsuarioSistema, FechaSistema) values (@CodigoHuesped, @CodigoHabitacion, @FechaEntrada, @FechaSalida, @Total, @UsuarioSistema, @FechaSistema);

Update tbl_Reservaciones
set CodigoHuesped = @CodigoHuesped, 
CodigoHabitacion = @CodigoHabitacion,
FechaEntrada = @FechaEntrada, 
FechaSalida = @FechaSalida, 
Total = @Total, 
UsuarioSistema = @UsuarioSistema, 
FechaSistema = @FechaSistema where CodigoReserva = @CodigoReserva;

CREATE TABLE tbl_Habitaciones
(
	CodigoHabitacion INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Numero VARCHAR(10),
	Ubicacion VARCHAR(100),
	Tipo VARCHAR(50),
	Precio DECIMAL(10,2),
	Estado VARCHAR(20),
	UsuarioSistema VARCHAR(50),
	FechaSistema DATETIME
);

SELECT * FROM tbl_Habitaciones;

CREATE TABLE tbl_Asignaciones
(
	CodigoAsignacion INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CodigoEmpleado INT,
	CodigoHabitacion INT,
	TipoAsignacion VARCHAR(50),
	FechaAsignacion DATETIME,
	Estado VARCHAR(20),
	UsuarioSistema VARCHAR(50),
	FechaSistema DATETIME,
	Foreign key (CodigoEmpleado) references tbl_Empleados(CodigoEmpleado),
	Foreign key (CodigoHabitacion) references tbl_Habitaciones(CodigoHabitacion)
);

SELECT * FROM tbl_Asignaciones;

Insert into tbl_Asignaciones(CodigoEmpleado, CodigoHabitacion, TipoAsignacion, FechaAsignacion, Estado, UsuarioSistema, FechaSistema) values (@CodigoEmpleado, @CodigoHabitacion, @TipoAsignacion, @FechaAsignacion, @Estado, @UsuarioSistema, @FechaSistema);

Update tbl_Asignaciones
set CodigoEmpleado = @CodigoEmpleado, 
CodigoHabitacion = @CodigoHabitacion,
TipoAsignacion = @TipoAsignacion, 
FechaAsignacion = @FechaAsignacion, 
Estado = @Estado, 
UsuarioSistema = @UsuarioSistema, 
FechaSistema = @FechaSistema where CodigoAsignacion = @CodigoAsignacion;

CREATE TABLE tbl_Consumos
(
	CodigoConsumo INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CodigoReserva INT,
	CodigoServicio INT,
	Monto DECIMAL(10,2),
	FechaConsumo DATETIME,
	Estado VARCHAR(20),
	UsuarioSistema VARCHAR(50),
	FechaSistema DATETIME,
	Foreign key (CodigoReserva) references tbl_Reservaciones(CodigoReserva),
	Foreign key (CodigoServicio) references tbl_Servicios(CodigoServicio)
);

SELECT * FROM tbl_Consumos;

Insert into tbl_Consumos(CodigoReserva, CodigoServicio, Monto, FechaConsumo, Estado, UsuarioSistema, FechaSistema) values (@CodigoReserva, @CodigoServicio, @Monto, @FechaConsumo, @Estado, @UsuarioSistema, @FechaSistema);

Update tbl_Consumos
set CodigoReserva = @CodigoReserva, 
CodigoServicio = @CodigoServicio,
Monto = @Monto, 
FechaConsumo = @FechaConsumo, 
Estado = @Estado, 
UsuarioSistema = @UsuarioSistema, 
FechaSistema = @FechaSistema where CodigoConsumo = @CodigoConsumo;

CREATE TABLE tbl_Servicios
(
	CodigoServicio INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(50),
	Tipo VARCHAR(50),
	Precio DECIMAL(10,2),
	FechaVigencia DATETIME,
	FechaVencimiento DATETIME,
	Estado VARCHAR(20),
	UsuarioSistema VARCHAR(50),
	FechaSistema DATETIME
);

SELECT * FROM tbl_Servicios;

CREATE TABLE tbl_Usuarios
(
	CodigoUsuario INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CodigoEmpleado INT,
	NombreUsuario VARCHAR(50),
	Contrasena VARCHAR(50),
	Rol VARCHAR(50),
	Estado VARCHAR(50),
	UsuarioSistema VARCHAR(50),
	FechaSistema DATETIME,
	Foreign key (CodigoEmpleado) references tbl_Empleados(CodigoEmpleado)
);

SELECT * FROM tbl_Usuarios;

Insert into tbl_Usuarios(CodigoEmpleado, NombreUsuario, Contrasena, Rol, Estado, UsuarioSistema, FechaSistema) values (1, 'Emp1', '123', 'Admin', 'Activo', 'Admin', '01/01/2025');
Insert into tbl_Usuarios(CodigoEmpleado, NombreUsuario, Contrasena, Rol, Estado, UsuarioSistema, FechaSistema) values (2, 'Emp2', '123456', 'Supervisor', 'Activo', 'Admin', '01/01/2025');
Insert into tbl_Usuarios(CodigoEmpleado, NombreUsuario, Contrasena, Rol, Estado, UsuarioSistema, FechaSistema) values (@CodigoEmpleado, @NombreUsuario, @Contrasena, @Rol, @Estado, @UsuarioSistema, @FechaSistema);

Update tbl_Usuarios
set CodigoEmpleado = @CodigoEmpleado, 
NombreUsuario = @NombreUsuario,
Contrasena = @Contrasena, 
Rol = @Rol,
Estado = @Estado,
UsuarioSistema = @UsuarioSistema,
FechaSistema = @FechaSistema where CodigoUsuario = @CodigoUsuario;

CREATE TABLE tbl_PagoPlanillas
(
	CodigoPagoPlanilla INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CodigoEmpleado INT,
	FechaPago DATETIME,
	Salario DECIMAL(10,2),
	Bono DECIMAL(10,2),
	HorasExtras INT,
	MontoTotal DECIMAL(10,2),
	Estado VARCHAR(20),
	UsuarioSistema VARCHAR(50),
	FechaSistema DATETIME,
	Foreign key (CodigoEmpleado) references tbl_Empleados(CodigoEmpleado)
);

SELECT * FROM tbl_PagoPlanillas;

Insert into tbl_PagoPlanillas(CodigoEmpleado, FechaPago, Salario, Bono, HorasExtras, MontoTotal, Estado, UsuarioSistema, FechaSistema) values (@CodigoEmpleado, @FechaPago, @Salario, @Bono, @HorasExtras, @MontoTotal, @Estado, @UsuarioSistema, @FechaSistema);

Update tbl_PagoPlanillas
set CodigoEmpleado = @CodigoEmpleado, 
FechaPago = @FechaPago,
Salario = @Salario, 
Bono = @Bono,
HorasExtras = @HorasExtras,
MontoTotal = @MontoTotal,
Estado = @Estado, 
UsuarioSistema = @UsuarioSistema, 
FechaSistema = @FechaSistema where CodigoPagoPlanilla = @CodigoPagoPlanilla;

CREATE TABLE tbl_Empleados
(
	CodigoEmpleado INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(50),
	Cargo VARCHAR(50),
	Salario DECIMAL(10,2),
	FechaContratacion DATETIME,
	Estado VARCHAR(20),
	UsuarioSistema VARCHAR(50),
	FechaSistema DATETIME
);

SELECT * FROM tbl_Empleados;

Insert into tbl_Empleados(Nombre, Cargo, Salario, FechaContratacion, Estado, UsuarioSistema, FechaSistema) values ('Empleado 1', 'Gerente', 35000, '01/01/2025', 'Activo', 'Admin', '01/01/2025');
Insert into tbl_Empleados(Nombre, Cargo, Salario, FechaContratacion, Estado, UsuarioSistema, FechaSistema) values ('Empleado 2', 'Supervisor', 15000, '01/01/2025', 'Activo', 'Supervisor', '01/01/2025');

Select CodigoHabitacion, Tipo from tbl_Habitaciones;

Select * from tbl_Habitaciones;