using FinalCheck.DataBase;
using MaterialDesignThemes.Wpf;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<ResultMain> dataforlistview { set; get; }
        public History()
        {
            InitializeComponent();
            dataforlistview = new ObservableCollection<ResultMain>();
            this.DataContext = this;

            //loaddatadetail("abc");
        }
        public void LoadDataForTableHistory(string datetimefrom, string datetimeto, string namecabi)
        {
            dataforlistview.Clear();
            DbConnect db_connect = new DbConnect();
            DataTable dt = db_connect.StoreFillDT("LoadDataForTableHistoryTrace", CommandType.StoredProcedure, datetimefrom, datetimeto, namecabi);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ResultMain RM = new ResultMain(i + 1, dt.Rows[i]["CodeModel"].ToString(), dt.Rows[i]["Judge_Total"].ToString(), dt.Rows[i]["TimeUpdate"].ToString());
                    dataforlistview.Add(RM);
                }

            }
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
        public Task UpdateDetail(string namecabi)
        {
            Task t1 = new Task(() =>
            {
                DbConnect dbc = new DbConnect();
                DataSet dts = dbc.StoreFillDS("GetDataDetail", System.Data.CommandType.StoredProcedure, namecabi);
                this.Dispatcher.Invoke(new Action(() =>
                {
                    dtg_VP.ItemsSource = dts.Tables[0].DefaultView;

                    dtg_GAS.ItemsSource = dts.Tables[1].DefaultView;

                    dtg_WI1WITH.ItemsSource = dts.Tables[2].DefaultView;

                    dtg_WI1START.ItemsSource = dts.Tables[3].DefaultView;

                    dtg_IP.ItemsSource = dts.Tables[4].DefaultView;

                    dtg_DF.ItemsSource = dts.Tables[5].DefaultView;

                    dtg_TEMP.ItemsSource = dts.Tables[6].DefaultView;

                    dtg_IOT.ItemsSource = dts.Tables[7].DefaultView;

                    dtg_WI2.ItemsSource = dts.Tables[8].DefaultView;

                    dtg_PAN.ItemsSource = dts.Tables[9].DefaultView;

                    dtg_CAMBACK.ItemsSource = dts.Tables[10].DefaultView;

                    dtg_CAMFRONT.ItemsSource = dts.Tables[11].DefaultView;
                }));
            });
            t1.Start();
            return t1;
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
                LoadDataForTableHistory(DateTimeFrom, DateTimeTo, txb_Cabi.Text);


            }
            else if (Ckb_nofinal.IsChecked == true)
            {
                UpdateDetail(txb_Cabi.Text);
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

        private void dtg_CAMFRONT_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_CAMFRONT.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_CAMFRONT.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_CAMFRONT_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_CAMFRONT.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_CAMFRONT.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_CAMBACK_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_CAMBACK.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_CAMBACK.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_CAMBACK_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_CAMBACK.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_CAMBACK.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_PAN_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_PAN.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_PAN.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_PAN_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_PAN.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_PAN.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_WI2_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_WI2.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_WI2.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_WI2_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_WI2.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_WI2.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_IOT_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_IOT.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_IOT.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_IOT_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_IOT.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_IOT.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_TEMP_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_TEMP.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_TEMP.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_TEMP_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_TEMP.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_TEMP.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_DF_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_DF.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_DF.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_DF_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_DF.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_DF.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_IP_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_IP.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_IP.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_IP_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_IP.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_IP.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_WI1START_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_WI1START.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_WI1START.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_WI1START_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_WI1START.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_WI1START.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_WI1WITH_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_WI1WITH.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_WI1WITH.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_WI1WITH_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_WI1WITH.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_WI1WITH.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_GAS_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_GAS.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_GAS.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_GAS_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_GAS.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_GAS.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void dtg_VP_MouseLeave(object sender, MouseEventArgs e)
        {
            dtg_VP.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            dtg_VP.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }

        private void dtg_VP_MouseMove(object sender, MouseEventArgs e)
        {
            dtg_VP.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            dtg_VP.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private async void lv1_MouseUp(object sender, MouseButtonEventArgs e)
        {
           await showdetail();
        }
        public async Task showdetail()
        {
            Task result;
            result = new Task(() =>
            {
                this.Dispatcher?.Invoke(new Action(() =>
                {
                    if (lv1.SelectedItem != null)
                    {
                        ResultMain dt = (ResultMain)lv1.SelectedItem;
                        DbConnect dbc = new DbConnect();
                        DataSet dts = dbc.StoreFillDS("GetDataDetail", System.Data.CommandType.StoredProcedure, dt.Cabinet);
                            dtg_VP.ItemsSource = dts.Tables[0].DefaultView;

                            dtg_GAS.ItemsSource = dts.Tables[1].DefaultView;

                            dtg_WI1WITH.ItemsSource = dts.Tables[2].DefaultView;

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
                }));
            });
            result.Start();
            await result;
        }
    }
}
