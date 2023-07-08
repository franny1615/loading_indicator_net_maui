# Loading Indicator Sample

Basic Activity Indicator using Community Toolkit Popup
* Relies on an svg called loading.svg.
* That svg is rotated 360 degress when indicator is showing.

## Adding To Project
* Drag and drop the StatusIndicator.cs file and adjust namespace.
* Take loading.svg from this project or creating your own loading wheel. 
```
// Add the manager as a service
... MauiProgram.cs
builder.Services.AddSingleton<StatusIndicatorManager>();
...
... SomePage.cs
private readonly StatusIndicatorManager _statusIndicatorManager;

public SomePage(StatusIndicatorManager statusIndicatorManager)
{
    InitializeComponent();
    _statusIndicatorManager = statusIndicatorManager;
}
...
```
## Usage
```
// Show/Update a status
//  this is anything that inherits from Page object
_statusIndicatorManager.ShowWithStatus("Loading...", this);

// Dimiss a status 
//  (required when you're done with the status)
_statusIndicatorManager.Dismiss();
```