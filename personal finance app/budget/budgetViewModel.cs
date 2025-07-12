using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Linq;

namespace personal_finance_app
{
    public class BudgetViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<BudgetItem> BudgetItems { get; set; } = new();

        public ICommand AddBudgetCommand { get; }

        private double totalBudget = 1500;
        public double TotalBudget
        {
            get => totalBudget;
            set
            {
                if (SetProperty(ref totalBudget, value))
                {
                    OnPropertyChanged(nameof(Remaining));
                    OnPropertyChanged(nameof(Progress));
                }
            }
        }

        public double TotalSpent => BudgetItems.Sum(item => item.Amount);

        public double Remaining => TotalBudget - TotalSpent;

        public double Progress => TotalBudget > 0 ? TotalSpent / TotalBudget : 0;

        public BudgetViewModel()
        {
            // Example data
            BudgetItems.Add(new BudgetItem { Name = "Groceries", Category = "Food", Amount = 200 });
            BudgetItems.Add(new BudgetItem { Name = "Gas", Category = "Transport", Amount = 100 });
            BudgetItems.Add(new BudgetItem { Name = "Electricity Bill", Category = "Utilities", Amount = 350 });

            AddBudgetCommand = new Command(OnAddBudgetItem);
            BudgetItems.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(TotalSpent));
                OnPropertyChanged(nameof(Remaining));
                OnPropertyChanged(nameof(Progress));
            };
        }

        private void OnAddBudgetItem()
        {
            // Simulate adding a new budget item
            BudgetItems.Add(new BudgetItem
            {
                Name = "New Item",
                Category = "Misc",
                Amount = 50
            });
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

    public class BudgetItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Amount { get; set; }
    }
}
