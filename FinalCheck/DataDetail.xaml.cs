using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalCheck
{
    /// <summary>
    /// Interaction logic for DataDetail.xaml
    /// </summary>
    public partial class DataDetail : Window,INotifyPropertyChanged
    {
        private string cabinet;

        public string Cabinet
        {
            get { return cabinet; }
            set
            {
                if (value != cabinet)
                {
                    cabinet = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public  DataDetail(string namecabi)
        {
           
            InitializeComponent();
           txb_namecabi.Text = namecabi;
           



        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MyControlBarTA_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
