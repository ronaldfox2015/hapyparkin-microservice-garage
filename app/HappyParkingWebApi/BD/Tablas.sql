-- DROP DATABASE BDHappyParking;
CREATE DATABASE BDHappyParking;
use BDHappyParking;

create table tbusuario
(
	idUsuario	serial,
    correo	varchar(100) NOT NULL UNIQUE, -- Correo o Numero celular
    clave 	varchar(255) NOT NULL,
--  	idrol	int,
--     nombre varchar(50),
--     apellido varchar(50),
    fechaCreacion Datetime NOT NULL,
    idUsuarioModificacion integer,
    fechaActualizacion datetime,
    estado int NOT NULL
);

CREATE TABLE tbpersona
(
	idPersona serial,
    idUsuario int references tbusuario(idusuario),
    nombres varchar(50), -- PJ:Nombre comercial PN: Nombre
    apellidos varchar(50),
    RazonSocial varchar(80),
    tipoDocumento int,  -- 1: DNI, 2:RUC, 3:CARNET EXT, 4: PASAPORTE
    numeroDocumento varchar(20),
    numeroCelular varchar(15),
    direccion Varchar(200),
    logo varchar(255),
    fechaCreacion Datetime,
    idUsuarioModificacion integer,
    fechaActualizacion datetime,
    estado int
);

CREATE TABLE tbrolpersona
(
	idRolPersona 	serial,
	idPersona 		int not null references tbpersona(idpersona),
    idUsuario		int,
    idRol 			int, -- Cliente, Empresa
    fechaCreacion 	Datetime,
    idUsuarioModificacion integer,
    fechaActualizacion datetime,
    estado 			int
);

CREATE TABLE tbcochera
(
	idCochera serial,
    idPersona int not null references tbpersona(idpersona),
    idUbicacion int,
    nombre varchar(200),
    direccion varchar(200),
    CapacidadVehiculos int,
    banner varchar(500),
    condiciones varchar(500),
    diasAntelacionReserva int,
    horasAntelacionReserva int,
    fechaCreacion Datetime,
    idUsuarioModificacion int,
    fechaActualizacion datetime,
    estado int
);

CREATE TABLE tbprecioCochera
(
	idPrecioCochera	int,
    idCochera int,
    tipoTarifa int,-- Dia Normal, Fin de Semana, Feriado
    diaSemana int,
    horaInicio time,
    HoraFin	time,
    precioPorHora decimal(8,2),
    fechaCreacion Datetime,
    idUsuarioModificacion int,
    fechaActualizacion datetime,
    estado int
);

CREATE TABLE tbvehiculo
(
	idvehiculo serial,
	idPersona int not null references tbpersona(idpersona),
    marca varchar(30),
    modelo varchar(30),
    color varchar(15),
    numeroPlaca varchar(20),
    descripcion varchar(50), 
    fechaCreacion Datetime,
    idUsuarioModificacion int,
    fechaActualizacion datetime,
    estado int
);

