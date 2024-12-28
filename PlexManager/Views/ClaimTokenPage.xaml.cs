using PlexManager.ViewModels;

namespace PlexManager.Views;

public partial class ClaimTokenPage : ContentPage
{
	public ClaimTokenPage(ClaimTokenViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}