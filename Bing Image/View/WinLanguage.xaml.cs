using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bing_Image.View
{
    /// <summary>
    /// Interaction logic for WinLanguage.xaml
    /// </summary>
    public partial class WinLanguage : DXWindow
    {
        public WinLanguage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Language == "fa-ir")
                LPersian.IsChecked = true;
            else
                LEnghlish.IsChecked = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (LEnghlish.IsChecked == true)
                Properties.Settings.Default.Language = "en-us";
            else
                Properties.Settings.Default.Language = "fa-ir";

            Properties.Settings.Default.Save();

            Properties.Resources.Culture = new CultureInfo(Properties.Settings.Default.Language);

            MessageBoxResult Result = MessageBox.Show(Properties.Resources.MSBChangeLanguage, "", MessageBoxButton.OKCancel);
            if(Result==MessageBoxResult.OK)
            {
                //this is for Restart App
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
