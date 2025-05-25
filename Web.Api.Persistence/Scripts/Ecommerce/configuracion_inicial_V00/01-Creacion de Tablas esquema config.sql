-- Crear el esquema "config" si no existe
CREATE SCHEMA IF NOT EXISTS config;
 
 
 create table config.online_shop(
    I_ONLINE_SHOP_ID int GENERATED ALWAYS AS IDENTITY, 
	I_ANIO int NOT NULL,
	I_PERIODO int NOT NULL,
	V_NOMBRE varchar(200) NOT NULL,
	V_BASES_DOCUMENTACION varchar(300) NOT NULL,
	D_BASES_PUBLICACION timestamp NOT NULL,
	D_REGISTRO timestamp NOT NULL,
	V_USR_REGISTRO varchar(20) NOT NULL,
	D_MODIFICACION timestamp NULL,
	V_USR_MODIFICACION varchar(20) NULL
 );


ALTER TABLE config.online_shop
ADD CONSTRAINT nombre_restriccion PRIMARY KEY (I_ONLINE_SHOP_ID);
  
-- Crear la tabla "momento" en PostgreSQL
CREATE TABLE config.momento (
    I_MOMENTO_ID serial PRIMARY key,  
    I_ONLINE_SHOP_ID int NOT NULL,
    V_NOMBRE varchar(200) NOT NULL,
    V_CODIGO varchar(20) NOT NULL,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL
);
 
-- Crear restricción de clave foránea
ALTER TABLE config.momento ADD CONSTRAINT R_5 FOREIGN KEY (I_ONLINE_SHOP_ID) REFERENCES config.online_shop (I_ONLINE_SHOP_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.momento.I_MOMENTO_ID IS 'Identificador del momento';
COMMENT ON COLUMN config.momento.I_ONLINE_SHOP_ID IS 'Identificador de la tienda online';
COMMENT ON COLUMN config.momento.V_NOMBRE IS 'Nombre del momento';
COMMENT ON COLUMN config.momento.V_CODIGO IS 'Código único del momento';
COMMENT ON COLUMN config.momento.D_REGISTRO IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.momento.V_USR_REGISTRO IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.momento.D_MODIFICACION IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.momento.V_USR_MODIFICACION IS 'Usuario que modifica el registro';

-- Agregar comentario a la tabla
COMMENT ON TABLE config.momento IS 'Configura los momentos de una tienda online.';
 
-- Crear la tabla "etapa" en PostgreSQL
CREATE TABLE config.etapa (
    I_ETAPA_ID serial,
    V_NOMBRE varchar(200) NOT NULL,
    V_CODIGO varchar(100) NOT NULL,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL
);

-- Crear clave primaria
ALTER TABLE config.etapa ADD PRIMARY KEY (I_ETAPA_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.etapa.I_ETAPA_ID IS 'Identificador de la etapa';
COMMENT ON COLUMN config.etapa.V_NOMBRE IS 'Nombre de la etapa';
COMMENT ON COLUMN config.etapa.V_CODIGO IS 'Código único de la etapa';
COMMENT ON COLUMN config.etapa.D_REGISTRO IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.etapa.V_USR_REGISTRO IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.etapa.D_MODIFICACION IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.etapa.V_USR_MODIFICACION IS 'Usuario que modifica el registro';

-- Agregar comentario a la tabla
COMMENT ON TABLE config.etapa IS 'Registra la lista de etapas que puede incluir un proceso de postulación.';



-- Crear la tabla "modulo" en PostgreSQL
CREATE TABLE config.modulo (
    I_MODULO_ID serial,
    I_MOMENTO_ID int NOT NULL,
    I_ETAPA_ID int NOT NULL,
    U_MODULO_TOKEN uuid NOT NULL,
    V_NOMBRE varchar(200) NOT NULL,
    B_OBLIGATORIO boolean NOT NULL,
    B_ESTADO boolean NOT NULL,
    I_SECUENCIA smallint NOT NULL,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL,
    I_MODULO_ID_PADRE int NULL
);

-- Crear clave primaria
ALTER TABLE config.modulo ADD PRIMARY KEY (I_MODULO_ID);

-- Crear restricciones de clave foránea
ALTER TABLE config.modulo ADD CONSTRAINT R_2 FOREIGN KEY (I_MOMENTO_ID) REFERENCES config.momento (I_MOMENTO_ID);
ALTER TABLE config.modulo ADD CONSTRAINT R_3 FOREIGN KEY (I_ETAPA_ID) REFERENCES config.etapa (I_ETAPA_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.modulo.I_MODULO_ID IS 'Identificador del módulo';
COMMENT ON COLUMN config.modulo.I_MOMENTO_ID IS 'Identificador del momento';
COMMENT ON COLUMN config.modulo.I_ETAPA_ID IS 'Identificador de la etapa';
COMMENT ON COLUMN config.modulo.U_MODULO_TOKEN IS 'Token único del módulo - KEY para el aplicativo cliente';
COMMENT ON COLUMN config.modulo.V_NOMBRE IS 'Nombre del módulo';
COMMENT ON COLUMN config.modulo.B_OBLIGATORIO IS 'Condición de obligatorio';
COMMENT ON COLUMN config.modulo.B_ESTADO IS 'Estado del módulo';
COMMENT ON COLUMN config.modulo.I_SECUENCIA IS 'Secuencia dentro del proceso de postulación';
COMMENT ON COLUMN config.modulo.D_REGISTRO IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.modulo.V_USR_REGISTRO IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.modulo.D_MODIFICACION IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.modulo.V_USR_MODIFICACION IS 'Usuario que modifica el registro';

-- Agregar comentario a la tabla
COMMENT ON TABLE config.modulo IS 'Configura los módulos (etapas) que incluyen un proceso de postulación y por los que deberá pasar el participante a un concurso de beca.';

 
-- Crear la tabla "cronograma" en PostgreSQL
CREATE TABLE config.cronograma (
    I_CRONOGRAMA_ID serial,
    I_MODULO_ID int NOT NULL,
    D_INICIO timestamp NOT NULL,
    D_TERMINO timestamp NOT NULL,
    D_REVERSION timestamp NOT NULL,
    V_DOCUMENTACION text NOT NULL,
    V_CONFIGURACION text NOT NULL,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL,
    B_ASIGNACION_AUTOMATICA boolean
);

-- Crear clave primaria
ALTER TABLE config.cronograma ADD PRIMARY KEY (I_CRONOGRAMA_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.cronograma.I_CRONOGRAMA_ID IS 'Identificador del cronograma';
COMMENT ON COLUMN config.cronograma.I_MODULO_ID IS 'Identificador del módulo';
COMMENT ON COLUMN config.cronograma.D_INICIO IS 'Fecha de apertura del módulo';
COMMENT ON COLUMN config.cronograma.D_TERMINO IS 'Fecha de cierre del módulo';
COMMENT ON COLUMN config.cronograma.D_REVERSION IS 'Fecha límite para reversiones dentro del módulo';
COMMENT ON COLUMN config.cronograma.V_DOCUMENTACION IS 'Sustento para apertura del módulo';
COMMENT ON COLUMN config.cronograma.V_CONFIGURACION IS 'JSON de configuración del módulo';
COMMENT ON COLUMN config.cronograma.D_REGISTRO IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.cronograma.V_USR_REGISTRO IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.cronograma.D_MODIFICACION IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.cronograma.V_USR_MODIFICACION IS 'Usuario que modifica el registro';
COMMENT ON COLUMN config.cronograma.B_ASIGNACION_AUTOMATICA IS 'Indicador de asignación automática';

-- Agregar comentario a la tabla
COMMENT ON TABLE config.cronograma IS 'Configura los cronogramas de los módulos de cada uno de los concursos de becas.';


 
-- Crear la tabla "estado" en PostgreSQL
CREATE TABLE config.estado (
    I_ESTADO_ID int NOT NULL,
    I_ETAPA_ID int NOT NULL,
    V_NOMBRE varchar(200) NOT NULL,
    I_ORDEN int NOT NULL,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL
);

-- Crear clave primaria
ALTER TABLE config.estado ADD PRIMARY KEY (I_ESTADO_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.estado.I_ESTADO_ID IS 'Identificador del estado';
COMMENT ON COLUMN config.estado.I_ETAPA_ID IS 'Identificador de la etapa';
COMMENT ON COLUMN config.estado.V_NOMBRE IS 'Nombre del estado';
COMMENT ON COLUMN config.estado.I_ORDEN IS 'Orden del estado dentro de la etapa';
COMMENT ON COLUMN config.estado.D_REGISTRO IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.estado.V_USR_REGISTRO IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.estado.D_MODIFICACION IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.estado.V_USR_MODIFICACION IS 'Usuario que modifica el registro';

-- Crear clave foránea
ALTER TABLE config.estado ADD CONSTRAINT FK_estado_etapa FOREIGN KEY (I_ETAPA_ID) REFERENCES config.etapa (I_ETAPA_ID);

-- Agregar comentario a la tabla
COMMENT ON TABLE config.estado IS 'Configura los estados en los que podrá encontrarse un participante dentro de un módulo (etapa) del proceso de postulación.';


 
-- Crear la tabla "tipo_enumerado" en PostgreSQL
CREATE TABLE config.tipo_enumerado (
    I_TIPO_ENUMERADO_ID int NOT NULL,
    V_CODIGO varchar(30) NOT NULL,
    V_NOMBRE varchar(200) NOT NULL,
    V_DESCRIPCION varchar(200) NOT NULL,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL
);

-- Crear clave primaria
ALTER TABLE config.tipo_enumerado ADD PRIMARY KEY (I_TIPO_ENUMERADO_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.tipo_enumerado.I_TIPO_ENUMERADO_ID IS 'Identificador de la tabla';
COMMENT ON COLUMN config.tipo_enumerado.V_CODIGO IS 'Código que identifica al tipo de enumerado';
COMMENT ON COLUMN config.tipo_enumerado.V_NOMBRE IS 'Tipo de enumerado';
COMMENT ON COLUMN config.tipo_enumerado.V_DESCRIPCION IS 'Detalle del tipo de enumerado';
COMMENT ON COLUMN config.tipo_enumerado.D_REGISTRO IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.tipo_enumerado.V_USR_REGISTRO IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.tipo_enumerado.D_MODIFICACION IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.tipo_enumerado.V_USR_MODIFICACION IS 'Usuario que modifica el registro';

-- Agregar comentario a la tabla
COMMENT ON TABLE config.tipo_enumerado IS 'Configura las tablas maestras.';


-- Crear la tabla "enumerado" en PostgreSQL
CREATE TABLE config.enumerado (
    I_ENUMERADO_ID int NOT NULL,
    I_TIPO_ENUMERADO_ID int NOT NULL,
    V_CODIGO varchar(200) NOT NULL,
    V_NOMBRE text NOT NULL,
    V_DESCRIPCION text NOT NULL,
    B_ESTADO boolean NOT NULL,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL
);

-- Crear clave primaria
ALTER TABLE config.enumerado ADD PRIMARY KEY (I_ENUMERADO_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.enumerado.I_ENUMERADO_ID IS 'Identificador del enumerado';
COMMENT ON COLUMN config.enumerado.I_TIPO_ENUMERADO_ID IS 'Identificador del tipo de enumerado';
COMMENT ON COLUMN config.enumerado.V_CODIGO IS 'Código del enumerado';
COMMENT ON COLUMN config.enumerado.V_NOMBRE IS 'Nombre del enumerado';
COMMENT ON COLUMN config.enumerado.V_DESCRIPCION IS 'Descripción del enumerado';
COMMENT ON COLUMN config.enumerado.B_ESTADO IS 'Estado del enumerado';
COMMENT ON COLUMN config.enumerado.D_REGISTRO IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.enumerado.V_USR_REGISTRO IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.enumerado.D_MODIFICACION IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.enumerado.V_USR_MODIFICACION IS 'Usuario que modifica el registro';

-- Crear clave foránea
ALTER TABLE config.enumerado ADD CONSTRAINT FK_enumerado_tipo_enumerado FOREIGN KEY (I_TIPO_ENUMERADO_ID) REFERENCES config.tipo_enumerado (I_TIPO_ENUMERADO_ID);

-- Agregar comentario a la tabla
COMMENT ON TABLE config.enumerado IS 'Configura los valores de las tablas maestras.';


 
-- Crear la tabla "paso" en PostgreSQL
CREATE TABLE config.paso (
    I_PASO_ID serial NOT NULL,
    I_MODULO_ID int NOT NULL,
    I_ORDEN int NOT NULL,
    V_NOMBRE varchar(200) NOT NULL,
    V_RUTA varchar(250) NOT NULL,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL
);

-- Crear clave primaria
ALTER TABLE config.paso ADD PRIMARY KEY (I_PASO_ID);

-- Agregar clave foránea
ALTER TABLE config.paso ADD CONSTRAINT FK_paso_modulo FOREIGN KEY (I_MODULO_ID)
REFERENCES config.modulo (I_MODULO_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.paso.I_PASO_ID IS 'Identificador de la sección';
COMMENT ON COLUMN config.paso.I_MODULO_ID IS 'Identificador del módulo';
COMMENT ON COLUMN config.paso.I_ORDEN IS 'Orden del paso';
COMMENT ON COLUMN config.paso.V_NOMBRE IS 'Nombre del paso';
COMMENT ON COLUMN config.paso.V_RUTA IS 'Url del paso en la aplicación cliente';
COMMENT ON COLUMN config.paso.D_REGISTRO IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.paso.V_USR_REGISTRO IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.paso.D_MODIFICACION IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.paso.V_USR_MODIFICACION IS 'Usuario que modifica el registro';

-- Agregar comentario a la tabla
COMMENT ON TABLE config.paso IS 'Configura los pasos que debe completar el participante dentro de un módulo.';
 

-- Crear la tabla "seccion" en PostgreSQL
CREATE TABLE config.seccion (
    I_SECCION_ID serial NOT NULL,
    I_PASO_ID int NOT NULL,
    I_ORDEN int NOT NULL,
    V_NOMBRE varchar(200) NOT NULL,
    V_CODIGO varchar(200) NOT NULL,
    V_TYPE varchar(200) NOT NULL,
    B_OBLIGATORIO boolean NOT NULL,
    B_ESPECIFICO boolean NOT NULL,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL
);

-- Crear clave primaria
ALTER TABLE config.seccion ADD PRIMARY KEY (I_SECCION_ID);

-- Agregar clave foránea
ALTER TABLE config.seccion ADD CONSTRAINT FK_seccion_paso FOREIGN KEY (I_PASO_ID)
REFERENCES config.paso (I_PASO_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.seccion.I_SECCION_ID IS 'Identificador de la tabla';
COMMENT ON COLUMN config.seccion.I_PASO_ID IS 'Identificador del paso';
COMMENT ON COLUMN config.seccion.I_ORDEN IS 'Orden de la sección';
COMMENT ON COLUMN config.seccion.V_NOMBRE IS 'Nombre de la sección';
COMMENT ON COLUMN config.seccion.V_CODIGO IS 'Código de la sección que será utilizado para consultar la sección de la vista';
COMMENT ON COLUMN config.seccion.V_TYPE IS 'Nombre de la clase que implementa la sección';
COMMENT ON COLUMN config.seccion.B_OBLIGATORIO IS 'Condición de obligatorio';
COMMENT ON COLUMN config.seccion.B_ESPECIFICO IS 'Condición de específica o general';
COMMENT ON COLUMN config.seccion.D_REGISTRO IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.seccion.V_USR_REGISTRO IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.seccion.D_MODIFICACION IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.seccion.V_USR_MODIFICACION IS 'Usuario que modifica el registro';

-- Agregar comentario a la tabla
COMMENT ON TABLE config.seccion IS 'Configura la lista de secciones que debe completar un participante dentro de un paso.';

 

-- Crear la tabla "modalidad" en PostgreSQL
CREATE TABLE config.modalidad (
    I_MODALIDAD_ID serial PRIMARY KEY,
    I_ONLINE_SHOP_ID int NOT NULL,
    V_CODIGO varchar(20) NOT NULL,
    V_NOMBRE varchar(200) NOT NULL,
    V_NOMBRE_COMPLETO varchar(250) NOT NULL,
    B_ESTADO boolean NOT NULL,
    V_CONFIGURACION jsonb,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL
);

-- Agregar clave foránea
ALTER TABLE config.modalidad ADD CONSTRAINT FK_modalidad_concurso FOREIGN KEY (I_ONLINE_SHOP_ID)
REFERENCES config.online_shop (I_ONLINE_SHOP_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.modalidad.I_MODALIDAD_ID IS 'Identificador de la modalidad.';
COMMENT ON COLUMN config.modalidad.I_ONLINE_SHOP_ID IS 'Identificador del concurso.';
COMMENT ON COLUMN config.modalidad.V_CODIGO IS 'Código de la modalidad.';
COMMENT ON COLUMN config.modalidad.V_NOMBRE IS 'Nombre corto de la modalidad.';
COMMENT ON COLUMN config.modalidad.V_NOMBRE_COMPLETO IS 'Nombre completo de la modalidad (el que figura en las bases).';
COMMENT ON COLUMN config.modalidad.B_ESTADO IS 'Estado de la modalidad.';
COMMENT ON COLUMN config.modalidad.V_CONFIGURACION IS 'Configuración JSON de la modalidad.';
COMMENT ON COLUMN config.modalidad.D_REGISTRO IS 'Fecha de creación del registro.';
COMMENT ON COLUMN config.modalidad.V_USR_REGISTRO IS 'Usuario que crea el registro.';
COMMENT ON COLUMN config.modalidad.D_MODIFICACION IS 'Fecha de modificación del registro.';
COMMENT ON COLUMN config.modalidad.V_USR_MODIFICACION IS 'Usuario que modifica el registro.';

-- Agregar comentario a la tabla
COMMENT ON TABLE config.modalidad IS 'Configura las modalidades de beca a las que puede inscribirse - postular un participante.';
 
-- Crear la tabla "claim" en PostgreSQL
CREATE TABLE config.claim (
    I_MODULO_ID int NOT NULL,
    I_MODALIDAD_ID int NOT NULL,
    V_CLAIM_NOMBRE varchar(20) NOT NULL,
    B_OBLIGATORIO boolean NOT NULL,
    D_REGISTRO timestamp NOT NULL,
    V_USR_REGISTRO varchar(20) NOT NULL,
    D_MODIFICACION timestamp NULL,
    V_USR_MODIFICACION varchar(20) NULL
);

-- Crear clave primaria
ALTER TABLE config.claim ADD PRIMARY KEY (I_MODALIDAD_ID, I_MODULO_ID);

-- Agregar claves foráneas
ALTER TABLE config.claim ADD CONSTRAINT FK_claim_modulo FOREIGN KEY (I_MODULO_ID)
REFERENCES config.modulo (I_MODULO_ID);

ALTER TABLE config.claim ADD CONSTRAINT FK_claim_modalidad FOREIGN KEY (I_MODALIDAD_ID)
REFERENCES config.modalidad (I_MODALIDAD_ID);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.claim.I_MODULO_ID IS 'Identificador del módulo.';
COMMENT ON COLUMN config.claim.I_MODALIDAD_ID IS 'Identificador de la modalidad.';
COMMENT ON COLUMN config.claim.V_CLAIM_NOMBRE IS 'Nombre del claim.';
COMMENT ON COLUMN config.claim.B_OBLIGATORIO IS 'Condición de obligatorio.';
COMMENT ON COLUMN config.claim.D_REGISTRO IS 'Fecha de creación del registro.';
COMMENT ON COLUMN config.claim.V_USR_REGISTRO IS 'Usuario que crea el registro.';
COMMENT ON COLUMN config.claim.D_MODIFICACION IS 'Fecha de modificación del registro.';
COMMENT ON COLUMN config.claim.V_USR_MODIFICACION IS 'Usuario que modifica el registro.';

-- Agregar comentario a la tabla
COMMENT ON TABLE config.claim IS 'Configura los claims que podrán/deberán ser registrados por participante dentro de un módulo.';



 