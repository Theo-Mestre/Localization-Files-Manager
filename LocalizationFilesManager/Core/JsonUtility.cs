using System.IO;
using System.Windows;

namespace LocalizationFilesManager
{
    public partial class MainWindow
    {
        // Json Utility Methods

        private void OnJsonFileOpened(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                // Process JSON data here
                MessageBox.Show("JSON Loaded:\n" + content);
            }
        }

        private void OnJsonFileSaved(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string content = ""; // Process JSON data here
                writer.Write(content);
                MessageBox.Show("JSON Loaded:\n" + content);
            }
        }
    }
}
