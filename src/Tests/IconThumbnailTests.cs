using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ThumbnailsGenerator;
using System.Drawing;

namespace Tests
{
    public class IconThumbnailTests
    {
        [Fact]
        public void GetThumbnailForImageReturnsProperIcon()
        {
            var target = new IconThumbnail();

            // Act
            byte[] pngIcon = target.GetThumbnailForMimeType("image/png");
            byte[] jpegIcon = target.GetThumbnailForMimeType("image/jpeg");
            byte[] bmpIcon = target.GetThumbnailForMimeType("image/bmp");
            byte[] tiffIcon = target.GetThumbnailForMimeType("image/tiff");
            byte[] gifIcon = target.GetThumbnailForMimeType("image/gif");
            byte[] blankIcon = target.GetThumbnailForMimeType("blank");

            // Assert
            CheckImageIcon(blankIcon);
            CheckImageIcon(pngIcon);
            CheckImageIcon(jpegIcon);
            CheckImageIcon(bmpIcon);
            CheckImageIcon(tiffIcon);
            CheckImageIcon(gifIcon);
        }

        static void CheckImageIcon(byte[] icon)
        {
            Assert.NotNull(icon);
            var ms = new System.IO.MemoryStream(icon);
            var img = Image.FromStream(ms, true, true);
        }
    }
}

