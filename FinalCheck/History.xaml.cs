using FinalCheck.DataBase;
using MaterialDesignThemes.Wpf;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
using System.Windows.Shapes;

namespace FinalCheck
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        public History()
        {
            InitializeComponent();
            this.DataContext = this;
            //loaddatadetail("abc");
        }
        private void lv1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;
            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;
            gView.Columns[0].Width = workingWidth * 0.1;
            gView.Columns[1].Width = workingWidth * 0.35;
            gView.Columns[2].Width = workingWidth * 0.2;
            gView.Columns[3].Width = workingWidth * 0.35;
        }
        public void loaddatadetail(string namecabi)
        {
            DbConnect dbc = new DbConnect();
            DataSet dts = dbc.StoreFillDS("GetDataDetail", System.Data.CommandType.StoredProcedure, namecabi);
            dtg_VP.ItemsSource = dts.Tables[0].DefaultView;

            dtg_GAS.ItemsSource = dts.Tables[1].DefaultView;

            dtg_WI1WITH .ItemsSource = dts.Tables[2].DefaultView;

            dtg_WI1START.ItemsSource = dts.Tables[3].DefaultView;

            dtg_IP.ItemsSource = dts.Tables[4].DefaultView;

            dtg_DF.ItemsSource = dts.Tables[5].DefaultView;

            dtg_TEMP.ItemsSource = dts.Tables[6].DefaultView;

            dtg_IOT.ItemsSource = dts.Tables[7].DefaultView;

            dtg_WI2.ItemsSource = dts.Tables[8].DefaultView;

            dtg_PAN.ItemsSource = dts.Tables[9].DefaultView;

            dtg_CAMBACK.ItemsSource = dts.Tables[10].DefaultView;

            dtg_CAMFRONT.ItemsSource = dts.Tables[11].DefaultView;

        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            if (Ckb_nofinal.IsChecked == false)
            {
                DateTime? selectTimeFrom = TimeFrom.SelectedTime;
                DateTime? selectDateFrom = DateFrom.SelectedDate;
                DateTime? selectTimeTo = TimeTo.SelectedTime;
                DateTime? selectDateTo = DateTo.SelectedDate;

                string DateTimeFrom = "";
                string DateTimeTo = "";

                if (selectTimeFrom.HasValue && selectDateFrom.HasValue)
                {
                    DateTime slDate = selectDateFrom.Value;
                    DateTime slTime = selectTimeFrom.Value;
                    DateTimeFrom = slDate.ToString("yyyy-MM-dd") + " " + slTime.ToString("HH:mm:ss");
                }
                else if (!selectTimeFrom.HasValue && selectDateFrom.HasValue)
                {
                    DateTime slDate = selectDateFrom.Value;
                    DateTimeFrom = slDate.ToString("yyyy-MM-dd") + " 00:00:00";
                }
                if (selectTimeTo.HasValue && selectDateTo.HasValue)
                {
                    DateTime slDate = selectDateTo.Value;
                    DateTime slTime = selectTimeTo.Value;
                    DateTimeTo = slDate.ToString("yyyy-MM-dd") + " " + slTime.ToString("HH:mm:ss");
                }
                else if (!selectTimeTo.HasValue && selectDateTo.HasValue)
                {
                    DateTime slDate = selectDateTo.Value;
                    DateTimeTo = slDate.ToString("yyyy-MM-dd") + " 00:00:00";
                }

                if (DateTimeFrom != "" && DateTimeTo != "" && txb_Cabi.Text != "")
                {
                    MessageBox.Show(DateTimeFrom + "\n" + DateTimeTo + "\n" + txb_Cabi.Text);
                }
                else if (DateTimeFrom != "" && DateTimeTo != "" && txb_Cabi.Text == "")
                {
                    MessageBox.Show(DateTimeFrom + "\n" + DateTimeTo);
                }
                else if (txb_Cabi.Text != "")
                {
                    MessageBox.Show(txb_Cabi.Text);
                }
                else
                {
                    MessageBox.Show("Chưa nhập thông tin để tìm kiếm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


            }
            else if (Ckb_nofinal.IsChecked == true)
            {
                MessageBox.Show("No Final Check");
            }

        }
        public void LoadDataFinalCheck()
        {

        }
        public void LoadDataNoFinalCheck()
        {

        }

        private void Ckb_nofinal_Checked(object sender, RoutedEventArgs e)
        {
           
                TimeFrom.Text = "";
                DateFrom.Text = "";
                TimeTo.Text = "";
                DateTo.Text = "";
                TimeFrom.IsEnabled = false;
                DateFrom.IsEnabled = false;
                TimeTo.IsEnabled = false;
                DateTo.IsEnabled = false;
        }

        private void Ckb_nofinal_Unchecked(object sender, RoutedEventArgs e)
        {
            TimeFrom.IsEnabled = true;
            DateFrom.IsEnabled = true;
            TimeTo.IsEnabled = true;
            DateTo.IsEnabled = true;
        }
    }
}
