using PlexManager.ViewModel;

namespace PlexManager.View;

public partial class ClaimTokenPage : ContentPage
{
	public ClaimTokenPage(ClaimTokenViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}