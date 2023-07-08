using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Markup;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;
using Microsoft.Maui.Controls.Shapes;

namespace LoadingIndicatorSample;

public class StatusIndicator : Popup 
{
	public static StatusIndicator Instance = new();

	#region Status
	private Label StatusLabel = new Label
		{
			MaxLines = 2,
			HorizontalTextAlignment = TextAlignment.Center
		}
		.TextColor(Colors.White)
        .Font(size: 16, bold: true);
	#endregion

	#region IsShown
	public static BindableProperty IsShownProperty = BindableProperty.Create(
		nameof(IsShownProperty),
		typeof(bool),
		typeof(StatusIndicator));

	public bool IsShown
	{
		get => (bool)GetValue(IsShownProperty);
		set => SetValue(IsShownProperty, value);
	}
    #endregion

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
					new ActivityIndicator
						{
							IsRunning = true,
							Color = Colors.White
						}
						.Row(0),
					StatusLabel
						.Row(1)
				}
			}
			.CenterVertical()
			.Margin(10)
		};
    }

	public void ShowWithStatus(string status, Page page)
	{
		StatusLabel.Text = status;

		if (IsShown)
			return;

		IsShown = true;
		page.ShowPopup(this);
	}

	public void Dismiss()
	{
		Close();
	}
}
