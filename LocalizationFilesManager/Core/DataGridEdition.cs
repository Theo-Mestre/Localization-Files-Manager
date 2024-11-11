using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Xml.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace LocalizationFilesManager
{
    class RowData
    {
        public string Key { get; set; } = "";
        public ObservableCollection<string> Languages { get; set; } = new();
        public string Comments { get; set; } = "";
    }

    class GridData
    {
        public RowData Key = new(); // Values of the key row in the data grid
        public ObservableCollection<RowData> Rows = new(); // Values of the rows in the data grid
    }

    public partial class MainWindow
    {
        GridData gridData = new();

        private void InitializeDataGrid()
        {
            // Exemple of data grid initialization
            gridData.Key.Key = "UUU";
            gridData.Key.Languages = new ObservableCollection<string> { "En", "Fr", "Ja" };
            gridData.Key.Comments = "Comments";

            gridData.Rows.Add(
                new RowData
                {
                    Key = "Key1",
                    Languages = new ObservableCollection<string> { "Value1", "Value2", "Value3" },
                    Comments = "Comments1"
                });

            gridData.Rows.Add(
                new RowData
                {
                    Key = "Key2",
                    Languages = new ObservableCollection<string> { "Value4", "Value5", "Value6" },
                    Comments = "Comments2"
                });
            // End Exemple

            InitializeDataGridKeyColumn();
        }

        private void InitializeDataGridKeyColumn()
        {
            var grid = GetDataGrid();

            grid.DataContext = gridData;
            grid.ItemsSource = gridData.Rows;
            grid.Columns.Clear();

            var keyColumn = new DataGridTextColumn();
            keyColumn.Header = "Key";
            keyColumn.Binding = new Binding("Key");
            grid.Columns.Add(keyColumn);

            for (int i = 0; i < gridData.Key.Languages.Count; i++)
            {
                var column = new DataGridTextColumn();
                column.Header = gridData.Key.Languages[i];
                column.Binding = new Binding($"Languages[{i}]");
                grid.Columns.Add(column);
            }

            var commentsColumn = new DataGridTextColumn();
            commentsColumn.Header = "Comments";
            commentsColumn.Binding = new Binding("Comments");
            grid.Columns.Add(commentsColumn);
        }

        private void OnGridDataEdited(object sender, EventArgs e)
        {
        }

        private DataGrid GetDataGrid()
        {
            return Application.Current.MainWindow.FindName("TranslationGrid") as DataGrid;
        }

    }
}
