using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_finance_app
{
    public class Transaction
    {

        public Transaction(transCategory category, string title, string description, double amount, DateTime dateCreated)
        {
            Category = category;
            Title = title;
            Description = description;
            Amount = amount;
            DateCreated = dateCreated;
        }
        #region Properties
        public string Title { get; set; }
        public double Amount { get; set; }
        public transCategory Category { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
       
        #endregion

    }
}
