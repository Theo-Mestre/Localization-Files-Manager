using System;
using System.Collections.Generic;
using System.IO;

namespace LocalizationFilesManager
{
    internal class LocalizationFilesExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a file name: ");
            string filePath = Console.In.ReadLine();

            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("File path is invalid.");
                return;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            string extension = Path.GetExtension(filePath);

            Dictionary<string, string> localizationData = new Dictionary<string, string>();
            switch (extension)
            {
                case ".csv":
                    // localizationData = OnCSVFileOpened(filePath, extension);
                    Console.WriteLine("This is a resx file.");
                    break;
                case ".json":
                    // localizationData = OnJsonFileOpened(filePath, extension);
                    Console.WriteLine("This is a json file.");
                    break;
                case ".xml":
                    // localizationData = OnXMLFileOpened(filePath, extension);
                    Console.WriteLine("This is a json file.");
                    break;
                default:
                    Console.WriteLine("This is an unknown file.");
                    break;
            }

            foreach (var item in localizationData)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }
    }
}
