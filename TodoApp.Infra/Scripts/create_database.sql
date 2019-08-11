/*

docker run -p 5432:5432 --name postgresql -e POSTGRES_PASSWORD=123456 -d postgres
docker exec -it postgresql psql -U postgres -c "create database todoapp"

*/
/*
CREATE TABLE public.user (
       id SERIAL,
       email VARCHAR(250) NOT NULL,
       password VARCHAR(250) NOT NULL,
       CONSTRAINT pk_user PRIMARY KEY (id)
);
insert into public.user (email, password) values ('lucas_val@outlook.com', '123456');


CREATE TABLE public.todotask (
       id SERIAL,
       description VARCHAR(250) NOT NULL, 
       createdate TIMESTAMP NOT NULL,
       status INTEGER NOT NULL,
       enddate TIMESTAMP,
       iduser INTEGER NOT NULL,
       CONSTRAINT pk_todotask PRIMARY KEY (id),
       FOREIGN KEY (iduser) REFERENCES public.user (id) ON DELETE RESTRICT ON UPDATE RESTRICT
);
insert into public.todotask (description, createdate, status, enddate, iduser) values ('New task 1', '2019-08-11 18:08:45', 1, null, 1);

*/