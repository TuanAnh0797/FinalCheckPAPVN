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
        public bool is_export = false;
        public ObservableCollection<ResultMain> dataforlistview { set; get; }
        public History()
        {
            InitializeComponent();
            dataforlistview = new ObservableCollection<ResultMain>();
            this.DataContext = this;

           
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
            try
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

                    if ((DateTimeFrom == "" || DateTimeTo == "") && txb_Cabi.Text == "" || (DateTimeFrom == "" && DateTimeTo == "" && txb_Cabi.Text == ""))
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           

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

        private async void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!is_export)
                {
                    is_export = true;
                    if (dataforlistview.Count > 100)
                    {
                        if (MessageBox.Show($"Số lượng export nhiều({dataforlistview.Count.ToString()}) có thể ảnh hưởng đến hiệu năng \n Bạn có muốn tiếp tục export không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                                using (System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
                                {
                                    // Thiết lập các thuộc tính cho FolderBrowserDialog (tùy chọn)
                                    folderBrowserDialog.Description = "Chọn thư mục để lưu tệp";
                                    folderBrowserDialog.ShowNewFolderButton = true; // Hiển thị nút để tạo thư mục mới

                                    // Hiển thị hộp thoại và kiểm tra xem người dùng đã chọn thư mục không
                                    System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

                                    if (result == System.Windows.Forms.DialogResult.OK)
                                    {
                                        string selectedFolderPath = folderBrowserDialog.SelectedPath;
                                        await exportdata(selectedFolderPath);
                                    MessageBox.Show($"Đã export vào folder: {selectedFolderPath}");
                                    }
                                }
                        }
                    }
                    else
                    {
                        if (dataforlistview.Count > 0)
                        {
                            using (System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
                            {
                                // Thiết lập các thuộc tính cho FolderBrowserDialog (tùy chọn)
                                folderBrowserDialog.Description = "Chọn thư mục để lưu tệp";
                                folderBrowserDialog.ShowNewFolderButton = true; // Hiển thị nút để tạo thư mục mới

                                // Hiển thị hộp thoại và kiểm tra xem người dùng đã chọn thư mục không
                                System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    string selectedFolderPath = folderBrowserDialog.SelectedPath;
                                    await exportdata(selectedFolderPath);
                                    MessageBox.Show($"Đã export vào folder: {selectedFolderPath}");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu để Export");
                        }
                    }


                    is_export = false;
                }
                else
                {
                    MessageBox.Show("Đang export. Hãy chờ export xong");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            
        }
        public void SaveLogCheck(string filepathlog, string NameCabi, ResultCheckFinal RCF)
        {
            
            string NameFile = NameCabi + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
            using (StreamWriter sw = new StreamWriter(filepathlog + "\\"  + NameFile, true, Encoding.UTF8))
            {
                string Content = "TimeCheck,ModelCode,VP,GAS,WI1 WITH,WI1 START,IP,DF,TEMP,IOT,WI2,PAN,CAMBACK,CAMFRONT,ToTal,Cách xử lý,Người xác nhận\n"
                + $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},{NameCabi},{RCF.Judge_VP},{RCF.Judge_GAS},{RCF.Judge_WI1WITH},{RCF.Judge_WI1START},{RCF.Judge_IP},{RCF.Judge_DF},{RCF.Judge_TEMP},{RCF.Judge_IOT},{RCF.Judge_WI2},{RCF.Judge_PAN},{RCF.Judge_CAMBACK},{RCF.Judge_CAMFRONT},{RCF.Judge_Total},{RCF.ReasonError},{RCF.PersonConfirm}";
                sw.WriteLine(Content);
            }
            
        }
        public async Task exportdata(string foldersave)
        {
            Task t1 = new Task(() =>
            {
                for (int i = 0; i < dataforlistview.Count; i++)
                {
                    
                    try
                    {
                        ResultCheckFinal RCF = LoadDataForCabi(dataforlistview[i].Cabinet);
                        SaveLogCheck(foldersave, dataforlistview[i].Cabinet, RCF);
                    }
                    catch (Exception)
                    {

                        continue;
                    }
                    
                }
            });
            t1.Start();
            await t1;
        }
        public ResultCheckFinal LoadDataForCabi(string cabinet)
        {
            DbConnect db_connect = new DbConnect();
            ResultCheckFinal RCF = new ResultCheckFinal();
            DataTable dt = db_connect.StoreFillDT("GetJudgeAllLineDetail", CommandType.StoredProcedure, cabinet);
            if (dt.Rows.Count > 0)
            {
                RCF.PersonConfirm = dt.Rows[0]["UserConfirm"].ToString();
                RCF.ReasonError = dt.Rows[0]["ReasonError"].ToString();
                if (dt.Rows[0]["JudgeVP"].ToString() == "OK" || dt.Rows[0]["JudgeVP"].ToString() == "NG")
                {
                    RCF.Judge_VP = dt.Rows[0]["JudgeVP"].ToString();
                }
                else
                {
                    RCF.Judge_VP = "PD";
                }
                //
                if (dt.Rows[0]["JudgeGAS"].ToString() == "OK" || dt.Rows[0]["JudgeGAS"].ToString() == "NG")
                {
                    RCF.Judge_GAS = dt.Rows[0]["JudgeGAS"].ToString();
                }
                else
                {
                    RCF.Judge_GAS = "PD";
                }
                //
                if (dt.Rows[0]["JudgeWI1WITH"].ToString() == "OK" || dt.Rows[0]["JudgeWI1WITH"].ToString() == "NG")
                {
                    RCF.Judge_WI1WITH = dt.Rows[0]["JudgeWI1WITH"].ToString();
                }
                else
                {
                    RCF.Judge_WI1WITH = "PD";
                }
                //
                if (dt.Rows[0]["JudgeWI1START"].ToString() == "OK" || dt.Rows[0]["JudgeWI1START"].ToString() == "NG")
                {
                    RCF.Judge_WI1START = dt.Rows[0]["JudgeWI1START"].ToString();
                }
                else
                {
                    RCF.Judge_WI1START = "PD";
                }
                //
                if (dt.Rows[0]["JudgeIP"].ToString() == "OK" || dt.Rows[0]["JudgeIP"].ToString() == "NG")
                {
                    RCF.Judge_IP = dt.Rows[0]["JudgeIP"].ToString();
                }
                else
                {
                    RCF.Judge_IP = "PD";
                }
                //
                if (dt.Rows[0]["JudgeDF"].ToString() == "OK" || dt.Rows[0]["JudgeDF"].ToString() == "NG")
                {
                    RCF.Judge_DF = dt.Rows[0]["JudgeDF"].ToString();
                }
                else
                {
                    RCF.Judge_DF = "PD";
                }
                //
                if (dt.Rows[0]["JudgeTEMP"].ToString() == "OK" || dt.Rows[0]["JudgeTEMP"].ToString() == "NG")
                {
                    RCF.Judge_TEMP = dt.Rows[0]["JudgeTEMP"].ToString();
                }
                else
                {
                    RCF.Judge_TEMP = "PD";
                }
                //
                if (dt.Rows[0]["JudgeIOT"].ToString() == "OK" || dt.Rows[0]["JudgeIOT"].ToString() == "NG")
                {
                    RCF.Judge_IOT = dt.Rows[0]["JudgeIOT"].ToString();
                }
                else
                {
                    RCF.Judge_IOT = "PD";
                }
                //
                if (dt.Rows[0]["JudgeWI2"].ToString() == "OK" || dt.Rows[0]["JudgeWI2"].ToString() == "NG")
                {
                    RCF.Judge_WI2 = dt.Rows[0]["JudgeWI2"].ToString();
                }
                else
                {
                    RCF.Judge_WI2 = "PD";
                }
                //
                if (dt.Rows[0]["JudgePAN"].ToString() == "OK" || dt.Rows[0]["JudgePAN"].ToString() == "NG")
                {
                    RCF.Judge_PAN = dt.Rows[0]["JudgePAN"].ToString();
                }
                else
                {
                    RCF.Judge_PAN = "PD";
                }
                //
                if (dt.Rows[0]["JudgeCAMBACK"].ToString() == "OK" || dt.Rows[0]["JudgeCAMBACK"].ToString() == "NG")
                {
                    RCF.Judge_CAMBACK = dt.Rows[0]["JudgeCAMBACK"].ToString();
                }
                else
                {
                    RCF.Judge_CAMBACK = "PD";
                }
                //
                if (dt.Rows[0]["JudgeCAMFRONT"].ToString() == "OK" || dt.Rows[0]["JudgeCAMFRONT"].ToString() == "NG")
                {
                    RCF.Judge_CAMFRONT = dt.Rows[0]["JudgeCAMFRONT"].ToString();
                }
                else
                {
                    RCF.Judge_CAMFRONT = "PD";
                }
                //
                RCF.Judge_Total = dt.Rows[0]["JudgeTotal"].ToString();
            }
            else
            {
                RCF.Judge_VP = "PD";
                RCF.Judge_GAS = "PD";
                RCF.Judge_WI1WITH = "PD";
                RCF.Judge_WI1START = "PD";
                RCF.Judge_IP = "PD";
                RCF.Judge_DF = "PD";
                RCF.Judge_TEMP = "PD";
                RCF.Judge_IOT = "PD";
                RCF.Judge_WI2 = "PD";
                RCF.Judge_PAN = "PD";
                RCF.Judge_CAMBACK = "PD";
                RCF.Judge_CAMFRONT = "PD";
                RCF.Judge_Total = "NG";
            }
            return RCF;

        }

    }
}
