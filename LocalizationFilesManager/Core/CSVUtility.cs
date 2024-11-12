using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

                int nbline = 5;

                gridData.Rows.Clear();

                List<string> text = new List<string>();

                for (int i = 0; i < nbline; i++)
                {
                    text = csvLine.Split(';').ToList();
                     
                    gridData.Rows.Add(
                    new RowData
                    {
                        Key = text[0],
                        Languages = new ObservableCollection<string> { text[1], text[2], text[3] },
                        Comments = ""
                    });

                    csvLine = reader.ReadLine();
                }

               // MessageBox.Show("CSV Loaded:\n" + csvLine);
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
