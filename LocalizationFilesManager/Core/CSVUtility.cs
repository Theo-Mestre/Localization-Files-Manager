using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace LocalizationFilesManager
{
    public partial class MainWindow
    {
        // CSV Utility Methods
        
        private void OnCSVFileOpened(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
               // string content = reader.ReadToEnd();

                // Process CSV content here
                string csvLine = reader.ReadLine();

                var grid = GetDataGrid();

                gridData.Rows.Clear();

                string[] text = new string[3];

                if(csvLine == ";")
                {

                }

                gridData.Rows.Add(
                new RowData
                {
                    Key = csvLine,
                    Languages = new ObservableCollection<string> { "Value4", "Value5", "Value6" },
                    Comments = "Comments2"
                });

                MessageBox.Show("CSV Loaded:\n" + csvLine);
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
