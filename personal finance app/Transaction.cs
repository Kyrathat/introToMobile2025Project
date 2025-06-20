using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_finance_app
{
    public class Transaction
    {

        public Transaction(transCategory category, string title, string description, double amount, string dateCreated)
        {
            _category = category;
            _title = title;
            _description = description;
            _amount = amount;
            _dateCreated = dateCreated;

        }
        #region fields and properties
        private string? _title;
        public string? Title { get { return _title; } set { _title = value; } }
        private double _amount;
        public double Amount { get { return _amount; } set { _amount = value; } }
        private transCategory _category;
        public transCategory Category { get { return _category; } set { _category = value; } }
        private string? _description;
        public string Description { get { return _description; } set { _description = value; }  }
        private string _dateCreated;
        public string DateCreated { get { return _dateCreated; } set { _dateCreated = value; } }
        private List<Transaction> _transactions = new List<Transaction>();
        public List<Transaction> Transactions { get { return _transactions; } set { _transactions = value; } }
        #endregion

        public string ChooseCategory(transCategory tC)
        {
            switch (tC)
            {
                case transCategory.Bill:
                    return "Bill";
                case transCategory.Car:
                    return "Car";
                case transCategory.CellPhone:
                    return "Cell Phone";
                case transCategory.Childcare:
                    return "Child Care";
                case transCategory.CreditCard:
                    return "Credit Card";
                case transCategory.Debt:
                    return "Debt";
                case transCategory.Emergency:
                    return "Emergency";
                case transCategory.Entertainment:
                    return "Entertainment";
                case transCategory.Gas:
                    return "Gas";
                case transCategory.Grocery:
                    return "Grocery";
                case transCategory.Housing:
                    return "Housing";
                case transCategory.Income:
                    return "Income";
                case transCategory.Insurance:
                    return "Insurance";
                case transCategory.Loan:
                    return "Loan";
                case transCategory.Other:
                    return "Other";
                case transCategory.Restaurant:
                    return "Restaurant";
                case transCategory.Subscription:
                    return "Subscription";
                case transCategory.Utility:
                    return "Utility";
                default:
                    return "n/A";
            }
        }

        /// <summary>
        /// deletes an existing transaction
        /// </summary>
        public void DeleteTransaction()
        {

        }

        /// <summary>
        /// edits an existing transaction
        /// </summary>
        public void EditTransaction()
        {

        }

        public void FindTransaction()
        {

        }

        /// <summary>
        /// creates a new transaction
        /// </summary>
        public void NewTransaction()
        {
            //Transaction tempTrans = new Transaction(transCategory.Bill, "Test1", "test1", 150, DateTime.Now);

            //Title = Console.ReadLine();
            //Amount = (double)Console.ReadLine();
            //Description = Console.ReadLine();
            //_dateCreated = DateTime.Now;

            //tempTrans = new Transaction(transCategory.Bill, Title, Description, Amount, _dateCreated);

            ////add trans to list
            //Transactions.Add(tempTrans);
        }

        /// <summary>
        /// lists all transactions
        /// </summary>
        public void ReturnAllTransactions()
        {
            foreach(Transaction t in Transactions)
            {
                Console.WriteLine(t.ToString);
            }
        }

        public override string ToString()
        {
            return $"{_category} {_title} {_description} {_amount} {_dateCreated}"; 
        }
    }
}
