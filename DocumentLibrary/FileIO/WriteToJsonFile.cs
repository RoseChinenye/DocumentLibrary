
using System.IO;

namespace DocumentLibrary.FileIO
{
    public static class WriteToJsonFile
    {
        public static void GetJsonFile()
        {
            using (StreamWriter writer = new StreamWriter("AttributesFile.pdf"))
            {
                writer.WriteLine("bgedieguduef");
            }
            File.Delete("AttributesFile.pdf");
            }
        }
}
