INSERT INTO DataModeling.dbo.Student
( Name, TotalScore )
VALUES
  ('Tom', 90), 
  ('Bob', 95), 
  ('John', 80),
  ('Mary', 91);

  INSERT INTO DataModeling.dbo.Teacher
( Name )
VALUES
  ('Sam'), 
  ('Frodo'), 
  ('Jane'),
  ('June');

    INSERT INTO DataModeling.dbo.Course
( Name, Score )
VALUES
  ('Math', 80), 
  ('Geometry', 70), 
  ('Biology', 60),
  ('History', 90);

    INSERT INTO DataModeling.dbo.Lesson
( Name, Score, CourseId )
VALUES
  ('FirstLesson', 80, 1), 
  ('SecondLesson', 80, 2), 
  ('ThirdLesson', 85, 3),
  ('FourthLesson', 90, 4);

      INSERT INTO DataModeling.dbo.StudentCourse
( CourseId, StudentId )
VALUES
  (1, 1), 
  (1, 2), 
  (2, 1),
  (3, 3);

      INSERT INTO DataModeling.dbo.TeacherCourse
( TeacherId, CourseId )
VALUES
  (1, 1), 
  (2, 2), 
  (3, 3),
  (4, 4);