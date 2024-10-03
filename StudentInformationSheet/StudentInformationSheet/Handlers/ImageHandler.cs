#nullable enable
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
        /// <summary>
        /// Decode a Base64 encoded image.
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static Image? DecodeImage(string? base64)
        {
            if (string.IsNullOrWhiteSpace(base64)) return null;
            return Image.FromStream(
                new System.IO.MemoryStream(
                    Convert.FromBase64String(base64)
                )
            );
        }

        /// <summary>
        /// Encode an image to Base64.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string? EncodeImage(Image? image)
        {
            if (image == null) return null;
            using (var stream = new System.IO.MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
