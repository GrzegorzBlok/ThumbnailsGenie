using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using ThumbnailsGenerator.Configuration;

namespace ThumbnailsGenerator
{
    internal class Icons
    {
        private static string IconsDirectory = "icons";
        private const string BLANK = "_blank";

        public Icons()
        {
            ThumbnailsConfigurationSection section = ConfigurationManager.GetSection("ThumbnailsGenerator") as ThumbnailsConfigurationSection;
            if(section != null)
            {
                IconsDirectory = section.IconsDirectory.value;
            }
        }

        Dictionary<Thumbnails.Size, Dictionary<string, byte[]>> IconsData
            = new Dictionary<Thumbnails.Size, Dictionary<string, byte[]>>(Enum.GetNames(typeof(Thumbnails.Size)).Length);

        private void LoadIcons(Thumbnails.Size size)
        {
            var iconsDirectory = Path.Combine(IconsDirectory, size.ToString());
            if(!Directory.Exists(iconsDirectory))
            {
                throw new DirectoryNotFoundException($"Icons directory {iconsDirectory} doesn't exist");
            }

            var iconsFiles = Directory.GetFiles(iconsDirectory, "*.png", SearchOption.TopDirectoryOnly);
            if(iconsFiles.Length < 2)
            {
                throw new FileNotFoundException($"Only {iconsFiles.Length} icons found in icons directory {iconsDirectory}");
            }

            var iconsFilesMapping = new Dictionary<string, byte[]>(iconsFiles.Length);
            foreach(var fileName in iconsFiles)
            {
                iconsFilesMapping[Path.GetFileNameWithoutExtension(fileName)] = File.ReadAllBytes(fileName);
            }

            // check correctness
            if(!iconsFilesMapping.ContainsKey(BLANK))
            {
                throw new FileNotFoundException($"No {BLANK} icon found in {iconsDirectory}");
            }
 
            IconsData[size] = iconsFilesMapping;
        }

        public byte[] GetIcon(string type, Thumbnails.Size size)
        {
            Dictionary<string, byte[]> iconsDictionary;
            if (!IconsData.TryGetValue(size, out iconsDictionary))
            {
                LoadIcons(size);
                iconsDictionary = IconsData[size];
            }

            byte[] icon;
            if(!iconsDictionary.TryGetValue(type, out icon))
            {
                return iconsDictionary[BLANK];
            }

            return icon;
        }
    }
}
