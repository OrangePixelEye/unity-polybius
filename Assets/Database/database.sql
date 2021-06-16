--Banco de dados Polybius



------------------

CREATE DATABASE Polybius;
USE Polybius;
-----------------
CREATE TABLE `Polybius`.`jogadores` ( `name` char(3) , `time` TIME , `final` tinyint ,  PRIMARY KEY (`name`)) ENGINE = InnoDB;
------------------
INSERT INTO jogadores
	(name, time, final)
    VALUES
    ("BBB", 830, 1);

INSERT INTO jogadores
	(name, time, final)
    VALUES
    ("CCC", 820, 1);

INSERT INTO jogadores
	(name, time, final)
    VALUES
    ("ABB", 900, 1);
