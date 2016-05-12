using System;
using MimeTypes;

namespace ThumbnailsGenie
{
    public class IconThumbnail
    {
        private readonly Icons iconsStorage = new Icons();

        public System.Drawing.Bitmap GetThumbnailForMimeType(string mimeType, Thumbnails.Size pxSize = Thumbnails.Size.Px32)
        {
            try
            {
                var extension = MimeTypeMap.GetExtension(mimeType);
 
                return iconsStorage.GetIcon(extension, pxSize);
            }
            catch (Exception)
            {
                return iconsStorage.GetIcon("_blank", pxSize);
            }    
        }

        public System.Drawing.Bitmap GetThumbnailForExtension(string extension, Thumbnails.Size pxSize = Thumbnails.Size.Px32)
        {
            try
            {
                return iconsStorage.GetIcon(extension, pxSize);
            }
            catch (Exception)
            {
                return iconsStorage.GetIcon("_blank", pxSize);
            }
        }
    }
}
