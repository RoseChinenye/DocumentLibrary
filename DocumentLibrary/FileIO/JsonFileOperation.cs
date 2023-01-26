using System.IO;
using DocumentLibrary.Attributes;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace DocumentLibrary.FileIO
{
    
    public class JsonFileOperation
    {
        public class Documentation
        {
            public List<getDetails> DetailsOfAssembly { get; set; }
        }

        public class getDetails
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Input { get; set; }
            public string Output { get; set; }
        }


        public static void GetDocs()
        {


            var types = Assembly.GetExecutingAssembly().GetTypes();

            var DocAttribute = new Documentation()
            {
                DetailsOfAssembly = new List<getDetails>()
            };

            
            var typesByType = types.GroupBy(t => t.IsClass).ToDictionary(g => g.Key, g => g.ToList());

            var classTypes = typesByType[true];

            var otherTypes = typesByType[false];

            
            foreach (var type in classTypes)
            {
                var typeAttribute = (DocumentAttribute)type.GetCustomAttribute(typeof(DocumentAttribute));

                if (typeAttribute != null)
                {
                    DocAttribute.DetailsOfAssembly.Add(new getDetails()
                    {
                        Name = type.Name,

                        Description = typeAttribute.Description
                    });
                }

                
                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    var propertyAttribute = (DocumentAttribute)property.GetCustomAttribute(typeof(DocumentAttribute));

                    if (propertyAttribute != null)
                    {
                        DocAttribute.DetailsOfAssembly.Add(new getDetails()
                        {
                            Name = property.Name,

                            Description = propertyAttribute.Description
                        });
                    }
                }

                
                var constructors = type.GetConstructors();

                foreach (var constructor in constructors)
                {
                    var constructorAttribute = (DocumentAttribute)constructor.GetCustomAttribute(typeof(DocumentAttribute));

                    if (constructorAttribute != null)
                    {
                        DocAttribute.DetailsOfAssembly.Add(new getDetails()
                        {
                            Name = constructor.Name,

                            Description = constructorAttribute.Description
                        });
                    }
                }
                
                var methods = type.GetMethods();

                foreach (var method in methods)
                {
                    var methodAttribute = (DocumentAttribute)method.GetCustomAttribute(typeof(DocumentAttribute));

                    if (methodAttribute != null)
                    {
                        var input = string.Join(",", method.GetParameters().Select(x => x.ParameterType.Name + " " + x.Name));

                        var output = method.ReturnType.Name;

                        DocAttribute.DetailsOfAssembly.Add(new getDetails()
                        {
                            Name = method.Name,

                            Description = methodAttribute.Description,

                            Input = input,

                            Output = output
                        });
                    }
                }
            }

            
            foreach (var type in otherTypes)
            {
                var attribute = (DocumentAttribute)type.GetCustomAttribute(typeof(DocumentAttribute));

                if (attribute != null)
                {
                    DocAttribute.DetailsOfAssembly.Add(new getDetails()
                    {
                        Name = type.Name,

                        Description = attribute.Description
                    });
                }
            }

            
            WriteToJson(DocAttribute, "JsonAttributeFile.json");

        }
        public static void WriteToJson<T>(T objGraph, string filename)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,

                    WriteIndented = true,
                };

                string jsonText = JsonSerializer.Serialize(objGraph, options);
                File.WriteAllText("JsonAttributeFile.json", jsonText);

                Console.WriteLine("\nCreated a Json file named AttributeFile and wrote the output of GetDocs() to it...");
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
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var getDocuments = ReadAsJsonFormat<Documentation>(options, "JsonAttributeFile.json");

                
                foreach (var type in getDocuments.DetailsOfAssembly)
                {
                    Console.WriteLine($"Name: {type.Name}");

                    Console.WriteLine($"Description: {type.Description}");

                    if (!string.IsNullOrEmpty(type.Input))
                    {
                        Console.WriteLine($"Input: {type.Input}");
                    }

                    if (!string.IsNullOrEmpty(type.Output))
                    {
                        Console.WriteLine($"Output: {type.Output}");
                    }


                    Console.WriteLine();
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine("\nReading from the JSON file was unsuccessful: " + e.Message);
            }
            


            

            
        }
        public static T ReadAsJsonFormat<T>(JsonSerializerOptions options, string fileName) => JsonSerializer.Deserialize<T>(File.ReadAllText(fileName), options);

    }

}
    

