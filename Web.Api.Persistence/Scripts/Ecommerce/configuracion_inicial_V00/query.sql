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
