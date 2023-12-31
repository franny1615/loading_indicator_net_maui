﻿namespace LoadingIndicatorSample;

public partial class MainPage : ContentPage
{
	private readonly StatusIndicatorManager _statusIndicatorManager;

	public MainPage(StatusIndicatorManager statusIndicatorManager)
	{
		InitializeComponent();
        _statusIndicatorManager = statusIndicatorManager;
	}

	private void TestStatusIndicator(object sender, EventArgs e)
	{
        _statusIndicatorManager.ShowWithStatus("Loading...", this);
		Task.Run(async () =>
		{
			await Task.Delay(500);
			MainThread.BeginInvokeOnMainThread(() =>
			{
                _statusIndicatorManager.ShowWithStatus("Message Changed", this);
            });
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _statusIndicatorManager.ShowWithStatus(null, this);
            });
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _statusIndicatorManager.ShowWithStatus("", this);
            });
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _statusIndicatorManager.ShowWithStatus("Message Changed Again", this);
            });
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _statusIndicatorManager.Dismiss();
            });
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _statusIndicatorManager.ShowWithStatus("Message Changed Again Again", this);
            });
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _statusIndicatorManager.Dismiss();
            });
        });
	}

    private void TestCompletionStatusIndicator(object sender, EventArgs e)
    {
        Task.Run(async () =>
        {
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _statusIndicatorManager.ShowCompletionWithStatus("Complete!", this);
            });
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _statusIndicatorManager.ShowCompletionWithStatus("", this);
            });
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _statusIndicatorManager.ShowCompletionWithStatus(null, this);
            });
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _statusIndicatorManager.Dismiss();
            });
        });
    }
}


