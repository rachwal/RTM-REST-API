using System.Drawing;

namespace RESTComponent.Images.Decoder
{
    public interface IImagesDecoder
    {
        Bitmap Decode(string encodedPicture);
    }
}