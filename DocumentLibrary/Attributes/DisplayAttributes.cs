using System;
using System.Linq;
using System.Reflection;

namespace DocumentLibrary.Attributes
{
    public class DisplayAttributes
    {
        
        public static string GetDocs()
        {
            var output = "";

                var assembly = Assembly.GetExecutingAssembly();

                output += assembly;
                var types = assembly.GetTypes();


                foreach (Type type in types)
                {
                    var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);

                    if (attributes.Length > 0)
                    {
                        if (type.IsClass)
                        {
                            output += "Class: " + type.Name + "\n";
                            output += "\tDescription: " +((DocumentAttribute)attributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description + "\n\n";
                            


                            foreach (ConstructorInfo constructor in type.GetConstructors())
                            {
                                var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
                                if (constructorAttributes.Length > 0)
                                {
                                    output += "Constructor: " + constructor.Name + "\n" ;
                                    output += "\tDescription: " +((DocumentAttribute)constructorAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description + "\n";
                                    output += "\tInput: " +((DocumentAttribute)constructorAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Input + "\n\n";
                                    
                            }
                            }

                            foreach (MethodInfo method in type.GetMethods())
                            {
                                var methodAttributes = method.GetCustomAttributes(typeof(DocumentAttribute), true);
                                if (methodAttributes.Length > 0)
                                {
                                    output += "Method: " + method.Name + "\n" ;
                                    output += "\tDescription: " +((DocumentAttribute)methodAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description + "\n";
                                    output += "\tInput: " +((DocumentAttribute)methodAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Input + "\n";
                                    output += "\tOutput: " +((DocumentAttribute)methodAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Output + "\n\n";
                                    
                                }
                            }

                            foreach (PropertyInfo property in type.GetProperties())
                            {
                                var propertyAttributes = property.GetCustomAttributes(typeof(DocumentAttribute), true);
                                if (propertyAttributes.Length > 0)
                                {
                                    output += "Property: " + property.Name + "\n";
                                    output += "\tDescription: " +((DocumentAttribute)propertyAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description + "\n";
                                    output += "\tOutput: " +((DocumentAttribute)propertyAttributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Output + "\n\n";
                                    
                                }
                            }

                        }

                        if (type.IsEnum)
                        {
                            output += "\n\n" + "Enum: " + type.Name + "\n";
                            //unboxing happens here: Converting an object to a value type.
                            output += "\tDescription: " +((DocumentAttribute)attributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description + "\n";

                            string[] names = type.GetEnumNames();
                            foreach (string name in names)
                            {
                                output += "\t" + name + "\n";

                            }
                        }

                    }
                }
            return output;
        }
    }
}
