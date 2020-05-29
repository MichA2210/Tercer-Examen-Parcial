create table IF NOT EXISTS alumnos(
	matricula int,
	nombre text,
	apellido text,
	genero text,
	materias list<text>, //este queda pendiente, no lo entiendo.
	fecha_nacimiento timestamp,
	carrera text,
	PRIMARY KEY (matricula)
);

insert into keyspace1.alumnos(
	matricula,
	nombre,
	apellido,
	genero,
	materias,
	fecha_nacimiento, carrera) values(2, 'A', 'B', 'Femenino', ['3','d','puto'], '2020-04-27', 'LMAD');

select * from alumnos;

drop table alumnos;