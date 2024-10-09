#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Handlers
{
    internal class ImageHandler
    {
        /// <summary>
        /// Convert a byte array to an image.
        /// </summary>
        /// <param name="byte_arr"></param>
        /// <returns>The image representation of the byte array.</returns>
        public static Image? DecodeImage(byte[]? byte_arr)
        {
            if (byte_arr == null)
                return null;
            using (MemoryStream ms = new MemoryStream(byte_arr))
                return Image.FromStream(ms);
        }

        /// <summary>
        /// Convert an image to a byte array.
        /// </summary>
        /// <param name="image"></param>
        /// <returns>The resulting byte array.</returns>
        public static byte[]? EncodeImage(Image? image)
        {
            if (image == null)
                return null;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
