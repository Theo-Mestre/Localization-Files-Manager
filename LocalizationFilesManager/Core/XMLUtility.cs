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

                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.LoadXml(content);

                //XmlNode languagesNode = xmlDoc.SelectSingleNode("/Languages");

                //foreach (XmlNode idNode in languagesNode.SelectNodes("id"))
                //{

                //}
                MessageBox.Show("XML Loaded:\n" + content);
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
