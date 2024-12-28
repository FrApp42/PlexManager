using PlexManager.ViewModels;

namespace PlexManager.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
        NavigatedTo += viewModel.Loaded;
        NavigatedFrom += viewModel.Unloaded;
    }
}
