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
        public static byte[] GetThumbnail(string mimeType, Thumbnails.Size pxSize = Thumbnails.Size.Px32)
        {
            try
            {
                var extension = MimeTypeMap.GetExtension(mimeType);
 
                return Icons.GetIcon(extension, pxSize);
            }
            catch (Exception)
            {
                return Icons.GetIcon("_blank", pxSize);
            }    
        }
    }
}
