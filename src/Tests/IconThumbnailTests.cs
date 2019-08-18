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
        public void GetThumbnailMimeTypeReturnsProperIcon_Px(Thumbnails.Size size)
        {
            var target = new IconThumbnail();
            var blankIcon = target.GetThumbnailForMimeType("blank", size);

            // Act
            var pngIcon = target.GetThumbnailForMimeType("image/png", size);
            var jpegIcon = target.GetThumbnailForMimeType("image/jpeg", size);
            var bmpIcon = target.GetThumbnailForMimeType("image/bmp", size);
            var tiffIcon = target.GetThumbnailForMimeType("image/tiff", size);
            var gifIcon = target.GetThumbnailForMimeType("image/gif", size);
            var xlsxIcon = target.GetThumbnailForMimeType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", size);
            var xlsmIcon = target.GetThumbnailForMimeType("application/vnd.ms-excel.sheet.macroEnabled.12", size);
            var csvIcon = target.GetThumbnailForMimeType("text/csv", size);
            var apkIcon = target.GetThumbnailForMimeType("application/vnd.android.package-archive", size);

            // Assert
            CheckImageIcon(pngIcon, (int)size, blankIcon);
            CheckImageIcon(jpegIcon, (int)size, blankIcon);
            CheckImageIcon(bmpIcon, (int)size, blankIcon);
            CheckImageIcon(tiffIcon, (int)size, blankIcon);
            CheckImageIcon(gifIcon, (int)size, blankIcon);
            CheckImageIcon(xlsxIcon, (int)size, blankIcon);
            CheckImageIcon(xlsmIcon, (int)size, blankIcon);
            CheckImageIcon(csvIcon, (int)size, blankIcon);
            CheckImageIcon(apkIcon, (int)size, blankIcon);
        }

        [Theory]
        [InlineData(Thumbnails.Size.Px512)]
        [InlineData(Thumbnails.Size.Px48)]
        [InlineData(Thumbnails.Size.Px32)]
        [InlineData(Thumbnails.Size.Px16)]
        public void GetThumbnailMimeTypeReturnsBlankIconForUnknownType(Thumbnails.Size size)
        {
            var target = new IconThumbnail();
            var blankIcon = target.GetThumbnailForMimeType("blank", size);

            // Act
            var icon = target.GetThumbnailForMimeType("noppe/popnee", size);

            // Assert
            Assert.NotNull(icon);
            var ms = new System.IO.MemoryStream(icon);
            var img = Image.FromStream(ms, true, true);
            Assert.Equal((int)size, img.Height);
            Assert.Equal((int)size, img.Width);
            Assert.Equal(blankIcon, icon);
        }

        static void CheckImageIcon(byte[] icon, int size, byte[] blankIcon)
        {
            Assert.NotNull(icon);
            var ms = new System.IO.MemoryStream(icon);
            var img = Image.FromStream(ms, true, true);
            Assert.Equal(size, img.Height);
            Assert.Equal(size, img.Width);
            Assert.NotEqual(blankIcon, icon);
        }
    }
}

