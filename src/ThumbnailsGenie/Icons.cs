using System;
using System.Collections.Generic;
using ThumbnailsGenie.Resources;

namespace ThumbnailsGenie
{
    internal class Icons
    {
        private const string BLANK = "_blank";

        public Icons()
        {
            IconsData[Thumbnails.Size.Px16] = new global::System.Resources.ResourceManager("ThumbnailsGenie.Resources.Px16", typeof(Px16).Assembly);
            IconsData[Thumbnails.Size.Px32] = new global::System.Resources.ResourceManager("ThumbnailsGenie.Resources.Px32", typeof(Px32).Assembly);
            IconsData[Thumbnails.Size.Px48] = new global::System.Resources.ResourceManager("ThumbnailsGenie.Resources.Px48", typeof(Px48).Assembly);
            IconsData[Thumbnails.Size.Px64] = new global::System.Resources.ResourceManager("ThumbnailsGenie.Resources.Px64", typeof(Px64).Assembly);
            IconsData[Thumbnails.Size.Px96] = new global::System.Resources.ResourceManager("ThumbnailsGenie.Resources.Px96", typeof(Px96).Assembly);
            IconsData[Thumbnails.Size.Px128] = new global::System.Resources.ResourceManager("ThumbnailsGenie.Resources.Px128", typeof(Px128).Assembly);
            IconsData[Thumbnails.Size.Px256] = new global::System.Resources.ResourceManager("ThumbnailsGenie.Resources.Px256", typeof(Px256).Assembly);
            IconsData[Thumbnails.Size.Px512] = new global::System.Resources.ResourceManager("ThumbnailsGenie.Resources.Px512", typeof(Px512).Assembly);
        }

        Dictionary<Thumbnails.Size, System.Resources.ResourceManager> IconsData = new Dictionary<Thumbnails.Size, System.Resources.ResourceManager>(Enum.GetNames(typeof(Thumbnails.Size)).Length);

        public byte[] GetIcon(string type, Thumbnails.Size size)
        {
            var icon = IconsData[size].GetObject(type) as byte[];

            if (icon == null)
            {
                return IconsData[size].GetObject(BLANK) as byte[];
            }

            return icon;
        }
    }
}
