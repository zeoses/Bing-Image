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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bing_Image.View.UC
{
    /// <summary>
    /// Interaction logic for UCGallery.xaml
    /// </summary>
    public partial class UCGallery : UserControl
    {
        public UCGallery()
        {
            InitializeComponent();
            if (Properties.Settings.Default.LocationDefult!="")
            gallry.Source = new Uri(Properties.Settings.Default.LocationDefult);
            if (Properties.Settings.Default.Language == "fa-ir")
                MMcontrol.FlowDirection = System.Windows.FlowDirection.RightToLeft;
        }

        private void btnOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.LocationDefult);
        }
        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
