using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace LocalizationFilesManager
{
    public partial class MainWindow
    {
        #region Open / Save / Export buttons
        private void OnOpenFileButtonClicked(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = supportedFiles;

            // Check if user selected a file
            if (dialog.ShowDialog() == false) return;

            currentFilePath = dialog.FileName;
            string extension = Path.GetExtension(currentFilePath);

            // Check if the file extension is supported
            if (!fileProcessingMethods.ContainsKey(extension))
            {
                MessageBox.Show("Unsupported file format");
                return;
            }

            fileProcessingMethods[extension][(int)FileOperation.Open](currentFilePath);
        }
        private void OnSaveFileButtonClicked(object sender, RoutedEventArgs e)
        {
            // Check if the file is not saved yet
            if (string.IsNullOrEmpty(currentFilePath))
            {
                OnExportAsButtonClicked(sender, e);
                return;
            }

            string extension = Path.GetExtension(currentFilePath);

            fileProcessingMethods[extension][(int)FileOperation.Save](currentFilePath);
        }
        private void OnExportAsButtonClicked(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = supportedFiles;

            if (dialog.ShowDialog() == false) return;

            currentFilePath = dialog.FileName;
            string extension = Path.GetExtension(currentFilePath);

            // Check if the file extension is supported
            if (!fileProcessingMethods.ContainsKey(extension))
            {
                MessageBox.Show("Unsupported file format");
                return;
            }

            fileProcessingMethods[extension][(int)FileOperation.Save](currentFilePath);
        }
        #endregion
        #region ThemeSwitch
        private bool IsLightThemeEnabled = false;
        private void OnThemeSwitchChecked(object sender, RoutedEventArgs e)
        {
            IsLightThemeEnabled = !IsLightThemeEnabled;

            string uri = IsLightThemeEnabled ? "Themes/LightTheme.xaml" : "Themes/DarkTheme.xaml";

            var theme = (ResourceDictionary)Application.LoadComponent(new System.Uri(uri, System.UriKind.Relative));
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            Application.Current.Resources.MergedDictionaries.Insert(0, theme);
        }
        #endregion
        #region TopBarControls
        private void OnTopBarClicked(object sender, MouseButtonEventArgs e)
        {
            // Handle double click to maximize window
            if (e.ClickCount == 2)
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                return;
            }

            // Return if left button is not pressed
            if (e.LeftButton != MouseButtonState.Pressed) return;

            // If window is maximized, set it to normal state
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                Top = e.GetPosition(this).Y - 10;
                Left = e.GetPosition(this).X - ActualWidth / 2;
            }

            // Drag the window
            DragMove();
        }

        private void OnMinimizeButtonClicked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void OnMaximizeButtonClicked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            return;
        }
        #endregion
    }
}