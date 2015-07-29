using System;
using System.Drawing;
using System.IO;

namespace RESTComponent.Images.Decoder
{
    public class ImagesDecoder : IImagesDecoder
    {
        public Bitmap Decode(string encodedPicture)
        {
            try
            {
                var bytes = Convert.FromBase64String(encodedPicture);

                Bitmap decoded;
                using (var stream = new MemoryStream(bytes))
                {
                    decoded = new Bitmap(stream);
                }
                return decoded;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
