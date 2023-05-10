using System.Collections.Generic;

using Windows.UI.Xaml.Controls;

namespace StoreLayoutTemplate.Views
{
  public sealed partial class Page1 : Page
  {
    public Page1()
    {
      InitializeComponent();

      var items = new List<string>();

      for (int i = 0; i < 10; i++)
      {
        items.Add($"Item {i}");
      }

      ContentGridView.ItemsSource = items;
    }
  }
}
