﻿using Bing_Image.helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Bing_Image.Classes
{
    class MainWindowVM : BaseViewModel
    {
        #region Fields
        private string bingSource;
        private string imageAddress;
        private string imageInformation;
        private string fileName;
        BitmapImage image ;
        
        
        #endregion

        #region Constructor
        public MainWindowVM()
        {
            Image = new BitmapImage();
            FindAndDownloadImage();
            InitializeCommands();
        }


        private void InitializeCommands()
        {
           

            this.RefreshCommand = new RelayCommand(param => this.FindAndDownloadImage());
            this.SetDesktopBackground = new RelayCommand(param => this.SetBackground());
            this.Getinform = new RelayCommand(param => this.GetInfo());
            
           // this.CloseCommand = new RelayCommand(param => this.Close());
          //  this.SaveCommand = new RelayCommand(param => this.Save(), param => CanSave());
          
        }
        #endregion

        #region Properties

        public SolidColorBrush ConnectColor
        {
            get {return
                        (Classes.CheckConnectionInternet.CheckForPing())
                             ? (new SolidColorBrush(Colors.GreenYellow)) : 
                                    (new SolidColorBrush(Colors.OrangeRed));
            }
        }
       public BitmapImage Image
        {
            get { return image; }
            set
            {
                if(value!=null)
                image = value;
                base.OnPropertyChanged("Image");
                base.OnPropertyChanged("ConnectColor");
            }
            
        }
        #endregion

        #region Command
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand SetDesktopBackground { get; set; }
        public RelayCommand Getinform { get; set; }

        public RelayCommand RefreshCommand { get; set; }
       

        #endregion

        #region Method
        private void Save()
        {
            
               
            
        }
        
       
        
        private void ChangeLocation()
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog SelectFolder = new System.Windows.Forms.FolderBrowserDialog();
                SelectFolder.ShowDialog();
                if (SelectFolder.SelectedPath != string.Empty)
                {
                    Properties.Settings.Default.LocationDefult = SelectFolder.SelectedPath;
                }
                else if (Properties.Settings.Default.LocationDefult==string.Empty)
                {
                    ChangeLocation();
                }
            }
            catch { }
        }


        private void FindAndDownloadImage()
        {

            try
            {
                if (Properties.Settings.Default.LocationDefult == null)
                    ChangeLocation();
                else
                    if (CheckConnectionInternet.CheckForPing())
                    {
                       
                        if (Properties.Settings.Default.LocationDefult != string.Empty)
                        {
                            if (Properties.Settings.Default.Rezouloactio == "1366x768")
                            {
                                using (var client = new WebClient())
                                {
                                    bingSource = client.DownloadString("http://www.bing.com/HPImageArchive.aspx?format=xml&idx=0&n=1&mkt=en-US");
                                    imageAddress = image1366x768(bingSource);
                                    imageInformation = GetInformation(bingSource);

                                    string[] name = (imageAddress.Split('/'));
                                    fileName = Properties.Settings.Default.LocationDefult + @"\\" + name[name.Length - 1];

                                    if (!File.Exists(fileName))
                                    {
                                        client.DownloadFile(imageAddress, @fileName);
                                    }
                                    else
                                    {
                                        if(Image.BaseUri!=null)
                                        System.Windows.Forms.MessageBox.Show(Properties.Resources.MSBDontAddNewImage, Properties.Resources.MSBMessage);
                                        
                                    }

                                }
                            }
                            else
                            {
                                using (var client = new WebClient())
                                {
                                    bingSource = client.DownloadString("http://www.bing.com/");
                                    imageAddress = image1920x1080(bingSource);
                                    imageInformation = GetInformation(bingSource);

                                    string[] name = (imageAddress.Split('/'));
                                    fileName = Properties.Settings.Default.LocationDefult + @"\\" + name[name.Length - 1];

                                    if (!File.Exists(fileName))
                                    {
                                        client.DownloadFile(imageAddress, @fileName);
                                    }
                                    else
                                    {
                                        if (Image.BaseUri != null)
                                        System.Windows.Forms.MessageBox.Show(Properties.Resources.MSBDontAddNewImage, Properties.Resources.MSBMessage);
                                        
                                    }
                                }
                            }
                            SetImage();
                        }
                        else
                        {
                            // this.locat_ItemClick(this.sender, e);
                            ChangeLocation();
                            Properties.Settings.Default.Save();
                        }

                       
                    }
                    else
                    {

                        System.Windows.Forms.MessageBox.Show(Properties.Resources.MSBDisconnect, Properties.Resources.MSBMessage);
                       
                        if (Properties.Settings.Default.LastFilepath != null)
                        {
                            fileName = Properties.Settings.Default.LastFilepath;
                            SetImage(fileName);
                        }


                    }
            }
            catch
            {
                try
                {
                    

                    SetImage((new Uri(System.Reflection.Assembly.GetExecutingAssembly() + @"\\1.jpg")).ToString());
                   
                    
                }
                catch { }
            }

        }
        private void SetImage()
        {
            Image = new BitmapImage();
            Image.BeginInit();
            Properties.Settings.Default.LastFilepath = fileName;
            Properties.Settings.Default.Save();
            Image.UriSource = new Uri(@fileName);
            Image.EndInit();
            
        }
        private void SetImage(string s)
        {
            Image = new BitmapImage();
            Image.BeginInit();
            Properties.Settings.Default.LastFilepath = fileName;
            Properties.Settings.Default.Save();
            Image.UriSource = new Uri(@fileName);
            Image.EndInit();
           
        }

        private string GetInformation(string s)
        {
           
            s = s.Replace("copyright", "Æ");
            string[] k = s.Split('Æ');
            return k[1];
        }

        private string image1366x768(string s)
        {
            try
            {
                s = s.Replace("<url>", "Æ");
                string[] k = s.Split('Æ');
                s = k[1].Replace("</url>", "Æ");
                k = s.Split('Æ');
                return "http://www.bing.com" + k[0];
            }
            catch { return " "; }
            
        }
        private string image1920x1080(string s)
        {
            try
            {
                s = s.Replace("url:", "Æ");
                string[] k = s.Split('Æ');
                k = s.Split('Æ');
                s = k[1].Replace("\"", "Æ");
                k = s.Split('Æ');
                return "http://www.bing.com" + k[1];
            }
            catch { return " "; }
        }
     
        private void SetBackground()
        {
            
            fileName = Properties.Settings.Default.LastFilepath;
            Classes.SetDesktopBackGround.Set(fileName, SetDesktopBackGround.Style.Stretched);

        }

        private void GetInfo()
        {
            if(imageInformation!=string.Empty)
            {
                System.Windows.Forms.MessageBox.Show(imageInformation, Properties.Resources.MSBMessage);
            }
        }
        #endregion Method

    }
}

