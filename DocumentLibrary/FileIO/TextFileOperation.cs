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
                using (StreamWriter writer = new StreamWriter("TextAttributeFile.txt"))
                {
                    writer.Write(DocAttribute);
                }
                
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
                using (StreamReader reader = File.OpenText("TextAttributeFile.txt"))
                {
                    string input = null;

                    while ((input = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(input);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nWriting to the Text file was unsuccessful: " + e.Message);
            }
        }
    }
}
