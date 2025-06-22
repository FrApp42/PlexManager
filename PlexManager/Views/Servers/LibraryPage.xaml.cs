using MauiIcons.Core;
using PlexManager.ViewModels.Servers;

namespace PlexManager.Views.Servers;

public partial class LibraryPage : ContentPage
{
	public LibraryPage(LibraryViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
        NavigatedTo += viewModel.Loaded;
        NavigatedFrom += viewModel.Unloaded;

        _ = new MauiIcon();
    }
}
