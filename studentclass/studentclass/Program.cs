

using System;
using System.Collections.Generic;
using System.Linq;
class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public Course(int courseId, string courseName)
    {
        CourseId = courseId;
        CourseName = courseName;
    }
}
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Course Course { get; set; }
    public Student(int id, string name, int age, Course course)
    {
        Id = id;
        Name = name;
        Age = age;
        Course = course;
    }
}
class StudentManager
{
    private List<Student> students = new List<Student>();
    public void AddStudent(Student student)
    {
        students.Add(student);
        Console.WriteLine("Student added successfully.");
    }
    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        Console.WriteLine("\nList of Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course.CourseName}");
        }
    }
    public void UpdateStudent(int id, string newName, int newAge, Course newCourse)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            student.Name = newName;
            student.Age = newAge;
            student.Course = newCourse;
            Console.WriteLine("Student updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
    public void DeleteStudent(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
    public void FindStudentsAboveAge(int age)
    {
        var result = students.Where(s => s.Age > age).ToList();
        if (result.Count == 0)
        {
            Console.WriteLine($"No students found above age {age}.");
            return;
        }

        Console.WriteLine($"\nStudents above age {age}:");
        foreach (var student in result)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course.CourseName}");
        }
    }
    public void FindStudentsInCourse(string courseName)
    {
        var result = students.Where(s => s.Course.CourseName == courseName).ToList();
        if (result.Count == 0)
        {
            Console.WriteLine($"No students found in course {courseName}.");
            return;
        }

        Console.WriteLine($"\nStudents in course {courseName}:");
        foreach (var student in result)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}");
        }
    }
}

class CourseManager
{
    private List<Course> courses = new List<Course>();

    public void AddCourse(Course course)
    {
        courses.Add(course);
        Console.WriteLine("Course added successfully.");
    }

    public void ViewCourses()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("No courses available.");
            return;
        }

        Console.WriteLine("\nList of Courses:");
        foreach (var course in courses)
        {
            Console.WriteLine($"Course ID: {course.CourseId}, Course Name: {course.CourseName}");
        }
    }
}

class Program
{
    static void Main()
    {
        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();

        Course csharpCourse = new Course(101, "C#");
        Course javaCourse = new Course(102, "Java");

        courseManager.AddCourse(csharpCourse);
        courseManager.AddCourse(javaCourse);

        studentManager.AddStudent(new Student(1, "Anwar", 25, csharpCourse));
        studentManager.AddStudent(new Student(2, "Rahul", 22, javaCourse));
        studentManager.AddStudent(new Student(3, "Sara", 26, csharpCourse));

        studentManager.ViewStudents();

        courseManager.ViewCourses();

        studentManager.UpdateStudent(2, "Rahul Kumar", 23, csharpCourse);
        studentManager.ViewStudents();

        studentManager.DeleteStudent(1);
        studentManager.ViewStudents();

        studentManager.FindStudentsAboveAge(23);

        studentManager.FindStudentsInCourse("C#");
    }
}
