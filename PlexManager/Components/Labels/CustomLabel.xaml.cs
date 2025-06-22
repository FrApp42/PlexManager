using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Reflection.PortableExecutable;

namespace PlexManager.Components.Labels;

public partial class CustomLabel : ContentView
{
	public CustomLabel()
	{
		InitializeComponent();        
	}

    public static readonly BindableProperty StartTextProperty =
        BindableProperty.Create(nameof(StartText), typeof(string), typeof(CustomLabel), string.Empty);

    public string StartText
    {
        get => (string)GetValue(StartTextProperty);
        set => SetValue(StartTextProperty, value);
    }

    public static readonly BindableProperty EndTextProperty =
        BindableProperty.Create(nameof(EndText), typeof(string), typeof(CustomLabel), string.Empty);

    public string EndText
    {
        get => (string)GetValue(EndTextProperty);
        set => SetValue(EndTextProperty, value);
    }

    public static readonly BindableProperty AllowCopyProperty =
    BindableProperty.Create(
        nameof(AllowCopy),
        typeof(bool),
        typeof(CustomLabel),
        false); // valeur par défaut : false

    public bool AllowCopy
    {
        get => (bool)GetValue(AllowCopyProperty);
        set => SetValue(AllowCopyProperty, value);
    }

    private async void OnCopyClicked(object sender, EventArgs e)
    {
        if (!AllowCopy || string.IsNullOrEmpty(EndText))
            return;

        await Clipboard.Default.SetTextAsync(EndText);

        CancellationTokenSource cancellationTokenSource = new();

        IToast toast = Toast.Make("Value copied to clipboard", ToastDuration.Short, 14);
        await toast.Show(cancellationTokenSource.Token);
    }


}