using PlexManager.ViewModel;

namespace PlexManager.View;

public partial class SingleServerPage : ContentPage
{
    public SingleServerPage(SingleServerViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;

		NavigatedTo += viewModel.Loaded;
	}
}
