using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LocalizationFilesManager
{
    public partial class MainWindow : Window
    {
        public string[] Columns = { "Id", "en", "fr", "es", "comments" };

        private string currentFilePath = "";
        private string supportedFiles = "";
        private Dictionary<string, Action<string>[]> fileProcessingMethods = new();
        private enum FileOperation
        {
            Open = 0,
            Save = 1
        }

        public MainWindow()
        {
            InitializeComponent();

            InitializeFileInfo();

            foreach (string column in Columns)
            {
                //Exemple pour ajouter une colonne à la grille
                DataGridTextColumn textColumn = new DataGridTextColumn();
                //L'entête de la colonne


                textColumn.Header = column;

                //le nom programmatique de la colonne
                textColumn.Binding = new Binding(column);

                //l'ajout'
                dataGrid.Columns.Add(textColumn);
            }
        }

        private void InitializeFileInfo()
        {
            supportedFiles = "All files (*.csv, *.json, *.xml)|*.csv;*.json;*.xml|"
                           + "CSV files (*.csv)|*.csv|"
                           + "JSON files (*.json)|*.json|"
                           + "XML files (*.xml)|*.xml";

            fileProcessingMethods[".csv"] = [OnCSVFileOpened, OnCSVFileSaved];
            fileProcessingMethods[".json"] = [OnJsonFileOpened, OnJsonFileSaved];
            fileProcessingMethods[".xml"] = [OnXMLFileOpened, OnXMLFileSaved];
        }
    }
}