using Microsoft.Win32;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Linq;

namespace Task4
{
    public static class SaveSetting
    {
        public static void SaveSettingToConfigFile(Dictionary<string, string> settings)
        {
            XDocument xDocument = new XDocument(new XElement("Settings"));
            foreach (var setting in settings)
            {
                xDocument.Root.Add(new XElement("Setting",
                    new XAttribute(setting.Key, setting.Value)));
            }

            xDocument.Save("setting.xml");
        }

        public static Dictionary<string, string> GetSettingFromConfigFile()
        {
            XmlTextReader reader = new XmlTextReader("setting.xml");
            var settings = new Dictionary<string, string>();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        while (reader.MoveToNextAttribute())
                        {
                            settings.Add(reader.Name, reader.Value);
                        }
                        break;
                }
            }

            return settings;
        }

        public static void SaveSettingToRegistry(Dictionary<string, string> settings)
        {
            using (RegistryKey currentUserKey = Registry.CurrentUser)
            using (RegistryKey settingsKey = currentUserKey.CreateSubKey("Settings", true))
            {
                foreach (var setting in settings)
                {
                    settingsKey.SetValue(setting.Key, setting.Value);
                }
            }
        }

        public static Dictionary<string, string> GetSettingFromRegistry()
        {
            var settings = new Dictionary<string, string>();

            using (RegistryKey currentUserKey = Registry.CurrentUser)
            using (RegistryKey settingsKey = currentUserKey.OpenSubKey("Settings"))
            {
                foreach (var valueName in settingsKey.GetValueNames())
                {
                    var value = settingsKey.GetValue(valueName).ToString();
                    settings[valueName] = value;
                }
            }

            return settings;
        }
    }    
}
