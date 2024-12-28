using MauiIcons.Core;
using PlexManager.ViewModels;

namespace PlexManager.Views;

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
