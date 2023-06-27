using Xunit;
using ThumbnailsGenie;
using System.IO;
using System.Drawing;

namespace Tests
{
    public class ImageThumbnailTests
    {
        [Theory]
        [InlineData(Thumbnails.Size.Px512)]
        [InlineData(Thumbnails.Size.Px256)]
        [InlineData(Thumbnails.Size.Px128)]
        [InlineData(Thumbnails.Size.Px96)]
        [InlineData(Thumbnails.Size.Px64)]
        [InlineData(Thumbnails.Size.Px48)]
        [InlineData(Thumbnails.Size.Px32)]
        [InlineData(Thumbnails.Size.Px16)]
        public void GetThumbnailForImageReturnsProperIcon_Px(Thumbnails.Size size)
        {
            // Act
            var ms = new MemoryStream();
            using (var imageStream = new FileStream("wasp.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                new ImageThumbnail(imageStream, size).SaveToStream(ms);
            }

            // Assert
            var thumbnailImg = Image.FromStream(ms);
            Assert.Equal((int)size, thumbnailImg.Width);
            Assert.Equal((int)size, thumbnailImg.Height);
        }

    }
}
