CREATE TABLE categoria(
    id bigint AUTO_INCREMENT PRIMARY KEY,
    nombre varchar(50) not null UNIQUE
    );

INSERT into categoria (nombre) VALUES ('categoria 1');
INSERT into categoria (nombre) VALUES ('categoria 2');
INSERT into categoria (nombre) VALUES ('categoria 3')
