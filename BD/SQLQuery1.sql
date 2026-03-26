create database ASIGNACION3; 
GO 
USE ASIGNACION3; 
GO 

CREATE TABLE Contactos 
(
id int identity(1,1) primary key, 
nombre nvarchar(50) not null, 
apellido nvarchar(50)not null,
correo nvarchar(100) not null,
telefono nvarchar(15) not null,
direccion nvarchar(255) not null,
--auditoria
creado_por nvarchar(50)not null,
fecha_creacion datetime not null default GETDATE(),  
fecha_modificacion datetime,
modificado_por nvarchar(50)not null,
);
go

--CRUD 
--Create 
CREATE PROCEDURE sp_CrearContacto 
@nombre nvarchar(50) , 
@apellido nvarchar(50),
@correo nvarchar(100),
@telefono nvarchar(15) ,
@direccion nvarchar(255) ,
@creado_por nvarchar(50)
AS
BEGIN
	INSERT INTO Contactos (Nombre, apellido, correo, telefono, direccion, creado_por)
	values (@nombre, @apellido, @correo, @telefono,@direccion, @creado_por); 
END
;
GO
--Read
CREATE PROCEDURE sp_LeerContacto 
AS
BEGIN
select * from Contactos;
END;
GO
--Update
CREATE PROCEDURE sp_ActualizarContacto 
@id int, 
@nombre nvarchar(50) , 
@apellido nvarchar(50),
@correo nvarchar(100),
@telefono nvarchar(15) ,
@direccion nvarchar(255) ,
@modificado_por nvarchar(50)
AS
BEGIN
update Contactos 
set  nombre = @nombre,
 @apellido=@apellido,
 @correo=@correo,
 @telefono=@telefono,
 @direccion=@direccion
where id=@id;
END;
GO
--Delete
CREATE PROCEDURE sp_EliminarContacto  @id int
AS
BEGIN
delete from Contactos where id=@id;
END;