-- Cambiar el contexto de base de datos en PostgreSQL se hace conectándose a la base de datos adecuada, no con el comando USE.

-- Crear esquema y tabla
CREATE SCHEMA IF NOT EXISTS config;
-- Crear esquema y tabla
CREATE SCHEMA IF NOT EXISTS proceso;

CREATE SCHEMA IF NOT EXISTS ecommerce;

CREATE TABLE config.concurso (
    i_concurso_id SERIAL PRIMARY KEY,
    i_anio INTEGER NOT NULL,
    i_periodo INTEGER NOT NULL,
    v_nombre VARCHAR(200) NOT NULL,
    v_bases_documentacion TEXT NOT NULL,
    d_bases_publicacion TIMESTAMP NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20)
);

-- Agregar comentarios a las columnas
COMMENT ON COLUMN config.concurso.i_concurso_id IS 'Identificador del concurso';
COMMENT ON COLUMN config.concurso.i_anio IS 'Año del concurso';
COMMENT ON COLUMN config.concurso.i_periodo IS 'Periodo del concurso';
COMMENT ON COLUMN config.concurso.v_nombre IS 'Nombre del concurso - beca';
COMMENT ON COLUMN config.concurso.v_bases_documentacion IS 'Bases del concurso';
COMMENT ON COLUMN config.concurso.d_bases_publicacion IS 'Fecha de publicación de las bases';
COMMENT ON COLUMN config.concurso.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.concurso.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.concurso.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.concurso.v_usr_modificacion IS 'Usuario que modifica el registro';


CREATE TABLE config.momento (
    i_momento_id SERIAL PRIMARY KEY,
    i_concurso_id INTEGER NOT NULL,
    v_nombre VARCHAR(200) NOT NULL,
    v_codigo VARCHAR(20) NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    CONSTRAINT fk_concurso FOREIGN KEY (i_concurso_id) REFERENCES config.concurso (i_concurso_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.momento IS 'Configura los momentos de un concurso.';
COMMENT ON COLUMN config.momento.i_momento_id IS 'Identificador del momento';
COMMENT ON COLUMN config.momento.i_concurso_id IS 'Identificador del concurso';
COMMENT ON COLUMN config.momento.v_nombre IS 'Nombre del momento';
COMMENT ON COLUMN config.momento.v_codigo IS 'Código único del momento';
COMMENT ON COLUMN config.momento.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.momento.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.momento.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.momento.v_usr_modificacion IS 'Usuario que modifica el registro';


 
CREATE TABLE config.etapa (
    i_etapa_id SERIAL PRIMARY KEY,
    v_nombre VARCHAR(200) NOT NULL,
    v_codigo VARCHAR(100) NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.etapa IS 'Registra la lista de etapas que puede incluir un proceso de postulación.';
COMMENT ON COLUMN config.etapa.i_etapa_id IS 'Identificador de la etapa';
COMMENT ON COLUMN config.etapa.v_nombre IS 'Nombre de la etapa';
COMMENT ON COLUMN config.etapa.v_codigo IS 'Código único de la etapa';
COMMENT ON COLUMN config.etapa.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.etapa.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.etapa.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.etapa.v_usr_modificacion IS 'Usuario que modifica el registro';
 
 
CREATE TABLE config.modulo (
    i_modulo_id SERIAL PRIMARY KEY,
    i_momento_id INTEGER NOT NULL,
    i_etapa_id INTEGER NOT NULL,
    u_modulo_token UUID NOT NULL,
    v_nombre VARCHAR(200) NOT NULL,
    b_obligatorio BOOLEAN NOT NULL,
    b_estado BOOLEAN NOT NULL,
    i_secuencia SMALLINT NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    i_modulo_id_padre INTEGER,
    CONSTRAINT fk_momento FOREIGN KEY (i_momento_id) REFERENCES config.momento (i_momento_id),
    CONSTRAINT fk_etapa FOREIGN KEY (i_etapa_id) REFERENCES config.etapa (i_etapa_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.modulo IS 'Configura los módulos (etapas) que incluyen un proceso de postulación y por los que deberá pasar el participante a un concurso de beca.';
COMMENT ON COLUMN config.modulo.i_modulo_id IS 'Identificador del módulo';
COMMENT ON COLUMN config.modulo.i_momento_id IS 'Identificador del momento';
COMMENT ON COLUMN config.modulo.i_etapa_id IS 'Identificador de la etapa';
COMMENT ON COLUMN config.modulo.u_modulo_token IS 'Token único del módulo - KEY para el aplicativo cliente';
COMMENT ON COLUMN config.modulo.v_nombre IS 'Nombre del módulo';
COMMENT ON COLUMN config.modulo.b_obligatorio IS 'Condición de obligatorio';
COMMENT ON COLUMN config.modulo.b_estado IS 'Estado del módulo';
COMMENT ON COLUMN config.modulo.i_secuencia IS 'Secuencia dentro del proceso de postulación';
COMMENT ON COLUMN config.modulo.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.modulo.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.modulo.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.modulo.v_usr_modificacion IS 'Usuario que modifica el registro';
COMMENT ON COLUMN config.modulo.i_modulo_id_padre IS 'Identificador del módulo padre';

 
CREATE TABLE config.paso (
    i_paso_id SERIAL PRIMARY KEY,
    i_modulo_id INT NOT NULL,
    i_orden INT NOT NULL,
    v_nombre VARCHAR(200) NOT NULL,
    v_ruta VARCHAR(250) NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    FOREIGN KEY (i_modulo_id) REFERENCES config.modulo (i_modulo_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.paso IS 'Configura los pasos que debe completar el participante dentro de un módulo.';
COMMENT ON COLUMN config.paso.i_paso_id IS 'Identificador de la sección';
COMMENT ON COLUMN config.paso.i_modulo_id IS 'Identificador del módulo';
COMMENT ON COLUMN config.paso.i_orden IS 'Orden del paso';
COMMENT ON COLUMN config.paso.v_nombre IS 'Nombre del paso';
COMMENT ON COLUMN config.paso.v_ruta IS 'Url del paso en la aplicación cliente';
COMMENT ON COLUMN config.paso.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.paso.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.paso.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.paso.v_usr_modificacion IS 'Usuario que modifica el registro';

 
CREATE TABLE config.seccion (
    i_seccion_id SERIAL PRIMARY KEY,
    i_paso_id INT NOT NULL,
    i_orden INT NOT NULL,
    v_nombre VARCHAR(200) NOT NULL,
    v_codigo VARCHAR(200) NOT NULL,
    v_type VARCHAR(200) NOT NULL,
    b_obligatorio BOOLEAN NOT NULL,
    b_especifico BOOLEAN NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    FOREIGN KEY (i_paso_id) REFERENCES config.paso (i_paso_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.seccion IS 'Configura la lista de secciones que debe completar un participante dentro de un paso.';
COMMENT ON COLUMN config.seccion.i_seccion_id IS 'Identificador de la tabla';
COMMENT ON COLUMN config.seccion.i_paso_id IS 'Identificador del paso';
COMMENT ON COLUMN config.seccion.i_orden IS 'Orden de la sección';
COMMENT ON COLUMN config.seccion.v_nombre IS 'Nombre de la sección';
COMMENT ON COLUMN config.seccion.v_codigo IS 'Código de la sección que será utilizado para consultar la sección de la vista';
COMMENT ON COLUMN config.seccion.v_type IS 'Nombre de la clase que implementa la sección';
COMMENT ON COLUMN config.seccion.b_obligatorio IS 'Condición de obligatorio';
COMMENT ON COLUMN config.seccion.b_especifico IS 'Condición de específica o general';
COMMENT ON COLUMN config.seccion.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.seccion.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.seccion.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.seccion.v_usr_modificacion IS 'Usuario que modifica el registro';

 
CREATE TABLE config.cronograma (
    i_cronograma_id SERIAL PRIMARY KEY,
    i_modulo_id INT NOT NULL,
    d_inicio TIMESTAMP NOT NULL,
    d_termino TIMESTAMP NOT NULL,
    d_reversion TIMESTAMP NOT NULL,
    v_documentacion TEXT NOT NULL,
    v_configuracion TEXT NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    b_asignacion_automatica BOOLEAN,
    FOREIGN KEY (i_modulo_id) REFERENCES config.modulo (i_modulo_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.cronograma IS 'Configura los cronogramas de los módulos de cada uno de los concursos de becas.';
COMMENT ON COLUMN config.cronograma.i_cronograma_id IS 'Identificador del cronograma';
COMMENT ON COLUMN config.cronograma.i_modulo_id IS 'Identificador del módulo';
COMMENT ON COLUMN config.cronograma.d_inicio IS 'Fecha de apertura del módulo';
COMMENT ON COLUMN config.cronograma.d_termino IS 'Fecha de cierre del módulo';
COMMENT ON COLUMN config.cronograma.d_reversion IS 'Fecha límite para reversiones dentro del módulo';
COMMENT ON COLUMN config.cronograma.v_documentacion IS 'Sustento para apertura del módulo';
COMMENT ON COLUMN config.cronograma.v_configuracion IS 'JSON de configuración del módulo';
COMMENT ON COLUMN config.cronograma.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.cronograma.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.cronograma.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.cronograma.v_usr_modificacion IS 'Usuario que modifica el registro';
COMMENT ON COLUMN config.cronograma.b_asignacion_automatica IS 'Indica si la asignación es automática';

  
CREATE TABLE config.modulo_parametro (
    i_modulo_parametro_id SERIAL PRIMARY KEY,
    i_modulo_id INT NOT NULL,
    v_parametro TEXT NOT NULL,
    v_valor TEXT NOT NULL,
    v_descripcion TEXT,
    b_estado BOOLEAN NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    FOREIGN KEY (i_modulo_id) REFERENCES config.modulo (i_modulo_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.modulo_parametro IS 'Parametrización de valores por módulo.';
COMMENT ON COLUMN config.modulo_parametro.i_modulo_parametro_id IS 'Identificador de la tabla.';
COMMENT ON COLUMN config.modulo_parametro.i_modulo_id IS 'Identificador del módulo.';
COMMENT ON COLUMN config.modulo_parametro.v_parametro IS 'Key del parámetro.';
COMMENT ON COLUMN config.modulo_parametro.v_valor IS 'Valor del parámetro.';
COMMENT ON COLUMN config.modulo_parametro.v_descripcion IS 'Descripción del parámetro.';
COMMENT ON COLUMN config.modulo_parametro.b_estado IS 'Estado del registro.';
COMMENT ON COLUMN config.modulo_parametro.d_registro IS 'Fecha de inserción del registro.';
COMMENT ON COLUMN config.modulo_parametro.v_usr_registro IS 'Usuario que insertó el registro.';
COMMENT ON COLUMN config.modulo_parametro.d_modificacion IS 'Fecha de modificación del registro.';
COMMENT ON COLUMN config.modulo_parametro.v_usr_modificacion IS 'Usuario que modificó el registro.';

 
CREATE TABLE config.modalidad (
    i_modalidad_id SERIAL PRIMARY KEY,
    i_concurso_id INT NOT NULL,
    v_codigo VARCHAR(20) NOT NULL,
    v_nombre VARCHAR(200) NOT NULL,
    v_nombre_completo VARCHAR(250) NOT NULL,
    b_estado BOOLEAN NOT NULL,
    v_configuracion TEXT,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    FOREIGN KEY (i_concurso_id) REFERENCES config.concurso (i_concurso_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.modalidad IS 'Configura las modalidades de beca a las que puede inscribirse - postular un participante.';
COMMENT ON COLUMN config.modalidad.i_modalidad_id IS 'Identificador de la modalidad';
COMMENT ON COLUMN config.modalidad.i_concurso_id IS 'Identificador del concurso';
COMMENT ON COLUMN config.modalidad.v_codigo IS 'Código de la modalidad';
COMMENT ON COLUMN config.modalidad.v_nombre IS 'Nombre corto de la modalidad';
COMMENT ON COLUMN config.modalidad.v_nombre_completo IS 'Nombre completo de la modalidad (el que figura en las bases)';
COMMENT ON COLUMN config.modalidad.b_estado IS 'Estado de la modalidad';
COMMENT ON COLUMN config.modalidad.v_configuracion IS 'Configuración JSON de la modalidad.';
COMMENT ON COLUMN config.modalidad.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.modalidad.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.modalidad.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.modalidad.v_usr_modificacion IS 'Usuario que modifica el registro';

 
CREATE TABLE config.requisito (
    i_requisito_id INT NOT NULL,
    i_modulo_id INT NOT NULL,
    i_modalidad_id INT NOT NULL,
    i_tipo_requisito INT NOT NULL,
    i_paso_orden INT NOT NULL,
    i_seccion_orden INT NOT NULL,
    v_descripcion VARCHAR(250) NOT NULL,
    v_comentario VARCHAR(250) NOT NULL,
    v_configuracion TEXT NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    PRIMARY KEY (i_requisito_id, i_modulo_id, i_modalidad_id),
    FOREIGN KEY (i_modulo_id) REFERENCES config.modulo (i_modulo_id),
    FOREIGN KEY (i_modalidad_id) REFERENCES config.modalidad (i_modalidad_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.requisito IS 'Configura la lista de requisitos que debe cumplir el participante dentro de un módulo.';
COMMENT ON COLUMN config.requisito.i_requisito_id IS 'Identificador de la tabla';
COMMENT ON COLUMN config.requisito.i_modulo_id IS 'Identificador del módulo';
COMMENT ON COLUMN config.requisito.i_modalidad_id IS 'Identificador de la modalidad';
COMMENT ON COLUMN config.requisito.i_tipo_requisito IS 'Tipo de requisito';
COMMENT ON COLUMN config.requisito.i_paso_orden IS 'Orden del paso';
COMMENT ON COLUMN config.requisito.i_seccion_orden IS 'Orden la sección';
COMMENT ON COLUMN config.requisito.v_descripcion IS 'Descripción del requisito';
COMMENT ON COLUMN config.requisito.v_comentario IS 'Comentarios adicionales del requisito';
COMMENT ON COLUMN config.requisito.v_configuracion IS 'JSON de configuración del requisito';
COMMENT ON COLUMN config.requisito.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.requisito.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.requisito.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.requisito.v_usr_modificacion IS 'Usuario que modifica el registro';

 
CREATE TABLE config.tipo_enumerado (
    i_tipo_enumerado_id SERIAL PRIMARY KEY,
    v_codigo VARCHAR(30) NOT NULL,
    v_nombre VARCHAR(200) NOT NULL,
    v_descripcion VARCHAR(200) NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.tipo_enumerado IS 'Configura las tablas maestras.';
COMMENT ON COLUMN config.tipo_enumerado.i_tipo_enumerado_id IS 'Identificador de la tabla';
COMMENT ON COLUMN config.tipo_enumerado.v_codigo IS 'Código que identifica al tipo de enumerado';
COMMENT ON COLUMN config.tipo_enumerado.v_nombre IS 'Tipo de enumerado';
COMMENT ON COLUMN config.tipo_enumerado.v_descripcion IS 'Detalle del tipo de enumerado';
COMMENT ON COLUMN config.tipo_enumerado.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.tipo_enumerado.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.tipo_enumerado.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.tipo_enumerado.v_usr_modificacion IS 'Usuario que modifica el registro';

 
CREATE TABLE config.enumerado (
    i_enumerado_id SERIAL PRIMARY KEY,
    i_tipo_enumerado_id INT NOT NULL,
    v_codigo VARCHAR(200) NOT NULL,
    v_nombre TEXT NOT NULL,
    v_descripcion TEXT NOT NULL,
    b_estado BOOLEAN NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    FOREIGN KEY (i_tipo_enumerado_id) REFERENCES config.tipo_enumerado (i_tipo_enumerado_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.enumerado IS 'Configura los valores de la tablas maestras.';
COMMENT ON COLUMN config.enumerado.i_enumerado_id IS 'Identificador del enumerado';
COMMENT ON COLUMN config.enumerado.i_tipo_enumerado_id IS 'Identificador del tipo de enumerado';
COMMENT ON COLUMN config.enumerado.v_codigo IS 'Código del enumerado';
COMMENT ON COLUMN config.enumerado.v_nombre IS 'Nombre del enumerado';
COMMENT ON COLUMN config.enumerado.v_descripcion IS 'Descripción del enumerado';
COMMENT ON COLUMN config.enumerado.b_estado IS 'Estado del enumerado';
COMMENT ON COLUMN config.enumerado.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.enumerado.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.enumerado.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.enumerado.v_usr_modificacion IS 'Usuario que modifica el registro';
 
CREATE TABLE config.estado (
    i_estado_id SERIAL PRIMARY KEY,
    i_etapa_id INT NOT NULL,
    v_nombre VARCHAR(200) NOT NULL,
    i_orden INT NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    CONSTRAINT fk_estado_etapa FOREIGN KEY (i_etapa_id)
        REFERENCES config.etapa(i_etapa_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.estado IS 'Configura los estados en los que podrá encontrarse un participante dentro de un módulo (etapa) del proceso de postulación.';
COMMENT ON COLUMN config.estado.i_estado_id IS 'Identificador del estado';
COMMENT ON COLUMN config.estado.i_etapa_id IS 'Identificador de la etapa';
COMMENT ON COLUMN config.estado.v_nombre IS 'Nombre del estado';
COMMENT ON COLUMN config.estado.i_orden IS 'Orden del estado dentro de la etapa';
COMMENT ON COLUMN config.estado.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.estado.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.estado.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.estado.v_usr_modificacion IS 'Usuario que modifica el registro';

 
CREATE TABLE config.documentacion (
    i_documentacion_id INT NOT NULL,
    i_modalidad_id INT NOT NULL,
    i_modulo_id INT NOT NULL,
    v_descripcion TEXT NOT NULL, -- VARCHAR(MAX) se convierte a TEXT
    v_comentario TEXT NOT NULL, -- VARCHAR(MAX) se convierte a TEXT
    i_tipo_documentacion INT NOT NULL,
    b_autogenerado BOOLEAN NOT NULL, -- BIT se convierte a BOOLEAN
    v_configuracion TEXT NOT NULL, -- VARCHAR(MAX) se convierte a TEXT
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    i_orden INT NOT NULL,
    CONSTRAINT pk_documentacion PRIMARY KEY (i_documentacion_id, i_modalidad_id, i_modulo_id),
    CONSTRAINT fk_documentacion_modulo FOREIGN KEY (i_modulo_id) REFERENCES config.modulo (i_modulo_id),
    CONSTRAINT fk_documentacion_modalidad FOREIGN KEY (i_modalidad_id) REFERENCES config.modalidad (i_modalidad_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.documentacion IS 'Configura la lista de documentos que deberá/podrá presentar (cargar) el participante dentro del módulo.';
COMMENT ON COLUMN config.documentacion.i_documentacion_id IS 'Identificador de la documentación';
COMMENT ON COLUMN config.documentacion.i_modalidad_id IS 'Identificador de la modalidad';
COMMENT ON COLUMN config.documentacion.i_modulo_id IS 'Identificador del módulo';
COMMENT ON COLUMN config.documentacion.v_descripcion IS 'Descripción de la documentación';
COMMENT ON COLUMN config.documentacion.v_comentario IS 'Comentario complementario de la documentación';
COMMENT ON COLUMN config.documentacion.i_tipo_documentacion IS 'Tipo de documentación';
COMMENT ON COLUMN config.documentacion.b_autogenerado IS 'Condición de documentación que debe ser autogenerada';
COMMENT ON COLUMN config.documentacion.v_configuracion IS 'JSON de configuración';
COMMENT ON COLUMN config.documentacion.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.documentacion.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.documentacion.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.documentacion.v_usr_modificacion IS 'Usuario que modifica el registro';
COMMENT ON COLUMN config.documentacion.i_orden IS 'Orden de visualización';

 
CREATE TABLE config.formato (
    i_formato_id SERIAL PRIMARY KEY,
    i_documentacion_id INT NOT NULL,
    i_modalidad_id INT NOT NULL,
    i_modulo_id INT NOT NULL,
    v_nombre VARCHAR(200) NOT NULL,
    v_comentario TEXT NOT NULL, -- VARCHAR(MAX) se convierte a TEXT
    v_ruta VARCHAR(200) NOT NULL,
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    b_generado BOOLEAN NOT NULL, -- BIT se convierte a BOOLEAN
    v_configuracion TEXT NOT NULL, -- VARCHAR(MAX) se convierte a TEXT
    CONSTRAINT fk_formato_documentacion FOREIGN KEY (i_documentacion_id, i_modalidad_id, i_modulo_id)
        REFERENCES config.documentacion (i_documentacion_id, i_modalidad_id, i_modulo_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.formato IS 'Configura los formatos que genera (fichas) y/o puede descargar el participante dentro de un módulo.';
COMMENT ON COLUMN config.formato.i_formato_id IS 'Identificador del formato';
COMMENT ON COLUMN config.formato.i_documentacion_id IS 'Identificador del documento asociado al formato';
COMMENT ON COLUMN config.formato.i_modalidad_id IS 'Identificador de la modalidad';
COMMENT ON COLUMN config.formato.i_modulo_id IS 'Identificador del módulo';
COMMENT ON COLUMN config.formato.v_nombre IS 'Nombre del formato';
COMMENT ON COLUMN config.formato.v_comentario IS 'Comentario del formato';
COMMENT ON COLUMN config.formato.v_ruta IS 'Url donde se aloja el formato';
COMMENT ON COLUMN config.formato.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.formato.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.formato.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.formato.v_usr_modificacion IS 'Usuario que modifica el registro';
COMMENT ON COLUMN config.formato.b_generado IS 'Condición de formato generado o no';
COMMENT ON COLUMN config.formato.v_configuracion IS 'Configuración JSON del formato';
  
 
CREATE TABLE config.documentacion_clasificacion (
    i_documentacion_clasificacion_id SERIAL PRIMARY KEY, -- SERIAL para incremento automático
    i_clasificacion_id INT NOT NULL,
    i_documentacion_id INT NOT NULL,
    i_modulo_id INT NOT NULL,
    v_descripcion VARCHAR(200) NOT NULL,
    b_estado BOOLEAN NOT NULL, -- BIT se convierte a BOOLEAN
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE config.documentacion_clasificacion IS 'Clasificación de documentos dentro de un módulo';
COMMENT ON COLUMN config.documentacion_clasificacion.i_documentacion_clasificacion_id IS 'Identificador de la tabla documentación clasificación';
COMMENT ON COLUMN config.documentacion_clasificacion.i_clasificacion_id IS 'Identificador de la clasificación';
COMMENT ON COLUMN config.documentacion_clasificacion.i_documentacion_id IS 'Identificador de la documentación';
COMMENT ON COLUMN config.documentacion_clasificacion.i_modulo_id IS 'Identificador del módulo';
COMMENT ON COLUMN config.documentacion_clasificacion.v_descripcion IS 'Descripción de documento de clasificación';
COMMENT ON COLUMN config.documentacion_clasificacion.b_estado IS 'Estado del registro';
COMMENT ON COLUMN config.documentacion_clasificacion.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN config.documentacion_clasificacion.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN config.documentacion_clasificacion.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN config.documentacion_clasificacion.v_usr_modificacion IS 'Usuario que modifica el registro';


CREATE TABLE proceso.participante (
    i_participante_id SERIAL PRIMARY KEY, -- SERIAL para incremento automático
    v_num_documento VARCHAR(20),
    i_persona_id INT NOT NULL,
    i_momento_id INT NOT NULL,
    u_participante_token UUID NOT NULL, -- UUID en lugar de uniqueidentifier
    i_postulacion_id INT,
    v_num_expediente VARCHAR(25),
    d_registro TIMESTAMP NOT NULL,
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    CONSTRAINT fk_participante_momento FOREIGN KEY (i_momento_id) REFERENCES config.momento (i_momento_id)
);

-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE proceso.participante IS 'Registra al participante y su estado dentro del módulo';
COMMENT ON COLUMN proceso.participante.i_participante_id IS 'Identificador del participante';
COMMENT ON COLUMN proceso.participante.v_num_documento IS 'Número de documento de identidad del participante';
COMMENT ON COLUMN proceso.participante.i_persona_id IS 'Identificador del participante de la tabla Persona de db_pronabec';
COMMENT ON COLUMN proceso.participante.i_momento_id IS 'Identificador del momento';
COMMENT ON COLUMN proceso.participante.u_participante_token IS 'Token único del participante';
COMMENT ON COLUMN proceso.participante.i_postulacion_id IS 'Número de expediente de inscripción - postulación';
COMMENT ON COLUMN proceso.participante.v_num_expediente IS 'Estado del participante';
COMMENT ON COLUMN proceso.participante.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN proceso.participante.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN proceso.participante.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN proceso.participante.v_usr_modificacion IS 'Usuario que modifica el registro';

 
CREATE TABLE proceso.participante_modulo (
    i_participante_mod_id SERIAL PRIMARY KEY, -- SERIAL para incremento automático
    i_participante_id INT NOT NULL,
    i_modulo_id INT NOT NULL,
    i_estado_modulo INT NOT NULL,
    d_inicio TIMESTAMP NOT NULL, -- datetime se convierte en TIMESTAMP
    d_termino TIMESTAMP, -- datetime se convierte en TIMESTAMP
    b_estado BOOLEAN NOT NULL, -- bit se convierte en BOOLEAN
    d_registro TIMESTAMP NOT NULL, -- datetime se convierte en TIMESTAMP
    v_usr_registro VARCHAR(20) NOT NULL,
    d_modificacion TIMESTAMP,
    v_usr_modificacion VARCHAR(20),
    CONSTRAINT fk_participante_modulo_participante FOREIGN KEY (i_participante_id) REFERENCES proceso.participante (i_participante_id), -- Agregar clave foránea a la tabla participante (si existe)
    CONSTRAINT fk_participante_modulo_modulo FOREIGN KEY (i_modulo_id) REFERENCES config.modulo (i_modulo_id) -- Agregar clave foránea a la tabla modulo (si existe)
);
 
-- Agregar comentarios a las columnas y tabla
COMMENT ON TABLE proceso.participante_modulo IS 'Registra el módulo en el que se encuentra el participante.';
COMMENT ON COLUMN proceso.participante_modulo.i_participante_mod_id IS 'Identificador único de participante por módulo';
COMMENT ON COLUMN proceso.participante_modulo.i_participante_id IS 'Identificador del participante';
COMMENT ON COLUMN proceso.participante_modulo.i_modulo_id IS 'Identificador el módulo';
COMMENT ON COLUMN proceso.participante_modulo.i_estado_modulo IS 'Estado del participante en el módulo';
COMMENT ON COLUMN proceso.participante_modulo.d_inicio IS 'Fecha en que el participante inicia el módulo';
COMMENT ON COLUMN proceso.participante_modulo.d_termino IS 'Fecha en la que el participante termina el módulo';
COMMENT ON COLUMN proceso.participante_modulo.b_estado IS 'Estado del registro';
COMMENT ON COLUMN proceso.participante_modulo.d_registro IS 'Fecha de creación del registro';
COMMENT ON COLUMN proceso.participante_modulo.v_usr_registro IS 'Usuario que crea el registro';
COMMENT ON COLUMN proceso.participante_modulo.d_modificacion IS 'Fecha de modificación del registro';
COMMENT ON COLUMN proceso.participante_modulo.v_usr_modificacion IS 'Usuario que modifica el registro';

--////////////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////////////////////////////////////////////////////////////////////////////////////


create table ecommerce.empresa(
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
 

create table ecommerce.local_comercial(
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

alter table ecommerce.local_comercial add constraint FK_EMPRESA foreign key(I_EMPRESA_ID) references  ecommerce.empresa(I_EMPRESA_ID);

--drop table ecommerce.producto
create table ecommerce.producto(
	I_PRODUCTO_ID integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	I_LOCAL_COMERCIAL_ID INTEGER,
	V_CODIGO_PRODUCTO varchar(250),
	I_SITIO_PAGINA int,
	I_CATEGORIA_ID integer,
	I_MARCA_ID integer,
	V_NOMBRE varchar(50) NOT NULL,
	V_DESCRIPCION varchar(50) NOT NULL,
	V_CARACTERISTICAS_DESTACADAS varchar(750),
	V_ESPECIFICACIONES varchar(750),
	V_INFORMACION_PRODUCTO varchar(750),
 	F_PRECIO_VENTA DECIMAL(18,2), 
    B_ACTIVO boolean NOT null,
    V_ESTADO varchar(1),
    V_USUARIO_REGISTRO varchar(20) not null,
    D_FECHA_REGISTRO timestamp not null,
    V_USUARIO_MODIFICACION varchar(20) null,
    D_FECHA_MODIFICACION timestamp null
);
alter table ecommerce.producto add constraint FK_LOCAL_COMERCIAL foreign key(I_LOCAL_COMERCIAL_ID) references  ecommerce.local_comercial(I_LOCAL_COMERCIAL_ID);
 
--drop table ecommerce.producto_imagen
create table ecommerce.producto_imagen(
	I_PRODUCTO_IMAGEN_ID integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    I_PRODUCTO_ID int,
    I_POSICION int,
    I_TIPO_TAMANIO int, -- sm, m ,l, xl
    I_COLOR int,
    V_NOMBRE_ARCHIVO varchar(500),
	V_URL_ARCHIVO varchar(500),
	B_ACTIVO boolean NOT null,
    V_USUARIO_REGISTRO varchar(20) not null,
    D_FECHA_REGISTRO timestamp not null,
    V_USUARIO_MODIFICACION VARCHAR(20) NULL,
    D_FECHA_MODIFICACION TIMESTAMP NULL
);
alter table ecommerce.producto_imagen add constraint FK_PRODUCTO_IMAGEN foreign key(I_PRODUCTO_ID) references ecommerce.producto(I_PRODUCTO_ID);



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

create table config.usuario(
	I_USUARIO_ID INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 		
	I_LOCAL_COMERCIAL_ID INTEGER, 
	V_NUMERO_DOCUMENTO VARCHAR(25),
	V_USUARIO VARCHAR(50), --
 	V_CONTRASENIA VARCHAR(750), --
	V_TIPO_USUARIO VARCHAR(2), --
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

