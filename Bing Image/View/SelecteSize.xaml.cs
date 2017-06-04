using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SelecteSize.xaml
    /// </summary>
    public partial class SelecteSize : DXWindow
    {
        public SelecteSize()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Rezouloactio == "1920x1080")
                rb1920x1080.IsChecked = true;
            else
                rb1366x768.IsChecked = true;
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (rb1366x768.IsChecked == true)
                Properties.Settings.Default.Rezouloactio = "1366x768";
            else 
                Properties.Settings.Default.Rezouloactio = "1920x1080";

            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnCancell_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
