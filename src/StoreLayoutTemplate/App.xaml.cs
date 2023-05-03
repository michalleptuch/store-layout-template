using System;

using StoreLayoutTemplate.Helpers;
using StoreLayoutTemplate.Services;
using StoreLayoutTemplate.Views;

using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace StoreLayoutTemplate
{
  sealed partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      SettingsHelper.CreateSettings();
    }

    public ThemeService ThemeService { get; private set; }

    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
      Frame rootFrame = Window.Current.Content as Frame;

      var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
      coreTitleBar.ExtendViewIntoTitleBar = true;

      ThemeService = new ThemeService(Window.Current);
      ThemeService.SetTheme();

      if (rootFrame == null)
      {
        rootFrame = new Frame();
        rootFrame.NavigationFailed += OnNavigationFailed;

        Window.Current.Content = rootFrame;
      }

      if (e.PrelaunchActivated == false)
      {
        if (rootFrame.Content == null)
        {
          rootFrame.Navigate(typeof(Main), e.Arguments);
        }

        Window.Current.Activate();
      }
    }

    void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
      throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }
  }
}