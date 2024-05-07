using System;

public abstract class TaxPayer
{
    private string _PANNo; 
    private string _address;
    private decimal _income; 
    private int _financialYear;

    
    public string PANNo
    {
        get
        {
            return _PANNo;
        }
        set
        {
            _PANNo = value;
        }
    }

    
    public string Address
    {
        get
        {
            return _address;
        }
        set
        {
            _address = value;
        }
    }

  
    public decimal Income
    {
        get
        {
            return _income;
        }
        set
        {
            _income = value;
        }
    }

   
    public int FinancialYear
    {
        get
        {
            return _financialYear;
        }
        set
        {
            _financialYear = value;
        }
    }
 


    public TaxPayer(string panNo, string address, decimal income, int financialYear)
    {
        PANNo = panNo;
        Address = address;
        Income = income;
        FinancialYear = financialYear;
    }

    
    public virtual void CalculateIncomeTax()
    {
    
    }
  
}


public class Individual : TaxPayer
{
    private decimal _totalTx;
    public Individual(string panNo, string address, decimal income, int financialYear) : base(panNo, address, income, financialYear)
    {
    }

    public override void CalculateIncomeTax()
    {
        decimal tax = 0;
        if (Income <= 500000)
        {
            tax = Income * 0.05m; 
        }
        else if (Income <= 1000000)
        {
            tax = 25000m + (Income - 500000m) * 0.1m; 
        }
        else
        {
            tax = 75000m + (Income - 1000000m) * 0.2m; 
        }
       this. _totalTx = tax;
        
    }
    public override string ToString()
    {
        return $" Individual \n Income = {this.Income} ,Address = {this.Address} , PAN  = {this.PANNo} , Income Tax = {this._totalTx}";

    }
}

public class Business : TaxPayer
{
    private decimal _expense;
    private decimal tax;

    public Business(string panNo, string address, decimal income, int financialYear, decimal expense) : base(panNo, address, income, financialYear)
    {
       this._expense = expense; 
    }

    public override void CalculateIncomeTax()
    {
     
        decimal taxableIncome = Income - _expense;
       
        if (taxableIncome <= 500000m)
        {
            this.tax = taxableIncome * 0.05m;
        }
        else if (taxableIncome <= 1000000m)
        {
            this.tax = 25000m + (taxableIncome - 500000m) * 0.1m; 
        }
        else
        {

        }
        
      
    }
    public override string ToString()
    {
        return $" Individual \n Income = {this.Income} ,Address = {this.Address} , PAN  = {this.PANNo} , Expense = {this._expense}, Income Tax = {this.tax}";

    }
}

public class CharitableOrganization : TaxPayer
{
    private decimal _expense;
    public decimal tax = 0;

    public CharitableOrganization(string panNo, string address, decimal income, int financialYear, decimal expense) : base(panNo, address, income, financialYear)
    {
        this._expense = expense; 
    }

    public override void CalculateIncomeTax()
    {
       
        decimal taxableIncome = Income - _expense;
    
        if (_expense >= 0.8m * Income)
        {
            this.tax = 0;
        }
        else
        {
           
          
            if (taxableIncome <= 500000)
            {
                this.tax = taxableIncome * 0.05m; 
            }
            else if (taxableIncome <= 1000000)
            {
                this.tax = 25000m + (taxableIncome - 500000m) * 0.1m; 
            }
            else
            {
                this.tax = 75000m + (taxableIncome - 1000000m) * 0.2m; 
            }
         
         
        }
    }
    public override string ToString()
    {
        return $" Individual \n Income = {this.Income} ,Address = {this.Address} , PAN  = {this.PANNo} , Expense = {this._expense}, Income Tax = {this.tax}";

    }
}
