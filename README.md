# ThumbnailsGenie - C# thumbnails/icons library

ThumbnailsGenie is a library that generates thumbnails from images and several other file types (e.g. pdf, doc, xls). Images are resized and other file types are given proper, nice looking icon.

File icons are embedded into assembly so the library is suited for the server usage. It does not use any windows explorer API.

## Install
Add To project via NuGet:  
1. Right click on a project and click 'Manage NuGet Packages'.  
2. Search for 'ThumbnailsGenie' and click 'Install'.  

## Examples

### Get icon for mime type

```csharp
using ThumbnailsGenie;

...

var icons = new IconThumbnail();

var pngIcon = icons.GetThumbnailForMimeType("image/png", Thumbnails.Size.Px512);
var jpegIcon = icons.GetThumbnailForMimeType("image/jpeg", Thumbnails.Size.Px48);
var bmpIcon = icons.GetThumbnailForMimeType("image/bmp", Thumbnails.Size.Px32);
var tiffIcon = icons.GetThumbnailForMimeType("image/tiff", Thumbnails.Size.Px16);
var gifIcon = icons.GetThumbnailForMimeType("image/gif");
var blankIcon = icons.GetThumbnailForMimeType("blank");
```

### Get icon for extension

```csharp
using ThumbnailsGenie;

...

var icons = new IconThumbnail();

var pdfIcon = icons.GetThumbnailForExtension("pdf", Thumbnails.Size.Px512);
var docIcon = icons.GetThumbnailForMimeType("doc");
var docIcon = icons.GetThumbnailForMimeType("exe");
var javaIcon = icons.GetThumbnailForMimeType("java");
```

### Get image thumbnail

```csharp
using ThumbnailsGenie;

...
var ms = new MemoryStream();

using (var imageStream = new FileStream("pic.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
{
  new ImageThumbnail(, Thumbnails.Size.Px512).SaveToStream(ms);
}

```
