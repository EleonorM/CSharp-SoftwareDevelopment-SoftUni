CREATE TABLE Planets(
	Id INT UNIQUE IDENTITY,
	[Name] VARCHAR(30) NOT NULL
	
	CONSTRAINT PK_Planets_Id
	PRIMARY KEY (Id))

CREATE TABLE Spaceports(
	Id INT UNIQUE IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT NOT NULL
	
	CONSTRAINT PK_Spaceports_Id
	PRIMARY KEY (Id)
	CONSTRAINT FK_Spaceports_PlanetId
	FOREIGN KEY (PlanetId)
	REFERENCES Planets(Id))

CREATE TABLE Spaceships(
	Id INT UNIQUE IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
	
	CONSTRAINT PK_Spaceships_Id
	PRIMARY KEY (Id))

CREATE TABLE Colonists(
	Id INT UNIQUE IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL UNIQUE,
	BirthDate DATE NOT NULL,
	
	CONSTRAINT PK_Colonists_Id
	PRIMARY KEY (Id))

CREATE TABLE Journeys(
	Id INT UNIQUE IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11),
	DestinationSpaceportId INT NOT NULL,
	SpaceshipId INT NOT NULL
	
	CONSTRAINT PK_Journeys_Id
	PRIMARY KEY (Id),
	CONSTRAINT FK_Journeys_DestinationSpaceportId
	FOREIGN KEY (DestinationSpaceportId)
	REFERENCES Spaceports(Id),
	CONSTRAINT FK_Journeys_SpaceshipId
	FOREIGN KEY (SpaceshipId)
	REFERENCES Spaceships(Id),
	
	CONSTRAINT check_Journeys_Purpose
    CHECK (Purpose IN('Medical', 'Technical', 'Educational', 'Military')))

CREATE TABLE TravelCards(
	Id INT UNIQUE IDENTITY,
	CardNumber CHAR(10) NOT NULL,
	JobDuringJourney VARCHAR(8) NOT NULL,
	ColonistId INT NOT NULL,
	JourneyId INT NOT NULL,
	
	CONSTRAINT PK_TravelCards_Id
	PRIMARY KEY (Id),
	CONSTRAINT FK_TravelCards_ColonistId
	FOREIGN KEY (ColonistId)
	REFERENCES Colonists(Id),
	CONSTRAINT FK_TravelCards_JourneyId
	FOREIGN KEY (JourneyId)
	REFERENCES Journeys(Id),
	
	CONSTRAINT check_TravelCards_JobDuringJourney
    CHECK (JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')))