create schema web
create schema ecommerce
CREATE SCHEMA config
go


drop table web.sitio_pagina ;
drop table web.pagina;
drop table web.sitio;

select * from web.sitio_pagina
drop table web.sitio_pagina

--- script de configuracion ---

insert into web.sitio(V_NOMBRE,B_ACTIVO,V_USUARIO_REGISTRO,D_REGISTRO)
values ('bazaronline.com', TRUE,'ADMIN',now())

select * from WEB.SITIO
select * from WEB.pagina

insert into web.pagina(V_NOMBRE,B_ACTIVO,V_USUARIO_REGISTRO,D_REGISTRO)
values ('Home', TRUE,'ADMIN', now())

 create PROCEDURE "ecommerce".sp_ArchivoInsert(nombre VARCHAR(250))
LANGUAGE SQL
AS $$ 
	insert into ecommerce.categoria (i_sitio_pagina,v_nombre,b_activo,v_usuario_registro,d_registro)
	values('1',nombre,true,'ADMIN',now());
$$;
 
drop procedure "ecommerce".sp_ArchivoInsert

CALL  "ecommerce".sp_ArchivoInsert('DIEGO');

select * from ecommerce.categoria 

select * from ecommerce.producto p --where d_modificacion is null 

delete from ecommerce.producto  


BEGIN;
 
   select  "ecommerce".SP_SEL_PRODUCTO(0,0,0,'','',0,1000000);
   -- Returns: <unnamed portal 2>
 
   FETCH ALL IN "<unnamed portal 5>";
   COMMIT;
end;


--******************************************** EMPRESA Y LOCAL COMERCIAL ************************************************

INSERT INTO ecommerce.empresa
(v_razon_social, v_ruc, v_direccion, v_telefono_principal, v_celular_principal, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES('EMPRESA TEST 1', '2222222222', 'VILLA RICA 423', '977777777', '977777777', true, '44836469', now(), null, null);


INSERT INTO ecommerce.local_comercial
(i_empresa_id, v_nombre_comercial, v_direccion, v_telefono_principal, v_celular_principal, t_hora_inicio, t_hora_fin, v_tipo_horario, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion)
VALUES(1, 'CASINOS SAN BORJA', 'JR LOS GERANIO 3454 SAN BORJA', '7778877887', '7878787', '21:59:59', '23:59:59', '1', true, '44836469', now(), null, null);

select * from ecommerce.empresa e 
select * from ecommerce.local_comercial lc

select * from ecommerce.producto p 
select * from ecommerce.producto_imagen pi2  

--***********************************************************************************************************************

INSERT INTO ecommerce.producto_imagen
(i_producto_id, i_posicion, i_tipo_tamanio, i_color, v_nombre_archivo, v_url_archivo, b_activo, v_usuario_registro, d_fecha_registro)
VALUES(8, 1, '1', 1, '1', '1', true, '1', now());




