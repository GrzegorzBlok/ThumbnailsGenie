using System.Configuration;

namespace ThumbnailsGenie.Configuration
{
    public class ThumbnailsConfigurationSection : ConfigurationSection
    {
        private ThumbnailsConfigurationSection() { }

        [ConfigurationProperty("IconsDirectory")]
        public ConfigurationDirectory IconsDirectory
        {
            get { return this["IconsDirectory"] as ConfigurationDirectory; }
            set { this["IconsDirectory"] = value; }
        }
    }

    public class ConfigurationDirectory : ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = "icons")]
        public string value
        {
            get { return this["value"] as string; }
            set { this["value"] = value; }
        }
    }
}
