using personal_finance_app;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace personal_finance_app;

public partial class newTrans : ContentPage
{
	public newTrans()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();

		//category, title, descr, amount, date
		Transaction newTrans = new Transaction(transCategory.Gas, "title", "Gas for car", 150, DateTime.Now.ToShortTimeString());
	}


    public class MainViewModel
    {
        public ObservableCollection<transCategory> TransCategories { get; set; }

        public MainViewModel()
        {
            TransCategories = new ObservableCollection<transCategory>(
                Enum.GetValues(typeof(transCategory)).Cast<transCategory>());
        }
    }
}