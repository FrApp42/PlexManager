using PlexManager.ViewModels.Tokens;

namespace PlexManager.Views.Tokens;

public partial class ClaimPage : ContentPage
{
	public ClaimPage(ClaimViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}