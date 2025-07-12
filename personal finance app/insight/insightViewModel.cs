using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Globalization;

namespace personal_finance_app
{
    public class InsightsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CategoryInsight> CategoryInsights { get; set; }

        public double TotalSpent => CategoryInsights.Sum(c => c.Amount);

        public string TotalSpentFormatted => $"Total Spent: {TotalSpent.ToString("C", CultureInfo.CurrentCulture)}";

        public string MostSpentCategory =>
            CategoryInsights.OrderByDescending(c => c.Amount).FirstOrDefault()?.Category is string top
            ? $"Most spent on: {top}"
            : "No spending data";

        public InsightsViewModel()
        {
            // Dummy insight data - Replace with real aggregation from transactions
            CategoryInsights = new ObservableCollection<CategoryInsight>
            {
                new CategoryInsight { Category = "Food", Amount = 400 },
                new CategoryInsight { Category = "Transport", Amount = 150 },
                new CategoryInsight { Category = "Utilities", Amount = 100 },
                new CategoryInsight { Category = "Entertainment", Amount = 80 }
            };

            // Calculate percentage for each
            UpdatePercentages();
        }

        private void UpdatePercentages()
        {
            double total = TotalSpent;
            foreach (var insight in CategoryInsights)
            {
                insight.PercentageUsed = total > 0
                    ? $"{(insight.Amount / total * 100):F1}%"
                    : "0%";
            }

            OnPropertyChanged(nameof(TotalSpentFormatted));
            OnPropertyChanged(nameof(MostSpentCategory));
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class CategoryInsight : INotifyPropertyChanged
    {
        private string category;
        private double amount;
        private string percentageUsed;

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public double Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }

        public string PercentageUsed
        {
            get => percentageUsed;
            set => SetProperty(ref percentageUsed, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
