using PlexManager.ViewModel;

namespace PlexManager.View;

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
