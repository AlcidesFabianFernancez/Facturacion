create table usuarios(
	cod_usuario serial primary key,
	nombre_usuario varchar(50) not null,
	pass varchar(30) not null,
	activo boolean
);

insert into usuarios(nombre_usuario, pass, activo) values('admin', 'admin', true);

create table empleados(
	cod_empleado serial primary key,
	nombres varchar(50) not null,
	apellidos varchar(50) not null,
	documento varchar(50) unique,
	direccion varchar(50),
	fecha_nacimiento date,
	sexo varchar(20),
	cargo varchar(20),
	fecha_inicio date,
	salario integer,
	cod_departamento integer,
	descuento integer,
	horas_extra int
);

create table departamento(
	cod_departamento serial primary key,
	nombre varchar(30) not null,
	descripcion varchar(100)
);


create table sucursales(
	cod_sucursal serial primary key,
	nombre varchar(30) not null,
	descripcion varchar(100)
);

create table clientes(
	cod_cliente serial primary key,
	nombre varchar(50) not null,
	ruc	varchar(50)not null,
	direccion varchar(100) not null,
	telefono varchar(30),
	tipo varchar(50) default 'Casual',
	contacto varchar(50),
	ciudad varchar(50),
	pais varchar(50),
	nro_cuenta varchar(50),
	saldo int
);

create table productos(
	cod_producto serial primary key,
	nombre varchar(50) not null,
	cod_barras varchar(50)not null unique,
	tipo varchar(30),
	fecha_vencimiento date,
	lote varchar(30),
	stock_minino integer,
	costo decimal(10,2),
	descripcion varchar(100),
	iva varchar(10),
	stock int,
	costo_promedio decimal(10,2),
	reajuste_stock int,
	descripcion_reajuste varchar(100)
);

create table proveedores(
	cod_proveedor serial primary key,
	nombre varchar(50) not null,
	direccion varchar(100),
	pais varchar(30) default'Paraguay',
	contacto varchar(50),
	categoria varchar(50) default '1',
	descripcion varchar(100),
	telefono varchar(50),
	fax varchar(50),
	correo varchar(50)	
);

create table compras(
	cod_compras serial primary key,
	cod_proveedor int not null,
	nro_factura int not null,
	costo decimal(10,2),
	tipo varchar(50),
	constraint fk_proveedor foreign key (cod_proveedor)
	references proveedores(cod_proveedor)
);

create table facturas(
	cod_facturas serial primary key,
	nro_factura int not null,
	fecha date not null,
	cod_cliente int not null,
	cod_sucursal int not null,
	tipo varchar(50) not null,
	cod_empleado int,
	total_iva decimal(10,2) not null,
	total_fatura decimal(10,2) not null,
	descuento decimal(10,2),
	prefijo integer,
	constraint fk_cliente foreign key(cod_cliente)
	references clientes(cod_cliente),
	constraint fk_sucursal foreign key(cod_sucursal)
	references sucursales(cod_sucursal)
);

create table compra_detalle(
	cod_compra_detalle serial primary key,
	cod_compra int not null,
	cod_producto int not null,
	cantidad int not null,
	costo decimal(10,2),
	lote varchar(30),
	fec_vencimiento date,
	constraint fk_compra foreign key (cod_compra)
	references compras(cod_compras),
	constraint fk_producto foreign key (cod_producto)
	references productos(cod_producto)
);

create table factura_detalle(
	cod_fac_detalle serial primary key,
	cod_factura int not null,
	cod_producto int not null,
	cantidad int not null,
	iva decimal(10,2),
	precio_venta decimal(10,2),
	constraint fk_factura foreign key(cod_factura)
	references facturas(cod_facturas),
	constraint fk_producto foreign key(cod_producto)
	references productos(cod_producto)
);