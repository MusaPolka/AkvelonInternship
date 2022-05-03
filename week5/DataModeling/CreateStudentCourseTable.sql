CREATE TABLE StudentCourse(
	StudentId int FOREIGN KEY REFERENCES Student(Id),
	CourseId int FOREIGN KEY REFERENCES Course(Id),
)