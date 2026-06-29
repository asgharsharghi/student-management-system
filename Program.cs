using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Database.InitializeDatabase();
        
        while (true)
        {
            Console.WriteLine("\n=== سیستم مدیریت دانشجویان ===");
            Console.WriteLine("1. ثبت دانشجوی جدید");
            Console.WriteLine("2. مشاهده تمام دانشجویان");
            Console.WriteLine("3. جستجوی دانشجو");
            Console.WriteLine("4. حذف دانشجو");
            Console.WriteLine("5. اضافه کردن درس");
            Console.WriteLine("6. ثبت نمره دانشجو");
            Console.WriteLine("7. خروج");
            Console.Write("انتخاب کنید: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    DisplayAllStudents();
                    break;
                case "3":
                    SearchStudent();
                    break;
                case "4":
                    DeleteStudent();
                    break;
                case "5":
                    AddCourse();
                    break;
                case "6":
                    EnrollStudent();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("انتخاب نامعتبر!");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("نام دانشجو: ");
        string name = Console.ReadLine();
        
        Console.Write("شماره دانشجویی: ");
        string studentId = Console.ReadLine();
        
        Console.Write("رشته تحصیلی: ");
        string major = Console.ReadLine();
        
        var student = new Student { Name = name, StudentId = studentId, Major = major };
        Database.AddStudent(student);
        Console.WriteLine("✓ دانشجو با موفقیت ثبت شد!");
    }

    static void DisplayAllStudents()
    {
        var students = Database.GetAllStudents();
        if (students.Count == 0)
        {
            Console.WriteLine("هیچ دانشجویی ثبت نشده است!");
            return;
        }
        
        Console.WriteLine("\n=== لیست دانشجویان ===");
        foreach (var student in students)
        {
            Console.WriteLine($"نام: {student.Name} | شماره: {student.StudentId} | رشته: {student.Major}");
        }
    }

    static void SearchStudent()
    {
        Console.Write("شماره دانشجویی را وارد کنید: ");
        string studentId = Console.ReadLine();
        
        var student = Database.GetStudent(studentId);
        if (student != null)
        {
            Console.WriteLine($"\nنام: {student.Name}");
            Console.WriteLine($"شماره: {student.StudentId}");
            Console.WriteLine($"رشته: {student.Major}");
        }
        else
        {
            Console.WriteLine("دانشجویی یافت نشد!");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("شماره دانشجویی را وارد کنید: ");
        string studentId = Console.ReadLine();
        
        if (Database.DeleteStudent(studentId))
        {
            Console.WriteLine("✓ دانشجو حذف شد!");
        }
        else
        {
            Console.WriteLine("خطا: دانشجویی یافت نشد!");
        }
    }

    static void AddCourse()
    {
        Console.Write("نام درس: ");
        string courseName = Console.ReadLine();
        
        Console.Write("کد درس: ");
        string courseCode = Console.ReadLine();
        
        Console.Write("اساتید: ");
        string instructor = Console.ReadLine();
        
        var course = new Course { CourseName = courseName, CourseCode = courseCode, Instructor = instructor };
        Database.AddCourse(course);
        Console.WriteLine("✓ درس اضافه شد!");
    }

    static void EnrollStudent()
    {
        Console.Write("شماره دانشجویی: ");
        string studentId = Console.ReadLine();
        
        Console.Write("کد درس: ");
        string courseCode = Console.ReadLine();
        
        Console.Write("نمره: ");
        if (double.TryParse(Console.ReadLine(), out double grade))
        {
            var enrollment = new StudentCourse { StudentId = studentId, CourseCode = courseCode, Grade = grade };
            Database.EnrollStudent(enrollment);
            Console.WriteLine("✓ دانشجو در درس ثبت شد!");
        }
        else
        {
            Console.WriteLine("نمره نامعتبر!");
        }
    }
}