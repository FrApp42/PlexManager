using MauiIcons.Core;
using PlexManager.ViewModels;

namespace PlexManager.Views
{
    public partial class SingleServerPage : ContentPage
    {
        public SingleServerPage(SingleServerViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
            NavigatedTo += viewModel.Loaded;
            NavigatedFrom += viewModel.Unloaded;

            _ = new MauiIcon();
        }
    }
};
