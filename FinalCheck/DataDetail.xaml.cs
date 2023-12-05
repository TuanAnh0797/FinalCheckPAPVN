using FinalCheck.DataBase;
using FinalCheck.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FinalCheck
{
    /// <summary>
    /// Interaction logic for DataDetail.xaml
    /// </summary>
    public partial class DataDetail : Window, INotifyPropertyChanged
    {
        Popup popupdisconnect = new Popup();
        Border borderdisconnect = new Border();
        TextBlock textBlockdisconnect = new TextBlock();
        private string cabinet;
        public ResultCheckFinal RS_Final;
        PLC Plc = new PLC();
        bool check_run = false;
        DispatcherTimer TimerCheck = new DispatcherTimer();
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
        public DataDetail(string namecabi)
        {

            InitializeComponent();
            Task t1 = UpdateJugde(namecabi);
            Task t2 = UpdateDetail(namecabi);
        }
        public DataDetail(string namecabi, ResultCheckFinal RCF)
        {
            InitializeComponent();
            RS_Final = RCF;
            innitpopdisconnect();
            Task t1 = UpdateJugdeError(namecabi, RCF);
            Task t2 = UpdateDetailError(namecabi);
            TimerCheck.Interval = TimeSpan.FromMilliseconds(500);
            TimerCheck.Start();
            TimerCheck.Tick += TimerCheck_Tick;
        }
        public Task UpdateJugdeError(string namecabi, ResultCheckFinal RCF)
        {
            Task t1 = new Task(() =>
            {
                this.Dispatcher?.Invoke(new Action(() =>
                {
                    txb_namecabi.Text = namecabi;
                    txbl_JugdeVP.Text = RCF.Judge_VP;
                    txbl_JugdeGAS.Text = RCF.Judge_GAS;
                    txbl_JugdeWI1WITH.Text = RCF.Judge_WI1WITH;
                    txbl_JugdeWI1START.Text = RCF.Judge_WI1START;
                    txbl_JugdeIP.Text = RCF.Judge_IP;
                    txbl_JugdeDF.Text = RCF.Judge_DF;
                    txbl_JugdeTEMP.Text = RCF.Judge_TEMP;
                    txbl_JugdeIOT.Text = RCF.Judge_IOT;
                    txbl_JugdeWI2.Text = RCF.Judge_WI2;
                    txbl_JugdePAN.Text = RCF.Judge_PAN;
                    txbl_JugdeCAMBACK.Text = RCF.Judge_CAMBACK;
                    txbl_JugdeCAMFRONT.Text = RCF.Judge_CAMFRONT;
                    txbl_JugdeTotal.Text = RCF.Judge_Total;
                }));

            });
            t1.Start();
            return t1;
        }

        public Task UpdateDetailError(string namecabi)
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
        public async Task<bool> ControlPlc(int timeout)
        {
            try
            {
                using (TcpClient tcpclient = new TcpClient())
                {
                    CancellationTokenSource PlcCancellationToken = new CancellationTokenSource();
                    Task connectTask = tcpclient.ConnectAsync(IPAddress.Parse(ConfigConnection.IpAddress), ConfigConnection.PortNumber);
                    if (await Task.WhenAny(connectTask, Task.Delay(timeout, PlcCancellationToken.Token)) != connectTask)
                    {
                        PlcCancellationToken.Cancel();
                        throw new TimeoutException("Error timed out PLC Open Connection .");
                    }
                    await connectTask;
                    NetworkStream StreamPLc = tcpclient.GetStream();
                    await Plc.WriteBit(StreamPLc, timeout, "M", ConfigConnection.WriteBit.AliveBit);
                    if (await Plc.ReadBit(StreamPLc, timeout, "M", ConfigConnection.ReadData.NameDeviceTrigerReadError))
                    {
                        string DataContentError = (string)await Plc.ReadData(StreamPLc, timeout, "D", ConfigConnection.ReadData.NameDeviceDataReason, ConfigConnection.ReadData.QuantityDataReason, "String");
                        string DataUser = (string)await Plc.ReadData(StreamPLc, timeout, "D", ConfigConnection.ReadData.NameDeviceDataPerson, ConfigConnection.ReadData.QuantityDataPerson, "String");
                        UpdateDataFinalCheck(txb_namecabi.Text, DataContentError, DataUser);
                        await Plc.WriteBit(StreamPLc, timeout, "M", ConfigConnection.WriteBit.NameDeviceSendConfirm);
                        return true;
                    }
                    tcpclient.Close();
                    popupdisconnect.IsOpen = false;
                }

            }
            catch (Exception ex)
            {
                SaveLogError(DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + ": " + ex.Message);
                if (ex.Message.Contains("timed out PLC"))
                {
                    popupdisconnect.IsOpen = true;
                }

            }
            return false;


        }
        public void SaveLogError(string data)
        {
            try
            {
                string namefile = DateTime.Now.ToString("ddMMyyyy");
                string filepath = Directory.GetCurrentDirectory() + "\\LOGERROR\\" + namefile + ".csv";
                using (var sr = new StreamWriter(filepath, true, Encoding.UTF8))
                {
                    sr.WriteLine(data);
                }
            }
            catch (Exception)
            {


            }

        }
        public void UpdateDataFinalCheck(string ModelCode, string ReasonError, string PersonConfirm)
        {
            DbConnect db_connect = new DbConnect();
            db_connect.exnonquery("UpdateDataFinalCheck", CommandType.StoredProcedure, ModelCode, ReasonError, PersonConfirm);

        }

        private async void TimerCheck_Tick(object sender, EventArgs e)
        {
            if (!check_run)
            {
                check_run = true;
                if (await ControlPlc(5000))
                {
                    this.Close();
                }
                check_run = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MyControlBarTA_Closed(object sender, EventArgs e)
        {
            TimerCheck.Stop();
            check_run = false;
        }
        public void innitpopdisconnect()
        {
            // Tạo một UserControl hoặc UIElement để đặt vào Popup

            borderdisconnect.Background = Brushes.Red; // Thay đổi màu nền theo nhu cầu

            // Tạo một UserControl hoặc UIElement để đặt vào Border
            // Ví dụ: Tạo một TextBlock để hiển thị nội dung

            textBlockdisconnect.Foreground = Brushes.White;
            textBlockdisconnect.HorizontalAlignment = HorizontalAlignment.Center;
            textBlockdisconnect.VerticalAlignment = VerticalAlignment.Center;
            textBlockdisconnect.FontSize = 40;
            textBlockdisconnect.FontWeight = FontWeight.FromOpenTypeWeight(600);
            textBlockdisconnect.Text = "Mất kết nối với PLC!";

            // Đặt UserControl hoặc UIElement vào Border
            borderdisconnect.Child = textBlockdisconnect;

            // Đặt kích thước cho Popup (nếu cần)
            popupdisconnect.Width = 600;
            popupdisconnect.Height = 150;

            // Đặt vị trí hiển thị của Popup giữa màn hình
            popupdisconnect.Placement = PlacementMode.Center;
            popupdisconnect.PlacementTarget = this; // Đặt làm PlacementTarget để Popup hiển thị giữa màn hình

            // Đặt Border vào Popup
            popupdisconnect.Child = borderdisconnect;
        }
        public ResultCheckFinal LoadDataForCabi(string cabinet)
        {
            DbConnect db_connect = new DbConnect();
            ResultCheckFinal RCF = new ResultCheckFinal();
            DataTable dt = db_connect.StoreFillDT("GetJudgeAllLine", CommandType.StoredProcedure, cabinet);
            if (dt.Rows.Count > 0)
            {
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
        public Task UpdateJugde(string namecabi)
        {
            Task t1 = new Task(() =>
            {
                ResultCheckFinal RCF = LoadDataForCabi(namecabi);
                this.Dispatcher?.Invoke(new Action(() =>
                {
                    txb_namecabi.Text = namecabi;
                    txbl_JugdeVP.Text = RCF.Judge_VP;
                    txbl_JugdeGAS.Text = RCF.Judge_GAS;
                    txbl_JugdeWI1WITH.Text = RCF.Judge_WI1WITH;
                    txbl_JugdeWI1START.Text = RCF.Judge_WI1START;
                    txbl_JugdeIP.Text = RCF.Judge_IP;
                    txbl_JugdeDF.Text = RCF.Judge_DF;
                    txbl_JugdeTEMP.Text = RCF.Judge_TEMP;
                    txbl_JugdeIOT.Text = RCF.Judge_IOT;
                    txbl_JugdeWI2.Text = RCF.Judge_WI2;
                    txbl_JugdePAN.Text = RCF.Judge_PAN;
                    txbl_JugdeCAMBACK.Text = RCF.Judge_CAMBACK;
                    txbl_JugdeCAMFRONT.Text = RCF.Judge_CAMFRONT;
                    txbl_JugdeTotal.Text = RCF.Judge_Total;
                }));

            });
            t1.Start();
            return t1;
        }
    }
}
