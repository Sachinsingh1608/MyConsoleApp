using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    public abstract class BankAccount
    {
        const int MAX_CUST_NAME_LEN = 10;
        public string BankName;
        public abstract string AccountType {  get; }
        public string BankBranch;
        public abstract int CustomerID { get; set; }
        private string _CustomerName;
        public DateTime CustomerDOB;
       

       
        public abstract float Interest();

        public string CustomerName
        {
            get { return _CustomerName; }
            set
            {
                 if(value.Length >  MAX_CUST_NAME_LEN)
                {
                    throw new Exception("Customer Name Can Not Be More Than " + MAX_CUST_NAME_LEN.ToString()); 
                }
                else
                {
                    _CustomerName = value;
                }
            }
        }
    }
    public class SavingAccount : BankAccount
    {
        private float _InterestRate;
        private float _MonthlyAvgBal;
        private int _CustomerID;
   
        public float MonthlyAvgBal
        {
            get
            {
                return _MonthlyAvgBal;
            }
            set
            {
                _MonthlyAvgBal = value;
            }
        }
        public float InterestRate
        {
            get { return _InterestRate; }
            set
            {
                if(value <= 12)
                {
                    _InterestRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public override int CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID= value;
            }
        }
        public int CustomerAge
        {
            get { return (int)((DateTime.Today - CustomerDOB).Days / 365.0); }
        }

        public override float Interest()
        {
            if(CustomerAge >= 50)
            {
                return (_MonthlyAvgBal * (InterestRate + 0.25f) / 100.0f);
            }
            else
            {
                return (_MonthlyAvgBal * InterestRate / 100.0f);
            }
        }
        public override string AccountType
        {
            get
            {
                return "Saving";
            }
        }
      
    }
    public class FDAccount : BankAccount
    {
        private float _InterestRate;
        private float _PRAmount;
        private int _CustomerID;
        public float PRAmount
        {
            get
            {
                return _PRAmount;
            }
            set{
                _PRAmount = value;
            }
        }
        public float InterestRate
        {
            get
            {
                return _InterestRate;
            }
            set
            {

                if(value <= 12.0)
                {
                    _InterestRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public override int CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }
        public override float Interest()
        {
            if (CustomerID >= 60)
            {
                return (_PRAmount * 0.5f * (InterestRate + 0.25f) / 100.0f);
                
            }
            return (_PRAmount * 0.5f * InterestRate / 100.0f);
        }
        public override string AccountType
        {
            get
            {
                return "Fixed Deposite";
            }
        }
        public float CustomerAge
        {
            get
            {
                return (int)((DateTime.Today - CustomerDOB).Days / 365.0);
            }
        }
    }
}
