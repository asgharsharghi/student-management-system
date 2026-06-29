using System;
using System.Collections.Generic;
using System.Linq;

static class Database
{
    private static List<Student> students = new List<Student>();
    private static List<Course> courses = new List<Course>();
    private static List<StudentCourse> enrollments = new List<StudentCourse>();

    public static void InitializeDatabase()
    {
        // داده های نمونه
        students.Add(new Student { Id = 1, Name = "علی محمدی", StudentId = "99001", Major = "کامپیوتر" });
        students.Add(new Student { Id = 2, Name = "فاطمه احمدی", StudentId = "99002", Major = "الکترونیک" });
        
        courses.Add(new Course { Id = 1, CourseName = "برنامه نویسی سی شارپ", CourseCode = "CS101", Instructor = "دکتر کاظمی" });
        courses.Add(new Course { Id = 2, CourseName = "پایگاه داده", CourseCode = "CS102", Instructor = "دکتر احمدی" });
    }

    public static void AddStudent(Student student)
    {
        student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
        students.Add(student);
    }

    public static List<Student> GetAllStudents() => students;

    public static Student GetStudent(string studentId)
    {
        return students.FirstOrDefault(s => s.StudentId == studentId);
    }

    public static bool DeleteStudent(string studentId)
    {
        var student = GetStudent(studentId);
        if (student != null)
        {
            students.Remove(student);
            return true;
        }
        return false;
    }

    public static void AddCourse(Course course)
    {
        course.Id = courses.Count > 0 ? courses.Max(c => c.Id) + 1 : 1;
        courses.Add(course);
    }

    public static List<Course> GetAllCourses() => courses;

    public static void EnrollStudent(StudentCourse enrollment)
    {
        enrollment.Id = enrollments.Count > 0 ? enrollments.Max(e => e.Id) + 1 : 1;
        enrollments.Add(enrollment);
    }

    public static List<StudentCourse> GetEnrollments() => enrollments;
}