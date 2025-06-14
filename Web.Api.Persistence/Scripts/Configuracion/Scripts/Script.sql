CREATE TABLE evento (
    id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    nombre VARCHAR,
    descripcion VARCHAR,
    fecha_inicio TIMESTAMP,
    fecha_fin TIMESTAMP,
    hora_inicio TIME,
    hora_fin TIME,
    activo BOOLEAN,
    usuario_registro VARCHAR,
    fecha_registro TIMESTAMP,
    usuario_modificacion VARCHAR,
    fecha_modificacion TIMESTAMP
);
