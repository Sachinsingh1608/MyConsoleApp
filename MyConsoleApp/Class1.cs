using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace MyConsoleApp
{
    public class Employee
    {
        public int emp_Id { get; set; }
        public string first_Name { get; set; }

        public string last_Name { get; set; }
        public DateTime birth_date { get; set; }
        public string gender { get; set; }

        public int age { get; set; }
        public string address { get; set; }

        public float salary { get; set; }
        public int dept_id { get; set; }
        public string Data_file { get; set; }

        public Employee() { }

        public void Add()
        {

        }

        public void List()
        {
            string lsDeptName = "";
            Console.WriteLine($"Id : {emp_Id} ,Name : {first_Name} {last_Name} , DOB : {birth_date} , Salary : {salary}" +
                $"Address : {address} ");
        }
        public void LoadEmp(ref List<Employee> IobjEmpList)
        {
            string data_Loc = "C:\\Employee\\Employee.json";
            string jsonString = File.ReadAllText(data_Loc);
            IobjEmpList = JsonSerializer.Deserialize<List<Employee>>(jsonString);

        }
        public void ReadInput()
        {
            Console.WriteLine("Enter A  First Name");
            this.first_Name = (Console.ReadLine());
            Console.WriteLine("Enter A  Last Name");
            this.last_Name = (Console.ReadLine());
            Console.WriteLine("Enter A  Birth Date");
            this.birth_date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter your  Gender");
            this.gender = Console.ReadLine();
            Console.WriteLine("Enter A Salary");
            this.salary= float.Parse(Console.ReadLine());
            Console.WriteLine("Enter your  Address");
            this.address= Console.ReadLine();
            Console.WriteLine("Enter Dept_id");
            this.dept_id= int.Parse(Console.ReadLine());


        }
        
    }
}