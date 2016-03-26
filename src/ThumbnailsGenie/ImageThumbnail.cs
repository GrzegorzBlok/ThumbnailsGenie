using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ThumbnailsGenie
{
    public class ImageThumbnail
    {
        public ImageThumbnail(Stream image, Thumbnails.Size thumbnailMaxPxSize = Thumbnails.Size.Px32)
        {
            ImgThumbnail = GenerateThumbnail(Image.FromStream(image), thumbnailMaxPxSize);
        }

        protected Image ImgThumbnail { get; set; }

        public void SaveToStream(Stream stream)
        {
            ImgThumbnail.Save(stream, ImageFormat.Jpeg);
        }

        protected static Image GenerateThumbnail(Image img, Thumbnails.Size maxPxSize)
        {
            Size thumbnailSize = GetThumbnailSize(img, Thumbnails.Size.Px32);
            return img.GetThumbnailImage(thumbnailSize.Width,
                thumbnailSize.Height, null, IntPtr.Zero);
        }

        protected static Size GetThumbnailSize(Image original, Thumbnails.Size maxPxSize)
        {
            double factor;
            if (original.Width > original.Height)
            {
                factor = (double)maxPxSize / original.Width;
            }
            else
            {
                factor = (double)maxPxSize / original.Height;
            }

            return new Size((int)(original.Width * factor), (int)(original.Height * factor));
        }
    }
}
