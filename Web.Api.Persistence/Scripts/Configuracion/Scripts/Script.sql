
select * from config.tipo_enumerado 
 
insert into config.tipo_enumerado (
	I_TIPO_ENUMERADO_ID ,
    V_CODIGO ,
    V_NOMBRE ,
    V_DESCRIPCION ,
    D_FECHA_REGISTRO ,
    V_USUARIO_REGISTRO)
    values(
    1,
    10001,
    'Colores',
    'Colores',
    now(),
    '44836469'
    )
    
insert into config.enumerado(
	I_ENUMERADO_ID int NOT NULL,
    I_TIPO_ENUMERADO_ID int NOT NULL,
    V_CODIGO varchar(200) NOT NULL,
    V_NOMBRE ,
    V_DESCRIPCION,
    B_ESTADO,
	D_FECHA_REGISTRO ,
    V_USUARIO_REGISTRO 
)values(
	1,
	1,
	'1',
	'AZUL',
	'Marca generica',
	true,
	now(),
	'44836469'
)

-- Crear la tabla "tipo_enumerado" en PostgreSQL
CREATE TABLE config.tipo_enumerado (
    I_TIPO_ENUMERADO_ID int NOT NULL,
    V_CODIGO varchar(30) NOT NULL,
    V_NOMBRE varchar(200) NOT NULL,
    V_DESCRIPCION varchar(200) NOT NULL,
    D_FECHA_REGISTRO timestamp NOT NULL,
    V_USUARIO_REGISTRO varchar(20) NOT NULL,
    D_FECHA_MODIFICACION timestamp NULL,
    V_USUARIO_MODIFICACION varchar(20) NULL
);

-- Crear clave primaria
ALTER TABLE config.tipo_enumerado ADD PRIMARY KEY (I_TIPO_ENUMERADO_ID);


-- Crear la tabla "enumerado" en PostgreSQL
CREATE TABLE config.enumerado (
    I_ENUMERADO_ID int NOT NULL,
    I_TIPO_ENUMERADO_ID int NOT NULL,
    V_CODIGO varchar(200) NOT NULL,
    V_NOMBRE text NOT NULL,
    V_DESCRIPCION text NOT NULL,
    B_ESTADO boolean NOT NULL,
	D_FECHA_REGISTRO timestamp NOT NULL,
    V_USUARIO_REGISTRO varchar(20) NOT NULL,
    D_FECHA_MODIFICACION timestamp NULL,
    V_USUARIO_MODIFICACION varchar(20) NULL
);

-- Crear clave primaria
ALTER TABLE config.enumerado ADD PRIMARY KEY (I_ENUMERADO_ID);

-- Crear clave foránea
ALTER TABLE config.enumerado ADD CONSTRAINT FK_enumerado_tipo_enumerado FOREIGN KEY (I_TIPO_ENUMERADO_ID) REFERENCES config.tipo_enumerado (I_TIPO_ENUMERADO_ID);

-- Agregar comentario a la tabla
COMMENT ON TABLE config.enumerado IS 'Configura los valores de las tablas maestras.';