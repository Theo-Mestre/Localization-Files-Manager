using System.Windows;
using System.Windows.Input;
using System.Xml.Schema;

namespace LocalizationFilesManager
{
    public partial class MainWindow
    {
        private void OnOpenFileButtonClicked(object sender, RoutedEventArgs e)
        {
            // Open file dialog

        }
        private void OnSaveFileButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void OnQuitButtonClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            return;
        }


        private bool IsLightThemeEnabled = false;
        private void OnThemeSwitchChecked(object sender, RoutedEventArgs e)
        {
            IsLightThemeEnabled = !IsLightThemeEnabled;

            string uri = IsLightThemeEnabled ? "Themes/LightTheme.xaml" : "Themes/DarkTheme.xaml";

            var theme = (ResourceDictionary)Application.LoadComponent(new System.Uri(uri, System.UriKind.Relative));
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            Application.Current.Resources.MergedDictionaries.Insert(0, theme);
        }

        #region TopBarControls
        private void OnTopBarClicked(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }

            if (e.LeftButton != MouseButtonState.Pressed) return;

            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                Top = e.GetPosition(this).Y - 10;
                Left = e.GetPosition(this).X - ActualWidth / 2;
            }

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