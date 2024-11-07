using System.IO;
using System.Windows;

namespace LocalizationFilesManager
{
    public partial class MainWindow
    {
        // XML Utility Methods

        private void OnXMLFileOpened(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                // Process XML data here
                MessageBox.Show("XML Loaded:\n" + content);
            }
        }

        private void OnXMLFileSaved(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string content = ""; // Process XML data here
                writer.Write(content);
                MessageBox.Show("XML Loaded:\n" + content);
            }
        }
    }
}
