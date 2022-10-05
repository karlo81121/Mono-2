CREATE TABLE Employee (
    ID INT PRIMARY KEY NOT NULL,
	first_name VARCHAR(20) NOT NULL,
	last_name VARCHAR(20) NOT NULL,
	birth_date DATE NOT NULL,
	gender CHAR(1) NOT NULL,
	hire_date DATE NOT NULL,
);

CREATE INDEX idx_employee ON Employee (first_name, last_name);

SELECT * FROM Employee;

SELECT * FROM Employee WHERE first_name = 'Pero' and last_name = 'Peric';
SELECT * FROM Employee WHERE gender IN ('M');
SELECT ID 'Employee ID', COUNT(*) 'no. of employees' FROM Employee GROUP BY ID;

SELECT * FROM Employee ORDER BY birth_date DESC;

UPDATE Employee SET first_name = '?uro' WHERE first_name = 'Pero';

INSERT INTO Employee VALUES(1, 'Piper', 'Baron','1999-10-10','M', '2022-4-4');
INSERT INTO Employee VALUES(2, 'Ryland', 'Bishop','2001-12-5','M', '2021-3-10');
INSERT INTO Employee VALUES(3, 'Sanai', 'Tucker','1999-10-10','M', '2016-1-22');
INSERT INTO Employee VALUES(4, 'Paulina', 'Becker','1999-10-10','F', '2016-1-22');
INSERT INTO Employee VALUES(5, 'Dante', 'Berg','1999-10-10','M', '2016-1-22');
INSERT INTO Employee VALUES(6, 'Karlie', 'Price','1999-10-10','F', '2016-1-22');
INSERT INTO Employee VALUES(7, 'Lillian', 'Salinas','1999-10-10','F', '2016-1-22');
INSERT INTO Employee VALUES(8, 'Litzy', 'Estrada','1999-10-10','F', '2016-1-22');
INSERT INTO Employee VALUES(9, 'Ishaan', 'Jarvis','1999-10-10','M', '2016-1-22');
INSERT INTO Employee VALUES(10, 'Azaria', 'Oliver','1999-10-10','F', '2016-1-22');
INSERT INTO Employee VALUES(11, 'Shane', 'Cannon','1999-10-10','M', '2022-4-4');
INSERT INTO Employee VALUES(12, 'Billy', 'Hester','2001-12-5','M', '2021-3-10');
INSERT INTO Employee VALUES(13, 'Garrett', 'Sosa','1999-10-10','M', '2016-1-22');
INSERT INTO Employee VALUES(14, 'Khloe', 'Koch','1999-10-10','F', '2016-1-22');
INSERT INTO Employee VALUES(15, 'Yair', 'Patton','1999-10-10','M', '2016-1-22');
INSERT INTO Employee VALUES(16, 'Arielle', 'Bowers','1999-10-10','F', '2016-1-22');
INSERT INTO Employee VALUES(17, 'Darion', 'Hunter','1999-10-10','M', '2016-1-22');
INSERT INTO Employee VALUES(18, 'Grady', 'Maxwell','1999-10-10','M', '2016-1-22');
INSERT INTO Employee VALUES(19, 'Emilee', 'Higgins','1999-10-10','F', '2016-1-22');
INSERT INTO Employee VALUES(20, 'Jon', 'Walters','1999-10-10','M', '2016-1-22');

DELETE FROM Employee;
DELETE FROM Employee WHERE ID = 1;

DROP TABLE Employee;
