delete from config.enumerado

select * from config.enumerado e 
 

select e.i_empresa_id ,e.v_razon_social ,e.v_ruc ,e.v_direccion ,e.v_telefono_principal ,e.v_celular_principal  from config.empresa e 
where e.b_activo = true order by v_razon_social asc
 
select * from config.empresa


SELECT  *
FROM config.local_comercial;
 
SELECT *
FROM config.usuario
where i_usuario_id ;

drop table config.usuario


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
 * CONSULTA DE USUARIO POR ROL
 */
select p.v_nombre || ' ' || p.v_apellido_paterno || ' ' || p.v_apellido_materno as nombre, u.v_usuario as usuario,r.v_nombre_rol, ur.v_usuario_registro ,ur.d_fecha_registro  
from administrador.usuario_rol ur inner join administrador.usuario u on ur.i_usuario_id  = u.i_usuario_id 
inner join administrador.rol r on ur.i_rol_id = r.i_rol_id 
inner join administrador.persona p  on u.i_persona_id = p.i_persona_id 

/*
 * El usuario super administrador podra registrar la empresa, local comercial y un usuario super administrador en la tabla config.usuario.
 */

INSERT INTO config.empresa
(v_razon_social, v_ruc, v_direccion, v_telefono_principal, v_celular_principal, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES('EMPRESA TEST', '11111111111', 'VILLA RICA 423', '977777777', '977777777', true, '44836469', now(), null, null);

select * from config.empresa e 
select * from config.local_comercial lc 

INSERT INTO config.local_comercial
(i_empresa_id, v_nombre_comercial, v_direccion, v_telefono_principal, v_celular_principal, t_hora_inicio, t_hora_fin, v_tipo_horario, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(14, 'CASINOS SAN BORJA', 'JR LOS GERANIO 3454 SAN BORJA', '7778877887', '7878787', '21:59:59', '23:59:59', '1', true, '44836469', now(), null, null);

select lc.i_local_comercial_id ,* from config.empresa e inner join config.local_comercial lc on e.i_empresa_id  = lc.i_empresa_id 
where e.i_empresa_id = 14

drop table config.usuario
delete from config.usuario 
select * from config.usuario u 

/*
 * Janina es la persona que hace el contrato con la empresa de software, el super administrador le crea el usuario luego ella registra a Alex como colaborador para el uso del sistema.
 * solo este tipo de usuario podra crear nuevos usuarios para sus locales comerciales.
 * 
 * */
INSERT INTO config.usuario
(i_local_comercial_id, v_numero_documento, v_usuario, v_contrasenia, v_tipo_usuario ,v_tipo_documento, v_nombre, v_apellido_paterno, v_apellido_materno, d_fecha_nacimiento, v_celular, v_correo_electronico, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(18, '11111111','jperez','123' , '01','01', 'JANINA', 'PEREZ', 'PEREZ', '24-07-1988', '988888888', 'janina@yopmail.com', true, '44836469', now(), null, null);

/*Este es el coloborador de la empresa de Janina
 *Janina puede crear promociones y cartillas para todos los locales
 *los colaboradores solo pueden crear en el local comercial asignado.
 * */
INSERT INTO config.usuario
(i_local_comercial_id, v_numero_documento, v_usuario, v_contrasenia, v_tipo_usuario ,v_tipo_documento, v_nombre, v_apellido_paterno, v_apellido_materno, d_fecha_nacimiento, v_celular, v_correo_electronico, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(18, '94141112','arodriguez','123', '02','01', 'ALEX', 'RODRIGUES', 'SANTISTEBAN', '24-07-1968', '988888888', 'janina@yopmail.com', true, '11111111', now(), null, null);




