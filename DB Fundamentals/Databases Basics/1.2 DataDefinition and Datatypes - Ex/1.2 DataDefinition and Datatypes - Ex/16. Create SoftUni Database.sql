CREATE DATABASE SoftUniDemo

USE SoftUniDemo

CREATE TABLE Towns(
  TownID INT IDENTITY NOT NULL,
  Name VARCHAR(50) NOT NULL,
  CONSTRAINT PK_Towns PRIMARY KEY (TownID)
)

CREATE TABLE Addresses(
  AddressID int IDENTITY NOT NULL,
  AddressText VARCHAR(100) NOT NULL,
  TownID int NULL,

  CONSTRAINT PK_Addresses PRIMARY KEY  (AddressID),
  CONSTRAINT FK_Addresses_TownID FOREIGN KEY(TownID)
  REFERENCES Towns(TownID)
)

CREATE TABLE Departments(
  DepartmentID int IDENTITY NOT NULL,
  [Name] VARCHAR(50) NOT NULL,
  CONSTRAINT PK_Departments PRIMARY KEY (DepartmentID)
)

CREATE TABLE Employees(
  EmployeeID INT IDENTITY NOT NULL,
  FirstName VARCHAR(50) NOT NULL,
  MiddleName VARCHAR(50),
  LastName VARCHAR(50) NOT NULL,
  JobTitle VARCHAR(50),
  DepartmentID INT NOT NULL,
  HireDate DATETIME ,
  Salary DECIMAL(15,3) ,
  AddressID int NOT NULL ,
  CONSTRAINT PK_Employees PRIMARY KEY (EmployeeID),
  CONSTRAINT FK_Employees_DepartmentID FOREIGN KEY(DepartmentID)
  REFERENCES Departments(DepartmentID),
  CONSTRAINT FK_Employees_AddressID FOREIGN KEY(AddressID)
  REFERENCES Addresses (AddressID)
)

INSERT INTO Towns ([Name])
VALUES 
('Sofia'),
('Varna'),
('Plovdiv')

INSERT INTO Addresses (AddressText, TownID)
VALUES 
('108 Lakeside Court', 1),
('1343 Prospect St', 2),
('1648 Eastgate Lane', 3)

INSERT INTO Departments ([Name])
VALUES 
('Engineering'),
('Tool Design'),
('Sales')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentID, HireDate, Salary, AddressID)
VALUES 
('Guy', 'R', 'Gilbert', 'Production Technician', 1,  '19980731', 12500, 1),
('Kevin', 'F', 'Brown', 'Marketing Assistant', 2, '19990226', 13500, 3),
('Roberto', NULL, 'Tamburello', 'Engineering Manager', 3,  '19991212', 43300, 2)
