`FlipNumbers` emulates the old-fashioned "split-flap" display, once
commonly used in clocks and timetables.  `FlipNumbers` supports iOS and
Android, and allows you to customize the flip animation duration.

## Examples

### Adding a `FlipNumbersView` to your iOS app:

First, you need to add `"Fonts/Bebas.ttf"` to your Info.plist file as
shown in [this screenshot](https://dl.dropbox.com/u/217582/xamarin/component-store/flip-numbers-plist.jpg).  Then add a `FlipNumbersView` from a controller:

```csharp
using FlipNumbers;
...

public override void ViewDidLoad ()
{
  base.ViewDidLoad ();

  var flipper = new FlipNumbersView (digitsCount: 4) {
    Center = View.Center,
		Value = 1234
  };
  View.AddSubview (flipper);
}
```

### Adding a `FlipNumbersView` to your Android app:

```csharp
using FlipNumbers;
...

protected override void OnCreate (Bundle bundle)
{
  base.OnCreate (bundle);
  
  var flipper = new FlipNumbersView (this, digitsCount: 4) {
		Value = 1234
	};
  AddContentView (flipper, new ViewGroup.LayoutParams (
    ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent));
}
```

### Changing the display

```csharp
// Without animation
flipper.Value = 1234;
flipper.SetValue (3456, animated: false);

// With animation
flipper.SetValue (4567, animated: true);
```

### Customization

On iOS, the flip duration unit is seconds:

```csharp
// Change flip animation duration (default is 0.2 seconds)
flipper.FlipDuration = 0.5;
```

On Android, the flip duration unit is milliseconds:

```csharp
// Change flip animation duration (default is 200 milliseconds)
flipper.FlipDuration = 500;
```

### Adding a FlipNumbersView to an AXML layout

```xml
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android" ... >
  <FlipNumbers.FlipNumbersView
    digits_count="4"
    flip_duration=".5"
    android:id="@+id/flipNumbersView"
    android:layout_width="wrap_content"
    android:layout_height="wrap_content" />
</LinearLayout>
```
