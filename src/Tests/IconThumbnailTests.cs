using Xunit;
using ThumbnailsGenie;
using System.Drawing;

namespace Tests
{
    public class IconThumbnailTests
    {
        [Theory]
        [InlineData(Thumbnails.Size.Px512)]
        [InlineData(Thumbnails.Size.Px48)]
        [InlineData(Thumbnails.Size.Px32)]
        [InlineData(Thumbnails.Size.Px16)]
        public void GetThumbnailForImageReturnsProperIcon_Px(Thumbnails.Size size)
        {
            var target = new IconThumbnail();

            // Act
            var blankIcon = target.GetThumbnailForMimeType("blank", size);
            var pngIcon = target.GetThumbnailForMimeType("image/png", size);
            var jpegIcon = target.GetThumbnailForMimeType("image/jpeg", size);
            var bmpIcon = target.GetThumbnailForMimeType("image/bmp", size);
            var tiffIcon = target.GetThumbnailForMimeType("image/tiff", size);
            var gifIcon = target.GetThumbnailForMimeType("image/gif", size);
            var xlsxIcon = target.GetThumbnailForMimeType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", size);
            var xlsmIcon = target.GetThumbnailForMimeType("application/vnd.ms-excel.sheet.macroEnabled.12", size);

            // Assert
            CheckImageIcon(blankIcon, (int)size);
            CheckImageIcon(pngIcon, (int)size);
            CheckImageIcon(jpegIcon, (int)size);
            CheckImageIcon(bmpIcon, (int)size);
            CheckImageIcon(tiffIcon, (int)size);
            CheckImageIcon(gifIcon, (int)size);
            CheckImageIcon(xlsxIcon, (int)size);
            CheckImageIcon(xlsmIcon, (int)size);
        }

        static void CheckImageIcon(byte[] icon, int size)
        {
            Assert.NotNull(icon);
            var ms = new System.IO.MemoryStream(icon);
            var img = Image.FromStream(ms, true, true);
            Assert.Equal(size, img.Height);
            Assert.Equal(size, img.Width);
        }
    }
}

