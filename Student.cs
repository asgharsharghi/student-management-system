using System;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string StudentId { get; set; }
    public string Major { get; set; }
    public DateTime EnrollmentDate { get; set; } = DateTime.Now;
}