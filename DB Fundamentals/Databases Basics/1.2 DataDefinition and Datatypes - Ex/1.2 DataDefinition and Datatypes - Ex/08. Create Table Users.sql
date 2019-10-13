CREATE TABLE Users
(	Id BIGINT  IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password]  VARCHAR(26) NOT NULL,
	ProfilePicture  VARBINARY(MAX),
	CHECK(DATALENGTH(ProfilePicture) <= 921600),
	LastLoginTime DATETIME2,
	IsDeleted BIT NOT NULL,

	CONSTRAINT  pk_Users_Id  PRIMARY KEY(Id)
)

INSERT INTO Users 
VALUES
('Pesho1', '123', NULL,NULL,0),
('Gosho', '123', NULL,NULL,0),
('Ivan', '123', NULL,NULL,0),
('Test', '123', NULL,NULL,0),
('Test2', '123', NULL,NULL,0)

select * from Users