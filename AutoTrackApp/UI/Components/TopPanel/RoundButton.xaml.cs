using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AutoTrackApp.UI.Components.TopPanel
{
  /// <summary>
  /// Круглая кнопка для WPF-интерфейса с поддержкой сглаживания, изменяемым размером и цветом заливки.
  /// Свойство <see cref="Background"/> управляет цветом круга, <see cref="SizeButton"/> задаёт диаметр.
  /// Событие <see cref="EllipsePreviewMouseDown"/> вызывается только при нажатии на сам круг.
  /// Курсор меняется на "руку" при наведении на круг.
  /// </summary>
  public partial class RoundButton : UserControl
  {
    public RoundButton()
    {
      InitializeComponent();
    }

    public static readonly new DependencyProperty BackgroundProperty =
        DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(RoundButton),
            new PropertyMetadata(Brushes.LightGray));

    /// <summary>
    /// Цвет заливки круга.
    /// </summary>
    public new Brush Background
    {
      get => (Brush)GetValue(BackgroundProperty);
      set => SetValue(BackgroundProperty, value);
    }

    public static readonly DependencyProperty SizeButtonProperty =
        DependencyProperty.Register(nameof(SizeButton), typeof(double), typeof(RoundButton),
            new PropertyMetadata(40.0, OnSizeButtonChanged));

    /// <summary>
    /// Диаметр круглой кнопки.
    /// </summary>
    public double SizeButton
    {
      get => (double)GetValue(SizeButtonProperty);
      set => SetValue(SizeButtonProperty, value);
    }

    private static void OnSizeButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      if (d is RoundButton rb)
      {
        double size = (double)e.NewValue;
        rb.Width = size;
        rb.Height = size;
        rb.ellipse.Width = size;
        rb.ellipse.Height = size;
      }
    }

    /// <summary>
    /// Событие, возникающее при нажатии на круг.
    /// </summary>
    public event MouseButtonEventHandler EllipsePreviewMouseDown;

    private void Ellipse_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      EllipsePreviewMouseDown?.Invoke(this, e);
    }
  }
}
