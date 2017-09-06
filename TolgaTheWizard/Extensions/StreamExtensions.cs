using System.IO;

namespace TolgaTheWizard.Extensions
{

    public static class StreamExtensions
    {
        /// <summary>
        /// Convert string to stream
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Stream ToStream(this string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
