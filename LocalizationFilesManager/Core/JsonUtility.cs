using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

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
                gridData.Rows.Clear();

                /*gridData.Rows.Add(
                    new RowData
                    {
                        Key = key,
                        Languages = values,
                        Comments = comment
                    });*/

                string[] lines = content.Split('\n');
                foreach (string line in lines)
                {
                    /* TODO LIST:
                     * 
                     * remove all '"' in the line
                     * remove the ':' in the line
                     * 
                     * store key
                     * store values
                     * store comment
                     * 
                     * add to Rows
                     * 
                     */

                    MessageBox.Show("Line:\n" + line);
                }

                MessageBox.Show("JSON Loaded:\n" + content);
            }
        }

        private void OnJsonFileSaved(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string content = "";
                List<string> keys = [];
                List<ObservableCollection<string>> values = [];
                List<string> comments = [];

                foreach (RowData rowData in gridData.Rows)
                {
                    content += "\"" + rowData.Key + "\":\n";
                    foreach (string value in rowData.Languages)
                        content += "\"" + value + "\"";
                }

                writer.Write(content);
                MessageBox.Show("JSON Saved:\n" + content);
            }
        }
    }
}
