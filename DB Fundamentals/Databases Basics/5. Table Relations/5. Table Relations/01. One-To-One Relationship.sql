CREATE DATABASE TableRelations


USE TableRelations


CREATE TABLE Passports
	(PassportID INT NOT NULL,
	PassportNumber NVARCHAR(50) NOT NULL

	CONSTRAINT PK_Passports_PassportID
	PRIMARY KEY (PassportID)
	)


CREATE TABLE Persons(
	PersonID INT NOT NULL,
	FirstName NVARCHAR(50),
	Salary DECIMAL(15,2),
	PassportID INT NOT NULL
	
	CONSTRAINT PK_People_PersonID
	PRIMARY KEY (PersonID)
	CONSTRAINT FK_People_Passports
	FOREIGN KEY (PassportID)
	REFERENCES Passports(PassportID)
	)


INSERT INTO Passports
VALUES(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')


INSERT INTO Persons
VALUES
(1, 'Roberto', 43300.00, 102),
(2, 'Tom',56100.00,103),
(3, 'Yana',60200.00,101)


SELECT * 
FROM Passports
GO

SELECT * 
FROM People
GO