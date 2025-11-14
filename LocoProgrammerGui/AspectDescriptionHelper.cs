using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocoProgrammer
{
    internal class AspectDescriptionHelper
    {
        private static string GetFilename(String DeviceName)
        {
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Build the folder path
            string folderPath = Path.Combine(myDocuments, "AspectNames");

            // Ensure the folder exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Build the file path with the variable value
            return Path.Combine(folderPath, $"AspDescr-{DeviceName}.txt");
        }

        public static void UpdateOrAddDescription(string Device, int id, string description)
        {
            string filePath = GetFilename(Device);
            var lines = new List<string>();

            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath).ToList();
            }

            bool updated = false;

            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split(';');
                if (parts.Length == 2 && int.TryParse(parts[0], out int existingId))
                {
                    if (existingId == id)
                    {
                        // Update description
                        lines[i] = $"{id};{description}";
                        updated = true;
                        break;
                    }
                }
            }

            if (!updated)
            {
                // Add new line
                lines.Add($"{id};{description}");
            }

            File.WriteAllLines(filePath, lines);
        }

        public static string GetDescriptionById(string Device, int index)
        {
            Console.WriteLine($"Index {index} for {Device}");
            string filePath = GetFilename(Device);

            if (!File.Exists(filePath))
                return "";

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(';');
                if (parts.Length == 2 && int.TryParse(parts[0], out int existingId))
                {
                    if (existingId == index)
                    {
                        return parts[1];
                    }
                }
            }

            return ""; // Not found
        }
    }
}
