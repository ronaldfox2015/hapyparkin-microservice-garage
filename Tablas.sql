-- DROP DATABASE BDHappyParking;
CREATE DATABASE BDHappyParking;
use BDHappyParking;

create table tbusuario
(
	idUsuario				serial primary KEY,
    correo					varchar(100) NOT NULL UNIQUE, -- Correo o Numero celular
    clave 					varchar(255) NOT NULL,
    fechaCreacion 			Datetime NOT NULL DEFAULT current_timestamp(),
    idUsuarioModificacion 	int,
    fechaActualizacion		datetime,
    estado 					int NOT NULL DEFAULT 1
);

CREATE TABLE tbpersona
(
	idPersona 				serial PRIMARY KEY,
    idUsuario 				int NOT NULL references tbusuario(idusuario),
    nombres	 				varchar(50), -- PJ:Nombre comercial PN: Nombre
    apellidos 				varchar(50),
    razonSocial 			varchar(80),
    idTipoDocumento 		int,  -- 1: DNI, 2:RUC, 3:CARNET EXT, 4: PASAPORTE
    numeroDocumento 		varchar(20),
    numeroCelular 			varchar(15),
    direccion 				Varchar(200),
    logo 					varchar(255),
    fechaCreacion 			Datetime NOT NULL DEFAULT current_timestamp(),
    idUsuarioModificacion 	int,
    fechaActualizacion 		datetime,
    estado 					int NOT NULL DEFAULT 1
);

CREATE TABLE tbrolpersona
(
	idRolPersona 			serial PRIMARY KEY,
	idPersona 				int not null references tbpersona(idpersona),
    idUsuario				int,
    idRol 					int NOT NULL, -- Cliente, Empresa
    fechaCreacion 			Datetime NOT NULL DEFAULT current_timestamp(),
    idUsuarioModificacion 	integer,
    fechaActualizacion 		datetime,
    estado 					int NOT NULL DEFAULT 1
);

CREATE TABLE tbcochera
(
	idCochera 				serial PRIMARY KEY,
    idPersona 				int not null references tbpersona(idpersona),
    idUbicacion 			int,
    nombre 					varchar(200),
    direccion 				varchar(200),
    capacidadVehiculos 		int,
    banner 					varchar(500),
    condiciones 			varchar(500),
    diasAntelacionReserva 	int,
    horasAntelacionReserva 	int,
    tiempoTolerancia		time,
    fechaCreacion 			Datetime NOT NULL DEFAULT current_timestamp(),
    idUsuarioModificacion	int,
    fechaActualizacion 		datetime,
    estado 					int NOT NULL DEFAULT 1
);

CREATE TABLE tbprecioCochera
(
	idPrecioCochera			int PRIMARY KEY,
    idCochera 				int NOT NULL references tbcochera(idcochera),
    tipoTarifa	 			int,-- Dia Normal, Fin de Semana, Feriado
    diaSemana 				int,
    horaInicio 				time,
    HoraFin					time,
    precioPorHora 			decimal(8,2),
    fechaCreacion 			Datetime NOT NULL DEFAULT current_timestamp(),
    idUsuarioModificacion 	int,
    fechaActualizacion 		datetime,
    estado 					int NOT NULL DEFAULT 1
);

CREATE TABLE tbvehiculo
(
	idvehiculo 				serial PRIMARY KEY,
	idPersona 				int not null references tbpersona(idpersona),
    marca 					varchar(30),
    modelo 					varchar(30),
    color 					varchar(15),
    numeroPlaca 			varchar(20) NOT NULL,
    descripcion 			varchar(50), 
    fechaCreacion 			Datetime NOT NULL DEFAULT current_timestamp(),
    idUsuarioModificacion 	int,
    fechaActualizacion 		datetime,
    estado 					int NOT NULL DEFAULT 1
);

CREATE TABLE tbreserva
(
	idreserva 				serial PRIMARY KEY,
	idcochera 				int NOT NULL references tbcochera(idcochera),
    idvehiculo				int NOT NULL references tbvehiculo(idvehiculo),
    fechaReserva 			DATE NOT NULL,
    horaInicioReserva		TIME NOT NULL,
    horaFinReserva			TIME,
    precioPorHora			decimal(8,2) NOT NULL,
    TotalHorasReserva		int NOT NULL,
    totalAPagar				decimal(8,2) NOT NULL,
    fechaCreacion 			Datetime NOT NULL DEFAULT current_timestamp(),
    idUsuarioModificacion 	int,
    fechaActualizacion 		datetime,
    estado 					int NOT NULL DEFAULT 1
);

CREATE TABLE tbCommprobantePago
(
	idComprobantePago		serial PRIMARY KEY,
	idreserva				int  NOT NULL references tbreserva(idreserva) ,
    idtipodocumento			int NOT NULL, -- Boleta, Factura, Recibo
    numeroDocumento			varchar(10),
    idFormaPago				int NOT NULL,
    fechaPago				date NOT NULL,
    horaPago				time,
    totalPago				decimal(10,2),
    fechaCreacion 			Datetime NOT NULL DEFAULT current_timestamp(),
    idUsuarioModificacion	int,
    fechaActualizacion 		datetime,
    estado 					int NOT NULL DEFAULT 1
);