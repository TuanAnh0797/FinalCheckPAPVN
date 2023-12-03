using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
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
using LiveCharts.Defaults;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
using System.Runtime.CompilerServices;
using System.Data;
using FinalCheck.DataBase;
using TALibrary;
using System.Net.Sockets;
using FinalCheck.Model;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.IO.Packaging;
using System.Globalization;

namespace FinalCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        PLC Plc = new PLC();
        //DispatcherTimer time1 = new DispatcherTimer();
        DispatcherTimer TimerCheck = new DispatcherTimer();
        bool check_run = false;
        bool rs_NG = false;
        public Func<double, string> Formatter { get; set; }

        public ObservableCollection<ResultMain> dataforlistview { set; get; }

        public ObservableCollection<ResultCheckFinal> List_Result_Check_Final { set; get; }

        public SeriesCollection datastackchart { set; get; }
        public SeriesCollection datapiechart { set; get; }
        public SeriesCollection databarchartNG { set; get; }
        public SeriesCollection databarchartPending { set; get; }

        public Func<ChartPoint, string> PointLabel { get; set; }

        public ObservableValue VPOK { get; set; }
        public ObservableValue GASOILOK { get; set; }
        public ObservableValue WI1WITHOK { get; set; }
        public ObservableValue WI1STARTOK { get; set; }
        public ObservableValue IPOK { get; set; }
        public ObservableValue DFOK { get; set; }
        public ObservableValue TEMPOK { get; set; }
        public ObservableValue IOTOK { get; set; }
        public ObservableValue WI2OK { get; set; }
        public ObservableValue PANOK { get; set; }
        public ObservableValue CAMBACKOK { get; set; }
        public ObservableValue CAMFRONTOK { get; set; }

        public ObservableValue VPNG { get; set; }
        public ObservableValue GASOILNG { get; set; }
        public ObservableValue WI1WITHNG { get; set; }
        public ObservableValue WI1STARTNG { get; set; }
        public ObservableValue IPNG { get; set; }
        public ObservableValue DFNG { get; set; }
        public ObservableValue TEMPNG { get; set; }
        public ObservableValue IOTNG { get; set; }
        public ObservableValue WI2NG { get; set; }
        public ObservableValue PANNG { get; set; }
        public ObservableValue CAMBACKNG { get; set; }
        public ObservableValue CAMFRONTNG { get; set; }
        public ObservableValue VPPENDING { get; set; }

        public ObservableValue GASOILPENDING { get; set; }
        public ObservableValue WI1WITHPENDING { get; set; }
        public ObservableValue WI1STARTPENDING { get; set; }
        public ObservableValue IPPENDING { get; set; }
        public ObservableValue DFPENDING { get; set; }
        public ObservableValue TEMPPENDING { get; set; }
        public ObservableValue IOTPENDING { get; set; }
        public ObservableValue WI2PENDING { get; set; }
        public ObservableValue PANPENDING { get; set; }
        public ObservableValue CAMBACKPENDING { get; set; }
        public ObservableValue CAMFRONTPENDING { get; set; }

        public ObservableValue TotalOK { get; set; }

        public ObservableValue TotalNG { get; set; }

        //public ObservableValue TotalPending { get; set; }

        public string[] Labels { get; set; }
        private string modelcurrent;
        public string ModelCurrent
        {
            get { return modelcurrent; }
            set
            {
                if (modelcurrent != value)
                {
                    modelcurrent = value;
                    OnPropertyChanged();
                }
            }
        }
        private string serialcurrent;

        public string SerialCurrent
        {
            get { return serialcurrent; }
            set
            {
                if (serialcurrent != value)
                {
                    serialcurrent = value;
                    OnPropertyChanged();
                }
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindow()
        {

            InitializeComponent();
            try
            {
                ModelCurrent = "";
                DataContext = this;
                loadConfigJson();
                loadConfigSQL();
                //time1.Interval = TimeSpan.FromSeconds(5);
                TimerCheck.Interval = TimeSpan.FromMilliseconds(300);
                innitproperty();
                innitchart();
                //time1.Start();
                TimerCheck.Start();
                TimerCheck.Tick += TimerCheck_Tick;
                //time1.Tick += Time1_Tick;
                LoadDataForCabi("abc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }


        }
        public void loadConfigJson()
        {
            string dataconfig = File.ReadAllText(Directory.GetCurrentDirectory() + "//config.json");
            Config myconfig = JsonConvert.DeserializeObject<Config>(dataconfig);
            StaticData.connection_string = myconfig.DataBase.ConnectionString;
        }
        public void loadConfigSQL()
        {
            DbConnect dbc = new DbConnect();

            DataTable dt = dbc.StoreFillDT("GetConfigConnectPlc", CommandType.StoredProcedure);

            if (dt.Rows.Count > 0)
            {
                ConfigConnection.IpAddress = dt.Rows[0]["IpAddress"].ToString();
                ConfigConnection.PortNumber = (int)dt.Rows[0]["PortNumber"];
                //
                ConfigConnection.ReadData.NameDeviceTrigerReadCabi = (int)dt.Rows[0]["NameDeviceTrigerReadCabi"];
                ConfigConnection.ReadData.NameDeviceDataCabi = (int)dt.Rows[0]["NameDeviceDataCabi"];
                ConfigConnection.ReadData.QuantityDataCabi = (int)dt.Rows[0]["QuantityDataCabi"];
                ConfigConnection.ReadData.NameDeviceDataPerson = (int)dt.Rows[0]["NameDeviceDataPerson"];
                ConfigConnection.ReadData.QuantityDataPerson = (int)dt.Rows[0]["QuantityDataPerson"];
                ConfigConnection.ReadData.NameDeviceDataReason = (int)dt.Rows[0]["NameDeviceDataReason"];
                ConfigConnection.ReadData.QuantityDataReason = (int)dt.Rows[0]["QuantityDataReason"];
                //
                ConfigConnection.WriteData.NameDeviceSendResult = (int)dt.Rows[0]["NameDeviceSendResult"];
                ConfigConnection.WriteData.QuantityDeviceSendResult = (int)dt.Rows[0]["QuantityDeviceSendResult"];
                //
                ConfigConnection.WriteBit.AliveBit = (int)dt.Rows[0]["AliveBit"];
                //
                ConfigConnection.ReadData.NameDeviceTrigerReadError = (int)dt.Rows[0]["NameDeviceTrigerReadError"];
                ConfigConnection.WriteBit.NameDeviceSendConfirm = (int)dt.Rows[0]["NameDeviceSendConfirm"];
            }
            else
            {
                throw (new Exception("Không tìm thấy dữ liệu ConfigConnectPLC. Xem datatable: ConfigConnectionPlc"));
            }

            
        }

      

        public void innitchart()
        {
            innitStackedbarchart();
            innitpiechart();
            innitbarchart();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #region
        //Random rd = new Random();
        //Random rd2 = new Random();
        //int index = 10;
        //int STT = 1;
        //private void Time1_Tick(object sender, EventArgs e)
        //{
        //    index++;
        //    int values2 = rd2.Next(0, 10);
        //    string timecheck = DateTime.Now.ToString();
        //    List_Result_Check_Final.Clear();
        //    ResultCheckFinal Result_Check_Final = new ResultCheckFinal();
        //    if (values2 < 8)
        //    {
        //        dataforlistview.Add(new ResultMain(STT, $"ABCDEFGHIK{index}", "OK", timecheck));
        //        Result_Check_Final.Judge_VP = "OK";
        //        Result_Check_Final.Judge_GAS = "OK";
        //        Result_Check_Final.Judge_WI1WITH = "OK";

        //        Result_Check_Final.Judge_WI1START = "OK";

        //        Result_Check_Final.Judge_IP = "OK";

        //        Result_Check_Final.Judge_DF = "OK";

        //        Result_Check_Final.Judge_TEMP = "OK";

        //        Result_Check_Final.Judge_IOT = "OK";

        //        Result_Check_Final.Judge_WI2 = "OK";

        //        Result_Check_Final.Judge_PAN = "OK";

        //        Result_Check_Final.Judge_CAMBACK = "OK";

        //        Result_Check_Final.Judge_CAMFRONT = "OK";



        //        ModelCurrent = $"ABCDEFGHIK";
        //        SerialCurrent = index.ToString();
        //        gr_header.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x45, 0xCD, 0x45));
        //        VPOK.Value++;
        //        GASOILOK.Value++;
        //        WI1WITHOK.Value++;
        //        WI1STARTOK.Value++;
        //        IPOK.Value++;
        //        DFOK.Value++;
        //        TEMPOK.Value++;
        //        IOTOK.Value++;
        //        WI2OK.Value++;
        //        PANOK.Value++;
        //        CAMBACKOK.Value++;
        //        CAMFRONTOK.Value++;
        //        TotalOK.Value++;
        //    }
        //    else
        //    {
        //        dataforlistview.Add(new ResultMain(STT, $"ABCDEFGHIK{index}", "NG", timecheck));
        //        ModelCurrent = $"ABCDEFGHI";
        //        SerialCurrent = index.ToString();
        //        gr_header.Background = new SolidColorBrush(Colors.Red);
        //        for (int i = 0; i < 12; i++)
        //        {
        //            int values = rd.Next(0, 20);
        //            switch (i)
        //            {
        //                case 0:
        //                    if (values < 3)
        //                    {
        //                        VPOK.Value++;
        //                        Result_Check_Final.Judge_VP = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        VPNG.Value++;
        //                        Result_Check_Final.Judge_VP = "NG";
        //                    }
        //                    else
        //                    {
        //                        VPPENDING.Value++;
        //                        Result_Check_Final.Judge_VP = "Pending";
        //                    }
        //                    break;
        //                case 1:
        //                    if (values < 3)
        //                    {
        //                        GASOILOK.Value++;
        //                        Result_Check_Final.Judge_GAS = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        GASOILNG.Value++;
        //                        Result_Check_Final.Judge_GAS = "NG";
        //                    }
        //                    else
        //                    {
        //                        GASOILPENDING.Value++;
        //                        Result_Check_Final.Judge_GAS = "Pending";
        //                    }
        //                    break;
        //                case 2:
        //                    if (values < 3)
        //                    {
        //                        WI1WITHOK.Value++;
        //                        Result_Check_Final.Judge_WI1WITH = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        WI1WITHNG.Value++;
        //                        Result_Check_Final.Judge_WI1WITH = "NG";
        //                    }
        //                    else
        //                    {
        //                        WI1WITHPENDING.Value++;
        //                        Result_Check_Final.Judge_WI1WITH = "Pending";
        //                    }
        //                    break;
        //                case 3:
        //                    if (values < 3)
        //                    {
        //                        WI1STARTOK.Value++;
        //                        Result_Check_Final.Judge_WI1START = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        WI1STARTNG.Value++;
        //                        Result_Check_Final.Judge_WI1START = "NG";
        //                    }
        //                    else
        //                    {
        //                        WI1STARTPENDING.Value++;
        //                        Result_Check_Final.Judge_WI1START = "Pending";
        //                    }
        //                    break;
        //                case 4:
        //                    if (values < 3)
        //                    {
        //                        IPOK.Value++;
        //                        Result_Check_Final.Judge_IP = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        IPNG.Value++;
        //                        Result_Check_Final.Judge_IP = "NG";
        //                    }
        //                    else
        //                    {
        //                        IPPENDING.Value++;
        //                        Result_Check_Final.Judge_IP = "Pending";
        //                    }
        //                    break;
        //                case 5:
        //                    if (values < 3)
        //                    {
        //                        DFOK.Value++;
        //                        Result_Check_Final.Judge_DF = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        DFNG.Value++;
        //                        Result_Check_Final.Judge_DF = "NG";
        //                    }
        //                    else
        //                    {
        //                        DFPENDING.Value++;
        //                        Result_Check_Final.Judge_DF = "Pending";
        //                    }
        //                    break;
        //                case 6:
        //                    if (values < 3)
        //                    {
        //                        TEMPOK.Value++;
        //                        Result_Check_Final.Judge_TEMP = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        TEMPNG.Value++;
        //                        Result_Check_Final.Judge_TEMP = "NG";
        //                    }
        //                    else
        //                    {
        //                        TEMPPENDING.Value++;
        //                        Result_Check_Final.Judge_TEMP = "Pending";
        //                    }
        //                    break;
        //                case 7:
        //                    if (values < 3)
        //                    {
        //                        IOTOK.Value++;
        //                        Result_Check_Final.Judge_IOT = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        IOTNG.Value++;
        //                        Result_Check_Final.Judge_IOT = "NG";
        //                    }
        //                    else
        //                    {
        //                        IOTPENDING.Value++;
        //                        Result_Check_Final.Judge_IOT = "Pending";
        //                    }
        //                    break;
        //                case 8:
        //                    if (values < 3)
        //                    {
        //                        PANOK.Value++;
        //                        Result_Check_Final.Judge_PAN = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        PANNG.Value++;
        //                        Result_Check_Final.Judge_PAN = "NG";
        //                    }
        //                    else
        //                    {
        //                        PANPENDING.Value++;
        //                        Result_Check_Final.Judge_PAN = "Pending";
        //                    }
        //                    break;
        //                case 9:
        //                    if (values < 3)
        //                    {
        //                        CAMBACKOK.Value++;
        //                        Result_Check_Final.Judge_CAMBACK = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        CAMBACKNG.Value++;
        //                        Result_Check_Final.Judge_CAMBACK = "NG";
        //                    }
        //                    else
        //                    {
        //                        CAMBACKPENDING.Value++;
        //                        Result_Check_Final.Judge_CAMBACK = "Pending";
        //                    }
        //                    break;
        //                case 10:
        //                    if (values < 3)
        //                    {
        //                        CAMFRONTOK.Value++;
        //                        Result_Check_Final.Judge_CAMFRONT = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        CAMFRONTNG.Value++;
        //                        Result_Check_Final.Judge_CAMFRONT = "NG";
        //                    }
        //                    else
        //                    {
        //                        CAMFRONTPENDING.Value++;
        //                        Result_Check_Final.Judge_CAMFRONT = "Pending";
        //                    }
        //                    break;
        //                case 11:
        //                    if (values < 3)
        //                    {
        //                        WI2OK.Value++;
        //                        Result_Check_Final.Judge_WI2 = "OK";
        //                    }
        //                    else if (values < 12)
        //                    {
        //                        WI2NG.Value++;
        //                        Result_Check_Final.Judge_WI2 = "NG";
        //                    }
        //                    else
        //                    {
        //                        WI2PENDING.Value++;
        //                        Result_Check_Final.Judge_WI2 = "Pending";
        //                    }
        //                    break;
        //            }
        //        }
        //        TotalNG.Value++;




        //    }
        //    STT++;
        //    List_Result_Check_Final.Add(Result_Check_Final);

        //}
        #endregion
        public void innitproperty()
        {

            dataforlistview = new ObservableCollection<ResultMain>();

            List_Result_Check_Final = new ObservableCollection<ResultCheckFinal>();

            TotalOK = new ObservableValue(0);
            TotalNG = new ObservableValue(0);
            //TotalPending = new ObservableValue(0);

            VPOK = new ObservableValue(0);
            GASOILOK = new ObservableValue(0);
            WI1WITHOK = new ObservableValue(0);
            WI1STARTOK = new ObservableValue(0);
            IPOK = new ObservableValue(0);
            DFOK = new ObservableValue(0);
            TEMPOK = new ObservableValue(0);
            IOTOK = new ObservableValue(0);
            WI2OK = new ObservableValue(0);
            PANOK = new ObservableValue(0);
            CAMBACKOK = new ObservableValue(0);
            CAMFRONTOK = new ObservableValue(0);


            VPNG = new ObservableValue(0);
            GASOILNG = new ObservableValue(0);
            WI1WITHNG = new ObservableValue(0);
            WI1STARTNG = new ObservableValue(0);
            IPNG = new ObservableValue(0);
            DFNG = new ObservableValue(0);
            TEMPNG = new ObservableValue(0);
            IOTNG = new ObservableValue(0);
            WI2NG = new ObservableValue(0);
            PANNG = new ObservableValue(0);
            CAMBACKNG = new ObservableValue(0);
            CAMFRONTNG = new ObservableValue(0);


            VPPENDING = new ObservableValue(0);
            GASOILPENDING = new ObservableValue(0);
            WI1WITHPENDING = new ObservableValue(0);
            WI1STARTPENDING = new ObservableValue(0);
            IPPENDING = new ObservableValue(0);
            DFPENDING = new ObservableValue(0);
            TEMPPENDING = new ObservableValue(0);
            IOTPENDING = new ObservableValue(0);
            WI2PENDING = new ObservableValue(0);
            PANPENDING = new ObservableValue(0);
            CAMBACKPENDING = new ObservableValue(0);
            CAMFRONTPENDING = new ObservableValue(0);

            Labels = new[] { "VP", "Nạp Gas", "WI1 W", "WI1 S", "IP", "DF", "TEMP", "IOT", "WI2", "PAN", "CAM B", "CAM F" };
        }

        public void innitStackedbarchart()
        {


            datastackchart = new SeriesCollection()
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<ObservableValue> { VPOK, GASOILOK, WI1WITHOK, WI1STARTOK, IPOK, DFOK, TEMPOK, IOTOK,WI2OK, PANOK, CAMBACKOK, CAMFRONTOK},
                    StackMode = StackMode.Values,
                     DataLabels = true,
                     Fill =new SolidColorBrush(Colors.Green),
                     Title = "OK"
                },
                 new StackedColumnSeries
                {
                    Values = new ChartValues<ObservableValue> { VPPENDING, GASOILPENDING, WI1WITHPENDING, WI1STARTPENDING, IPPENDING, DFPENDING, TEMPPENDING, IOTPENDING,WI2PENDING,PANPENDING, CAMBACKPENDING, CAMFRONTPENDING},
                    StackMode = StackMode.Values,
                     DataLabels = true,
                     Fill =new SolidColorBrush(Colors.Orange),
                     Title = "Pending"
                },
                 new StackedColumnSeries
                {
                     Values = new ChartValues<ObservableValue> { VPNG, GASOILNG, WI1WITHNG, WI1STARTNG, IPNG, DFNG, TEMPNG, IOTNG,WI2NG, PANNG, CAMBACKNG,CAMFRONTNG},
                        StackMode = StackMode.Values,
                     DataLabels = true,
                      Fill =new SolidColorBrush(Colors.Red),
                      Title = "NG"
                }

            };

        }

        public void innitpiechart()
        {
            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            datapiechart = new SeriesCollection()
            {
                new PieSeries
                {
                   Values = new ChartValues<ObservableValue> { TotalOK },
                   LabelPoint = PointLabel,
                   DataLabels= true,
                   Title = "OK",
                   Fill = new SolidColorBrush(Colors.Green)

                },
                new PieSeries
                {
                     Values = new ChartValues<ObservableValue> { TotalNG },
                     LabelPoint = PointLabel,
                      DataLabels= true,
                     Title = "NG",
                      Fill = new SolidColorBrush(Colors.Red)
                }

            };

        }
        public void innitbarchart()
        {
            databarchartNG = new SeriesCollection()
            {
                new ColumnSeries
                {
                     Values = new ChartValues<ObservableValue> { VPNG, GASOILNG, WI1WITHNG, WI1STARTNG, IPNG, DFNG, TEMPNG, IOTNG,WI2NG, PANNG, CAMBACKNG, CAMFRONTNG},
                     DataLabels = true,
                     Fill = new SolidColorBrush(Colors.Red),
                     Title = "NG"

                }

            };
            databarchartPending = new SeriesCollection()
            {
                new ColumnSeries
                {
                     Values = new ChartValues<ObservableValue> { VPPENDING, GASOILPENDING, WI1WITHPENDING, WI1STARTPENDING, IPPENDING, DFPENDING, TEMPPENDING, IOTPENDING,WI2PENDING,PANPENDING, CAMBACKPENDING, CAMFRONTPENDING},
                     DataLabels = true,
                     Fill = new SolidColorBrush(Colors.Orange),
                     Title = "Pending",

                }

            };
            Formatter = value => value.ToString();
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{



        //}



        private async void lv1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            await showdetail();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btn_open.IsChecked == true)
            {
                btn_open.IsChecked = false;
            }
        }

        private void btn_report_Click(object sender, RoutedEventArgs e)
        {
            if (btn_open.IsChecked == true)
            {
                btn_open.IsChecked = false;
            }
        }

        private void btn_config_Click(object sender, RoutedEventArgs e)
        {
            if (btn_open.IsChecked == true)
            {
                btn_open.IsChecked = false;
            }
            Login p = new Login();
            p.ShowDialog();
        }

        private async void btn_History_Click(object sender, RoutedEventArgs e)
        {
            if (btn_open.IsChecked == true)
            {
                btn_open.IsChecked = false;
            }
            await showhistory();
        }
        public async Task showdetail()
        {
            Task result;
            result = new Task(() =>
            {
                this.Dispatcher?.Invoke(new Action(() =>
                {
                    ResultMain dt = (ResultMain)lv1.SelectedItem;
                    DataDetail p = new DataDetail(dt.Cabinet);
                    p.Show();
                }));
            });
            result.Start();
            await result;
        }
        public async Task showhistory()
        {
            Task result;
            result = new Task(() =>
            {
                this.Dispatcher?.Invoke(new Action(() =>
                {
                    History p = new History();
                    p.Show();
                }));
            });
            result.Start();
            await result;
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

        private void lv_rsdetail_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;
            var workingWidth = listView.ActualWidth;
            double with = 0.083;
            gView.Columns[0].Width = workingWidth * with;
            gView.Columns[1].Width = workingWidth * with;
            gView.Columns[2].Width = workingWidth * with;
            gView.Columns[3].Width = workingWidth * with;
            gView.Columns[4].Width = workingWidth * with;
            gView.Columns[5].Width = workingWidth * with;
            gView.Columns[6].Width = workingWidth * with;
            gView.Columns[7].Width = workingWidth * with;
            gView.Columns[8].Width = workingWidth * with;
            gView.Columns[9].Width = workingWidth * with;
            gView.Columns[10].Width = workingWidth * with;
            gView.Columns[11].Width = workingWidth * with;
        }


        //Load Data For Chart

        public void LoadDataForChart()
        {
            DbConnect db_connect = new DbConnect();
            DataTable dt = db_connect.StoreFillDT("", CommandType.StoredProcedure, "");
            //OK
            if (dt.Rows.Count > 0)
            {
                VPOK.Value = (double)dt.Rows[0]["VPOK"];
                GASOILOK.Value = (double)dt.Rows[0]["GASOILOK"];
                WI1WITHOK.Value = (double)dt.Rows[0]["WI1WITHOK"];
                WI1STARTOK.Value = (double)dt.Rows[0]["WI1STARTOK"];
                IPOK.Value = (double)dt.Rows[0]["IPOK"];
                DFOK.Value = (double)dt.Rows[0]["DFOK"];
                TEMPOK.Value = (double)dt.Rows[0]["TEMPOK"];
                IOTOK.Value = (double)dt.Rows[0]["IOTOK"];
                WI2OK.Value = (double)dt.Rows[0]["WI2OK"];
                PANOK.Value = (double)dt.Rows[0]["PANOK"];
                CAMBACKOK.Value = (double)dt.Rows[0]["CAMBACKOK"];
                CAMFRONTOK.Value = (double)dt.Rows[0]["CAMFRONTOK"];
                //NG
                VPNG.Value = (double)dt.Rows[0]["VPNG"];
                GASOILNG.Value = (double)dt.Rows[0]["GASOILNG"];
                WI1WITHNG.Value = (double)dt.Rows[0]["WI1WITHNG"];
                WI1STARTNG.Value = (double)dt.Rows[0]["WI1STARTNG"];
                IPNG.Value = (double)dt.Rows[0]["IPNG"];
                DFNG.Value = (double)dt.Rows[0]["DFNG"];
                TEMPNG.Value = (double)dt.Rows[0]["TEMPNG"];
                IOTNG.Value = (double)dt.Rows[0]["IOTNG"];
                WI2NG.Value = (double)dt.Rows[0]["WI2NG"];
                PANNG.Value = (double)dt.Rows[0]["PANNG"];
                CAMBACKNG.Value = (double)dt.Rows[0]["CAMBACKNG"];
                CAMFRONTNG.Value = (double)dt.Rows[0]["CAMFRONTNG"];
                //PENDING
                VPPENDING.Value = (double)dt.Rows[0]["VPPENDING"];
                GASOILPENDING.Value = (double)dt.Rows[0]["GASOILPENDING"];
                WI1WITHPENDING.Value = (double)dt.Rows[0]["WI1WITHPENDING"];
                WI1STARTPENDING.Value = (double)dt.Rows[0]["WI1STARTPENDING"];
                IPPENDING.Value = (double)dt.Rows[0]["IPPENDING"];
                DFPENDING.Value = (double)dt.Rows[0]["DFPENDING"];
                TEMPPENDING.Value = (double)dt.Rows[0]["TEMPPENDING"];
                IOTPENDING.Value = (double)dt.Rows[0]["IOTPENDING"];
                WI2PENDING.Value = (double)dt.Rows[0]["WI2PENDING"];
                PANPENDING.Value = (double)dt.Rows[0]["PANPENDING"];
                CAMBACKPENDING.Value = (double)dt.Rows[0]["CAMBACKPENDING"];
                CAMFRONTPENDING.Value = (double)dt.Rows[0]["CAMFRONTPENDING"];
                //Total
                TotalOK.Value = (double)dt.Rows[0]["TotalOK"];
                TotalNG.Value = (double)dt.Rows[0]["TotalNG"];
            }
        }
        public ResultCheckFinal LoadDataForCabi(string cabinet)
        {
            List_Result_Check_Final.Clear();
            DbConnect db_connect = new DbConnect();
            ResultCheckFinal RCF = new ResultCheckFinal();
            DataTable dt = db_connect.StoreFillDT("GetJudgeAllLine", CommandType.StoredProcedure, cabinet);
            if (dt.Rows.Count > 0)
            {
                //
                if (dt.Rows[0]["JudgeVP"].ToString() == "OK" && dt.Rows[0]["JudgeVP"].ToString() == "NG")
                {
                    RCF.Judge_VP = dt.Rows[0]["JudgeVP"].ToString();
                }
                else
                {
                    RCF.Judge_VP = "PD";
                }
                //
                if (dt.Rows[0]["JudgeGAS"].ToString() == "OK" && dt.Rows[0]["JudgeGAS"].ToString() == "NG")
                {
                    RCF.Judge_GAS = dt.Rows[0]["Judge_GAS"].ToString();
                }
                else
                {
                    RCF.Judge_GAS = "PD";
                }
                //
                if (dt.Rows[0]["JudgeWI1WITH"].ToString() == "OK" && dt.Rows[0]["JudgeWI1WITH"].ToString() == "NG")
                {
                    RCF.Judge_WI1WITH = dt.Rows[0]["JudgeWI1WITH"].ToString();
                }
                else
                {
                    RCF.Judge_WI1WITH = "PD";
                }
                //
                if (dt.Rows[0]["JudgeWI1START"].ToString() == "OK" && dt.Rows[0]["JudgeWI1START"].ToString() == "NG")
                {
                    RCF.Judge_WI1START = dt.Rows[0]["Judge_WI1START"].ToString();
                }
                else
                {
                    RCF.Judge_WI1START = "PD";
                }
                //
                if (dt.Rows[0]["JudgeIP"].ToString() == "OK" && dt.Rows[0]["JudgeIP"].ToString() == "NG")
                {
                    RCF.Judge_IP = dt.Rows[0]["JudgeIP"].ToString();
                }
                else
                {
                    RCF.Judge_IP = "PD";
                }
                //
                if (dt.Rows[0]["JudgeDF"].ToString() == "OK" && dt.Rows[0]["JudgeDF"].ToString() == "NG")
                {
                    RCF.Judge_DF = dt.Rows[0]["JudgeDF"].ToString();
                }
                else
                {
                    RCF.Judge_DF = "PD";
                }
                //
                if (dt.Rows[0]["JudgeTEMP"].ToString() == "OK" && dt.Rows[0]["JudgeTEMP"].ToString() == "NG")
                {
                    RCF.Judge_TEMP = dt.Rows[0]["Judge_TEMP"].ToString();
                }
                else
                {
                    RCF.Judge_TEMP = "PD";
                }
                //
                if (dt.Rows[0]["JudgeIOT"].ToString() == "OK" && dt.Rows[0]["JudgeIOT"].ToString() == "NG")
                {
                    RCF.Judge_IOT = dt.Rows[0]["JudgeIOT"].ToString();
                }
                else
                {
                    RCF.Judge_IOT = "PD";
                }
                //
                if (dt.Rows[0]["JudgeWI2"].ToString() == "OK" && dt.Rows[0]["JudgeWI2"].ToString() == "NG")
                {
                    RCF.Judge_WI2 = dt.Rows[0]["JudgeWI2"].ToString();
                }
                else
                {
                    RCF.Judge_WI2 = "PD";
                }
                //
                if (dt.Rows[0]["JudgePAN"].ToString() == "OK" && dt.Rows[0]["JudgePAN"].ToString() == "NG")
                {
                    RCF.Judge_PAN = dt.Rows[0]["JudgePAN"].ToString();
                }
                else
                {
                    RCF.Judge_PAN = "PD";
                }
                //
                if (dt.Rows[0]["JudgeCAMBACK"].ToString() == "OK" && dt.Rows[0]["JudgeCAMBACK"].ToString() == "NG")
                {
                    RCF.Judge_CAMBACK = dt.Rows[0]["JudgeCAMBACK"].ToString();
                }
                else
                {
                    RCF.Judge_CAMBACK = "PD";
                }
                //
                if (dt.Rows[0]["JudgeCAMFRONT"].ToString() == "OK" && dt.Rows[0]["JudgeCAMFRONT"].ToString() == "NG")
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
            if (RCF.Judge_Total == "OK")
            {
                RCF.ReasonError = "";
                RCF.PersonConfirm = "";
                gr_header.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x45, 0xCD, 0x45));
            }
            else
            {
                gr_header.Background = new SolidColorBrush(Colors.Red);
            }
            List_Result_Check_Final.Add(RCF);
            return RCF;

        }
        //ControlPlc

        public async Task ControlPlc(int timeout)
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
                    if (await Plc.ReadBit(StreamPLc, timeout, "M", ConfigConnection.ReadData.NameDeviceTrigerReadCabi))
                    {
                        string DataCabi = (string)await Plc.ReadData(StreamPLc, timeout, "D", ConfigConnection.ReadData.NameDeviceDataCabi, ConfigConnection.ReadData.QuantityDataCabi, "String");
                        if (DataCabi != null && DataCabi.Length >= 19)
                        {
                            ModelCurrent = DataCabi.Substring(0, 12);
                            SerialCurrent = DataCabi.Substring(12, 7);
                            ResultCheckFinal RCF = LoadDataForCabi(DataCabi.Substring(0, 19));
                            if (RCF.Judge_Total == "OK")
                            {
                                //Save Data Sql
                                SaveDataFinal(DataCabi, RCF);
                                //
                                await Plc.WriteASCII(StreamPLc, timeout, "D", ConfigConnection.WriteData.NameDeviceSendResult, ConfigConnection.WriteData.QuantityDeviceSendResult, "OKOKOKOKOKOKOKOKOKOKOKOKOK");
                            }
                            else
                            {
                                SaveDataFinal(DataCabi, RCF);
                                string rs = RCF.Judge_VP + RCF.Judge_GAS + RCF.Judge_WI1WITH + RCF.Judge_WI1START + RCF.Judge_IP + RCF.Judge_DF + RCF.Judge_TEMP + RCF.Judge_IOT + RCF.Judge_WI2 + RCF.Judge_PAN + RCF.Judge_CAMBACK + RCF.Judge_CAMFRONT + RCF.Judge_Total;
                                await Plc.WriteASCII(StreamPLc, timeout, "D", ConfigConnection.WriteData.NameDeviceSendResult, ConfigConnection.WriteData.QuantityDeviceSendResult, rs);
                                //rs_NG = true;
                            }
                        }
                        else
                        {
                            await Plc.WriteASCII(StreamPLc, timeout, "D", ConfigConnection.WriteData.NameDeviceSendResult, ConfigConnection.WriteData.QuantityDeviceSendResult, "NoDataCabi");
                        }

                    }
                    tcpclient.Close();
                }
                if (rs_NG)
                {
                    //Hiểm thị thông tin lỗi:
                }
            }
            catch (Exception)
            {

                
            }
           

        }
        public void SaveDataFinal(string CodeModel,ResultCheckFinal rfc)
        {
            DbConnect db_connect = new DbConnect();
            db_connect.exnonquery("InsertDataFinalCheck", CommandType.StoredProcedure,CodeModel, rfc.Judge_VP, rfc.Judge_GAS, rfc.Judge_WI1WITH, rfc.Judge_WI1START, rfc.Judge_IP, rfc.Judge_DF, rfc.Judge_TEMP, rfc.Judge_IOT, rfc.Judge_WI2, rfc.Judge_PAN, rfc.Judge_CAMBACK, rfc.Judge_CAMFRONT, rfc.Judge_Total, rfc.ReasonError, rfc.PersonConfirm);
        }
        private async void TimerCheck_Tick(object sender, EventArgs e)
        {
            if (!check_run&&!rs_NG)
            {
                check_run = true;
               // await ControlPlc(5000);
                check_run = false;
            }
        }

        private void MainForm_Closed(object sender, EventArgs e)
        {
            TimerCheck.Stop();
            Environment.Exit(0);
        }
    }
}
