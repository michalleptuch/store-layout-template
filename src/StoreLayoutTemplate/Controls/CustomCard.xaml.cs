using System.ComponentModel;
using System.Numerics;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace StoreLayoutTemplate.Controls
{
  public sealed partial class CustomCard : UserControl, INotifyPropertyChanged
  {
    public static new readonly DependencyProperty ContentProperty =
      DependencyProperty.Register("Content", typeof(UIElement), typeof(CustomCard), new PropertyMetadata(null));

    public CustomCard()
    {
      InitializeComponent();

      VisualStateManager.GoToState(this, "Normal", true);
    }

    public new UIElement Content
    {
      get => (UIElement)GetValue(ContentProperty);
      set
      {
        SetValue(ContentProperty, value);
        PropertyChanged?.Invoke(value, new PropertyChangedEventArgs(nameof(Content)));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void SetPointerNormalState(object sender, PointerRoutedEventArgs e)
    {
      VisualStateManager.GoToState(this, "Normal", true);
    }

    private void SetPointerOverState(object sender, PointerRoutedEventArgs e)
    {
      VisualStateManager.GoToState(this, "PointerOver", true);
    }

    private void SetPointerPressedState(object sender, PointerRoutedEventArgs e)
    {
      VisualStateManager.GoToState(this, "Pressed", true);
    }
  }
}