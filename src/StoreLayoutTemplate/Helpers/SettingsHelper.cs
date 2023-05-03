using System.Linq;

using Windows.Storage;

namespace StoreLayoutTemplate.Helpers
{
  public static class SettingsHelper
  {
    private static readonly ApplicationDataContainer Settings = ApplicationData.Current.LocalSettings;

    public static void SetValue(string key, object value)
    {
      Settings.Values[key] = value;
    }

    public static object GetValue(string key)
    {
      if (Settings.Values.Any(x => x.Key == key))
      {
        return Settings.Values[key];
      }

      return null;
    }

    public static void CreateSettings()
    {
      if (!Settings.Values.Any(x => x.Key == Consts.Settings.Theme))
      {
        Settings.Values[Consts.Settings.Theme] = 0;
      }
    }
  }
}