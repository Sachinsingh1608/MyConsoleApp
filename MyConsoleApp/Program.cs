using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace MyConsoleApp
{
    internal class Program
    {
        static void ValidationForFLoat()
        {
            string lsStr ;
            string lsFloat = "";
            int lsDecimalCount = 0;
            int lscheckMinus = 0;
            int lsCheckAlpha = 0;
            Console.WriteLine("Enter a Float Number ");
            lsStr = Console.ReadLine();

            for (int lscount = 0; lscount < lsStr.Length; lscount++)
            {
                if((lscount == 0 || lsStr[lscount] == '-'))
                {
                    lscheckMinus++;
                    lsFloat += lsStr[lscount];

                }
                else if (lsStr[lscount] == '.' )
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
           if(lsDecimalCount == 1 && lsCheckAlpha == 0 && lscheckMinus <= 1)
            {
                Console.WriteLine("Valid Float Number {0}", float.Parse(lsFloat));
            }
            else
            {
                Console.WriteLine("Not a Valid Float Number");
            }

            Console.ReadLine();
        }
        static void ValidationForNumeric()
        {
            string lsStr = "";
            string lsNumeric="";
            int NotNumeric = 0;
            int lscheckMinus = 0;
            int lsDecimalCount = 0;
            Console.WriteLine("Enter a Number");
            lsStr = Console.ReadLine();
            
           
            for (int lscount=0; lscount<lsStr.Length; lscount++)
            {
                if ((lscount == 0 && lsStr[lscount] == '-'))
                {
                    lscheckMinus++;

                    lsNumeric += lsStr[lscount];

                }
                else if (lsStr[lscount] == '.')
                {
                    lsDecimalCount++;
                    lsNumeric += lsStr[lscount];
                }
                else if (lsStr[lscount] >= '0' && lsStr[lscount] <= '9')
                    lsNumeric += lsStr[lscount];
                else
                {
                    NotNumeric = 1;
                    break;
                }
            }
            if(NotNumeric == 0 && (lscheckMinus ==1 || lsDecimalCount==1))
                Console.WriteLine("Valid Number {0}", lsNumeric);
            else
                Console.WriteLine("Not a Valid Number");

            Console.ReadLine();
        }
        static void ReverseStringAndPalindrome()
        {
            string lsStr;
            string lsRevStr = "";
            int CheckPal = 0;
            int EmtVal = 0;
            Console.WriteLine("Enter a String");

            lsStr = Console.ReadLine();

            // Validation
            if (lsStr.Length == 0) {
                Console.WriteLine("Empty String");
                EmtVal = 1;
                    }
            // Reverse String 


            for (int lsCount = lsStr.Length-1; lsCount >= 0; lsCount--)
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
            if(EmtVal == 0)
            Console.WriteLine("Reverse String is :- {0}", lsRevStr);


            if ( CheckPal == 0 && EmtVal == 0)
                Console.WriteLine("Palindrome String ");
            else if(EmtVal == 0)
                Console.WriteLine(" Not  a Palindrome String ");
            Console.ReadLine();
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
                if (lsChar=='a' || lsChar=='e' || lsChar=='i' || lsChar == 'o' || lsChar=='u' ||
                    lsChar == 'A' || lsChar == 'E' || lsChar == 'I' || lsChar == 'O' || lsChar == 'U' )
           
                    lsVowels += (char)lsChar;
                
                else
                
                   lsConsonents += (char)lsChar;
                
            }
            Console.WriteLine("Vowel is :- {0} Consonents is :- {1} ", lsVowels, lsConsonents);
            Console.ReadLine();
        }
      static void SeperateAlphaAndNumber()
        {
            string lsStr ;
            string lsNum = "";
            string lsAlpha = "";
            Console.WriteLine("Enter a String");
            lsStr= Console.ReadLine();
           

            for(int lsCount=0; lsCount < lsStr.Length; lsCount++)
            {
                char lsChar = lsStr[lsCount];
                if(((lsChar >='a' && lsChar<='z') || (lsChar >='A' && lsChar <= 'Z')))
                {
                    lsAlpha += (char)lsChar;
                }
                else if(lsChar >='0' && lsChar <='9')
                {
                    lsNum += (char)lsChar;
                }
            }
            Console.WriteLine("Alpha is :- {0} Nuumeric is :- {1} And AlphaNumeric is :- {2}",lsAlpha, lsNum,lsAlpha+lsNum);
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
            for (int lscount = 0; lscount<lsval.Length; lscount++)
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
              for(int lnCount=0; lnCount < lsval.Length; lnCount++)
            {
                
                if (lsval[lnCount] >= 'a' && lsval[lnCount] <= 'z')
                {
                    
                    resStr += (char)(lsval[lnCount] -32);
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
            if(lnA > lnB)
            {
                Console.WriteLine(" A is Greater  Number");
               
            }
            else if(lnA < lnB)
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
            
            Console.WriteLine("total of A and B = c is " +lnC.ToString());
            Console.ReadLine();
        }
        static public void AddTwoNumber_1()
        {
            int lnA, lnB, lnC;
            string lsValue1;
            Console.WriteLine("Enter A first Number");
            lsValue1=Console.ReadLine();
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

        static void Main(string[] args)
        {
            int lsRightEx = 0;
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
                Console.WriteLine("8. SeperateVowelAndConso");
                Console.WriteLine("9. ReverseStringAndPalindrome ");
                Console.WriteLine("10. ValidationForNumeric ");
                Console.WriteLine("     For Exit Press 0");

                lsExNum = Console.ReadLine();


                if (lsExNum.Length == 0) {
                    Console.WriteLine("Empty");
                    continue;
                        }
                lsNum = int.Parse(lsExNum);


                switch (lsNum)
                {
                    case 0:
                        lsRightEx = 2;
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
                        lsRightEx = 1;
                        break;

                }
                if (lsRightEx == 1)
                {
                    Console.WriteLine("Enter Exercise Number From 1 to 10");
                    Console.ReadLine();

                }

              
                Console.Clear();
             
            } while (lsRightEx!=2);
         





            
        }
    }
}
