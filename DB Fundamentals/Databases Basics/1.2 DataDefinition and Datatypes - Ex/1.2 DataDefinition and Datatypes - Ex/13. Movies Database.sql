CREATE DATABASE Movies

CREATE TABLE Directors
(Id INT IDENTITY,
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(100),

CONSTRAINT pk_Id PRIMARY KEY(Id)  
)

CREATE TABLE Genres 
(Id INT IDENTITY,
GenreName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(100),

CONSTRAINT pk_Genres_Id PRIMARY KEY(Id)  
)

CREATE TABLE Categories 
(Id INT IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(50),

CONSTRAINT pk_Categories_Id PRIMARY KEY(Id)  
)

CREATE TABLE Movies  
(Id INT IDENTITY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT NOT NULL,
CopyrightYear Date,
[Length] DECIMAL(15,2),
GenreId INT,
CategoryId INT, 
Rating DECIMAL(5,2),
Notes NVARCHAR(100), 

CONSTRAINT pk_Movies_Id PRIMARY KEY(Id) ,
CONSTRAINT fk_DirectorId FOREIGN KEY(DirectorId)
REFERENCES Directors(Id),
CONSTRAINT fk_GenreId FOREIGN KEY(GenreId)
REFERENCES Genres(Id),
CONSTRAINT fk_CategoryId FOREIGN KEY(CategoryId)
REFERENCES Categories(Id)
)

INSERT INTO Directors
VALUES
('Luc Beson', NULL),
('Quentin Tarantino', NULL),
('Steven Spielberg', NULL),
('Martin Scorsese', NULL),
('James Cameron', NULL)

INSERT INTO Genres
VALUES
('Action', NULL),
('Romance', NULL),
('Drama', NULL),
('Comedy', NULL),
('Family', NULL)

INSERT INTO Categories
VALUES
('History', NULL),
('Documentary', NULL),
('Fantasy', NULL),
('Western', NULL),
('Political', NULL)

INSERT INTO Movies
VALUES
('Titanic', 5, '2000', 2.15, 3, 1, 8.4, NULL),
('Run', 4, '2015', 2.00, 2, 2, 6.2, NULL),
('Avatar', 2, '2009', 1.45, 5, 3,8, NULL),
('Inception', 3, '2019', 1.35, 4, 4, 9.4, NULL),
('Far Away', 1, '1997', 1.55, 1, 5, 4.4, NULL)