create database Metallica

use Metallica

 create table Album
(
 Id int primary key identity(1,1) not null,
 Nombre varchar(30) not null,
 Fecha datetime,
 Compositores text
)