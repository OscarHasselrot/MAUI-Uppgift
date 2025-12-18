namespace MAUI_Uppgift.Views.Controls;

using System.ComponentModel;

public partial class BusyOverlay : ContentView
{
    public BusyOverlay()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty IsBusyProperty =
        BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(BusyOverlay), false,
            propertyChanged: (b, o, n) => ((BusyOverlay)b).OnBusyChanged((bool)n));

    public bool IsBusy
    {
        get => (bool)GetValue(IsBusyProperty);
        set => SetValue(IsBusyProperty, value);
    }

    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(BusyOverlay), default(ImageSource));

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public static readonly BindableProperty ImageSizeProperty =
        BindableProperty.Create(nameof(ImageSize), typeof(double), typeof(BusyOverlay), 48d);

    public double ImageSize
    {
        get => (double)GetValue(ImageSizeProperty);
        set => SetValue(ImageSizeProperty, value);
    }

    void OnBusyChanged(bool isBusy)
    {
        if (isBusy)
        {
            // Rotate forever
            var anim = new Animation(v => LoadingImage.Rotation = v, 0, 360);
            anim.Commit(this, "BusyRotate", 16, 900, Easing.Linear, repeat: () => true);
        }
        else
        {
            this.AbortAnimation("BusyRotate");
            LoadingImage.Rotation = 0;
        }
    }
}