using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace personal_finance_app
{
    public class TransactionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Transaction> Transactions { get; set; } = new();
        public ObservableCollection<transCategory> Categories { get; set; }
        public ICommand addTransaction { get; }
        public ICommand DeleteCommand { get; }

        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        private double amount;
        public double Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
        private transCategory category;
        public transCategory Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }
        private Transaction selectedTransaction;
        public Transaction SelectedTransaction
        {
            get => selectedTransaction;
            set => SetProperty(ref selectedTransaction, value);
        }
        private void DeleteTransaction(Transaction transaction)
        {
            if (Transactions.Contains(transaction))
            {
                Transactions.Remove(transaction);
            }
        }

        public TransactionViewModel()
        {
            Categories = new ObservableCollection<transCategory>((transCategory[])Enum.GetValues(typeof(transCategory)));
            addTransaction = new Command(OnAddTransaction);
            DeleteCommand = new Command<Transaction>(DeleteTransaction);
        }


        private void OnAddTransaction()
        {
            var newTransaction = new Transaction
            (
                Category,
                Title,
                Description,
                Amount,
                DateTime.Now
            );

            Transactions.Add(newTransaction);

            // ✅ Select the newly added transaction
            SelectedTransaction = newTransaction;

            // Reset form
            Title = string.Empty;
            Description = string.Empty;
            Amount = 0;
            Category = Categories[0];
        }



        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string name = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(name);
            return true;
        }
    }
}