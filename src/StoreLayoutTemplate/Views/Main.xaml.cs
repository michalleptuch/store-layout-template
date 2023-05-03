using System;
using System.Linq;

using Microsoft.UI.Xaml.Controls;

using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StoreLayoutTemplate.Views
{
  public sealed partial class Main : Page
  {
    public Main()
    {
      InitializeComponent();

      if (Environment.OSVersion.Version.Build >= 22000)
      {
        SetValue(BackdropMaterial.ApplyToRootOrPageBackgroundProperty, true);
      }

      Window.Current.SetTitleBar(TitleBarGrid);

      Window.Current.Activated += (s, e) =>
      {
        TitleBarGrid.Opacity = e.WindowActivationState != CoreWindowActivationState.Deactivated ? 1 : 0.5;
      };

      NavigationViewControl.SelectedItem = NavigationViewControl.MenuItems.First();

      ContentFrame.Navigate(typeof(Page1));
    }

    private void Navigate(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
    {
      var index = sender.MenuItems.IndexOf(args.InvokedItemContainer);

      if (index == -1)
      {
        ContentFrame.Navigate(typeof(Settings));

        return;
      }

      ContentFrame.Navigate(index % 2 == 0 ? typeof(Page1) : typeof(Page2));
    }
  }
}