using System.IO;
using DocumentLibrary.Attributes;
using System;
using System.Text.Json;

namespace DocumentLibrary.FileIO
{
    
    public class JsonFileOperation
    {

        
        public static void WriteToJson()
        {
            var DocAttribute = DisplayAttributes.GetDocs();

            try
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                    WriteIndented = true
                };

                string jsonText = JsonSerializer.Serialize(DocAttribute, options);
                File.WriteAllText("JsonAttributeFile.json", jsonText);

                Console.WriteLine("\nCreated a text file named AttributeFile and wrote the output of GetDocs() to it...");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nWriting to the JSON file was unsuccessful: " + e.Message);
            }
        }

        public static void ReadFromJson()
        {
            try
            {
                string jsonFile = File.ReadAllText("JsonAttributeFile.json");

                var getDocuments = JsonSerializer.Deserialize<string>(jsonFile);
                Console.WriteLine(getDocuments);

            }
            catch (Exception e)
            {
                Console.WriteLine("\nReading from the JSON file was unsuccessful: " + e.Message);
            }
        }

    }
    
}
    

