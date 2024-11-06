using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LocalizationFilesManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] Columns = { "Id", "en", "fr", "es", "comments" };

        public MainWindow()
        {
            InitializeComponent();

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
    }
}