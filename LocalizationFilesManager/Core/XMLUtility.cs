using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

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
                gridData.Rows.Clear();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(content);

                XmlNode languagesNode = xmlDoc.SelectSingleNode("/Languages");

                if (languagesNode != null)
                {
                    XmlNodeList idNodes = languagesNode.SelectNodes("id");
                    for (int i = 0; i < idNodes.Count; i++)
                    {
                        XmlNode idNode = idNodes[i];
                        var row = new RowData();

                        if (idNode.Attributes["value"] != null)
                        {
                            row.Key = idNode.Attributes["value"].Value;
                        }
                        else
                        {
                            row.Key = string.Empty;
                        }

                        var translations = new ObservableCollection<string>();
                        for (int j = 0; j < gridData.Key.Languages.Count; j++)
                        {
                            string lang = gridData.Key.Languages[j];
                            XmlNode translationNode = idNode.SelectSingleNode(lang);

                            if (translationNode != null)
                            {
                                translations.Add(translationNode.InnerText);
                            }
                            else
                            {
                                translations.Add(string.Empty);
                            }
                        }

                        row.Languages = translations;

                        gridData.Rows.Add(row);
                    }
                    MessageBox.Show("XML Loaded:\n" + content);
                }

            }
        }

        private void OnXMLFileSaved(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                //string content = ""; // Process XML data here
                //writer.Write(content);
                XmlWriter xmlWriter = new XmlTextWriter(writer);
                XmlWriter.Create(xmlWriter);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Languages");

                foreach (var row in gridData.Rows)
                {
                    xmlWriter.WriteStartElement("id");
                    xmlWriter.WriteAttributeString("value", row.Key);

                    for (int i = 0; i < gridData.Key.Languages.Count; i++)
                    {
                        string language = gridData.Key.Languages[i];
                        string translation = row.Languages[i];
                        xmlWriter.WriteElementString(language, translation);
                    }

                    xmlWriter.WriteElementString("Comments", row.Comments);

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                MessageBox.Show("XML Loaded:\n" + xmlWriter);
            }
        }
    }
}
