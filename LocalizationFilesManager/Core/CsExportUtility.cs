using System.IO;
using System.Windows;

namespace LocalizationFilesManager
{
    public partial class MainWindow
    {
        private void OnCsFileSaved(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string csContent = "";

                csContent +=
                    "using System.Collections.Generic;\r\n\n" +
                    "class Data\r\n" +
                    "{\r\n" +
                    "\tpublic static void Init(string Language)\r\n" +
                    "\t{\r\n" +
                    "\t\tswitch (Language)\r\n" +
                    "\t\t{\r\n" +
                    "{SwitchContent}\r\n" +
                    "\t\t\t\tdefault:\r\n" +
                    "\t\t\t\t\tbreak;\r\n" +
                    "\t\t\t}\r\n" +
                    "\t}\n\n" +
                    "\tpublic static string GetText(string key)\r\n" +
                    "\t{\r\n        " +
                    "\t\tif (data.ContainsKey(key))\r\n" +
                    "\t\t{\r\n" +
                    "\t\t\treturn data[key];\r\n" +
                    "\t\t}\r\n" +
                    "\t\t\treturn key;\r\n" +
                    "\t\t}\r\n\r\n" +
                    "\tprivate static Dictionary<string, string> data = new Dictionary<string, string>();\r\n" +
                    "}\r\n";

                string switchBranch = "\r\n" +
                    "\t\t\tcase \"{0}\":\r\n" +
                    "\t\t\t{Add}" +
                    "\t\t\t\tbreak;\r\n";

                string addContent = "\t\t\t\tdata.Add(\"{Key}\", \"{Value}\");\r\n";

                string switchContent = "";
                for (int i = 0; i < gridData.Key.Languages.Count; i++)
                {
                    string keyValues = "";
                    switchContent += switchBranch.Replace("{0}", gridData.Key.Languages[i]);

                    for (int j = 0; j < gridData.Rows.Count; j++)
                    {
                        var row = gridData.Rows[j];
                        keyValues += addContent
                            .Replace("{Key}", row.Key)
                            .Replace("{Value}", row.Languages[i]);
                    }
                    switchContent = switchContent.Replace("{Add}", keyValues);
                }

                csContent = csContent.Replace("{SwitchContent}", switchContent);

                writer.Write(csContent);
                MessageBox.Show($"Data exported as Cs to: {filePath}");
            }
        }
    }
}
