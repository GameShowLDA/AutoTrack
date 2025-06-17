using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoTrackApp.UI.Components.Icons
{
  public partial class CloseIcon : UserControl
  {
    public CloseIcon()
    {
      InitializeComponent();
    }

    public static readonly DependencyProperty IconFillProperty =
        DependencyProperty.Register(nameof(IconFill), typeof(Brush), typeof(CloseIcon), new PropertyMetadata(Brushes.Red));

    public Brush IconFill
    {
      get => (Brush)GetValue(IconFillProperty);
      set => SetValue(IconFillProperty, value);
    }

    public static readonly DependencyProperty HoverFillProperty =
        DependencyProperty.Register(nameof(HoverFill), typeof(Brush), typeof(CloseIcon), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(220, 20, 60))));

    public Brush HoverFill
    {
      get => (Brush)GetValue(HoverFillProperty);
      set => SetValue(HoverFillProperty, value);
    }

    public static readonly DependencyProperty SizeProperty =
        DependencyProperty.Register(nameof(Size), typeof(double), typeof(CloseIcon), new PropertyMetadata(24.0, OnSizeChanged));

    public double Size
    {
      get => (double)GetValue(SizeProperty);
      set => SetValue(SizeProperty, value);
    }

    private static void OnSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      if (d is CloseIcon icon)
      {
        icon.Width = icon.Size;
        icon.Height = icon.Size;
      }
    }
  }
}
