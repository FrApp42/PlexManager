using PlexManager.ViewModels;

namespace PlexManager.Views;

public partial class ServersPage : ContentPage
{
    int count = 0;

    public ServersPage(ServersViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        //Loaded += viewModel.Loaded;
        NavigatedTo += viewModel.Loaded;
	}
}