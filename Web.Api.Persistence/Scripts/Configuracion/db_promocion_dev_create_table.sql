create schema config;
create schema proceso;
create schema administrador;


/*Estos son los usuarios encargados de crear los administradores*/
create table config.tipo_enumerado(
	I_TIPO_ENUMERADO_ID INTEGER NOT NULL,
	V_CODIGO varchar(30) NOT NULL,
	V_NOMBRE varchar(200) NOT NULL,
	V_DESCRIPCION varchar(200) NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL 
	)
	
alter table config.tipo_enumerado add constraint PK_ENUMERADO primary key(I_TIPO_ENUMERADO_ID) ;

INSERT INTO config.tipo_enumerado
(i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(10, 'TIPO_DOCUMENTO_IDENTIFICACION', 'TIPO_IDENTIFICACION', 'tipo de documento de identificacion dni, carnet, passporte etc', 'ADMIN', now(), NULL, NULL);



create table config.enumerado(
	I_ENUMERADO_ID INTEGER NOT NULL,
	I_TIPO_ENUMERADO_ID INTEGER NOT NULL,
	V_CODIGO varchar(200) NOT NULL,
	V_NOMBRE varchar(750) NOT NULL,
	V_DESCRIPCION varchar(750) NOT NULL,
	B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL 
)

alter table config.enumerado add constraint FK_ENUMERADO_TIPO_ENUMERADO foreign key(I_TIPO_ENUMERADO_ID) references  config.tipo_enumerado(I_TIPO_ENUMERADO_ID);

delete from config.enumerado

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(100001, 10, '01', 'DNI', 'LIBRETA ELECTORAL O DNI', true, 'ADMIN', now(), null, null);

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(100002, 10, '04', 'CARNET EXT.', 'CARNET DE EXTRANJERIA', true, 'ADMIN', now(), null, null);

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(100003, 10, '06', 'RUC', 'REG. UNICO DE CONTRIBUYENTES', true, 'ADMIN', now(), null, null);

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(100004, 10, '07', 'PASAPORTE', 'PASAPORTE', true, 'ADMIN', now(), null, null);

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(100005, 10, '11', 'P. NAC.', 'PART. DE NACIMIENTO-IDENTIDAD', true, 'ADMIN', now(), null, null);

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(100006, 10, '00', 'OTROS', 'OTROS', true, 'ADMIN', now(), null, null);

select * from config.enumerado e 


create table administrador.sa(
	I_SA_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 		
	I_PERSONA_ID INTEGER,
 	V_USUARIO VARCHAR(50),
 	V_CONTRASENIA VARCHAR(750),
 	V_TIPO_USUARIO VARCHAR(2),
    B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL 
)

alter table administrador.usuario add constraint FK_SA_PERSONA foreign key(I_PERSONA_ID) references  administrador.persona(I_PERSONA_ID);

/*Este registra las empresas que son los clientes de la empresa*/
create table administrador.persona(
	I_PERSONA_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 		
	V_NUMERO_DOCUMENTO VARCHAR(25),
	V_TIPO_DOCUMENTO VARCHAR(2),
	V_NOMBRE VARCHAR(50),
	V_APELLIDO_PATERNO VARCHAR(100),
	V_APELLIDO_MATERNO VARCHAR(100),
	D_FECHA_NACIMIENTO  DATE not NULL,
	V_CELULAR VARCHAR(16),
	V_CORREO_ELECTRONICO VARCHAR(120),
    B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL 
)

create table administrador.rol(
	I_ROL_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 		
	V_NOMBRE_ROL VARCHAR(150),
	V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL 
)

--drop table administrador.usuario
create table administrador.usuario(
	I_USUARIO_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 		
	I_PERSONA_ID INTEGER,
 	V_USUARIO VARCHAR(50),
 	V_CONTRASENIA VARCHAR(750),
 	V_TIPO_USUARIO VARCHAR(2),
    B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL 
)

alter table administrador.usuario add constraint FK_USUARIO_PERSONA foreign key(I_PERSONA_ID) references  administrador.persona(I_PERSONA_ID);


create table administrador.usuario_rol(
	I_USUARIO_ROL_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 		
	I_USUARIO_ID INTEGER not NULL,
	I_ROL_ID INTEGER not null,
	B_ACTIVO boolean NOT NULL,
	V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL 
)

alter table administrador.usuario_rol add constraint FK_USUARIO_ROL foreign key(I_EMPRESA_ID) references  config.empresa(I_EMPRESA_ID);




select e.i_empresa_id ,e.v_razon_social ,e.v_ruc ,e.v_direccion ,e.v_telefono_principal ,e.v_celular_principal  from config.empresa e 
where e.b_activo = true order by v_razon_social asc
 
select * from config.empresa

create table config.empresa(
	I_EMPRESA_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	V_RAZON_SOCIAL VARCHAR(150),
	V_RUC VARCHAR(25),
	V_DIRECCION VARCHAR(350),
	V_TELEFONO_PRINCIPAL VARCHAR(16),
	V_CELULAR_PRINCIPAL VARCHAR(16),
	B_ACTIVO boolean NOT NULL,
	V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL
);
 
SELECT  *
FROM config.local_comercial;

create table config.local_comercial(
	I_LOCAL_COMERCIAL_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 		
	I_EMPRESA_ID INTEGER,
	V_NOMBRE_COMERCIAL VARCHAR(350),
	V_DIRECCION VARCHAR(350),
	V_TELEFONO_PRINCIPAL VARCHAR(16),
	V_CELULAR_PRINCIPAL VARCHAR(16),
	T_HORA_INICIO TIME,
	T_HORA_FIN TIME, 
	V_TIPO_HORARIO VARCHAR(2), -- ALMACENA EL TIPO DE HORARIO SI ES 24 HORAS O PARCIAL
	B_ACTIVO boolean NOT NULL,
	V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL
);

alter table config.local_comercial add constraint FK_EMPRESA foreign key(I_EMPRESA_ID) references  config.empresa(I_EMPRESA_ID);

create table proceso.cliente(
	I_CLIENTE_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 		
	I_LOCAL_COMERCIAL_ID INTEGER, 
	V_TIPO_CLIENTE VARCHAR(2),
	V_NUMERO_DOCUMENTO VARCHAR(25),
	V_TIPO_DOCUMENTO VARCHAR(2),
	V_NOMBRE VARCHAR(50),
	V_APELLIDO_PATERNO VARCHAR(100),
	V_APELLIDO_MATERNO VARCHAR(100),
	D_FECHA_NACIMIENTO DATE not NULL,
	V_CELULAR VARCHAR(16),
	V_CORREO_ELECTRONICO VARCHAR(16),
    B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL
);

alter table proceso.cliente add constraint FK_LOCAL_COMERCIAL foreign key(I_LOCAL_COMERCIAL_ID) references  config.local_comercial(I_LOCAL_COMERCIAL_ID);


SELECT *
FROM config.usuario
where i_usuario_id ;

drop table config.usuario
create table config.usuario(
	I_USUARIO_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 		
	I_LOCAL_COMERCIAL_ID INTEGER, 
	V_NUMERO_DOCUMENTO VARCHAR(25),
	V_TIPO_DOCUMENTO VARCHAR(2),
	V_NOMBRE VARCHAR(50),
	V_APELLIDO_PATERNO VARCHAR(100),
	V_APELLIDO_MATERNO VARCHAR(100),
	D_FECHA_NACIMIENTO  DATE not NULL,
	V_CELULAR VARCHAR(16),
	V_CORREO_ELECTRONICO VARCHAR(120),
    B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL
);

alter table config.usuario add constraint FK_LOCAL_COMERCIAL foreign key(I_LOCAL_COMERCIAL_ID) references  config.local_comercial(I_LOCAL_COMERCIAL_ID);

create table proceso.promocion(
	I_PROMOCION_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	I_LOCAL_COMERCIAL_ID INTEGER,	
	V_TITULO VARCHAR(250),
	V_DESCRIPCION VARCHAR(250),
	V_ESTADO VARCHAR(2),
	B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL
);
 
alter table proceso.promocion add constraint FK_LOCAL_COMERCIAL foreign key(I_LOCAL_COMERCIAL_ID) references  config.local_comercial(I_LOCAL_COMERCIAL_ID);
 
create table proceso.cartilla(
	I_CARTILLA_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	I_LOCAL_COMERCIAL_ID INTEGER,	
	V_CODIGO VARCHAR(50),
	V_TITULO VARCHAR(250),
	V_DESCRIPCION VARCHAR(250),
	I_CANTIDAD_SELLO INTEGER,
	I_CANTIDAD_PROMOCION INTEGER,
	V_ESTADO VARCHAR(2),
	B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL
);

alter table proceso.cartilla add constraint FK_LOCAL_COMERCIAL foreign key(I_LOCAL_COMERCIAL_ID) references  config.local_comercial(I_LOCAL_COMERCIAL_ID);
  
create table proceso.cartilla_promocion(
	I_CARTILLA_PROMOCION_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	I_CARTILLA_ID INTEGER,
	I_PROMOCION_ID INTEGER,
	I_LOCAL_COMERCIAL_ID INTEGER,	
	D_FECHA_PROMOCION_INICIO TIMESTAMP not NULL,
	D_FECHA_PROMOCION_FIN TIMESTAMP not NULL,
	V_ESTADO VARCHAR(2),
	B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL
);

alter table proceso.cartilla_promocion add constraint FK_LOCAL_COMERCIAL foreign key(I_LOCAL_COMERCIAL_ID) references  config.local_comercial(I_LOCAL_COMERCIAL_ID);
alter table proceso.cartilla_promocion add constraint FK_PROMOCION foreign key(I_PROMOCION_ID) references  proceso.promocion(I_PROMOCION_ID);
alter table proceso.cartilla_promocion add constraint FK_CARTILLA foreign key(I_CARTILLA_ID) references  proceso.cartilla(I_CARTILLA_ID);
 
create table proceso.cliente_cartilla(
	I_CLIENTE_CARTILLA_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,	
	I_CLIENTE_ID INTEGER,
	I_CARTILLA_PROMOCION_ID INTEGER,
	I_LOCAL_COMERCIAL_ID INTEGER,	
	I_NUMERO_PROMOCION INTEGER,
	I_NUMERO_SELLO INTEGER,
	V_ESTADO VARCHAR(2),
	B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL
);

alter table proceso.cliente_cartilla add constraint FK_LOCAL_COMERCIAL foreign key(I_LOCAL_COMERCIAL_ID) references  config.local_comercial(I_LOCAL_COMERCIAL_ID);
alter table proceso.cliente_cartilla add constraint FK_CLIENTE foreign key(I_CLIENTE_ID) references  proceso.cliente(I_CLIENTE_ID);
alter table proceso.cliente_cartilla add constraint FK_CARTILLA_PROMOCION foreign key(I_CARTILLA_PROMOCION_ID) references  proceso.cartilla_promocion(I_CARTILLA_PROMOCION_ID);
 
create table proceso.cliente_cartilla_detalle(
	I_CLIENTE_CARTILLA_DETALLE_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,	
	I_CLIENTE_CARTILLA_ID INTEGER, 
	I_NUMERO_PROMOCION INTEGER,
	I_NUMERO_SELLO INTEGER,
	I_LOCAL_COMERCIAL_ID INTEGER,	
	V_REFERENCIA_PAGO VARCHAR(16),
	V_ESTADO VARCHAR(2),
	B_ACTIVO boolean NOT NULL,
    V_USUARIO_REGISTRO VARCHAR(20) NOT NULL,
    D_FECHA_REGISTRO TIMESTAMP not NULL,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL
);

alter table proceso.cliente_cartilla_detalle add constraint FK_LOCAL_COMERCIAL foreign key(I_LOCAL_COMERCIAL_ID) references  config.local_comercial(I_LOCAL_COMERCIAL_ID);
alter table proceso.cliente_cartilla add constraint FK_CLIENTE_CARTILLA foreign key(I_CLIENTE_CARTILLA_ID) references  proceso.cliente_cartilla(I_CLIENTE_CARTILLA_ID);


select * from proceso.cliente_cartilla_detalle


drop table proceso.cliente_cartilla_detalle
drop table proceso.cliente_cartilla
drop table proceso.cartilla_promocion
drop table proceso.cartilla
drop table proceso.promocion
drop table config.usuario
drop table proceso.cliente
drop table config.local_comercial


/*
 * Insercion de usuario de configuracion de empresa
 * */

INSERT INTO administrador.persona
(v_numero_documento, v_tipo_documento, v_nombre, v_apellido_paterno, v_apellido_materno, d_fecha_nacimiento, v_celular, v_correo_electronico, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES('44836469', '01', 'DIEGO ARMANDO JESUS', 'LUNA', 'QUINTO', '21/10/1987', '957625308', 'diegoarmando21.10@gmail.com', true, 'ADMIN', NOW(), NULL, NULL);

select * from administrador.persona p inner join administrador.sa s on p.i_persona_id = s.i_persona_id 

INSERT INTO administrador.sa
(i_persona_id, v_usuario, v_contrasenia, v_tipo_usuario, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(1, 'sa', 'sa', '1', true, 'CORE', NOW(), NULL, NULL);



