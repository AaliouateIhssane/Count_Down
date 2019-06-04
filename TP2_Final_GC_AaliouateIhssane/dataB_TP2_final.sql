use master
create DATABASE TP2_db

USE TP2_db

drop table  Msg

select*from register

CREATE TABLE register (
id int  primary key identity(1,1),
UserName varchar(20) NOT null,
UserPassword varchar(20) NOT null,
job varchar(30),
email varchar(40),
Photo varchar(30) ,
DateR date not null default getdate() )

drop table register



insert into register values('Ihssane','Abc123','Developper','User-image/1.jpg',getdate())

CREATE TABLE Msg( 
id int  primary key identity(1,1),
Email varchar(20)  NOT null,
UserName  varchar(20) NOT null,
mssg varchar(300) NOT null,
DateM date not null default getdate())

insert into Msg values('Ihssane@gmail.com','ihssane','salut jai rien a dire',getdate())

select*from register
select*from Msg