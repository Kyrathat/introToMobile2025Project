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
            public string Image { get; set; }
        }

        public class MainViewModel
        {
            public ObservableCollection<myItem> MyItems { get; set; }

            public MainViewModel()
            {
                MyItems = new ObservableCollection<myItem>()
                {
                    new myItem { Title = "First", Image = "first"},
                    new myItem { Title = "Second", Image = "second"}
                };
            }
        }


    }

}
