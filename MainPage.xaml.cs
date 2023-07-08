namespace LoadingIndicatorSample;

public partial class MainPage : ContentPage
{
	private StatusIndicator StatusIndicator
		=> StatusIndicator.Instance;

	public MainPage()
	{
		InitializeComponent();
	}

	private void TestStatusIndicator(object sender, EventArgs e)
	{
		StatusIndicator.ShowWithStatus("Loading...", this);
		Task.Run(async () =>
		{
			await Task.Delay(1000);
			MainThread.BeginInvokeOnMainThread(() =>
			{
                StatusIndicator.ShowWithStatus("1 Second has passed", this);
            });
			await Task.Delay(1000);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                StatusIndicator.ShowWithStatus("2 Second has passed", this);
            });
            await Task.Delay(1000);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                StatusIndicator.ShowWithStatus("3 Second has passed", this);
            });
            await Task.Delay(1000);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                StatusIndicator.Dismiss();
            });
        });
	}
}


