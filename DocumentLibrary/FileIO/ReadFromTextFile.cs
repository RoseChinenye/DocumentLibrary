
using System.IO;
using System;

namespace DocumentLibrary.FileIO
{
    public static class ReadFromTextFile
    {
        public static void ReadTextFile()
        {
            Console.WriteLine("Here are the outputs of the text file named AttributesFile:\n");
            using (StreamReader sr = new StreamReader("AttributesFile.txt"))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
            Console.ReadLine();
        }
    }
}
