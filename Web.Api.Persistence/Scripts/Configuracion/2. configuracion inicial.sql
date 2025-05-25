
/*
 * CONFIGURAMOS LOS ENUMERADOS
 * */
INSERT INTO config.tipo_enumerado
(i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(10, 'TIPO_DOCUMENTO_IDENTIFICACION', 'TIPO_IDENTIFICACION', 'tipo de documento de identificacion dni, carnet, passporte etc', 'ADMIN', now(), NULL, NULL);



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


INSERT INTO config.tipo_enumerado
(i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(11, 'TIPO_USUARIO', 'TIPO_USUARIO', 'tipo de usuario en el sistema de las empresas admin, colobaradores', 'ADMIN', now(), NULL, NULL);

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(110001, 11, '01', 'ADMIN', 'ADMINISTRADOR DEL SISTEMA', true, 'ADMIN', now(), null, null);

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(110002, 11, '02', 'TRABAJADOR', 'TRABAJADOR DEL SISTEMA', true, 'ADMIN', now(), null, null);

INSERT INTO config.tipo_enumerado
(i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(12, 'ESTADO PROMOCION', 'ESTADO_PROMOCION', ' Indica si la promoción está activa, inactiva o programada', 'ADMIN', now(), NULL, NULL);

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(120001, 12, '01', 'Activo', 'Activo', true, 'ADMIN', now(), null, null);

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(120002, 12, '02', 'Inactivo', 'Inactivo', true, 'ADMIN', now(), null, null);

INSERT INTO config.enumerado
(i_enumerado_id, i_tipo_enumerado_id, v_codigo, v_nombre, v_descripcion, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(120002, 12, '03', 'Programado', 'Programado', true, 'ADMIN', now(), null, null);


/*
 * Insercion de supera administrador para la configuracion de empresas (clientes del aplicativo)
 * */

INSERT INTO administrador.persona
(v_numero_documento, v_tipo_documento, v_nombre, v_apellido_paterno, v_apellido_materno, d_fecha_nacimiento, v_celular, v_correo_electronico, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES('44836469', '01', 'DIEGO ARMANDO JESUS', 'LUNA', 'QUINTO', '21/10/1987', '957625308', 'diegoarmando21.10@gmail.com', true, 'ADMIN', NOW(), NULL, NULL);

select * from administrador.persona p inner join administrador.sa s on p.i_persona_id = s.i_persona_id 

/*Este es el unico usuario que puede crear otros super administradores*/
INSERT INTO administrador.sa
(i_persona_id, v_usuario, v_contrasenia, v_tipo_usuario, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(1, 'sa', 'sa', '1', true, 'CORE', NOW(), NULL, NULL);


INSERT INTO administrador.rol
(v_nombre_rol,V_CODIGO_ROL, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES('super administrador', 'SA' ,'44836469', now(), null, null);


INSERT INTO administrador.usuario
(i_persona_id, v_usuario, v_contrasenia, v_tipo_usuario, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(1, 'ADMIN', 'ADMIN', '1', true, '44836469', now(), null, null);

 
INSERT INTO administrador.usuario_rol
(i_usuario_id, i_rol_id, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(1, 1, true,  '44836469', now(), null, null);





