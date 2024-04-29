using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Principal;


namespace MyConsoleApp
{
    public class Animal
    {
        private float _height;
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }
        private float _Weight;

        public float Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        private int _Color;
        private bool _Veg;
        public bool Veg
        {
            get { return _Veg; }
            set { _Veg = value; }
        }
        public virtual void AnimalSound()
        {
            Console.WriteLine("The Animal Makes A Sound");
        }
    }

    internal class Program
    {
       
        
        public static decimal RootFind(int num)
        {
           
            decimal lnans = -1;
            for(decimal lnct = 0m ; lnct <=num; lnct+=0.01m)
            {
                if(lnct * lnct <= num )
                {
                    lnans = lnct;
                }
            }
         
            return (lnans*100)/100.00m;
        }
       
        public static void RemoveStudentDetail(string[] IobjStudentName, string[] IobjStudentAddress,
       double[] IobjStudentMarks, int[] IobjStudentRoll, ref int lnNumberOfStd)
        {
            Console.WriteLine("Enter A Roll Number");
            int InRollNum = int.Parse(Console.ReadLine());
            int inFoundIndex = -1;
            for (int lncnt = 0; lncnt < lnNumberOfStd - 1; lncnt++)
            {
                if (IobjStudentRoll[lncnt] == InRollNum)
                {
                    inFoundIndex = lncnt;
                    break;
                }
            }
            if (inFoundIndex == -1)
            {
                Console.WriteLine("Wrong Roll Number");
            }
            else
            {
                Console.WriteLine("Current RollNo :- {0} Name :- {1} Address :- {2} Marks:-{3}", IobjStudentRoll[inFoundIndex
                    ], IobjStudentName[inFoundIndex], IobjStudentAddress[inFoundIndex], IobjStudentMarks[inFoundIndex]);



                IobjStudentName[inFoundIndex] = "" ;



                IobjStudentRoll[inFoundIndex] = 0;
          
             
                
                    IobjStudentAddress[inFoundIndex] = "";


                IobjStudentMarks[inFoundIndex] = 0;
               
                Console.WriteLine("Record Deleted");
                Console.Write("Current RollNo :- {0} Name :- {1} Address :- {2} Marks:-{3}", IobjStudentRoll[inFoundIndex
                    ], IobjStudentName[inFoundIndex], IobjStudentAddress[inFoundIndex], IobjStudentMarks[inFoundIndex]);
            }
            lnNumberOfStd--;
        }
        public static void ChangeStudentDetail(string[] IobjStudentName, string[] IobjStudentAddress,
            double[] IobjStudentMarks, int[] IobjStudentRoll, ref int lnNumberOfStd)
        {
            Console.WriteLine("Enter A Roll Number");
            int InRollNum = int.Parse(Console.ReadLine());
            int inFoundIndex = -1;
            for (int lncnt = 0; lncnt < IobjStudentRoll.Length; lncnt++)
            {
                if (IobjStudentRoll[lncnt] == InRollNum)
                {
                    inFoundIndex = lncnt;
                    break;
                }
            }
            if(inFoundIndex == -1)
            {
                Console.WriteLine("Wrong Roll Number");
            }
            else
            {
                Console.WriteLine("Current RollNo :- {0} Name :- {1} Address :- {2} Marks:-{3}", IobjStudentRoll[inFoundIndex
                    ], IobjStudentName[inFoundIndex], IobjStudentAddress[inFoundIndex], IobjStudentMarks[inFoundIndex]);


                Console.WriteLine("Enter A New Name if Not Just Press Enter");
                string lsName = Console.ReadLine();
                if (lsName.Length>0)
                {
                    IobjStudentName[inFoundIndex] = lsName;
                }
                Console.WriteLine("Enter A New Roll if Not Just Press Enter");
                string lnRoll = Console.ReadLine();
                if (lnRoll.Length > 0)
                {
                    IobjStudentRoll[inFoundIndex] = int.Parse(lnRoll);
                }
                Console.WriteLine("Enter A New Address if Not Just Press Enter");
                string lsAddress = Console.ReadLine();
                if (lsAddress.Length > 0)
                {
                    IobjStudentAddress[inFoundIndex] = lsAddress;
                }
                Console.WriteLine("Enter A New Marks if Not Just Press Enter");
                string lnMarks = Console.ReadLine();
                if (lnMarks.Length > 0)
                {
                    IobjStudentMarks[inFoundIndex] = double.Parse(lnMarks);
                }
                Console.WriteLine("Record Changed");
                Console.Write("Current RollNo :- {0} Name :- {1} Address :- {2} Marks:-{3}", IobjStudentRoll[inFoundIndex
                    ], IobjStudentName[inFoundIndex], IobjStudentAddress[inFoundIndex], IobjStudentMarks[inFoundIndex]);
            }
        }
        public static void AddStudentDetails(string[] IobjStudentName, string[] IobjStudentAddress, 
            double[] IobjStudentMarks, int[] IobjStudentRoll, ref int lnNumberOfStd)
        {
            int lnRoll = lnNumberOfStd;
          
                    Console.Write("Enter a RollNum of Student:- ");
                    IobjStudentRoll[lnRoll - 1] = int.Parse(Console.ReadLine());

                    Console.Write("Enter a Name Student:- ");
                    IobjStudentName[lnRoll - 1] = Console.ReadLine();
                    Console.Write("Enter a Address of  Student:- ");
                    IobjStudentAddress[lnRoll - 1] = Console.ReadLine();
                    Console.Write("Enter a Marks of  Student:- ");
                    IobjStudentMarks[lnRoll - 1] = double.Parse(Console.ReadLine());

                    Console.WriteLine("Student Records Saved");
                    Console.WriteLine("Roll Number -> {0}  Name -> {1} Address-> {2} Marks -> {3} ",
                           IobjStudentRoll[lnRoll - 1], IobjStudentName[lnRoll - 1],
                           IobjStudentAddress[lnRoll - 1], IobjStudentMarks[lnRoll - 1]);


                
            lnNumberOfStd++;

        }
        public static void ReadToFile(string[] studentNames, string[] studentAddresses,
        double[] studentMarks, int[] studentRolls, ref int numberOfStudents)
        {
     
            using (FileStream fs = new FileStream("C:\\Users\\singh\\Desktop\\napasoft Assignment\\Student1Detail.dat",
                FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    string studentData = reader.ReadString(); 
                    string[] studentFields = studentData.Split('|'); 

                 
                        int roll = int.Parse(studentFields[0]);
                        string name = studentFields[1];
                        string address = studentFields[2];
                        double marks = double.Parse(studentFields[3]);

                     

                        studentRolls[numberOfStudents] = roll;
                        studentNames[numberOfStudents] = name;
                        studentAddresses[numberOfStudents] = address;
                        studentMarks[numberOfStudents] = marks;
                        Console.WriteLine("Roll Number -> {0}   Name -> {1}   Address -> {2}   Marks -> {3} ",
                   studentRolls[numberOfStudents], studentNames[numberOfStudents], studentAddresses[numberOfStudents],
                   studentMarks[numberOfStudents]);
                        numberOfStudents++;
                        
                    
                }
            }

          
            Console.ReadLine();
        }

        public static void SaveToFile(string[] studentNames, string[] studentAddresses,
            double[] studentMarks, int[] studentRolls, ref int numberOfStudents)
        {
            using (FileStream fs = new FileStream("C:\\Users\\singh\\Desktop\\napasoft Assignment\\Student1Detail.dat",
                FileMode.Append, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                for (int i = 0; i < numberOfStudents - 1; i++)
                {

                    writer.Write(studentRolls[i]);
                    writer.Write(studentNames[i]);
                    writer.Write(studentAddresses[i]);
                    writer.Write(studentMarks[i]);
                }
            }
        }
        public static void ReadBinaryFile()
        {
            using (FileStream fs = new FileStream("C:\\Users\\singh\\Desktop\\napasoft Assignment\\Student1Detail.dat",
            FileMode.Append, FileAccess.Write))
            using (BinaryReader IObjReader = new BinaryReader(File.Open("C:\\Users\\singh\\Desktop\\napasoft Assignment\\TestBinary.dat", FileMode.Open)))
            {
                Console.WriteLine("Double Value:" + IObjReader.ReadDouble());
                Console.WriteLine("String Value:" + IObjReader.ReadString());
                Console.WriteLine("Boolean Value:" + IObjReader.ReadBoolean());
            }
        }
  
        public static void ReadBinaryFileFloat1To10()
        {
            using (FileStream fs = new FileStream("C:\\Users\\singh\\Desktop\\napasoft Assignment\\" +
                "1.0To10.0.dat",
        FileMode.Open, FileAccess.Read))
            using (BinaryReader IObjReader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    decimal lnNum = IObjReader.ReadDecimal();
                    Console.WriteLine($"{lnNum}");
                }

            }
        }
        public static void WriteBinaryFileFloat1To10()
        {
            using (BinaryWriter IObjBW = new BinaryWriter(File.Open("C:\\Users\\singh\\Desktop\\napasoft Assignment\\" +
                "1.0To10.0.dat", FileMode.Create)))
            {
                for (decimal lncnt = 1.0m; lncnt <= 10.0m; lncnt++)
                {
                    IObjBW.Write(lncnt);
                }
            }
        }
        public static void ReadBinaryFileOneToTen()
        {
            using (FileStream fs = new FileStream("C:\\Users\\singh\\Desktop\\napasoft Assignment\\" +
                "Onetoten.dat",
        FileMode.Open, FileAccess.Read))
            using (BinaryReader IObjReader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    string lsNum = IObjReader.ReadString();
                    Console.WriteLine($"{lsNum}");
                }

            }
        }
        public static void WriteBinaryFileOneToTen()
        {
            using (BinaryWriter IObjBW = new BinaryWriter(File.Open("C:\\Users\\singh\\Desktop\\napasoft Assignment\\" +
                "Onetoten.dat", FileMode.Create)))
            {
                
                IObjBW.Write("one");
                IObjBW.Write("two");
                IObjBW.Write("three");
                IObjBW.Write("four");
                IObjBW.Write("five");
                IObjBW.Write("six");
                IObjBW.Write("seven");
                IObjBW.Write("eight");
                IObjBW.Write("nine");
                IObjBW.Write("ten");
      


            }
        }
        public static void ReadBinaryFile1To10()
        {
            using (FileStream fs = new FileStream("C:\\Users\\singh\\Desktop\\napasoft Assignment\\" +
                "1To10.dat",
        FileMode.Open, FileAccess.Read))
            using (BinaryReader IObjReader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    int lnNum = IObjReader.ReadInt32();
                    Console.WriteLine($"{lnNum}");
                }

            }
        }
        public static void WriteBinaryFile1To10()
        {
            using (BinaryWriter IObjBW = new BinaryWriter(File.Open("C:\\Users\\singh\\Desktop\\napasoft Assignment\\" +
                "1To10.dat", 
                FileMode.Create)))
            {
                for(int lncnt =1; lncnt <=10;lncnt++)
                {
                    IObjBW.Write(lncnt);
                }
            }
        }
        public static void WriteBinaryFile()
        {
            using (BinaryWriter IObjBW = new BinaryWriter(File.Open("C:\\Users\\singh\\Desktop\\napasoft Assignment\\" +
                "TestBinary.dat", FileMode.Create)))
            {
                IObjBW.Write(12.5);
                IObjBW.Write("this is string data");
                IObjBW.Write(true);
            }
        }
        public static void StudentReacordeSystem()
        {
            const int MAX_STUDENT = 50;
            string[] IobjStudentName = new string[MAX_STUDENT];
            string[] IobjStudentAddress = new string[MAX_STUDENT];
            double[] IobjStudentMarks = new double[MAX_STUDENT];
            int[] IobjStudentRoll = new int[MAX_STUDENT];
            
            int lnNumberOfStd = 1;
           
            bool CheckModification = false;
            while(!CheckModification)
            {
              
                Console.WriteLine("Add Student Details Name Press 1");
                Console.WriteLine("Change Student Details Name Press 2");
                Console.WriteLine("Remove Student Details Name Press 3");
                Console.WriteLine("Save  Student Details Name Press 4");
                Console.WriteLine("Read  Student Details Name Press 5");
                Console.WriteLine("For Exit Press 0");
                string lsModification = Console.ReadLine();
          
                switch(lsModification)
                {
                    case "0":
                        CheckModification= true; 
                        break;
                    case "1":
                        AddStudentDetails(IobjStudentName, IobjStudentAddress, IobjStudentMarks, 
                            IobjStudentRoll,ref lnNumberOfStd);
                        break;
                    case "2":
                        ChangeStudentDetail(IobjStudentName, IobjStudentAddress, IobjStudentMarks,
                            IobjStudentRoll, ref lnNumberOfStd);
                        break;
                    case "3":
                        RemoveStudentDetail(IobjStudentName, IobjStudentAddress, IobjStudentMarks,
                           IobjStudentRoll, ref lnNumberOfStd);
                        break;
                    case "4":
                        SaveToFile(IobjStudentName, IobjStudentAddress, IobjStudentMarks,
                           IobjStudentRoll, ref lnNumberOfStd);
                        break;
                    case "5":
                        ReadToFile(IobjStudentName, IobjStudentAddress, IobjStudentMarks,
                           IobjStudentRoll, ref lnNumberOfStd);
                        break;




                }
             

            }
            
        }
        public static bool CheckDuplicate(string[] InCountryName, string instr)
        {
            for (int lncnt = 0; lncnt < InCountryName.Length; lncnt++)
            {
                if (InCountryName[lncnt] == instr)
                    return true;
            }
            return false;
        }
        public static bool ValidateCountryName(string inStr)
        {
            string lslowecase = inStr.ToLower();
            string[] CountryName = { "china", "bhutan", "nepal", "pakistan", "bangladesh", "myanmar" };
            for (int lncnt = 0; lncnt < CountryName.Length; lncnt++)
            {
                if (lslowecase == CountryName[lncnt])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CountryNameFull(string[] InCountryName)
        {
            foreach (string name in InCountryName)
            {
                if (string.IsNullOrEmpty(name))
                {
                    return false;
                }
            }
            return true;
        }

        public static void RandomCountryName()
        {
            string[] CountryName = new string[6];
            Random Index = new Random(0);
            int lnCountryCounter = 1;
            while (!CountryNameFull(CountryName))
            {

                int IndexValue = Index.Next(0, 6);

                if (string.IsNullOrEmpty(CountryName[IndexValue]))
                {

                    Console.Write("Enter India Neighbouring Country " + lnCountryCounter+" :-");
                    string lsCountryName = Console.ReadLine();
                    if (!ValidateCountryName(lsCountryName) && !CheckDuplicate(CountryName, lsCountryName))
                    {
                        CountryName[IndexValue] = lsCountryName;
                        lnCountryCounter++;
                    }
                    else if (ValidateCountryName(lsCountryName) == true)
                    {
                        Console.WriteLine(lsCountryName + " Wrong country Name");
                        continue;
                    }
                    else if (CheckDuplicate(CountryName, lsCountryName) == true)
                    {
                        Console.WriteLine(lsCountryName + " Country Name is already Present");
                        continue;

                    }


                }
            }

            Console.Clear();
            bool gameSrt = true;
            while (gameSrt)
            {

                Console.WriteLine("Game Started");

                string lsCountryName = "";
                bool lsValidCountryName = false;
                bool lsValidIndex = false;
                int index = -1;
                while (!lsValidCountryName)
                {
                    Console.WriteLine("Enter A Country Name");
                    lsCountryName = Console.ReadLine();
                    if (!ValidateCountryName(lsCountryName))
                    {
                        lsValidCountryName = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid Country Name");
                    }

                }
       
                while (!lsValidIndex)
                {
                    Console.WriteLine("Enter A Index Value Of Country");
                    index = int.Parse(Console.ReadLine());
                    if (index >= 0 && index < CountryName.Length)
                    {
                        lsValidIndex = true;
                    }
                    else
                    {
                        Console.WriteLine("Position Should be Between 0-5");
                    }
                }


                if (CountryName[index] == lsCountryName)
                {
                    Console.WriteLine("YOU WIN");
                }
                else
                {
                    Console.WriteLine("YOU LOSE");
                }
                Console.WriteLine("Press 1 for Play");
                Console.WriteLine("Press 0 for Exit");
                int InA = int.Parse(Console.ReadLine());
                if (InA == 0)
                    gameSrt = false;

            }

        }
    

        public static void Array2()
        {
            string[] lsStr = new string[6];
            for(int i = 0; i<6; i++)
            {
                Console.WriteLine();
            }
            
        }
        public static void SumofThreeAndFive(int inNum,ref double SumofThree,ref double SumofFive)
        {
            for(int lnCount=1; lnCount<=inNum; lnCount++)
            {
                if(lnCount % 3 == 0)
                {
                    SumofThree += lnCount;
                }
                if(lnCount % 5 == 0)
                {
                    SumofFive += lnCount;
                }
            }
        }
       public static string  SimpleAndCompoundInterest(double InAmount,double InInterest,int InYear)
        {
            double lnCompoundInterest = InAmount * Math.Pow((1 + InInterest / 100), InYear);
            double lnSimpleinterest = (InAmount * InInterest * InYear) / 100;
            Console.WriteLine("Simple Interest is :- {0} and Compound Interest is :-{1}", lnSimpleinterest+InAmount, lnCompoundInterest);  
            string OutAns = lnCompoundInterest.ToString()+" "+lnCompoundInterest.ToString();
            return OutAns;
            
        }
        public static bool CheckPrime(int Innum)
        {
            int counter = 0;
            for(int lncount = 1; lncount <= Innum; lncount++)
            {
                if(Innum % lncount == 0)
                {
                    counter++;
                }
            }
            if(counter == 2)
                return true;
            return false;
        }
        public static void ArrayPractice()
        {
            int[] lnnums = new int[100];
            int lnTotalSum = 0;
            for(int lncount = 0; lncount<100; lncount++)
            {
                lnnums[lncount] = lncount+1;
            }
            // Reverse Order
            Console.WriteLine("Reverse Order");
            for(int lncount = lnnums.Length-1;lncount>=0; lncount--)
            {
                Console.Write(lnnums[lncount]+" ");
               lnTotalSum += lnnums[lncount];
            }
            Console.WriteLine();
            Console.WriteLine("Prime Number");

            for(int lncount=0; lncount<lnnums.Length; lncount++)
            {
                if (CheckPrime(lnnums[lncount]))
                {
                    Console.WriteLine(lnnums[lncount]+" "+"Index position is "+lncount);
                }
            }
            Console.WriteLine();
            Console.WriteLine(" Total Sum is {0} ",lnTotalSum);

        }
        public static void SnakeLadder()
        {
            Console.WriteLine("*GAME STARTS*");
            Console.WriteLine("Press 1 for play");
            Console.WriteLine("Press 0 for exit");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                Console.WriteLine("Exiting the game.");
                return;
            }

            Random dice = new Random();
            int[] playerPositions = new int[2]; // Store positions for two players
            int[] diceCounts = new int[2]; // Store dice counts for two players
            bool gameEnd = false;
            int currentPlayer = 0; // Player 1 starts first

            Console.WriteLine("WELCOME TO SNAKE & LADDER GAME");

            while (!gameEnd)
            {
                Console.WriteLine($"Player {currentPlayer + 1}'s turn. Press any key to roll the dice.");
                Console.ReadKey();

                int diceValue = dice.Next(1, 7); // Dice rolls between 1 and 6
                diceCounts[currentPlayer]++; // Increment dice count for the current player
                Console.WriteLine($"Dice Value is {diceValue}");

                playerPositions[currentPlayer] += diceValue; // Move player

                // Check for ladder or snake
                switch (playerPositions[currentPlayer])
                {
                    // LADDER
                    case 4:
                        playerPositions[currentPlayer] = 14;
                        break;
                    case 21:
                        playerPositions[currentPlayer] = 76;
                        break;
                    case 31:
                        playerPositions[currentPlayer] = 42;
                        break;
                    case 71:
                        playerPositions[currentPlayer] = 92;
                        break;
                    // SNAKE
                    case 36:
                        playerPositions[currentPlayer] = 6;
                        break;
                    case 62:
                        playerPositions[currentPlayer] = 18;
                        break;
                    case 88:
                        playerPositions[currentPlayer] = 24;
                        break;
                    case 99:
                        playerPositions[currentPlayer] = 35;
                        break;
                }

                Console.WriteLine($"Player {currentPlayer + 1} is at position {playerPositions[currentPlayer]}");

                // Check for winning condition
                if (playerPositions[currentPlayer] >= 100)
                {
                    Console.WriteLine($"Congratulations! Player {currentPlayer + 1} wins! They took {diceCounts[currentPlayer]} attempts to win.");
                    gameEnd = true;
                }
                else
                {
                    currentPlayer = (currentPlayer + 1) % 2; // Switch to the other player
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }







        public static void Recursion(int num)
        {
            if (num > 100)
                return;
            else
            {
                Console.WriteLine(num);
                Recursion(num + 1);
               
            }
        }
        public static int FindOccuerenceOfChar(string InStr, char InChar)
        {
            int lnCount = 0;
            for(int lnCnt=0; lnCnt<InStr.Length; lnCnt++)
            {
                if (InStr[lnCnt] == InChar)
                    lnCount++;
            }
            return lnCount;
        }
       /* public static double CalculateCompoundInterest(double principal, double interestRate, int years)
        {


            //double amount = principal;
            // for (int i = 0; i < years; i++)
            // {
            //      amount += amount * interestRate;
            //  }

            // double compoundInterest = amount - principal;
         
            return amount;

        }*/
        public static void SumOfOddEven(int InNum)
        {
            int lnEvenSum = 0;
            int lnOddSum = 0;
            for (int lnCnt = 0; lnCnt <= InNum; lnCnt++)
            {
                if ((lnCnt & 1) == 0)
                    lnEvenSum += lnCnt;

                else
                {
                    lnOddSum += lnCnt;
                }
            }
            Console.WriteLine("Even Sum is {0} and Odd sum is {1} ",lnEvenSum, lnOddSum);
            Console.ReadLine();
        }
        public static string ConvertLowercase(string str)
        {
            string lsStr = "";
            for(int i=0; i<str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    lsStr += (char)(str[i] + 32);
                else
                    lsStr += str[i];
            }

            return lsStr;
        }
        public static void TitleSentence()
        {
            Console.WriteLine("Enter A string");
            string lsLowerCase  = ConvertLowercase(Console.ReadLine());
           //'0   Console.WriteLine(lsLowerCase);
            string lsStr = LRTrim(lsLowerCase);
           
            string lsAnsStr = "";
            string lsAnsStr2 = "";

            string lstemp1 = "";

            for (int lnCnt  = 0; lnCnt < lsStr.Length; lnCnt++)
            {
                
                if (lsStr[lnCnt] == ' ')
                {
                    string lstemp2 = "";
                   
                    for(int lnCnt2 = 0;lnCnt2 < lstemp1.Length;lnCnt2++)
                    {
                        if(lnCnt2 == 0)
                        {
                            lstemp2 += (char)(lstemp1[lnCnt2] - 32);
                        }
                        else
                        {
                            lstemp2 += lstemp1[lnCnt2];
                        }
                    }
                    lsAnsStr += lstemp2 + ' ';
                    lstemp1 = "";
                }
                else if (lsStr[lnCnt] == '.')
                {
                    string lstemp2 = "";
                    for (int lnCnt2 = 0; lnCnt2 < lstemp1.Length; lnCnt2++)
                    {
                        if (lnCnt2 == 0)
                        {
                            lstemp2 += (char)(lstemp1[lnCnt2] - 32);
                        }
                        else
                        {
                            lstemp2 += lstemp1[lnCnt2];
                        }
                    }
                    lsAnsStr += lstemp2 + ' ';
                    lstemp1 = "";
                }
                else if (lnCnt == lsStr.Length-1)
                {
                    string lstemp2 = "";
                    for (int lnCnt2 = 0; lnCnt2 < lstemp1.Length; lnCnt2++)
                    {
                        if (lnCnt2 == 0)
                        {
                            lstemp2 += (char)(lstemp1[lnCnt2] - 32);
                        }
                        else
                        {
                            lstemp2 += lstemp1[lnCnt2];
                        }
                    }
                    lsAnsStr += lstemp2 + '.';
                    lstemp1 = "";
                }
                else
                {
                    lstemp1 += (lsStr[lnCnt]);
                }
            }
            lsAnsStr2 = LRTrim(lsAnsStr);
            lsAnsStr2 +=  '.';



            Console.WriteLine("Title Sentence of {0} is :- {1} ",lsStr,lsAnsStr2);
            Console.ReadLine();
        }
        public static void FindSubString()
        {
            Console.WriteLine("Enter A string ");
            string lsStr = Console.ReadLine();
            Console.WriteLine("Enter index of String");
            int lsIdx = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter length of String");
            int lsLen = int.Parse(Console.ReadLine());
            bool lsValidIdx = false;
            string lsAnsStr = "";

            if (lsIdx < 0 || lsIdx > lsStr.Length || lsLen>lsStr.Length)
            {
                Console.WriteLine("Enter valid index");
                lsValidIdx = true;
            }


            if (lsLen > lsStr.Length)
            {
                Console.WriteLine("Enter valid Length");
                lsValidIdx = true;
            }


            if (lsValidIdx == false)
            {
                for (int lncnt = lsIdx; lncnt < lsLen; lncnt++)
                {
                    lsAnsStr += lsStr[lncnt];
                }
            }
            if (lsValidIdx == false)
                Console.WriteLine("Substring of {0} is this {1}", lsStr, lsAnsStr);
            Console.ReadLine();
        }
        public static bool ValidationForHexa(string hexa)
        {
            for(int i = 0; i < hexa.Length; i++)
            {
                if ((hexa[i] >= '0' && hexa[i] <= '9') || (hexa[i] >= 'a' && hexa[i] <= 'f') ||
                    (hexa[i] >= 'A' && hexa[i] <= 'F'))
                    continue;
                else
                    return false;
            }
            return true;
        }
        public static void HexaToDecimal()
        {
            int lsDeci=0;
            int power = 1; int num=0;
            Console.WriteLine("Enter a Number");
            string lsval = Console.ReadLine();
            if (ValidationForHexa(lsval))
            {

                for (int lncnt = lsval.Length - 1; lncnt >= 0; lncnt--)
                {
                    char rem = lsval[lncnt];

                    if (rem == 'A' || rem == 'a')
                        num = 10;
                    else if (rem == 'B' || rem == 'b') num = 11;
                    else if (rem == 'C' || rem == 'c') num = 12;
                    else if (rem == 'D' || rem == 'd') num = 13;
                    else if (rem == 'E' || rem == 'e') num = 14;
                    else if (rem == 'F' || rem == 'f') num = 15;

                    if (rem >= '0' && rem <= '9')
                    {
                        int number = rem - '0';
                        lsDeci = lsDeci + (power * number);
                    }
                    else
                        lsDeci = lsDeci + (power * num);
                    power *= 16;

                }
                Console.WriteLine("Decimal value of {0} is this {1}",lsval,lsDeci);
            }
            else
            {
                Console.WriteLine("Not A valid HexaNumber");
            }
            Console.ReadLine();
        }
        public static void DecimalToHex()
        {
            string lsHex = "";
            Console.WriteLine("Enter a Number");
            string lsval=Console.ReadLine();
            if(ValidationForNumeric(lsval) == true)
            {
                int lsNum = int.Parse(lsval);
                 while(lsNum !=0)
                {
                    int rem = lsNum % 16;
                    if (rem == 10)
                        lsHex += 'A';
                    else if(rem == 11) lsHex += 'B';
                   else if (rem == 12) lsHex += 'C';
                    else if (rem == 13) lsHex += 'D';
                   else if (rem == 14) lsHex += 'E';
                   else if (rem == 15) lsHex += 'F';
                    else lsHex += rem;
                    lsNum/= 16;
                }
                Console.WriteLine("HexaDecimal is this  {0} of a Number {1}", ReverseString(lsHex), lsval);
            }

            else
            {
                Console.WriteLine("Not A Valid Number");
            }
            Console.ReadLine();
        }
        public static string ReverseString(string inStr)
        {
            string lsStr = "";
            for(int lncnt=inStr.Length-1; lncnt>=0; lncnt--)
            {
                lsStr += inStr[lncnt];
            }
            return lsStr;
        }
        public static void DecimalToBinary()
        {
            Console.WriteLine("Enter A Decimal Number ");
            string lsStr = Console.ReadLine();
        
            string lsBinaryString = "";
           

            if (ValidationForNumeric(lsStr) == true)
            {
                int lsNum = int.Parse(lsStr);
                while(lsNum != 0)
                {
                    int lsRem = lsNum % 2;
                    lsBinaryString += lsRem;
                    lsNum /= 2;
                }
               Console.WriteLine("The Binar String is {0}",ReverseString(lsBinaryString));
            }
            else
            {
                Console.WriteLine("Not a valid Decimal Number");
            }

            Console.ReadLine();
        }
        public static bool IsBinary(string isstr)
        {
            for(int lncnt =0; lncnt < isstr.Length; lncnt++)
            {
                if (isstr[lncnt] == '1' || isstr[lncnt] == '0')
                {
                    continue;
                }
                else
                    return false;
            }
            return true;
        }
        public  static void BinaryToDecimal()
        {
            Console.WriteLine("Enter A  Binary Number ");
            string lsStr = Console.ReadLine();
            int lsDeci = 0;
         
            int power = 1;

            if (IsBinary(lsStr) == true)
            {
                for (int lncnt = lsStr.Length - 1; lncnt >=0; lncnt--)
                {
                    if (lsStr[lncnt] == '1')
                    {
                        lsDeci += power; 
                    }
                    power *= 2;
                }
                Console.WriteLine("Decimal Value is {0}", lsDeci);
            }
            else
            {
                Console.WriteLine("Not a valid Binary");
            }
          
            Console.ReadLine();
        }
        public static void CheckPalindromeOrNot()
        {
            Console.WriteLine("Enter A Number ");
            string lsStr = Console.ReadLine();
            
          
            if(ValidationForNumeric(lsStr) == false)
            {
                Console.WriteLine("Not A valid Number");
                
            }
            else
            {
                
               /* int lstempNum = lsNum;
                while (lstempNum != 0)
                {
                    int lsRem = lstempNum % 10;
                    lsRevNum = lsRevNum * 10 + lsRem;
                    lstempNum /= 10;
                }
                if (lsRevNum == lsNum)
                    Console.WriteLine("{0} is a Palidrome Number ", lsNum);
                else
                    Console.WriteLine("{0} is Not a Palidrome Number ", lsNum);
               */
               if(ReverseStringAndPalindrome(lsStr) == true)
                    Console.WriteLine("{0} is a Palidrome Number ", lsStr);
               else
                    Console.WriteLine("{0} is Not a Palidrome Number ", lsStr);

            }
            Console.ReadLine();
        }
        public static void MaxAndMinOccurence(string instr)
        {
            int lsmax = 0;
            int lsMaxCh = -1;
            int lsmin = 100000;
            int lsMinCh = -1;

            int[] CountALpha = new int[26];
            int spaceCount = 0;



            for (int lnCnt = 0; lnCnt < instr.Length; lnCnt++)
            {
                char lschar = instr[lnCnt];
               
                if (lschar == ' ')
                {
                    spaceCount++;
                }
                else
                {

                    CountALpha[(int)(lschar) - 97]++;

                }
            }
            for (int lnCnt = 0; lnCnt < CountALpha.Length; lnCnt++)
            {

                if (CountALpha[lnCnt] == 0)
                    continue;
                Console.WriteLine("{0} freq is :- {1}", (char)(lnCnt + 'a'), CountALpha[lnCnt]);
            }
         
            Console.WriteLine("__________________________________________");


          // maximum find

            for (int lnCnt = 0; lnCnt < CountALpha.Length; lnCnt++)
            {
                if (CountALpha[lnCnt] > lsmax)
                {
                    lsmax = CountALpha[lnCnt];
                    lsMaxCh = lnCnt;
                }
            }
            // minimum find

            for (int lnCnt = 0; lnCnt < CountALpha.Length; lnCnt++)
            {
                if (CountALpha[lnCnt] != 0 && CountALpha[lnCnt] < lsmin)
                {
                    lsmin = CountALpha[lnCnt];
                    lsMinCh = lnCnt;
                }
            }

            Console.WriteLine("Max Occurence is {0} of {1}", (char)(lsMaxCh + 'a'), lsmax);
            Console.WriteLine("Max Occurence is {0} of {1}", (char)(lsMinCh + 'a'), lsmin);

            Console.ReadLine();


        }
        public static void CountAlphaNumericAndSpace(string instr)
        {

            string lsAlpha = "";
            string lsNumb = "";
            for(int lscnt=0; lscnt < instr.Length; lscnt++)
            {
                if ((instr[lscnt] >='a' && instr[lscnt] <='z') || (instr[lscnt] >= 'A' && instr[lscnt] <= 'Z'))
                    lsAlpha += instr[lscnt];
                if (instr[lscnt] >= '0' && instr[lscnt] <= '9')
                    lsNumb += instr[lscnt]; 
            }
            Console.WriteLine("{0} string length {1}", lsAlpha, lsAlpha.Length);
            Console.WriteLine("{0} string length {1}", lsNumb, lsNumb.Length);
            Console.ReadLine();


        }

        public static void CountAlphaAndSpace(string instr)
        {
           
            int[] CountALpha = new int[26];
            int spaceCount = 0;
            for(int lnCnt = 0; lnCnt < instr.Length; lnCnt++)
            {
                char lschar = instr[lnCnt];
               // Console.WriteLine((int)lschar);
                if (lschar == ' ')
                {
                    spaceCount++;
                }
                else
                {
   
                    CountALpha[(int)(lschar)-97]++;
     
                }
            }
            for(int lnCnt = 0;lnCnt < CountALpha.Length; lnCnt++)
            {

                if (CountALpha[lnCnt] == 0)
                    continue;
                Console.WriteLine("{0} freq is :- {1}", (char)(lnCnt + 'a'), CountALpha[lnCnt]);
            }
            Console.WriteLine("Space freq is :- {0}",spaceCount);
            Console.ReadLine();
           
        }
        public static int SearchWord(string isSentence, string inWord)
        {
            string lsWord ;
            for(int lnCnt=0; lnCnt< isSentence.Length;lnCnt++)
            {
                int lnStartSearchPos = lnCnt;
                bool lbFound = true;
                if ((lnStartSearchPos == 0) && (isSentence[0] != ' '))
                    lsWord = inWord+" ";
                else if (lnStartSearchPos == (isSentence.Length - inWord.Length - 1))
                    lsWord = " " + inWord;
                else
                    lsWord = " " + inWord + " ";
                for(int lncnt1=0;  lncnt1<lsWord.Length; lncnt1++)
                {
                    if (isSentence[lnStartSearchPos+lncnt1] != lsWord[lncnt1])
                    {
                        lbFound = false;
                        break;
                    }
                }
                if(lbFound)
                {
                    if (lsWord[0] == ' ')
                        return (lnStartSearchPos + 2);
                    else
                        return (lnStartSearchPos + 1);
                }
            }
            return -1;
        }
        public static string LRTrim(string inStr)
        {
           string leftTrim = LTrim(inStr);
            string rightTrim = RTrim(leftTrim);
            return rightTrim;
        }

        static double Sum(double inNum)
        {
            if(inNum <= 0) return 0;
            return (inNum + Sum(inNum - 1));
        }
        public static int FindWord(string inStr , string inWord)
        {
         
            string lsFinalTrim = LRTrim(inStr);
            string lsWordTrim = LRTrim(inWord);
            
            for(int lscountI=0;  lscountI<lsFinalTrim.Length; lscountI++)
            {
                int lscount = 0;
                int firstIndex = lscountI;
                for (int lsCountJ = 0; lsCountJ < lsWordTrim.Length; lsCountJ++)
                {
                    if ( firstIndex < lsFinalTrim.Length && inStr[firstIndex] == lsWordTrim[lsCountJ])
                    {
                        lscount++;
                        firstIndex++;
                    }
                    else
                        break;


                }
                if (lscount == inWord.Length && inStr[firstIndex] == ' ' && inStr[lscountI-1] == ' ')
                    return lscount+1;
            }
            return -1;
        }
  

 
        public static string RTrim(string inStr)
        {
            string str = "";
            int lsAlphaIndex = inStr.Length - 1;
            while (lsAlphaIndex >= 0) {
                if (inStr[lsAlphaIndex] == ' ')
                    lsAlphaIndex--;
                else
                    break;
           }
            for(int lscount=0; lscount<=lsAlphaIndex; lscount++)
            {
                str += inStr[lscount];
            }
            return str;
        }
        public static string LTrim(string inStr)
        {
            string str = "";
            int lsAlphaIndex = 0;
            while (lsAlphaIndex < inStr.Length)
            {
                if (inStr[lsAlphaIndex] == ' ')
                    lsAlphaIndex++;
                else
                    break;
            }
            for (int lscount = lsAlphaIndex; lscount < inStr.Length; lscount++)
            {
                str += inStr[lscount];
            }
            return str;
        }
        public static double Factorial_Recursion(double inNumber)
        {
            if(inNumber < 1) {
                return -1;

            }
            else if(inNumber == 1) {
                return 1;

            }
            else
            {
                return (inNumber * Factorial_Recursion(inNumber - 1));
            }
        }

        static void ExampleForJumpBreak2()
        {
            for(int lnj  = 0; lnj < 5 ; lnj++)
            {
                for(int lni = 1; lni <=100 ; lni++)
                {
                    if (lni == 5)
                        break;
                    Console.Write($"{lni} ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void ExampleForJumpBreak1()
        {
            int[] number = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            char[] character = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'i', 'j' };
            
           for(int i = 0; i < number.Length; i++)
            {
                Console.WriteLine($"num = {number[i]}");
                for(int j=0;j<character.Length; j++)
                {
                    if (j == i)
                        break;
                    Console.Write($"{character[j]}");
                }

                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void ExampleForJumpGoto3()
        {
            int lnX = 200;
            int lnY = 4;
            int lnCounter = 0;
            int[,] IobjArray = new int[lnX, lnY];


            for(int lnI = 0; lnI < lnX; lnI++)
                for(int lnJ=0; lnJ < lnY;lnJ++)
                    IobjArray[lnI, lnJ] = ++lnCounter;
         
            Console.WriteLine("Enter the Number to search for ");
            string ls = Console.ReadLine();


            int lnMynumber=int.Parse(ls);

            for (int lnI = 0; lnI < lnX; lnI++)
                for (int lnJ = 0; lnJ < lnY; lnJ++)
                    if (IobjArray[lnI, lnJ] == lnMynumber)
                        goto Found;
               
      
            Console.WriteLine("The Number {0} is Not Found", lnMynumber);
            goto Finish;


          Found:
            Console.WriteLine("The Number {0} is Not Found", lnMynumber);


            Finish:
          Console.WriteLine("End Of Search ");
        }
        static void ExampleForJumpGoto2()
        {
            Console.WriteLine("Coffee Size:1=Small 2=Medium 3=Large");
            Console.Write("Please Enter your Selection");
            string s= Console.ReadLine();
            int n=int.Parse(s);
            int cost = 0;
            switch(n)
            {
                case 1:
                    cost += 25;
                    break;
                case 2:
                    cost += 25;
                    goto case 1;
                case 3:
                    cost += 50;
                    goto case 1;
                default:
                    Console.WriteLine("Invalid Selection");
                    break;

            }
            if (cost != 0)
                Console.WriteLine($"Please insert {cost} cents");
            Console.WriteLine("Thank you for Your Business");
            Console.ReadLine();
        }
        static void ExampleForJumpGoto1()
        {
            int lsX = 0;
        loop:
            lsX++;
            if(lsX < 100)
            {
                Console.WriteLine("Value of lnX {0}", lsX);
                goto loop;
            }
            Console.ReadLine();
        }
        static void ValidationForFLoat()
        {
            string lsStr;
            string lsFloat = "";
            int lsDecimalCount = 0;
            int lscheckMinus = 0;
            int lsCheckAlpha = 0;
            Console.WriteLine("Enter a Float Number ");
            lsStr = Console.ReadLine();

            for (int lscount = 0; lscount < lsStr.Length; lscount++)
            {
                if ((lscount == 0 || lsStr[lscount] == '-'))
                {
                    lscheckMinus++;
                    lsFloat += lsStr[lscount];

                }
                else if (lsStr[lscount] == '.')
                {
                    lsFloat += lsStr[lscount];
                    lsDecimalCount++;
                }
                else if ((lsStr[lscount] >= 'a' && lsStr[lscount] <= 'z') && (lsStr[lscount] >= 'A' && lsStr[lscount] <= 'z'))
                {
                    lsCheckAlpha = 1;
                    break;
                }
                else if ((lsStr[lscount]) >= '0' && lsStr[lscount] <= '9')
                {
                    lsFloat += lsStr[lscount];
                }

            }
            if (lsDecimalCount == 1 && lsCheckAlpha == 0 && lscheckMinus <= 1)
            {
                Console.WriteLine("Valid Float Number {0}", float.Parse(lsFloat));
            }
            else
            {
                Console.WriteLine("Not a Valid Float Number");
            }

            Console.ReadLine();
        }
        static bool ValidationForNumeric(string lsStr)
        {
           
            




            for (int lscount = 0; lscount < lsStr.Length; lscount++)
            {
                if ((lsStr[lscount] >= 'a' && lsStr[lscount] <= 'z') || (lsStr[lscount] >= 'A' && lsStr[lscount] <= 'Z'))
                    return false;
             
                  
            }
            return true;

         
        }
        static bool ReverseStringAndPalindrome(string lsStr)
        {
          
            string lsRevStr = "";
            int CheckPal = 0;
           
         

     

            // Validation
         
            // Reverse String 


            for (int lsCount = lsStr.Length - 1; lsCount >= 0; lsCount--)
            {
                lsRevStr += lsStr[lsCount];

            }
            // Palindrome Check

            for (int lsCount = 0; lsCount < lsStr.Length; lsCount++)
            {
                if (lsRevStr[lsCount] != lsStr[lsCount])
                {
                    CheckPal = 1;
                    break;
                }

            }
            if (CheckPal == 0)
                return true;
            else return false;
            
  
        }
        static void SeperateVowelAndConso()
        {
            string lsStr;
            string lsVowels = "";
            string lsConsonents = "";
            Console.WriteLine("Enter a String");
            lsStr = Console.ReadLine();

            for (int lsCount = 0; lsCount < lsStr.Length; lsCount++)
            {
                char lsChar = lsStr[lsCount];
                if (lsChar == 'a' || lsChar == 'e' || lsChar == 'i' || lsChar == 'o' || lsChar == 'u' ||
                    lsChar == 'A' || lsChar == 'E' || lsChar == 'I' || lsChar == 'O' || lsChar == 'U')

                    lsVowels += (char)lsChar;

                else

                    lsConsonents += (char)lsChar;

            }
            Console.WriteLine("Vowel is :- {0} Consonents is :- {1} ", lsVowels, lsConsonents);
            Console.ReadLine();
        }
        static void SeperateAlphaAndNumber()
        {
            string lsStr;
            string lsNum = "";
            string lsAlpha = "";
            Console.WriteLine("Enter a String");
            lsStr = Console.ReadLine();


            for (int lsCount = 0; lsCount < lsStr.Length; lsCount++)
            {
                char lsChar = lsStr[lsCount];
                if (((lsChar >= 'a' && lsChar <= 'z') || (lsChar >= 'A' && lsChar <= 'Z')))
                {
                    lsAlpha += (char)lsChar;
                }
                else if (lsChar >= '0' && lsChar <= '9')
                {
                    lsNum += (char)lsChar;
                }
            }
            Console.WriteLine("Alpha is :- {0} Nuumeric is :- {1} And AlphaNumeric is :- {2}", lsAlpha, lsNum, lsAlpha + lsNum);
            Console.ReadLine();
        }
        static void PrintZeroToNine()
        {
            string lsval = "";
            Console.WriteLine("Enter A Number 0 To 9");
            lsval = Console.ReadLine();
            int lsNum = int.Parse(lsval);
            switch (lsNum)
            {
                case 0:
                    Console.WriteLine("Zero");
                    break;
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                case 4:
                    Console.WriteLine("Four");
                    break;
                case 5:
                    Console.WriteLine("Five");
                    break;
                case 6:
                    Console.WriteLine("Six");
                    break;
                case 7:
                    Console.WriteLine("Seven");
                    break;
                case 8:
                    Console.WriteLine("Eight");
                    break;
                case 9:
                    Console.WriteLine("Nine");
                    break;
                default:
                    Console.WriteLine("Not Valid number");
                    break;

            }
            Console.ReadLine();
        }
        static void IterationString()
        {
            string lsval = "";
            Console.WriteLine("Enter A String");
            lsval = Console.ReadLine();
            for (int lscount = 0; lscount < lsval.Length; lscount++)
            {
                Console.WriteLine("index of :- '{0}' is :- {1} and ASCII Value is :- {2}", lsval[lscount], lscount, (int)(lsval[lscount]));
            }
            Console.ReadLine();
        }
        static void UpperCase()
        {
            string lsval;
            Console.WriteLine("Enter a String");
            lsval = Console.ReadLine();
            string resStr = "";
            for (int lnCount = 0; lnCount < lsval.Length; lnCount++)
            {

                if (lsval[lnCount] >= 'a' && lsval[lnCount] <= 'z')
                {

                    resStr += (char)(lsval[lnCount] - 32);
                }
                else
                {

                    resStr += lsval[lnCount];

                }
            }
            Console.WriteLine(resStr);
            Console.ReadLine();
        }

        static public void CheckNumberGreater()
        {
            int lnA, lnB;
            string lsValue1;
            Console.WriteLine("Enter A first Number");
            lsValue1 = Console.ReadLine();
            lnA = int.Parse(lsValue1);
            Console.WriteLine("Enter A Second Number");
            lsValue1 = Console.ReadLine();

            lnB = int.Parse(lsValue1);
            if (lnA > lnB)
            {
                Console.WriteLine(" A is Greater  Number");

            }
            else if (lnA < lnB)
            {
                Console.WriteLine(" B is Greater  Number");

            }
            else
            {
                Console.WriteLine(" A and B are Equal  Number");

            }
            Console.ReadLine();
        }
        static public void AddTwoNumber()
        {
            int lnA, lnB, lnC;
            lnA = 10;
            lnB = 20;
            lnC = lnA + lnB;

            Console.WriteLine("total of A and B = c is " + lnC.ToString());
            Console.ReadLine();
        }
        static public void AddTwoNumber_1()
        {
            int lnA, lnB, lnC;
            string lsValue1;
            Console.WriteLine("Enter A first Number");
            lsValue1 = Console.ReadLine();
            lnA = int.Parse(lsValue1);
            Console.WriteLine("Enter A Second Number");
            lsValue1 = Console.ReadLine();

            lnB = int.Parse(lsValue1);
            lnC = lnA + lnB;

            Console.WriteLine("total of A and B = c is " + lnC.ToString());
            Console.ReadLine();
        }
        public void L2_EX2(string isValue)
        {
            char lcChar;
            Console.WriteLine("Output Without using $");
            Console.WriteLine("\"{0}\".Length= '{1}'", isValue, isValue.Length);
            Console.WriteLine("OutPut Using $");
            Console.WriteLine($"\"{isValue}\".Length = {isValue.Length}");
            for (int lnCnt = 0; lnCnt < isValue.Length; lnCnt++)
            {
                lcChar = isValue[lnCnt];
                Console.WriteLine("lcChar in normal Char = '{0}',in hexaDecimal = {1:x4},in Int {2:d2}", lcChar, (int)lcChar, (int)lcChar);
                Console.WriteLine($"is[{lnCnt}] = '{isValue[lnCnt]}' ('\\u{(int)isValue[lnCnt]:d4}')\n");
            }
            Console.ReadLine();
        }
        public static void ReadData()
        {
            FileStream IobjFS = new FileStream("C:\\Users\\singh\\Desktop\\napasoft Assignment\\test.txt",
                FileMode.Open, FileAccess.Read);
            StreamReader IobjSR = new StreamReader(IobjFS);
            Console.WriteLine("Program To Show Content Of Test File");
            while(!IobjSR.EndOfStream)
            {
                Console.WriteLine(IobjSR.ReadLine());
            }
            Console.ReadLine() ;
            IobjSR.Close();
            IobjSR.Close();
            

        }
        public static void  WriteData()
        {
            FileStream IobjFS = new FileStream("C:\\Users\\singh\\Desktop\\napasoft Assignment\\test.txt",
                FileMode.Append,FileAccess.Write); 
            StreamWriter IobjSW = new StreamWriter(IobjFS);
            Console.WriteLine("Enter The Text Which You Want to Write To The File");
            string lsStr  = Console.ReadLine();
            IobjSW.WriteLine(lsStr);
            IobjSW.Flush();
            IobjSW.Close();
            IobjFS.Close();
            
        }
        public static void SeperateCombinedNumbers()
        {
            Console.WriteLine("Enter a String");
            string lsStr = Console.ReadLine();
            string lsTempStr = "";
            for(int lncnt=0; lncnt<lsStr.Length; lncnt++)
            {
               char lcChar = lsStr[lncnt];
                if(lcChar >= '0' && lcChar <= '9')
                {
                    lsTempStr += lcChar;
                }
                else
                {
                    if(lsTempStr.Length > 1) {
                        Console.WriteLine("Numbers Are :- "+lsTempStr);
                        lsTempStr = "";
                    }
                    else
                    {
                        lsTempStr = "";
                    }
                }
            }
            if(lsTempStr.Length > 1) {
                Console.WriteLine("Numbers Are :- " + lsTempStr); 
            }
        }
        static void Main(string[] args)
        {
            // WriteBinaryFile();
            // ReadBinaryFile();
            // WriteBinaryFile1To10();
            //ReadBinaryFile1To10();
            // WriteBinaryFileOneToTen();
            //  ReadBinaryFileOneToTen();
            //WriteBinaryFileFloat1To10();
            // ReadBinaryFileFloat1To10() ;
            //Console.ReadLine ();
            // StudentReacordeSystem();
            //WriteData();

            // ReadData();



           // SeperateCombinedNumbers();






            /*  bool lsRightEx = false;
              do
              {
                  Console.Clear();
                  string lsExNum;
                  int lsNum;

                  Console.WriteLine("Enter a Exericse Number:-");
                  Console.WriteLine("1. Add Two Number ");
                  Console.WriteLine("2. CheckNumberGreater");
                  Console.WriteLine("3. UpperCase ");
                  Console.WriteLine("4. AddTwoNumber_1");
                  Console.WriteLine("5. IterationString ");
                  Console.WriteLine("6. PrintZeroToNine");
                  Console.WriteLine("7. SeperateAlphaAndNumber");
                  Console.WriteLine("8. SeperateVowelAndConso");0
                  Console.WriteLine("9. ReverseStringAndPalindrome ");
                  Console.WriteLine("10. ValidationForNumeric ");
                  Console.WriteLine("     For Exit Press 0");

                  lsExNum = Console.ReadLine();


                  if (lsExNum.Length == 0)
                  {
                      Console.WriteLine("Empty");
                      continue;
                  }
                  lsNum = int.Parse(lsExNum);


                  switch (lsNum)
                  {
                      case 0:
                          lsRightEx = true;
                          break;

                      case 1:
                          Console.Clear();
                          Console.WriteLine("Add Two Number ");
                          AddTwoNumber();
                          break;


                      case 2:
                          Console.Clear();
                          Console.WriteLine("CheckNumberGreater");
                          CheckNumberGreater();
                          break;


                      case 3:
                          Console.Clear();
                          Console.WriteLine("UpperCase ");
                          UpperCase();
                          break;


                      case 4:
                          Console.Clear();
                          Console.WriteLine(" AddTwoNumber_1");
                          AddTwoNumber_1();
                          break;


                      case 5:
                          Console.Clear();
                          Console.WriteLine("IterationString ");
                          IterationString();
                          break;


                      case 6:
                          Console.Clear();
                          Console.WriteLine("PrintZeroToNine");
                          PrintZeroToNine();
                          break;


                      case 7:
                          Console.Clear();
                          Console.WriteLine("SeperateAlphaAndNumber");
                          SeperateAlphaAndNumber();
                          break;


                      case 8:
                          Console.Clear();
                          Console.WriteLine("SeperateVowelAndConso ");
                          SeperateVowelAndConso();
                          break;


                      case 9:
                          Console.Clear();
                          Console.WriteLine("ReverseStringAndPalindrome ");
                          ReverseStringAndPalindrome();
                          break;


                      case 10:
                          Console.Clear();
                          Console.WriteLine("ValidationForNumeric ");
                          ValidationForNumeric();
                          break;


                      default:
                          Console.WriteLine("Enter Exercise Number From 1 to 10");
                          Console.ReadLine();
                          break;

                  }


                  Console.Clear();

              } while (lsRightEx != true);*/

            // ExampleForJumpGoto1();
            // ExampleForJumpGoto2();
            //ExampleForJumpGoto3();
            //ExampleForJumpBreak1();
            //ExampleForJumpBreak2();

            // Factorial 
            /*  Console.WriteLine("Enter a Number ");
              string lsStr = Console.ReadLine();
              double lsNum = double.Parse(lsStr);
             double lsFact= Factorial_Recursion(lsNum);
              Console.WriteLine("Factorial of {0} is {1}",lsNum,lsFact);
             Console.ReadLine();*/


            // Ltrim


            /*Console.WriteLine("Enter A string ");
            string lsStr = Console.ReadLine();
            string lsResStr = LTrim(lsStr);
            Console.WriteLine("Trim String is :-{0}", lsResStr);
            Console.ReadLine();*/


            // RTrim

            /* Console.WriteLine("Enter A string ");
             string lsStr = Console.ReadLine();
             string lsResStr = RTrim(lsStr);
             Console.WriteLine("Trim String is :-{0}", lsResStr);
             Console.ReadLine();*/

            // LRTrim
            /*  Console.WriteLine("Enter A string ");
             string lsStr = Console.ReadLine();
             string lsResStr = LRTrim(lsStr);
             Console.WriteLine("Trim String is :-{0}", lsResStr);
             Console.ReadLine();*/


            /* Console.WriteLine("Enter A String");
             string lsStr = Console.ReadLine();
              Console.WriteLine("Enter A Word");
              string lsWord = Console.ReadLine();
              int  lsFind = SearchWord(lsStr, lsWord);
              if (lsFind != -1)
              {
                  Console.WriteLine("Found at {0}",lsFind);
              }
              else
                  Console.WriteLine(" Not Found");

              Console.ReadLine();*/

            /* Console.WriteLine("Enter A Number");
             double lsNum = double.Parse(Console.ReadLine());
             double FinalSum = Sum(lsNum);
             Console.WriteLine("The Sum is {0}", FinalSum);
             Console.ReadLine();*/
            //Console.WriteLine("Enter A String");
            // string lsStr = Console.ReadLine();

            // CountAlphaAndSpace(lsStr);
            // CountAlphaNumeric(lsStr);
            // MaxAndMinOccurence(lsStr);
            //CheckPalindromeOrNot();

            //BinaryToDecimal();
            //DecimalToBinary();
            //DecimalToHex();
            // HexaToDecimal();
            // FindSubString();
            // TitleSentence();

            /*   Console.WriteLine("Enter A Number");
               int lnNum = int.Parse((Console.ReadLine()));
               SumOfOddEven(lnNum);*/
            //CalculateCompoundInterest();
            /*  Console.WriteLine("Enter A String");
              string lsStr  = Console.ReadLine();
              Console.WriteLine("Enter a character");
              char lcChar  =char.Parse(Console.ReadLine());
              int lnFrequency = FindOccuerenceOfChar(lsStr, lcChar);

              Console.WriteLine("Frequency of {0} is :- {1}",lcChar, lnFrequency);
              Console.ReadLine();*/
            // Recursion(1);
            //SnakeLadder();

            // ArrayPractice();
            /*  Console.WriteLine("Enter a Amount");
              double lnAmount = double.Parse(Console.ReadLine());
              Console.WriteLine("Enter a Interset");
              double lnInterest = double.Parse(Console.ReadLine());
              Console.WriteLine("Enter a Year");
              int lnYear = int.Parse(Console.ReadLine());
              string lnAns = SimpleAndCompoundInterest(lnAmount, lnInterest,lnYear);
              string simpleIn = "";
              string CompoundIn = "";
              int flag = 0;
              for(int lncount =0; lncount < lnAns.Length; lncount++)
              {
                  if(flag == 0)
                  {
                      simpleIn += lnAns[lncount];
                  }
                  if (lnAns[lncount]==' ')
                  {
                      flag = 1;
                  }
                  if(flag == 1)
                  {
                      CompoundIn+= lnAns[lncount];
                  }
              }
              // Console.WriteLine(simpleIn + " " + CompoundIn);
            */
            /* double SumOfThree = 0;
             double SumOfFive = 0;
             Console.WriteLine("Enter A Number ");
             int lnNum = int.Parse(Console.ReadLine());
             SumofThreeAndFive(lnNum, ref SumOfThree, ref SumOfFive);
             Console.WriteLine("Sum of Divisble By three is :- "+SumOfThree + " " + "Sum of Divisble By Five is:- "+ SumOfFive);
             Console.ReadLine();*/
            // RandomCountryName();
            // StudentReacordeSystem();
            /* Console.WriteLine("Enter A Number ");
             int num = int.Parse(Console.ReadLine());




             decimal sqRoot1 = RootFind(num);
             if (sqRoot1 != -1)
             {
                 Console.WriteLine(sqRoot1);
             }
             else
             {
                 Console.WriteLine("Not Found");
             }
            */
           Animal lobjMyanimal = new Animal();
            lobjMyanimal.Height = 100.5f;
            lobjMyanimal.Weight = 24.4f;
          
            lobjMyanimal.AnimalSound();


            Console.ReadLine();
        }
    }
}
