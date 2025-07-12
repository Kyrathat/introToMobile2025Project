namespace personal_finance_app;

public partial class insight : ContentPage
{
	public insight()
	{
        InitializeComponent();
        this.BindingContext = new InsightsViewModel();
    }
}