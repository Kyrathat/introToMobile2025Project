using System.Collections.ObjectModel;

namespace personal_finance_app
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        public class myItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class MainViewModel
        {
            public ObservableCollection<myItem> MyItems { get; set; }

            public MainViewModel()
            {
                MyItems = new ObservableCollection<myItem>()
                {
                    new myItem { Title = "First", Description = "This is where your recent transactions go"},
                    new myItem { Title = "Second", Description = "This is where your overall budget for the month is."}
                };
            }
        }


    }

}
