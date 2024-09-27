using PlexManager.ViewModel;

namespace PlexManager.View;

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