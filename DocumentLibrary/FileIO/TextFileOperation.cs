using System;
using System.IO;
using DocumentLibrary.Attributes;

namespace DocumentLibrary.FileIO
{
    public class TextFileOperation
    {
        public static void WriteToText()
        {
            var DocAttribute = DisplayAttributes.GetDocs();

            try
            {
                File.WriteAllText("TextAttributeFile.txt", DocAttribute);

                Console.WriteLine("\nCreated a text file named AttributeFile and wrote the output of GetDocs() to it...");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nWriting to the Text file was successful: " + e.Message);
            }
        }

        public static void ReadFromText()
        {
            try
            {
                var DocAttribute = File.ReadAllText("TextAttributeFile.txt");

                Console.WriteLine(DocAttribute);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nWriting to the Text file was unsuccessful: " + e.Message);
            }
        }
    }
}
