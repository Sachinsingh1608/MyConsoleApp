using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    public  class SchoolSystem
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Affiliation { get; set; }
        public decimal TotalMonthlyFees { get; set; }
        public int NumberOfGrades { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>(); 
        public int NumberOfStudents { get; set; }
        public int NumberOfTeachers { get; set; }
        public decimal TotalSalaryPaid { get; set; }
    }
    public class Students 
    {
        public int rollNumber { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public string GuardianName { get; set; }
        public int Std { get; set; }
        public List<string> Subjects { get; set; } =new List<string>();
        public int fees { get; set; }
        public string caste { get; set; }
        public void AddSubject()
        {
            bool addSub = true;
            while (addSub)
            {
                Console.WriteLine("Enter subject Name ");
                string inSubject = Console.ReadLine();
                Subjects.Add(inSubject);
                Console.WriteLine("For Exit 0");
                int x = int.Parse(Console.ReadLine());
                if(x==0)
                    addSub = false;

            }
        }
        public void RemoveSubject(string inSubject)
        {
            Subjects.Remove(inSubject);
        }
        public void AddStudent()
        {
            Console.WriteLine("Enter Student Name");
            StudentName = Console.ReadLine();
            Console.WriteLine("Enter Student Address");
            StudentAddress = Console.ReadLine();
            Console.WriteLine("Enter Student Guardian Name");
            GuardianName = Console.ReadLine();
            Console.WriteLine("Enter Student Class");
            Std = int.Parse(Console.ReadLine());
        
            AddSubject();
           
            Console.WriteLine("Type Student Caste \n 1:General \n2:OBC \n3:SC/ST");
            string tempCaste = (Console.ReadLine());
            if (tempCaste.ToUpper() == "GENERAL")
            {
                caste = "GENERAL";
                fees = 10000;
            }
            else if(tempCaste.ToUpper() == "OBC")
            {
                caste = "OBC";
                fees = 8000;
            }
            else if (tempCaste.ToUpper() == "SC")
            {
                caste = "SC";
                fees = 5000;
            }

        }
        public void List()
        {
            string lsDeptName = "";
            Console.WriteLine($"Roll No : {rollNumber} | Name : {StudentName}  | Address : {StudentAddress}  | GuardianName :{GuardianName}  | " +
                $"   fees:{fees} | caste : {caste}");
            SubjectList();
        }
        public void SubjectList()
        {
            foreach(string subject in Subjects)
            {
                Console.Write($"{subject } |  ");
            }
        }





    }

    // Grade class
    public class Grade
    {
        public string ClassName { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }
   
        public List<Students> lobjStudents { get; set; }= new List<Students>();
        public Teacher ClassTeacher { get; set; }
        public decimal MonthlyFees { get; set; }
       
    }

    // Student class
 

    // Teacher class
    public class Teacher
    {
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public decimal Salary { get; set; }
        public List<string> SubjectsTeach { get; set; } = new List<string>();
        public void AddSubject(string inSubject)
        {
            SubjectsTeach.Add(inSubject);
        }
        public void RemoveSubject(string inSubject)
        {
            SubjectsTeach.Remove(inSubject);
        }
    }
}
