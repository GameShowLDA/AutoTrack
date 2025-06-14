using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoTrackApp.UI.Components.Icons
{
  public partial class PencilIcon : UserControl
  {
    public PencilIcon()
    {
      InitializeComponent();
    }

    public static readonly DependencyProperty IconFillProperty =
        DependencyProperty.Register(nameof(IconFill), typeof(Brush), typeof(PencilIcon),
            new PropertyMetadata(Brushes.Blue));

    public Brush IconFill
    {
      get => (Brush)GetValue(IconFillProperty);
      set => SetValue(IconFillProperty, value);
    }

    public static readonly DependencyProperty HoverFillProperty =
        DependencyProperty.Register(nameof(HoverFill), typeof(Brush), typeof(PencilIcon),
            new PropertyMetadata(new SolidColorBrush(Color.FromRgb(37, 99, 235)))); // #2563eb

    public Brush HoverFill
    {
      get => (Brush)GetValue(HoverFillProperty);
      set => SetValue(HoverFillProperty, value);
    }

    public static readonly DependencyProperty SizeProperty =
        DependencyProperty.Register(nameof(Size), typeof(double), typeof(PencilIcon),
            new PropertyMetadata(24.0, OnSizeChanged));

    public double Size
    {
      get => (double)GetValue(SizeProperty);
      set => SetValue(SizeProperty, value);
    }

    private static void OnSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      if (d is PencilIcon icon)
      {
        icon.Width = icon.Size;
        icon.Height = icon.Size;
      }
    }
  }
}