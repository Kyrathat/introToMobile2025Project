using System.ComponentModel.DataAnnotations;

namespace PFAPI.Models
{
    public class TransactionModel
    {
        public TransactionModel() { }
        public TransactionModel(int TransactionID, string Title, double Amount, double Balance, 
            string Description, string TransactionCategory, DateTime DateCreated)
        {
            this.TransactionID = TransactionID;
            this.Title = Title;
            this.Amount = Amount;
            this.Balance = Balance;
            this.Description = Description;
            this.TransactionCategory = TransactionCategory;
            this.DateCreated = DateCreated;
        }
        [Key]
        public int TransactionID { get; set; }
        public string? Title { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
        public string? Description { get; set; }
        public string? TransactionCategory { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
