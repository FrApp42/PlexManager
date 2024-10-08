using PlexManager.ViewModel;

namespace PlexManager.View;

public partial class SingleServer : ContentPage
{
	public SingleServer(SingleServerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
