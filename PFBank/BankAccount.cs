using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFBank
{
    public class BankAccount
    {
        public string AcNumber { get; set; }

        public string OwnerName { get; set;}

        public decimal Balance { 
            get
            {
            
                decimal balance = 0;    

                foreach (var item in allTransictions)
                {
                    balance += item.Amount;
                }
                return balance; 
            } 
        
        }

        private static int AccountNumber = 1001;

        List<Transaction> allTransictions = new List<Transaction>(); 


        public BankAccount(string name, decimal initialBalance) 
        {
           this.OwnerName = name;
            MakeDiposit(initialBalance, DateTime.Now, "Initial Balance");
            this.AcNumber = AccountNumber.ToString();
            AccountNumber++;    
        
        
        }

        public void MakeDiposit(decimal amount, DateTime date, string note )
        {
            if ( amount <= 0 )
            {

                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");

            }

            var deposit = new Transaction(amount, date, note);
            allTransictions.Add(deposit);

        }


        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransictions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            // Header 

            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransictions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");

            }
            return report.ToString();
        }


    }
}
