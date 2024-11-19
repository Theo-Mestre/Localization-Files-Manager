using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace LocalizationFilesManager
{
    public partial class MainWindow
    {
        // Json Utility Methods

        private void OnJsonFileOpened(string filePath)
        {
            gridData.Rows.Clear();

            string content = File.ReadAllText(filePath);
            JObject jObject = JObject.Parse(content);

            foreach (var entry in jObject)
            {
                string key = entry.Key;
                JObject values = (JObject)entry.Value;
                ObservableCollection<string> languages = [];
                string comment = "";

                foreach (var subKey in values)
                {
                    string subKeyName = subKey.Key;
                    gridData.Key.Languages.Add(subKeyName);
                }

                int i = 0;
                foreach (var subKey in values)
                {
                    string value = subKey.Value.ToString();

                    if (i == values.Count - 1)
                        comment = value;
                    else
                        languages.Add(value);

                    i++;
                }

                gridData.Rows.Add(
                    new RowData
                    {
                        Key = key,
                        Languages = languages,
                        Comments = comment
                    });
            }
        }

        private void OnJsonFileSaved(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string content = "{\n";
                ObservableCollection<string> keyLanguages = gridData.Key.Languages;
                ObservableCollection<RowData> rows = gridData.Rows;

                foreach (RowData rowData in rows)
                {
                    content += "\t\"" + rowData.Key + "\": {\n";

                    for (int i = 0; i < keyLanguages.Count; i++)
                    {
                        string languageKey = keyLanguages[i];
                        string value = rowData.Languages[i];

                        content += "\t\t\"" + languageKey + "\": \"" + value + "\",\n";
                    }

                    content += "\t\t\"Comments\": \"" + rowData.Comments + "\"\n";
                    content += "\t}";

                    if (rowData != rows[rows.Count - 1])
                        content += ",";

                    content += "\n";
                }

                content += "}";

                writer.Write(content);
                MessageBox.Show("JSON Saved:\n" + content);
            }
        }
    }
}
