`FlipNumbers` emulates the old-fashioned "split-flap" display, once
commonly used in clocks and timetables.  `FlipNumbers` supports iOS and
Android, and allows you to customize the flip animation duration.

### Adding a `FlipNumbersView` to your iOS app:

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

*This control was created by [Touch Instinct](http://touchinstinct.com).*
*Screenshot assembled with [PlaceIt](http://placeit.breezi.com/).*
