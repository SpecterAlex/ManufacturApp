using ColmenApp.Models;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ColmenApp.Cache
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(nameof(GeneralSettings), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(GeneralSettings), value);
        }

        public static void SetJsonGeneralSetting(GeneralSetting Setting)
        {
            GeneralSettings = JsonConvert.SerializeObject(Setting);
        }

        public static GeneralSetting GetJsonGeneralSetting()
        {
            GeneralSetting Setting = new GeneralSetting();

            Setting = JsonConvert.DeserializeObject<GeneralSetting>(GeneralSettings);

            return Setting ?? new GeneralSetting();
        }
    }
}
