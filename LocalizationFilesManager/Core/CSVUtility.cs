using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;

namespace LocalizationFilesManager
{
    public partial class MainWindow
    {
        // CSV Utility Methods

        public Dictionary<string, string> GetLanguage(string language, string filePath)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            List<string> languageText = new List<string>();
            int sizeLanguageText;

            List<string> text = new List<string>();

            StreamReader reader = new StreamReader(filePath);
            string csvLine;

            int nbLanguage = 0;
            int nbline = 0;

            csvLine = reader.ReadLine();
            languageText = csvLine.Split(';').ToList();
            sizeLanguageText = languageText.Count;

            // initialisation du nombre de langue existant dans le fichier
            for (int i = sizeLanguageText - 1; i >= 0; i--)
            {
                if (languageText[i] != "Id" && languageText[i] != "comment" && languageText[i] != "")
                {
                    nbLanguage++;
                }
                else
                {
                    // supression des données qui ne sont pas une langue
                    languageText.RemoveAt(i);
                }
            }

            
            for (int i = 0; i < nbLanguage; i++)
            {
                if (language == languageText[i])
                {
                    for (int j = 0; j <= nbline; j++)
                    {
                        // lecture des données et recupération des données
                        csvLine = reader.ReadLine();
                        text = csvLine.Split(';').ToList();

                        // ajout des données dans le dictionnaire
                        dictionary.Add(text[0], text[i]);

                        nbline++;

                        if (reader.EndOfStream)
                        {
                            return dictionary;
                        }

                    }
                }
            }

            return dictionary;
        }

        // import
        private void OnCSVFileOpened(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // string content = reader.ReadToEnd();

                // Process CSV content here

                string csvLine = reader.ReadLine();

                int nbline = 0;

                gridData.Rows.Clear();

                List<string> text = new List<string>();

                for (int i = 0; i <= nbline; i++)
                {
                    // import des valeur csv dans le datagrid

                    text = csvLine.Split(';').ToList();

                    gridData.Rows.Add(
                    new RowData
                    {
                        Key = text[0],
                        Languages = new ObservableCollection<string> { text[1], text[2], text[3] },
                        Comments = ""
                    });

                    csvLine = reader.ReadLine();

                    nbline++;

                    if (reader.EndOfStream)
                    {
                        // import de la derniere ligne de valeur dans le datagrid + fin de la boucle
                        text = csvLine.Split(';').ToList();

                        gridData.Rows.Add(
                        new RowData
                        {
                            Key = text[0],
                            Languages = new ObservableCollection<string> { text[1], text[2], text[3] },
                            Comments = ""
                        });

                        return;
                    }


                }

                // MessageBox.Show("CSV Loaded:\n" + csvLine);
            }
        }

        private void OnCSVFileSaved(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string csvContent = ""; // Sampled CSV content
                int nbLanguage = gridData.Rows[0].Languages.Count;

                // ecriture des valeur
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    csvContent = gridData.Rows[i].Key;
                    writer.Write(csvContent + ";");


                    for (int j = 0; j < nbLanguage; j++)
                    {
                        csvContent = gridData.Rows[i].Languages[j];

                        writer.Write(csvContent + ";");
                    }

                    csvContent = gridData.Rows[i].Comments;
                    writer.Write(csvContent);

                    //changement de ligne
                    writer.WriteLine();

                }

                MessageBox.Show($"Data exported as CSV to: {filePath}");
            }
        }
    }
}
