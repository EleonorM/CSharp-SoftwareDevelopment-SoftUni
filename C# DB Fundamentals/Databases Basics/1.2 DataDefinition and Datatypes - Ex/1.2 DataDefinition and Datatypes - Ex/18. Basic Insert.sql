INSERT INTO Towns ([Name])
VALUES 
('Sofia'),
('Varna'),
('Plovdiv'),
('Burgas')

INSERT INTO Addresses (AddressText, TownID)
VALUES 
('108 Lakeside Court', 1),
('1343 Prospect St', 2),
('1648 Eastgate Lane', 3)

INSERT INTO Departments ([Name])
VALUES 
('Engineering'),
('Marketing'),
('Sales'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentID, HireDate, Salary, AddressID)
VALUES 
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4,  '20130201', 3500.00, 1),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '20040302', 4000.00, 3),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '20160828', 525.25, 2),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 3, '20071209', 3000.00, 3),
('Peter', 'Pan', 'Pan', 'Intern', 2, '20160828', 599.88, 3)