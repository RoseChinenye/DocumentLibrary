using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DocumentLibrary.Attributes;

namespace DocumentLibrary.FileIO
{
    public static class WriteToTextFile
    {
        public static void GetTextFile()
        {
            Console.WriteLine();

            using (StreamWriter writer = new StreamWriter("AttributesFile.txt"))
            {

                var assembly = Assembly.GetExecutingAssembly();

                writer.WriteLine(assembly);
                var types = assembly.GetTypes();


                foreach (Type type in types)
                {
                    var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);

                    if (attributes.Length > 0)
                    {
                        if (type.IsClass)
                        {
                            writer.WriteLine("Class: " + type.Name);
                            writer.WriteLine("\tDescription: " + ((DocumentAttribute)attributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);
                            writer.WriteLine();


                            foreach (ConstructorInfo constructor in type.GetConstructors())
                            {
                                var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
                                if (constructorAttributes.Length > 0)
                                {
                                    writer.WriteLine("Constructor: " + constructor.Name);
                                    writer.WriteLine("\tDescription: " + ((DocumentAttribute)constructorAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);
                                    writer.WriteLine("\tInput: " + ((DocumentAttribute)constructorAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Input);
                                    writer.WriteLine();
                                }
                            }

                            foreach (MethodInfo method in type.GetMethods())
                            {
                                var methodAttributes = method.GetCustomAttributes(typeof(DocumentAttribute), true);
                                if (methodAttributes.Length > 0)
                                {
                                    writer.WriteLine("Method: " + method.Name);
                                    writer.WriteLine("\tDescription: " + ((DocumentAttribute)methodAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);
                                    writer.WriteLine("\tInput: " + ((DocumentAttribute)methodAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Input);
                                    writer.WriteLine("\tOutput: " + ((DocumentAttribute)methodAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Output);
                                    writer.WriteLine();
                                }
                            }

                            foreach (PropertyInfo property in type.GetProperties())
                            {
                                var propertyAttributes = property.GetCustomAttributes(typeof(DocumentAttribute), true);
                                if (propertyAttributes.Length > 0)
                                {
                                    writer.WriteLine("Property: " + property.Name);
                                    writer.WriteLine("\tDescription: " + ((DocumentAttribute)propertyAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);
                                    writer.WriteLine("\tOutput: " + ((DocumentAttribute)propertyAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Output);
                                    writer.WriteLine();
                                }
                            }

                        }

                        if (type.IsEnum)
                        {
                            writer.WriteLine("Enum: " + type.Name);
                            writer.WriteLine("\tDescription: " + ((DocumentAttribute)attributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);

                            string[] names = type.GetEnumNames();
                            foreach (string name in names)
                            {
                                writer.WriteLine(name);

                            }
                            writer.WriteLine();
                        }

                    }
                }

            }
            Console.WriteLine("Created a text file named AttributeFile and wrote the output of GetDocs() to it...");
            Console.ReadLine();
            //File.Delete("AttributesFile.txt");
        }
    }
}
