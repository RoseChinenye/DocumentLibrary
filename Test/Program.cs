
using DocumentLibrary.FileIO;


namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
Start: try
            {
                Console.WriteLine("****************This App Writes to and Reads from a text and Json file!***************\n");
                Console.WriteLine("Enter 1, 2, 3, 4 or 5\n1: Write to Text File (FileName: TextAttributeFile)\n2: Read from the Text File \n3: Write to Json File (FileName: JsonAttributeFile) \n4: Read from the Json File \n5: Exit \n");

                var selection = Console.ReadLine();
                if (int.TryParse(selection, out int option))
                {

                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            TextFileOperation.WriteToText();
                            break;
                        case 2:
                            Console.Clear();
                            TextFileOperation.ReadFromText();
                            break;
                        case 3:
                            Console.Clear();
                            JsonFileOperation.WriteToJson();
                            break;
                        case 4:
                            Console.Clear();
                            JsonFileOperation.ReadFromJson();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                    Console.ReadLine();
                    Console.Clear();
                    goto Start;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }
    }
}