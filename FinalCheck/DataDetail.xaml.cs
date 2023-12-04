using FinalCheck.DataBase;
using FinalCheck.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
using System.Windows.Threading;

namespace FinalCheck
{
    /// <summary>
    /// Interaction logic for DataDetail.xaml
    /// </summary>
    public partial class DataDetail : Window, INotifyPropertyChanged
    {
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
            txb_namecabi.Text = namecabi;
        }
        public DataDetail(string namecabi, ResultCheckFinal RCF)
        {
            InitializeComponent();
            RS_Final = RCF;
            Task t1 = UpdateJugde(namecabi, RCF);
            Task t2 = UpdateDetail(namecabi);
            TimerCheck.Interval = TimeSpan.FromMilliseconds(500);
            TimerCheck.Start();
            TimerCheck.Tick += TimerCheck_Tick;
        }
        public Task UpdateJugde(string namecabi, ResultCheckFinal RCF)
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
                        throw new TimeoutException("Error timed out Open Connection .");
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
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return false;


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
    }
}
