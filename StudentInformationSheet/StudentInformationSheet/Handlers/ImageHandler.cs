using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSheet.Handlers
{
    internal class ImageHandler
    {
        public static Image DecodeImage(string base64)
        {
            return Image.FromStream(
                new System.IO.MemoryStream(
                    Convert.FromBase64String(base64)
                )
            );
        }

        public static string EncodeImage(Image image)
        {
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
