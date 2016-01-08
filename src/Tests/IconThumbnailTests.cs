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
            // Act
            byte[] pngIcon = IconThumbnail.GetThumbnail("image/png");
            byte[] jpegIcon = IconThumbnail.GetThumbnail("image/jpeg");
            byte[] bmpIcon = IconThumbnail.GetThumbnail("image/bmp");
            byte[] tiffIcon = IconThumbnail.GetThumbnail("image/tiff");
            //byte[] epsIcon = IconThumbnail.GetThumbnail("image/eps");
            //byte[] tgaIcon = IconThumbnail.GetThumbnail("image/tga");
            byte[] gifIcon = IconThumbnail.GetThumbnail("image/gif");
            byte[] blankIcon = IconThumbnail.GetThumbnail("blank");

            // Assert
            CheckImageIcon(blankIcon);
            CheckImageIcon(pngIcon);
            CheckImageIcon(jpegIcon);
            CheckImageIcon(bmpIcon);
            CheckImageIcon(tiffIcon);
            //CheckImageIcon(epsIcon);
            //CheckImageIcon(tgaIcon);
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

