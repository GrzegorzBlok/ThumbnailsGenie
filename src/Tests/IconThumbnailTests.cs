using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ThumbnailsGenie;
using System.Drawing;

namespace Tests
{
    public class IconThumbnailTests
    {
        [Fact]
        public void GetThumbnailForImageReturnsProperIcon_Px32()
        {
            GetThumbnailForImageReturnsProperIcon_Px(Thumbnails.Size.Px32);
        }

        [Fact]
        public void GetThumbnailForImageReturnsProperIcon_Px512()
        {
            GetThumbnailForImageReturnsProperIcon_Px(Thumbnails.Size.Px512);
        }

        public void GetThumbnailForImageReturnsProperIcon_Px(Thumbnails.Size size)
        {
            var target = new IconThumbnail();

            // Act
            var pngIcon = target.GetThumbnailForMimeType("image/png", size);
            var jpegIcon = target.GetThumbnailForMimeType("image/jpeg", size);
            var bmpIcon = target.GetThumbnailForMimeType("image/bmp", size);
            var tiffIcon = target.GetThumbnailForMimeType("image/tiff", size);
            var gifIcon = target.GetThumbnailForMimeType("image/gif", size);
            var blankIcon = target.GetThumbnailForMimeType("blank", size);

            // Assert
            CheckImageIcon(blankIcon, (int)size);
            CheckImageIcon(pngIcon, (int)size);
            CheckImageIcon(jpegIcon, (int)size);
            CheckImageIcon(bmpIcon, (int)size);
            CheckImageIcon(tiffIcon, (int)size);
            CheckImageIcon(gifIcon, (int)size);
        }

        static void CheckImageIcon(System.Drawing.Bitmap icon, int size)
        {
            Assert.NotNull(icon);
            Assert.Equal(size, icon.Height);
            Assert.Equal(size, icon.Width);
        }
    }
}

