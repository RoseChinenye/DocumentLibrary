using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DocumentLibrary.Attributes;

namespace DocumentLibrary.FileIO
{
    public class TextFileOperation
    {
        public static void WriteToText()
        {
            
            var getDocument = DisplayAttributes.GetDocs();

            try
            {
                File.WriteAllText("AttributeFile.txt", getDocument);

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
                var txtText = File.ReadAllText("AttributeFile.txt");

                Console.WriteLine(txtText);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nWriting to the Text file was unsuccessful: " + e.Message);
            }
        }
    }
}
