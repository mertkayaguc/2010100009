using System;
using System.Collections.Generic;

public class Student
{
    public static float MiniumumGPA { get; set; }
    public string StudentNo { get; set; }
    public string FullName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string StudentId { get; set; }
    public string Email { get; set; }

    public List<StudentCourse> Courses { get; set; }

    public Student()
    {
        Courses = new List<StudentCourse>();
    }

    public Student(string studentNo, string fullName, string name, string surname, string studentId, string email)
    {
        this.StudentNo = studentNo;
        this.FullName = fullName;
        this.Name = name;
        this.Surname = surname;
        this.StudentId = studentId;
        this.Email = email;
    }

    public Student Edit(string studentNo, string fullName, string name, string surname, string studentId, string email)
    {
        return new Student()
        {
            StudentNo = studentNo,
            FullName = fullName,
            Name = name,
            Surname = surname,
            StudentId = studentId,
            Email = email
        };
    }

    public float CalculateGPA()
    {


        float totalCredit = 0;
        float totalCreditGrade = 0;
        foreach (var course in Courses)
        {
            totalCredit += course.TakenCourse.Credit;
            totalCreditGrade += (course.TakenCourse.Credit * course.GradeValue);
        }
        return totalCreditGrade / totalCredit;
    }

    public virtual bool CanGradute()
    {
        if (CalculateGPA() >= MiniumumGPA && HasNoFailedCourse())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool HasNoFailedCourse()
    {
        foreach (var course in Courses)
        {
            if (course.StudentGrade == Grade.F)
            {
                return false;
            }
        }
        return true;
    }
}