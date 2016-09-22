CREATE TABLE categoria(
    id bigint AUTO_INCREMENT PRIMARY KEY,
    nombre varchar(50) not null UNIQUE
    );

INSERT into categoria (nombre) VALUES ('categoria 1');
INSERT into categoria (nombre) VALUES ('categoria 2');
INSERT into categoria (nombre) VALUES ('categoria 3');

create table articulo(
	id bigint auto_increment primary key,
	nombre varchar(50) not null unique,
	precio decimal (10,2)
	categoria bigint
);

alter table articulo add foreign key (categoria) references categoria (id);

INSERT into categoria (nombre,precio,categoria) VALUES ('articulo 1',1,1);
INSERT into categoria (nombre,precio,categoria) VALUES ('articulo 2',2,2);
INSERT into categoria (nombre,precio) VALUES ('articulo 3',3);
INSERT into categoria (nombre) VALUES ('articulo 4');
