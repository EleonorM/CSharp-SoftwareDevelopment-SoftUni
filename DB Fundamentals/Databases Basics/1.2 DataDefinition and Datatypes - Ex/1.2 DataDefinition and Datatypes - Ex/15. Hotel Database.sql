CREATE DATABASE Hotel

CREATE TABLE Employees  
(Id INT IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) ,
Notes NVARCHAR(50),

CONSTRAINT pk_Employees_Id PRIMARY KEY(Id)  
)

CREATE TABLE Customers   
(AccountNumber INT UNIQUE NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber INT,
EmergencyName NVARCHAR(50) ,
EmergencyNumber INT ,
Notes NVARCHAR(50),

CONSTRAINT pk_Customers_AccountNumber PRIMARY KEY(AccountNumber)  
)

CREATE TABLE RoomStatus    
(RoomStatus NVARCHAR(50) UNIQUE NOT NULL,
Notes NVARCHAR(50),

CONSTRAINT pk_RoomStatus_RoomStatus PRIMARY KEY(RoomStatus)  
)

CREATE TABLE RoomTypes     
(RoomType NVARCHAR(50) UNIQUE NOT NULL,
Notes NVARCHAR(50),

CONSTRAINT pk_RoomTypes_RoomType PRIMARY KEY(RoomType)  
)

CREATE TABLE BedTypes     
(BedType NVARCHAR(50) UNIQUE NOT NULL,
Notes NVARCHAR(50),

CONSTRAINT pk_BedTypes_BedType PRIMARY KEY(BedType)  
)

CREATE TABLE Rooms  
(RoomNumber INT UNIQUE NOT NULL,
RoomType NVARCHAR(50)  NOT NULL,
BedType NVARCHAR(50)  NOT NULL,
Rate DECIMAL(5,2),
RoomStatus NVARCHAR(50)  NOT NULL,
Notes NVARCHAR(50),

CONSTRAINT pk_Rooms_RoomNumber PRIMARY KEY(RoomNumber),
CONSTRAINT fk_Rooms_RoomType FOREIGN KEY(RoomType)
REFERENCES RoomTypes(RoomType),
CONSTRAINT fk_Rooms_BedType FOREIGN KEY(BedType)
REFERENCES BedTypes(BedType),
CONSTRAINT fk_Rooms_RoomStatus FOREIGN KEY(RoomStatus)
REFERENCES RoomStatus(RoomStatus)  
)

CREATE TABLE Payments   
(Id INT IDENTITY,
EmployeeId INT NOT NULL,
PaymentDate DATE,
AccountNumber INT NOT NULL,
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays INT,
AmountCharged DECIMAL(15,3),
TaxRate DECIMAL(15,3),
TaxAmount DECIMAL(15,3),
PaymentTotal DECIMAL(15,3),
Notes NVARCHAR(50),

CONSTRAINT pk_Payments_Id PRIMARY KEY(Id),
CONSTRAINT fk_Payments_EmployeeId FOREIGN KEY(EmployeeId)
REFERENCES Employees(Id),
CONSTRAINT fk_Payments_AccountNumber FOREIGN KEY(AccountNumber)
REFERENCES Customers(AccountNumber),
)

CREATE TABLE Occupancies    
(Id INT IDENTITY,
EmployeeId INT NOT NULL,
DateOccupied DATE,
AccountNumber INT NOT NULL,
RoomNumber INT NOT NULL,
RateApplied DATE,
PhoneCharge INT,
Notes NVARCHAR(50),

CONSTRAINT pk_Occupancies_Id PRIMARY KEY(Id),
CONSTRAINT fk_Occupancies_EmployeeId FOREIGN KEY(EmployeeId)
REFERENCES Employees(Id),
CONSTRAINT fk_Occupancies_AccountNumber FOREIGN KEY(AccountNumber)
REFERENCES Customers(AccountNumber),
CONSTRAINT fk_Occupancies_RoomNumber FOREIGN KEY(RoomNumber)
REFERENCES Rooms(RoomNumber)
)

INSERT INTO Employees
VALUES
('Name1', 'Last1', NULL, NULL),
('Name2', 'Last2', NULL, NULL),
('Name3', 'Last3', NULL, NULL)

INSERT INTO Customers
VALUES
(1643, 'Name4', 'Last4', NULL, NULL, NULL, NULL),
(9866, 'Name5', 'Last5', NULL, NULL, NULL, NULL),
(1978, 'Name6', 'Last6', NULL, NULL, NULL, NULL)

INSERT INTO RoomStatus
VALUES
('Occupied', NULL),
('Free',  NULL),
('Reserved', NULL)

INSERT INTO RoomTypes
VALUES
('Single', NULL),
('Double',  NULL),
('Apartment', NULL)

INSERT INTO BedTypes
VALUES
('Single', NULL),
('Double',  NULL),
('Separete', NULL)

INSERT INTO Rooms
VALUES
(1, 'Single', 'Single', NULL, 'Free', NULL),
(2, 'Double', 'Double', NULL, 'Occupied', NULL),
(3, 'Single', 'Separete', NULL, 'Free', NULL)

INSERT INTO Payments
VALUES
(1, '2019-09-01', 1643, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(3, '2019-09-01', 9866, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, '2019-09-02', 9866, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO Occupancies
VALUES
(1, '2019-09-01', 1643, 1, NULL, NULL, NULL),
(3, '2019-09-01', 9866, 2, NULL, NULL, NULL),
(2, '2019-09-02', 9866, 3, NULL, NULL, NULL)
