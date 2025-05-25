create schema web
create schema ecommerce
go


drop table web.sitio_pagina ;
drop table web.pagina;
drop table web.sitio;



CREATE TABLE web.sitio (
    I_SITIO_ID integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    V_NOMBRE varchar(50) NOT NULL,
    B_ACTIVO boolean NOT null,
    V_USUARIO_REGISTRO varchar(20) not null,
    D_REGISTRO timestamp not null,
    V_USR_MODIFICACION varchar(20) null,
    D_MODIFICACION timestamp null    
);
 
create table web.pagina(
	I_PAGINA_ID integer GENERATED ALWAYS AS IDENTITY primary key,
	V_NOMBRE varchar(50),
	B_ACTIVO boolean NOT null,
	V_USUARIO_REGISTRO varchar(20) not null,
    D_REGISTRO timestamp not null,
    V_USR_MODIFICACION varchar(20) null,
    D_MODIFICACION timestamp null  
)



create table web.componente(
	I_COMPONENTE_ID integer GENERATED ALWAYS AS IDENTITY primary key,
	I_PAGINA_ID INT,
	I_SECCION INT,
	V_NOMBRE VARCHAR(50),
	V_DESCRIPCION VARCHAR(150),
	V_CODIGO VARCHAR(50),
	V_VALOR VARCHAR(50),
	B_ACTIVO boolean NOT null,
	V_USUARIO_REGISTRO varchar(20) not null,
    D_REGISTRO timestamp not null
)
 

CREATE TABLE web.sitio_pagina (
    I_SITIO_PAGINA_ID integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    I_SITIO_ID int not null,
    I_PAGINA_ID int not null,
    V_NOMBRE varchar(50) NOT NULL,
    B_ACTIVO boolean NOT null,
    V_USUARIO_REGISTRO varchar(20) not null,
    D_REGISTRO timestamp not null,
    V_USR_MODIFICACION varchar(20) null,
    D_MODIFICACION timestamp null
);

alter table web.sitio_pagina add constraint FK_SITIO_PAGINA_1 foreign key(I_SITIO_ID) references web.sitio (I_SITIO_ID);
alter table web.sitio_pagina add constraint FK_SITIO_PAGINA_2 foreign key(I_PAGINA_ID) references web.pagina (I_PAGINA_ID);


drop table ecommerce.categoria
create table ecommerce.categoria(
	I_CATEGORIA_ID integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    I_SITIO_PAGINA int,
	V_NOMBRE varchar(50) NOT NULL,
    B_ACTIVO boolean NOT null,
    V_USUARIO_REGISTRO varchar(20) not null,
    D_REGISTRO timestamp not null,
    V_USR_MODIFICACION varchar(20) null,
    D_MODIFICACION timestamp null
);

alter table ecommerce.categoria add constraint FK_CATEGORIA_SITIO foreign key(I_SITIO_PAGINA) references web.sitio(I_SITIO_ID);

drop table ecommerce.marca
create table ecommerce.marca(
	I_MARCA_ID integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    I_SITIO_PAGINA int,
	V_NOMBRE varchar(50) NOT NULL,
    B_ACTIVO boolean NOT null,
    V_USUARIO_REGISTRO varchar(20) not null,
    D_REGISTRO timestamp not null,
    V_USR_MODIFICACION varchar(20) null,
    D_MODIFICACION timestamp null
);
alter table ecommerce.marca add constraint FK_MARCA_SITIO foreign key(I_SITIO_PAGINA) references web.sitio(I_SITIO_ID);

drop table ecommerce.producto
create table ecommerce.producto(
	I_PRODUCTO_ID integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
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
    V_USUARIO_REGISTRO varchar(20) not null,
    D_REGISTRO timestamp not null,
    V_USR_MODIFICACION varchar(20) null,
    D_MODIFICACION timestamp null
);

alter table ecommerce.producto add constraint FK_PRODUCTO_SITIO foreign key(I_SITIO_PAGINA) references web.sitio(I_SITIO_ID);
alter table ecommerce.producto add constraint FK_PRODUCTO_CATEGORIA foreign key(I_CATEGORIA_ID)  references ecommerce.categoria(I_CATEGORIA_ID);
alter table ecommerce.producto add constraint FK_PRODUCTO_MARCA foreign key(I_MARCA_ID)  references ecommerce.marca(I_MARCA_ID);

 
create table ecommerce.producto_imagen(
	I_PRODUCTO_IMAGEN_ID integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    I_PRODUCTO_ID int,
    I_POSICION int,
    I_TIPO_TAMANIO varchar(500), -- sm, m ,l, xl
    I_COLOR int,
    V_NOMBRE_ARCHIVO varchar(500),
	V_URL_ARCHIVO varchar(500),
	B_ACTIVO boolean NOT null,
    V_USUARIO_REGISTRO varchar(20) not null,
    D_REGISTRO timestamp not null
);
alter table ecommerce.producto_imagen add constraint FK_PRODUCTO_IMAGEN foreign key(I_PRODUCTO_ID) references ecommerce.producto(I_PRODUCTO_ID);

DROP TABLE ecommerce.producto_imagen
select * from ecommerce.producto_imagen
select * from ecommerce.producto_imagen
select * from web.sitio_pagina
drop table web.sitio_pagina 
