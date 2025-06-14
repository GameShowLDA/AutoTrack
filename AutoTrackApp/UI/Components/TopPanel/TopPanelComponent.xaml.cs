using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoTrackApp.UI.Components.TopPanel
{
  /// <summary>
  /// Логика взаимодействия для TopPanelComponent.xaml
  /// </summary>
  public partial class TopPanelComponent : UserControl
  {
    public TopPanelComponent()
    {
      InitializeComponent();
      this.MouseLeftButtonDown += TopPanelComponent_MouseLeftButtonDown;
    }

    private void TopPanelComponent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      Window window = Window.GetWindow(this);
      if (window != null)
      {
        window.DragMove();
      }
    }

    private void MinimizeButton_EllipsePreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      Window window = Window.GetWindow(this);
      if (window != null)
      {
        window.WindowState = WindowState.Minimized;
      }
    }

    private void MaximizeButton_EllipsePreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      Window window = Window.GetWindow(this);
      if (window != null)
      {
        if (window.WindowState == WindowState.Maximized)
        {
          window.WindowState = WindowState.Normal;
        }
        else
        {
          window.WindowState = WindowState.Maximized;
        }
      }
    }

    private void CloseButton_EllipsePreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
