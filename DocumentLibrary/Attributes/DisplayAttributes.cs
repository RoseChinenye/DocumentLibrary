using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DocumentLibrary.Attributes
{
    public static class DisplayAttributes
    {
        public static void GetDocs()
        {

                var assembly = Assembly.GetExecutingAssembly();

                Console.WriteLine(assembly);
                var types = assembly.GetTypes();


                foreach (Type type in types)
                {
                    var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);

                    if (attributes.Length > 0)
                    {
                        if (type.IsClass)
                        {
                            Console.WriteLine("Class: " + type.Name);
                            Console.WriteLine("\tDescription: " + ((DocumentAttribute)attributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);
                            Console.WriteLine();


                            foreach (ConstructorInfo constructor in type.GetConstructors())
                            {
                                var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
                                if (constructorAttributes.Length > 0)
                                {
                                    Console.WriteLine("Constructor: " + constructor.Name);
                                    Console.WriteLine("\tDescription: " + ((DocumentAttribute)constructorAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);
                                    Console.WriteLine("\tInput: " + ((DocumentAttribute)constructorAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Input);
                                    Console.WriteLine();
                                }
                            }

                            foreach (MethodInfo method in type.GetMethods())
                            {
                                var methodAttributes = method.GetCustomAttributes(typeof(DocumentAttribute), true);
                                if (methodAttributes.Length > 0)
                                {
                                    Console.WriteLine("Method: " + method.Name);
                                    Console.WriteLine("\tDescription: " + ((DocumentAttribute)methodAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);
                                    Console.WriteLine("\tInput: " + ((DocumentAttribute)methodAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Input);
                                    Console.WriteLine("\tOutput: " + ((DocumentAttribute)methodAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Output);
                                    Console.WriteLine();
                                }
                            }

                            foreach (PropertyInfo property in type.GetProperties())
                            {
                                var propertyAttributes = property.GetCustomAttributes(typeof(DocumentAttribute), true);
                                if (propertyAttributes.Length > 0)
                                {
                                    Console.WriteLine("Property: " + property.Name);
                                    Console.WriteLine("\tDescription: " + ((DocumentAttribute)propertyAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);
                                    Console.WriteLine("\tOutput: " + ((DocumentAttribute)propertyAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Output);
                                    Console.WriteLine();
                                }
                            }

                        }

                        if (type.IsEnum)
                        {
                            Console.WriteLine("Enum: " + type.Name);
                            //unboxing happens here: Converting an object to a value type.
                            Console.WriteLine("\tDescription: " + ((DocumentAttribute)attributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);

                            string[] names = type.GetEnumNames();
                            foreach (string name in names)
                            {
                                Console.WriteLine(name);

                            }
                            Console.WriteLine();
                        }

                    }
                }

        }
    }
}
