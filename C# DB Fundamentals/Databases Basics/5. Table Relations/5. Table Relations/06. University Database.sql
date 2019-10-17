CREATE DATABASE University

use University

CREATE TABLE Subjects(
SubjectID INT NOT NULL,
SubjectName NVARCHAR(50)

CONSTRAINT PK_Subjects_SubjectID
 PRIMARY KEY (SubjectID))

 CREATE TABLE Majors(
MajorID INT NOT NULL,
[Name] NVARCHAR(50)

CONSTRAINT PK_Majors_MajorID
 PRIMARY KEY (MajorID))

 CREATE TABLE Students(
StudentID INT NOT NULL,
StudentNumber INT,
StudentName NVARCHAR(50),
MajorID INT NOT NULL

CONSTRAINT PK_Students_StudentID
 PRIMARY KEY (StudentID)
 CONSTRAINT FK_Major_Student
 FOREIGN KEY (MajorID)
 REFERENCES Majors(MajorID))

  CREATE TABLE Agenda(
StudentID INT NOT NULL,
SubjectID INT NOT NULL

CONSTRAINT PK_Agenda_StudentID_SubjectID 
 PRIMARY KEY (StudentID, SubjectID)
  CONSTRAINT FK_Agenda_Student
 FOREIGN KEY (StudentID)
 REFERENCES Students(StudentID),
   CONSTRAINT FK_Agenda_Subject
 FOREIGN KEY (SubjectID)
 REFERENCES Subjects(SubjectID))

  CREATE TABLE Payments(
PaymentID INT NOT NULL,
PaymentDate DATE,
PaymentAmount DECIMAL(15,3),
StudentID INT NOT NULL

CONSTRAINT PK_Payments_PaymentID
 PRIMARY KEY (PaymentID)
 CONSTRAINT FK_Student_Payment
 FOREIGN KEY (StudentID)
 REFERENCES Students(StudentID))

