CREATE TABLE Lesson(
	Id int NOT NULL PRIMARY KEY,
	Name nvarchar(50) NOT NULL,
	Score int,
	CourseId int FOREIGN KEY REFERENCES Course(Id),
)