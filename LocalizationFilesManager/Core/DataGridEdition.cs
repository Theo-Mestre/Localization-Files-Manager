using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LocalizationFilesManager
{

    class RowData
    {
        public string Key = "";
        public List<string> Languages = new();
        public string Comments = "";
    }

    class GridData
    {
        public List<RowData> Rows = new();
    }

    public partial class MainWindow
    {
        GridData gridData = new();

        private void InitializeDataGrid()
        {
            RowData row = new();

            row.Key = "Start";
            row.Languages = new List<string> { "en", "fr", "ja" };
            row.Comments = "When game start";

            gridData.Rows.Add(row);

            var grid = App.Current.MainWindow.FindName("DataGrid") as System.Windows.Controls.DataGrid;

            if (grid == null)
            {
                MessageBox.Show("DataGrid not found");
                return;
            }

            foreach (var column in gridData.Rows)
            {
                var dataGridTextColumn = new System.Windows.Controls.DataGridTextColumn();
                dataGridTextColumn.Header = column.Key;
                dataGridTextColumn.Binding = new System.Windows.Data.Binding(column.Languages[1]);
                grid.Columns.Add(dataGridTextColumn);
            }
        }

    }
}
