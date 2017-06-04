using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Bing_Image.helper
{
    class BaseViewModel :  INotifyPropertyChanged, IDisposable
    {
        DispatcherTimer timer = new DispatcherTimer();


        public event PropertyChangedEventHandler PropertyChanged;
      
        string message = "";
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
                timer.Stop();
                timer.Start();
            }
        }
        protected BaseViewModel()
        {
            // this.errorList = new Dictionary<string, string>();
            timer.Interval = TimeSpan.FromMilliseconds(2000);
            timer.Tick += timer_Tick;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Message = "";
            timer.Stop();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
