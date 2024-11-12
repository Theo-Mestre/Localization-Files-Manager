using System;
using System.Windows;
using System.Collections.Generic;

namespace LocalizationFilesManager
{
    public partial class MainWindow : Window
    {
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

            InitializeDataGrid();
        }

        private void InitializeFileInfo()
        {
            supportedFiles = "All files (*.csv, *.json, *.xml, *.cs, *.cpp)|*.csv;*.json;*.xml;*.cs;*.cpp|"
                           + "CSV files (*.csv)|*.csv|"
                           + "JSON files (*.json)|*.json|"
                           + "XML files (*.xml)|*.xml";

            fileProcessingMethods[".csv"] = [OnCSVFileOpened, OnCSVFileSaved];
            fileProcessingMethods[".json"] = [OnJsonFileOpened, OnJsonFileSaved];
            fileProcessingMethods[".xml"] = [OnXMLFileOpened, OnXMLFileSaved];
            fileProcessingMethods[".cs"] = [OnCsFileOpened, OnCsFileSaved];
            //fileProcessingMethods[".cpp"] = [OnCppFileOpened, OnCppFileSaved];
        }
    }
}