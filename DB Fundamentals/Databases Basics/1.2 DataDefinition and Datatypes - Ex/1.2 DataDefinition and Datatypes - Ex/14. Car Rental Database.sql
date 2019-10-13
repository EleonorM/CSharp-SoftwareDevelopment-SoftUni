CREATE DATABASE CarRental 

CREATE TABLE Categories 
(Id INT IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
DailyRate DECIMAL(3,2),
WeeklyRate DECIMAL(3,2),
MonthlyRate DECIMAL(3,2),
WeekendRate DECIMAL(3,2),

CONSTRAINT pk_Categories_Id PRIMARY KEY(Id)  
)

CREATE TABLE Cars  
(Id INT IDENTITY,
PlateNumber VARCHAR(10) NOT NULL,
Manufacturer NVARCHAR(50),
Model NVARCHAR(50),
CarYear DATE,
CategoryId INT,
Doors INT,
Picture VARBINARY(MAX),
Condition NVARCHAR(100),
Available BIT NOT NULL,


CONSTRAINT pk_Cars_Id PRIMARY KEY(Id)  
)

CREATE TABLE Employees  
(Id INT IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) ,
Notes NVARCHAR(50),

CONSTRAINT pk_Employees_Id PRIMARY KEY(Id)  
)

CREATE TABLE Customers   
(Id INT IDENTITY,
DriverLicenceNumber VARCHAR(10) NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(50) ,
City NVARCHAR(50) ,
ZIPCode INT ,
Notes NVARCHAR(50),

CONSTRAINT pk_Customers_Id PRIMARY KEY(Id)  
)

CREATE TABLE RentalOrders   
(Id INT IDENTITY,
EmployeeId INT NOT NULL,
CustomerId INT NOT NULL,
CarId INT NOT NULL,
TankLevel INT,
KilometrageStart DECIMAL(15,2),
KilometrageEnd DECIMAL(15,2),
TotalKilometrage DECIMAL(15,2),
StartDate DATE,
EndDate DATE,
TotalDays INT,
RateApplied DECIMAL(3,2),
TaxRate DECIMAL(3,2),
OrderStatus NVARCHAR(30),
Notes NVARCHAR(100), 

CONSTRAINT pk_RentalOrders_Id PRIMARY KEY(Id) ,
CONSTRAINT fk_EmployeeId FOREIGN KEY(EmployeeId)
REFERENCES Employees(Id),
CONSTRAINT fk_CustomerId FOREIGN KEY(CustomerId)
REFERENCES Customers(Id),
CONSTRAINT fk_CarId FOREIGN KEY(CarId)
REFERENCES Cars(Id)
)

INSERT INTO Categories
VALUES
('Average', 3, 5.1, 8, 9),
('Bigger', 2, 5, 3.4, 4),
('Smaller', 7, 9.6, 2, 6)

INSERT INTO Cars
VALUES
('987654AA', 'VW', 'Golf', '2005', 1, 4, NULL, NULL, 1),
('IU8654AA', 'Honda', 'Jazz', '2015', 3, 5, NULL, NULL, 0),
('AC654AA', 'BMW', '507', '2019', 2, 3, NULL, NULL, 0)

INSERT INTO Employees
VALUES
('Eleonor', 'Manolova', NULL, NULL),
('Pesho', 'Manolov', NULL, NULL),
('Gosho', 'Goshev', NULL, NULL)

INSERT INTO Customers
VALUES
('987654A', 'Ina Manolova', NULL, 'Varna', 9000, NULL),
('886253B', 'Alan Right', NULL, 'Sofia', 1500, NULL),
('B92833A', 'Kate Scott', NULL, 'Varna', 9000, NULL)

INSERT INTO RentalOrders
VALUES
(1, 2, 2, 12, 0 , 10000, 10000, '2009', '2015', NULL, NULL,NULL,NULL,NULL),
(3, 1, 1, 21, 160000, 165000, 5000, '2015', '2019', NULL, NULL,NULL,NULL,NULL),
(2, 3, 3, 43, 10000, 150000, 140000, '2019', '2019', NULL, NULL,NULL,NULL,NULL)