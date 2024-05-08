using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    public class Student
    {
        public int mnRollNo;
        public string msName;


        public  Student(int inRollNo,string inName)
        {
            mnRollNo = inRollNo;
            msName = inName;
        }

    }
}
