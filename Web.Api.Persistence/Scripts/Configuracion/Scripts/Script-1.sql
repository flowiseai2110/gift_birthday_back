
--Conexion a la base de datos Postgres
create schema config
go
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
INSERT INTO config.empresa
(v_razon_social, v_ruc, v_direccion, v_telefono_principal, v_celular_principal, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES('EMPRESA TEST', '11111111111', 'Av Republica de panama 2343', '977777777', '977777777', true, '44836469', now(), null, null);

INSERT INTO config.empresa
(v_razon_social, v_ruc, v_direccion, v_telefono_principal, v_celular_principal, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES('Grupo gloria', '91111111199', 'Av Industrial 256', '977777777', '977777777', true, '44836469', now(), null, null);

update config.empresa set v_razon_social = 'Grupo Intercorp', v_direccion = 'Av Republica de panama 2343' where i_empresa_id = 1

select * from config.empresa;

create table empresa(
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

INSERT INTO empresa
(v_razon_social, v_ruc, v_direccion, v_telefono_principal, v_celular_principal, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES('EMPRESA TEST', '11111111111', 'Av Republica de panama 2343', '977777777', '977777777', true, '44836469', now(), null, null);

update config.empresa set v_razon_social = 'Grupo Intercorp', v_direccion = 'Av Republica de panama 2343' where i_empresa_id = 1

INSERT INTO empresa
(v_razon_social, v_ruc, v_direccion, v_telefono_principal, v_celular_principal, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES('Grupo gloria', '91111111199', 'Av Industrial 256', '977777777', '977777777', true, '44836469', now(), null, null);

select * from empresa;
update empresa set v_razon_social = 'Grupo Intercorp', v_direccion = 'Av Republica de panama 2343' where i_empresa_id = 1


INSERT INTO empresa
(v_razon_social, v_ruc, v_direccion, v_telefono_principal, v_celular_principal, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES('Prueba examen 1', '787878787', 'Av shell 958', '977777777', '977777777', true, '44836469', now(), null, null);


select * from empresa

