using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Markup;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;
using Microsoft.Maui.Controls.Shapes;

namespace LoadingIndicatorSample;

public class StatusIndicatorManager
{
	private StatusIndicator Indicator;

	public StatusIndicatorManager()
	{
		Indicator = new();
	}

	public void ShowWithStatus(string status, Page page)
	{
		Indicator.ShowWithStatus(status, page);
	}

	public void ShowCompletionWithStatus(string status, Page page)
	{
		Indicator.ShowCompletionWithStatus(status, page);
	}

	public void Dismiss()
	{
		Indicator.Dismiss();
		Indicator = new();
	}
}

public class StatusIndicator : Popup 
{
	private Label StatusLabel = new Label
		{
			MaxLines = 2,
			HorizontalTextAlignment = TextAlignment.Center
		}
		.TextColor(Colors.White)
        .Font(size: 16, bold: true);

	private Image LoadingImage = new Image()
		.CenterVertical()
		.CenterHorizontal()
		.Size(50,50)
		.Source("loading.png");

	private bool IsShown = false;

    public StatusIndicator()
	{
		CanBeDismissedByTappingOutsideOfPopup = false; 
		Color = Colors.Transparent;
		Size = new Size(width: 150, height: 150);
		Content = new Border
		{
			BackgroundColor = Color.FromArgb("#5A5A5A"),
			Stroke = Colors.Transparent,
			StrokeShape = new RoundRectangle
			{
				CornerRadius = 5
			},
			Content = new Grid
			{
				RowDefinitions = Rows.Define(Auto, Star),
				RowSpacing = 8,
				Children =
				{
					LoadingImage 
						.Row(0),
					StatusLabel
						.Row(1)
				}
			}
			.CenterVertical()
			.Margin(10)
		};
    }

    #region Status Actions
    public void ShowWithStatus(string status, Page page)
	{
		SetStatus(status);
		ShowOn(page, action: RotateLoading);
    }

    public void ShowCompletionWithStatus(string status, Page page)
    {
        SetStatus(status);
        ShowOn(page, action: ChangeToCheckMark);
    }

    public void Dismiss()
    {
        IsShown = false;
        Close();
    }
    #endregion 

    #region Helpers
    private void SetStatus(string status)
	{
        if (string.IsNullOrEmpty(status))
            StatusLabel.IsVisible = false;
        else
            StatusLabel.IsVisible = true;

        StatusLabel.Text = status;
    }

    private void ShowOn(Page page, Action action)
	{
        if (IsShown)
            return;

        IsShown = true;
		action();
        page.ShowPopup(this);
    }

    private async void RotateLoading()
    {
        if (!IsShown)
            return;

		LoadingImage.Source = "loading.png";
        await LoadingImage.RotateTo(360, 1000);
        LoadingImage.Rotation = 0;
        RotateLoading();
    }

	private void ChangeToCheckMark()
	{
		if (!IsShown)
			return;

		LoadingImage.Source = "check_circle_outline.png";
	}
    #endregion
}
