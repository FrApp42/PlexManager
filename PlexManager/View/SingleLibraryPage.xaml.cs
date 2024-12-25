using MauiIcons.Core;
using PlexManager.ViewModel;

namespace PlexManager.View;

public partial class SingleLibraryPage : ContentPage
{
	public SingleLibraryPage(SingleLibraryViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
        NavigatedTo += viewModel.Loaded;
        NavigatedFrom += viewModel.Unloaded;

        _ = new MauiIcon();
    }
}
