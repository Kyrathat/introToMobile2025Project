using System.Collections.ObjectModel;
using System.Transactions;

namespace personal_finance_app;

public partial class editTrans : ContentPage
{
    ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

    public ObservableCollection<Transaction> Transactions { get { return transactions; } }

    public editTrans()
	{
		InitializeComponent();

        #region garbageTransaction
        Transaction t1 = new Transaction(transCategory.Gas, "Gas Test", "Gas Description", 150, DateTime.Now.ToShortDateString());

            Transactions.Add(t1);
            Transactions.Add(new Transaction(transCategory.Bill, "Bill Test", "Bill Description", 225, DateTime.Today.ToShortDateString()));
            Transactions.Add(new Transaction(transCategory.Car, "Car Test", "Car Description", 50, DateTime.Now.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Bill, "Bill Test", "Bill Description", 225, DateTime.Today.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Car, "Car Test", "Car Description", 50, DateTime.Now.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Bill, "Bill Test", "Bill Description", 225, DateTime.Today.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Car, "Car Test", "Car Description", 50, DateTime.Now.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Bill, "Bill Test", "Bill Description", 225, DateTime.Today.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Car, "Car Test", "Car Description", 50, DateTime.Now.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Bill, "Bill Test", "Bill Description", 225, DateTime.Today.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Car, "Car Test", "Car Description", 50, DateTime.Now.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Bill, "Bill Test", "Bill Description", 225, DateTime.Today.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Car, "Car Test", "Car Description", 50, DateTime.Now.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Bill, "Bill Test", "Bill Description", 225, DateTime.Today.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Car, "Car Test", "Car Description", 50, DateTime.Now.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Bill, "Bill Test", "Bill Description", 225, DateTime.Today.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Car, "Car Test", "Car Description", 50, DateTime.Now.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Bill, "Bill Test", "Bill Description", 225, DateTime.Today.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Car, "Car Test", "Car Description", 50, DateTime.Now.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Bill, "Bill Test", "Bill Description", 225, DateTime.Today.ToShortDateString()));
        Transactions.Add(new Transaction(transCategory.Car, "Car Test", "Car Description", 50, DateTime.Now.ToShortDateString()));
        #endregion


        transactionsView.ItemsSource = transactions;

            transactionsView.ScrollTo(1);   

    }

}