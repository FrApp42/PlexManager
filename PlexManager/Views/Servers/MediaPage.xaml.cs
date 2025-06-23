using AndroidX.Lifecycle;
using PlexManager.ViewModels.Servers;

namespace PlexManager.Views.Servers;

public partial class MediaPage : ContentPage
{
	public MediaPage(MediaViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
        NavigatedTo += viewModel.Loaded;
        //NavigatedFrom += viewModel.Unloaded;
    }
}