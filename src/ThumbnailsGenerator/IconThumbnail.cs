using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeTypes;

namespace ThumbnailsGenerator
{
    public class IconThumbnail
    {
        private Icons iconsStorage = new Icons();

        public byte[] GetThumbnailForMimeType(string mimeType, Thumbnails.Size pxSize = Thumbnails.Size.Px32)
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

        public byte[] GetThumbnailForExtension(string extension, Thumbnails.Size pxSize = Thumbnails.Size.Px32)
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
