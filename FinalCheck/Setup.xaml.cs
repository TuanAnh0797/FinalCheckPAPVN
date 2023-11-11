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

namespace FinalCheck
{
    /// <summary>
    /// Interaction logic for Setup.xaml
    /// </summary>
   
    public partial class Setup : Window
    {
        public delegate void mydeledate();
        public mydeledate confirmcloseform;
      public Setup()
        {
            InitializeComponent();
        }

        private void MyControlBarTA_Closed(object sender, EventArgs e)
        {
            confirmcloseform?.Invoke();
        }
    }
}
