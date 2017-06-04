using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bing_Image
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {
            Properties.Resources.Culture = new CultureInfo(Properties.Settings.Default.Language);
            InitializeComponent();
            if (Properties.Settings.Default.Language == "fa-ir")
                MMControl.FlowDirection = System.Windows.FlowDirection.RightToLeft;

            tblState.Background = (Classes.CheckConnectionInternet.CheckForPinck()) ? (new SolidColorBrush(Colors.GreenYellow)) : (new SolidColorBrush(Colors.OrangeRed));
            
       
        }

        private void resoulotion_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            new View.SelecteSize().ShowDialog();
        }

        private void SelectLanguage_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            new View.WinLanguage().ShowDialog();
        }

       
        private void Images_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (Properties.Settings.Default.LocationDefult != string.Empty)
            {
                if (Directory.Exists(Properties.Settings.Default.LocationDefult))
                {
                    ucGallery.Visibility = Visibility.Visible;
                   
                    //  System.Diagnostics.Process.Start(Properties.Settings.Default.locationDefult);
                }
            }
            else
            {
               // ChangeLocate();
            }
        }
    }
}
