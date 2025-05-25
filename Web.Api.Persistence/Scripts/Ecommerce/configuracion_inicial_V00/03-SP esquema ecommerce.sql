

call "ecommerce".SP_INS_PRODUCTO(
	1 ,
	1 ,
	1 ,
	'TEST' ,
	'TEST' ,
	'TEST' ,
	'TEST' ,
	'TEST' ,
 	5 ,
    'ADMIN');

  select * from ecommerce.producto p 
   
CREATE PROCEDURE "ecommerce".SP_INS_PRODUCTO(
	I_SITIO_PAGINA int,
	I_CATEGORIA_ID integer,
	I_MARCA_ID integer,
	V_NOMBRE varchar(50) ,
	V_DESCRIPCION varchar(50),
	V_CARACTERISTICAS_DESTACADAS varchar,
	V_ESPECIFICACIONES varchar,
	V_INFORMACION_PRODUCTO varchar,
 	F_PRECIO_VENTA DECIMAL(18,2),
    V_USUARIO_REGISTRO varchar(20)
)
LANGUAGE sql

AS $$
	 
	insert into ecommerce.producto(
	v_codigo_producto ,
	i_sitio_pagina ,
	i_categoria_id ,
	i_marca_id ,
	v_nombre ,
	v_descripcion ,
	v_caracteristicas_destacadas ,
	v_especificaciones ,
	v_informacion_producto ,
 	f_precio_venta ,
    b_activo ,
    v_usuario_registro,
    d_registro 
	)
	values(
	'' ,
	I_SITIO_PAGINA ,
	I_CATEGORIA_ID ,
	I_MARCA_ID ,
	V_NOMBRE ,
	V_DESCRIPCION ,
	V_CARACTERISTICAS_DESTACADAS ,
	V_ESPECIFICACIONES ,
	V_INFORMACION_PRODUCTO ,
 	F_PRECIO_VENTA ,
    true ,
    V_USUARIO_REGISTRO,
    now() 
	);
$$;



BEGIN;
 
   select  "ecommerce".SP_SEL_PRODUCTO(0,0,0,'','',0,1000000);
   -- Returns: <unnamed portal 2>
 
   FETCH ALL IN "<unnamed portal 2>";
   COMMIT;
end;

 --call "ecommerce".SP_SEL_PRODUCTO(0,0,0,'','',0) 

CREATE OR REPLACE FUNCTION "ecommerce".sp_sel_producto( 
	PRODUCTO_ID integer = 0,
	CATEGORIA_ID integer = 0,
	MARCA_ID integer = 0,
	NOMBRE varchar(50) = '',
	DESCRIPCION varchar(50) = '',
 	PRECIO_VENTA_INICIAL numeric(18,2) = 0,
 	PRECIO_VENTA_FINAL numeric(18,2) = 10000000
)  
RETURNS refcursor  
AS $$ 
DECLARE
      ref refcursor;
BEGIN
	OPEN ref FOR 
	SELECT 
	v_codigo_producto ,
	i_sitio_pagina ,
	i_categoria_id ,
	i_marca_id ,
	v_nombre ,
	v_descripcion ,
	v_caracteristicas_destacadas ,
	v_especificaciones ,
	v_informacion_producto ,
 	f_precio_venta  
    FROM
	ecommerce.producto p 
	where
	(p.i_producto_id = PRODUCTO_ID or PRODUCTO_ID = 0) and 
	(p.i_categoria_id  = CATEGORIA_ID or CATEGORIA_ID = 0) and 
	(p.i_marca_id  = MARCA_ID or MARCA_ID = 0)and
	(p.v_nombre like  '%'|| NOMBRE ||'%') and
	(p.v_descripcion  like  '%'|| DESCRIPCION || '%') and
	(p.f_precio_venta  >= PRECIO_VENTA_INICIAL and p.f_precio_venta <= PRECIO_VENTA_FINAL) and
	p.b_activo = true;

	RETURN ref;
END;
$$ LANGUAGE plpgsql;
--

 

drop FUNCTION "ecommerce".SP_SEL_PRODUCTO
