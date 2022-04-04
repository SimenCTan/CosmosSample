namespace CosmosSample.MauiCRM.Pages;

public partial class SalesPage : ContentPage
{
    private SalesViewModel _salesViewModel=>BindingContext as SalesViewModel;
	public SalesPage(SalesViewModel salesViewModel)
	{
		InitializeComponent();
        BindingContext = salesViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _salesViewModel.InitializeAsync();
    }
}
