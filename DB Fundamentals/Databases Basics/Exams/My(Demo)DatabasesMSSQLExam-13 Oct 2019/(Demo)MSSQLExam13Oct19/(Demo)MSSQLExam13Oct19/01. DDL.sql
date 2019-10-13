CREATE DATABASE Bitbucket
GO

USE Bitbucket
GO

CREATE TABLE Users(
	Id INT UNIQUE IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
	
	CONSTRAINT PK_Users_Id
	PRIMARY KEY (Id))
GO

CREATE TABLE Repositories(
	Id INT UNIQUE IDENTITY,
	[Name] VARCHAR(50) NOT NULL
	
	CONSTRAINT PK_Repositories_Id
	PRIMARY KEY (Id))
GO

CREATE TABLE RepositoriesContributors(
	RepositoryId INT NOT NULL,
	ContributorId INT NOT NULL
	
	CONSTRAINT PK_RepositoriesContributors_RepositoryId_ContributorId
	PRIMARY KEY (RepositoryId ,ContributorId)
	CONSTRAINT FK_RepositoriesContributors_RepositoryId
	FOREIGN KEY (RepositoryId)
	REFERENCES Repositories(Id),
	CONSTRAINT FK_RepositoriesContributors_ContributorId
	FOREIGN KEY (ContributorId)
	REFERENCES Users(Id))
GO

CREATE TABLE Issues(
	Id INT UNIQUE IDENTITY,
	Title VARCHAR(225) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT NOT NULL,
	AssigneeId INT NOT NULL,
	
	CONSTRAINT PK_Issues_Id
	PRIMARY KEY (Id),
	CONSTRAINT FK_Issues_RepositoryId
	FOREIGN KEY (RepositoryId)
	REFERENCES Repositories(Id),
	CONSTRAINT FK_Issues_AssigneeId
	FOREIGN KEY (AssigneeId)
	REFERENCES Users(Id))
GO


CREATE TABLE Commits(
	Id INT UNIQUE IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT,
	RepositoryId INT NOT NULL,
	ContributorId INT NOT NULL
	
	CONSTRAINT PK_Commits_Id
	PRIMARY KEY (Id)
	CONSTRAINT FK_Commits_IssueId
	FOREIGN KEY (IssueId)
	REFERENCES Issues(Id),
	CONSTRAINT FK_Commits_RepositoryId
	FOREIGN KEY (RepositoryId)
	REFERENCES Repositories(Id),
	CONSTRAINT FK_Commits_ContributorId
	FOREIGN KEY (ContributorId)
	REFERENCES Users(Id))
GO

CREATE TABLE Files(
	Id INT UNIQUE IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(15,2) NOT NULL,
	ParentId INT,
	CommitId INT NOT NULL,
	
	CONSTRAINT PK_Files_Id
	PRIMARY KEY (Id),
	CONSTRAINT FK_Files_ParentId
	FOREIGN KEY (ParentId)
	REFERENCES Files(Id),
	CONSTRAINT FK_Files_CommitId
	FOREIGN KEY (CommitId)
	REFERENCES Commits(Id),)
GO