drop database DB_TPC_Rubinstein_prueba

use master
go
create database DB_TPC_Rubinstein_prueba
go
use DB_TPC_Rubinstein_prueba

go
create table Proveedor( 
    IdProveedor int not null primary key identity(1,1),
    CUIL varchar(50) not null,
    RazonSocial varchar(50) not null,
    Direccion varchar (60) not null,
    Localidad varchar(60) not null,
    Contacto varchar(60) not null,
    Telefono varchar(60) not null,
    Mail varchar(60) not null,
    Estado bit not null
)
go
create table Administrador(
    IdAdmin int not null primary key identity(1,1),
    Nombre varchar(50) not null,
    Mail varchar(60) not null,
    Pass varchar(60) not null,   
    --Estado bit not null,
    --Bloqueado bit not null
)

go
create table Cliente( 
    IdCliente int not null primary key identity(1,1),
    Nombre varchar(50) not null,
    Apellido varchar(50) not null,
    Direccion varchar (60) not null,
    Localidad varchar(60) not null,
    Telefono varchar(60) not null,
    Mail varchar(60) not null,
    Pass varchar(60) not null,   
    Estado bit not null,
    Bloqueado bit not null
)
GO
CREATE TABLE MARCA(
	IDMARCA INT NOT NULL PRIMARY KEY identity(1,1),
	DESCRIPCION VARCHAR(50)NOT NULL 
)

go
create table Producto(
IdProducto int not null primary key identity(1,1),
Descripcion varchar (60) not null,
--IDMARCA INT NULL FOREIGN KEY REFERENCES MARCA(IDMARCA),
--StockMinimo int not null, 
StockActual int not null,
Impuesto money not null,
Precio money not null,
Costo money not null,
Estado bit not null,
Imagen varchar(200) null
)

GO 
CREATE TABLE CATEGORIA(
	IDCATEGORIA INT NOT NULL PRIMARY KEY identity(1,1),
	CATEGORIA VARCHAR(30) NOT NULL
)

GO
CREATE TABLE CATEGORIAS_X_PRODUCTO(
	IDPRODUCTO INT NOT NULL FOREIGN KEY REFERENCES PRODUCTO (IDPRODUCTO),
	IDCATEGORIA INT NOT NULL FOREIGN KEY REFERENCES CATEGORIA (IDCATEGORIA),
	PRIMARY KEY (IDPRODUCTO, IDCATEGORIA)
)

GO
CREATE TABLE PROVEEDORES_X_PRODUCTO(
	IDPRODUCTO INT NOT NULL FOREIGN KEY REFERENCES PRODUCTO (IDPRODUCTO),
	IDPROVEEDOR INT NOT NULL FOREIGN KEY REFERENCES PROVEEDOR (IDPROVEEDOR),
	PRIMARY KEY (IDPRODUCTO, IDPROVEEDOR)
)

go
create table PEDIDO(
IdPedido int not null primary key identity(1,1),
IdCliente int not null foreign key references CLIENTE(IdCliente),
Fecha DATE not null,
FechaEntrega DATE not null,
Estado bit not null,
--CondicionVenta varchar(30) not null,
)
go
create table DETALLE_PEDIDO(
IdDetalle int not null primary key identity(1,1),
IdPedido int not null foreign key references PEDIDO(IdPedido),
IdProducto int not null foreign key references PRODUCTO(IdProducto),
Cantidad int not null,
Precio money not null,
)

--go
--create TABLE DETALLE_X_PEDIDO(
--IdPedido
--)

--PROVEEDORES
INSERT INTO PROVEEDOR (CUIL, RazonSocial, Direccion, Localidad, Contacto, Telefono,Mail,Estado) VALUES ('30-67853957-7', 'GRUPO BIMBO','Av. Corrientes 330', 'San Nicolas','Mariela Gutierrez','4546-9909','mgutierrez@grupobimbo.com.ar', 1)
INSERT INTO PROVEEDOR (CUIL, RazonSocial, Direccion, Localidad, Contacto, Telefono,Mail,Estado) VALUES ('30-61493539-8', 'GRANIX SA','Av San Martin 4625','Florida','Nicolas Brauli','4788-8922','nbrauli@granix.com',1)
INSERT INTO PROVEEDOR (CUIL, RazonSocial, Direccion, Localidad, Contacto, Telefono,Mail,Estado) VALUES ('30-50085862-8','MOLINOS RIO DE LA PLATA SA','Uruguay 4075','Victoria','Dario Leuco','4345-9494','dleuco@molinosdelplata.com.ar',0)

--CLIENTES
insert into Cliente(Nombre,Apellido,Direccion,Localidad,Telefono,Mail,Estado,Pass,Bloqueado)values ('Daniela','Rubinstein','Ecuador 1444','Don Torcuato','4590-0099','danurubin@gmail.com',1,'password1',1)
insert into Cliente(Nombre,Apellido,Direccion,Localidad,Telefono,Mail,Estado,Pass,Bloqueado)values ('Bireli','Lagrene','Brasil 789','Florida','4678-0033','birelilagrene@outlook.com',1,'password2',1)
insert into Cliente(Nombre,Apellido,Direccion,Localidad,Telefono,Mail,Estado,Pass,Bloqueado)values ('Marco','Gallo','Calle 15','La Plata','0345-345-678','mgallo@gmail.com',1,'password3',1)

--ADMIN
insert into Administrador(Nombre,Mail,Pass)values ('Veronica','verodelecumbarry@gmail.com','password1')

--MARCA
--insert into MARCA(DESCRIPCION) values('Bimbo')
--insert into MARCA(DESCRIPCION) values('Skarchitos')
--insert into MARCA(DESCRIPCION) values('La Salteña')
--insert into MARCA(DESCRIPCION) values ('Las Frambuesas')

--CATEGORIA
insert into CATEGORIA(CATEGORIA) values('Chocolate')
insert into CATEGORIA(CATEGORIA) values('Cheesecake')
insert into CATEGORIA(CATEGORIA) values('Frutales')
insert into CATEGORIA(CATEGORIA) values('Dulce de leche')
insert into CATEGORIA(CATEGORIA) values('Tematicas')

--CALCULAR PRECIOS CON EL IMPUESTO
--PRODUCTO
insert into Producto (Descripcion,StockActual,Costo,Impuesto,Precio,Estado,Imagen) 
values ('Cheesecake Oreo',10,100,21,400,1,'https://drive.google.com/uc?id=1ebTBanCHNF9PHFAFn6iz2nNFbTsTWZd0')
insert into Producto (Descripcion,StockActual,Costo,Impuesto,Precio,Estado,Imagen) 
values ('Torta de golosinas',10,100,21,200,1,'https://drive.google.com/uc?id=1ixn8lIkUz5tcbNo_-dFLSeVSbfgtreFi')
insert into Producto (Descripcion,StockActual,Costo,Impuesto,Precio,Estado,Imagen) 
values ('Tarta de manzana',10,100,21,200,1,'https://drive.google.com/uc?id=1sNmubgVGXU_GO8q-C_XpFc3Qx6SnnA3C')
insert into Producto (Descripcion,StockActual,Costo,Impuesto,Precio,Estado,Imagen) 
values ('Tarta de coco',10,100,21,200,1,'https://drive.google.com/uc?id=12oXldsEryI3vXW-Sj3p8uQRJrRyAJwqn')
insert into Producto (Descripcion,StockActual,Costo,Impuesto,Precio,Estado,Imagen) 
values ('Marquise de chocolate',10,100,21,200,1,'https://drive.google.com/uc?id=1KH9bMYhw7FjkSD8TrIzCIqF6qJAo9jna')


--CATEGORIAS POR PRODUCTO
INSERT INTO CATEGORIAS_X_PRODUCTO(IDPRODUCTO, IDCATEGORIA) VALUES (1, 1)
INSERT INTO CATEGORIAS_X_PRODUCTO(IDPRODUCTO, IDCATEGORIA) VALUES (1, 3)
INSERT INTO CATEGORIAS_X_PRODUCTO(IDPRODUCTO, IDCATEGORIA) VALUES (2, 5)
INSERT INTO CATEGORIAS_X_PRODUCTO(IDPRODUCTO, IDCATEGORIA) VALUES (2, 1)
INSERT INTO CATEGORIAS_X_PRODUCTO(IDPRODUCTO, IDCATEGORIA) VALUES (3, 3)
INSERT INTO CATEGORIAS_X_PRODUCTO(IDPRODUCTO, IDCATEGORIA) VALUES (4, 4)
INSERT INTO CATEGORIAS_X_PRODUCTO(IDPRODUCTO, IDCATEGORIA) VALUES (4, 3)
INSERT INTO CATEGORIAS_X_PRODUCTO(IDPRODUCTO, IDCATEGORIA) VALUES (5, 1)
INSERT INTO CATEGORIAS_X_PRODUCTO(IDPRODUCTO, IDCATEGORIA) VALUES (5, 2)

--PROVEEDORES POR PRODUCTO
INSERT INTO PROVEEDORES_X_PRODUCTO(IDPRODUCTO, IDPROVEEDOR) VALUES (1, 1)
INSERT INTO PROVEEDORES_X_PRODUCTO(IDPRODUCTO, IDPROVEEDOR) VALUES (2, 2)
INSERT INTO PROVEEDORES_X_PRODUCTO(IDPRODUCTO, IDPROVEEDOR) VALUES (3, 3)

--PEDIDOS
insert into PEDIDO(IdCliente,Fecha,FechaEntrega,Estado) values(1, getdate(), '2019-12-27',1)
insert into PEDIDO(IdCliente,Fecha,FechaEntrega,Estado) values(2, getdate(), '2019-12-28',1)
--DETALLE PEDIDOS
insert into DETALLE_PEDIDO(IdPedido,IdProducto,Cantidad,Precio)values(1,1,1,200)
insert into DETALLE_PEDIDO(IdPedido,IdProducto,Cantidad,Precio)values(1,2,1,200)
insert into DETALLE_PEDIDO(IdPedido,IdProducto,Cantidad,Precio)values(2,3,1,200)


--SELECTS
select P.IdProducto, P.Descripcion,C.Categoria,StockActual,Precio,Impuesto,Costo,Estado,Imagen from producto as P
inner join CATEGORIAS_X_PRODUCTO as CxP on P.IdProducto=CxP.IDPRODUCTO
inner join CATEGORIA as c on CxP.IDCATEGORIA=C.IDCATEGORIA

Select P.IdProducto, P.Descripcion,C.Categoria,StockActual,Precio,Impuesto,Costo,Estado,Imagen 
from producto as P 
inner join CATEGORIAS_X_PRODUCTO as CxP on P.IdProducto = CxP.IDPRODUCTO 
inner join CATEGORIA as c on CxP.IDCATEGORIA = C.IDCATEGORIA where Estado=1
--
Select P.IdProducto, P.Descripcion,C.Categoria,StockActual,Precio,Impuesto,Costo,Estado,Imagen 
from producto as P 
left join CATEGORIAS_X_PRODUCTO as CxP on P.IdProducto = CxP.IDPRODUCTO 
left join CATEGORIA as c on CxP.IDCATEGORIA = C.IDCATEGORIA 
where Estado=1

Select P.IdProducto, P.Descripcion,C.Categoria,StockActual,Precio,Impuesto,Costo,Estado,Imagen 
from producto as P 
left join CATEGORIAS_X_PRODUCTO as CxP on P.IdProducto = CxP.IDPRODUCTO 
left join CATEGORIA as c on CxP.IDCATEGORIA = C.IDCATEGORIA 
where P.IdProducto=1

select * from CATEGORIAS_X_PRODUCTO
select * from CATEGORIA
select * from Producto
select * from Cliente
select * from Pedido
select * from DETALLE_PEDIDO

--select de pedido
select P.IdPedido,P.Fecha,P.FechaEntrega,P.Estado,
C.IdCliente,C.Nombre,C.Apellido,C.Direccion,C.Localidad,C.Telefono,C.Mail,
DP.IdDetalle, DP.Cantidad, DP.Precio,
Prod.Descripcion
from PEDIDO as P
inner join Cliente as C on P.IdCliente=C.IdCliente
inner join DETALLE_PEDIDO as DP on P.IdPedido=DP.IdPedido
inner join Producto as Prod on DP.IdProducto=Prod.IdProducto
where p.Estado=1 and exists(select 1 from pedido as p where p.IdPedido=DP.IdPedido group by p.IdPedido)

select * from PEDIDO 
inner join Cliente on PEDIDO.IdCliente=Cliente.IdCliente
inner join DETALLE_PEDIDO on PEDIDO.IdPedido=DETALLE_PEDIDO.IdPedido
inner join Producto on DETALLE_PEDIDO.IdProducto=Producto.IdProducto
where PEDIDO.Estado=1

select DP.IdDetalle, Prod.Descripcion, DP.Cantidad,DP.Precio
from PEDIDO as P
inner join DETALLE_PEDIDO as DP on P.IdPedido=DP.IdPedido
inner join Producto as Prod on DP.IdProducto=Prod.IdProducto
where  DP.IdPedido=1

update Producto set precio=400 where IdProducto=1
