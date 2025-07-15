using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace PFAPI.Models
{
    public class TransDataContext :DbContext
    {
        public TransDataContext(DbContextOptions<TransDataContext> options) : base(options) { }

        public DbSet<TransactionModel> Transact{ get; set; } 
    }
}
