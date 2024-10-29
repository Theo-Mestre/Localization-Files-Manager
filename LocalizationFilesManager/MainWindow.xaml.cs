using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        } 
        private void Button_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}