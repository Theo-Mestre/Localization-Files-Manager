using System.IO;
using System.Windows;

namespace LocalizationFilesManager
{
    public partial class MainWindow
    {
        private void OnCppFileSaved(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string cppContent = "";

                cppContent +=
                    "#pragma once\r\n" +
                    "#include <unordered_map>\r\n" +
                    "#include <string>\r\n" +
                    "class Data\r\n" +
                    "{\r\n" +
                    "\tpublic:\r\n" +
                    "\tstatic void Init(const std::string& _language)\r\n" +
                    "\t{\r\n" +
                    "{IfContent}\r\n" +
                    "\t}\n\n" +
                    "\tstatic const std::string& GetText(const std::string& _key)\r\n" +
                    "\t{\r\n        " +
                    "\t\tif (data.find(_key) != data.end())\r\n" +
                    "\t\t{\r\n" +
                    "\t\t\treturn data[_key];\r\n" +
                    "\t\t}\r\n" +
                    "\t\t\treturn _key;\r\n" +
                    "\t\t}\r\n\r\n" +
                    "\tprivate:\r\n" +
                    "\tinline static std::unordered_map<std::string, std::string> data;\r\n" +
                    "};\r\n";

                string ifBranch = "" +
                    "if (_language == \"{0}\")\r\n" +
                    "{\r\n" +
                    "{Add}" +
                    "}\r\n";

                string addContent = "\t\t\t\tdata[\"{Key}\"] = \"{Value}\";\r\n";

                string switchContent = "";
                for (int i = 0; i < gridData.Key.Languages.Count; i++)
                {
                    string keyValues = "";
                    switchContent += ifBranch.Replace("{0}", gridData.Key.Languages[i]);

                    for (int j = 0; j < gridData.Rows.Count; j++)
                    {
                        var row = gridData.Rows[j];
                        keyValues += addContent
                            .Replace("{Key}", row.Key)
                            .Replace("{Value}", row.Languages[i]);

                    }
                    switchContent = switchContent.Replace("{Add}", keyValues);
                }

                cppContent = cppContent.Replace("{IfContent}", switchContent);

                writer.Write(cppContent);
                MessageBox.Show($"Data exported as .h to: {filePath}");
            }
        }
    }
}