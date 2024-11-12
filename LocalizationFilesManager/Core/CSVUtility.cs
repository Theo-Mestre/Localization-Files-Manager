using System.IO;
using System.Windows;

namespace LocalizationFilesManager
{
    public partial class MainWindow
    {
        // CSV Utility Methods
        
        private void OnCSVFileOpened(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                // Process CSV content here

                gridData.Rows.Clear();

                MessageBox.Show("CSV Loaded:\n" + content);
            }
        }

        private void OnCSVFileSaved(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string csvContent = ""; // Sampled CSV content
                writer.Write(csvContent);
                MessageBox.Show($"Data exported as CSV to: {filePath}");
            }
        }
    }
}
