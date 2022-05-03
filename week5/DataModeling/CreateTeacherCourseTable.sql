CREATE TABLE TeacherCourse(
	TeacherId int FOREIGN KEY REFERENCES Teacher(Id),
	CourseId int FOREIGN KEY REFERENCES Course(Id)
)