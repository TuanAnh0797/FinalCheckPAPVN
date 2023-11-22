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
using TALibrary;


namespace FinalCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        DispatcherTimer time1 = new DispatcherTimer();
        public Func<double, string> Formatter { get; set; }
        public ObservableCollection<ResultMain> dataforlistview { set; get; }


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

        public ObservableValue TotalPending { get; set; }


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
            ModelCurrent = "";
            DataContext = this;
            time1.Interval = TimeSpan.FromSeconds(5);
            
            innitproperty();
            innitStackedbarchart();
            innitpiechart();
            innitbarchart();
            innitlistview();
            time1.Start();
            time1.Tick += Time1_Tick;

        }
        Random rd = new Random();
        Random rd2 = new Random();
        int index = 10;
        int STT = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        private void Time1_Tick(object sender, EventArgs e)
        {
            index++;
            
            int values2 = rd2.Next(0,10);
            string timecheck = DateTime.Now.ToString();

            if (values2 < 8 )
            {
                dataforlistview.Add(new ResultMain(STT, $"ABCDEFGHIK{index}","OK",timecheck) );
                ModelCurrent = $"ABCDEFGHIK";
                SerialCurrent =  index.ToString();
                gr_header.Background = new SolidColorBrush(Colors.Green);
                VPOK.Value++;
                GASOILOK.Value++;
                WI1WITHOK.Value++;
                WI1STARTOK.Value++;
                IPOK.Value++;
                DFOK.Value++;
                TEMPOK.Value++;
                IOTOK.Value++;
                WI2OK.Value++;
                PANOK.Value++;
                CAMBACKOK.Value++;
                CAMFRONTOK.Value++;
                TotalOK.Value++;
            }
            else 
            {
                dataforlistview.Add(new ResultMain(STT, $"ABCDEFGHIK{index}", "NG", timecheck));
                ModelCurrent = $"ABCDEFGHI";
                SerialCurrent = index.ToString();
                gr_header.Background = new SolidColorBrush(Colors.Red);
                for (int i = 0; i < 12; i++)
                {
                    int values = rd.Next(0, 20);
                    switch (i)
                    {
                        case 0:
                            if (values < 3)
                            {
                                VPOK.Value++;
                            }
                            else if (values < 12)
                            {
                                VPNG.Value++;
                            }
                            else
                            {
                                VPPENDING.Value++;
                            }
                            break;
                        case 1:
                            if (values < 3)
                            {
                                GASOILOK.Value++;
                            }
                            else if (values < 12)
                            {
                                GASOILNG.Value++;
                            }
                            else
                            {
                                GASOILPENDING.Value++;
                            }
                            break;
                        case 2:
                            if (values < 3)
                            {
                                WI1WITHOK.Value++;
                            }
                            else if (values < 12)
                            {
                                WI1WITHNG.Value++;
                            }
                            else
                            {
                                WI1WITHPENDING.Value++;
                            }
                            break;
                        case 3:
                            if (values < 3)
                            {
                                WI1STARTOK.Value++;
                            }
                            else if (values < 12)
                            {
                                WI1STARTNG.Value++;
                            }
                            else
                            {
                                WI1STARTPENDING.Value++;
                            }
                            break;
                        case 4:
                            if (values < 3)
                            {
                                IPOK.Value++;
                            }
                            else if (values < 12)
                            {
                                IPNG.Value++;
                            }
                            else
                            {
                                IPPENDING.Value++;
                            }
                            break;
                        case 5:
                            if (values < 3)
                            {
                                DFOK.Value++;
                            }
                            else if (values < 12)
                            {
                                DFNG.Value++;
                            }
                            else
                            {
                                DFPENDING.Value++;
                            }
                            break;
                        case 6:
                            if (values < 3)
                            {
                                TEMPOK.Value++;
                            }
                            else if (values < 12)
                            {
                                TEMPNG.Value++;
                            }
                            else
                            {
                                TEMPPENDING.Value++;
                            }
                            break;
                        case 7:
                            if (values < 3)
                            {
                                IOTOK.Value++;
                            }
                            else if (values < 12)
                            {
                                IOTNG.Value++;
                            }
                            else
                            {
                                IOTPENDING.Value++;
                            }
                            break;
                        case 8:
                            if (values < 3)
                            {
                                PANOK.Value++;
                            }
                            else if (values < 12)
                            {
                                PANNG.Value++;
                            }
                            else
                            {
                                PANPENDING.Value++;
                            }
                            break;
                        case 9:
                            if (values < 3)
                            {
                                CAMBACKOK.Value++;
                            }
                            else if (values < 12)
                            {
                                CAMBACKNG.Value++;
                            }
                            else
                            {
                                CAMBACKPENDING.Value++;
                            }
                            break;
                        case 10:
                            if (values < 3)
                            {
                                CAMFRONTOK.Value++;
                            }
                            else if (values < 12)
                            {
                                CAMFRONTNG.Value++;
                            }
                            else
                            {
                                CAMFRONTPENDING.Value++;
                            }
                            break;
                        case 11:
                            if (values < 3)
                            {
                                WI2OK.Value++;
                            }
                            else if (values < 12)
                            {
                                WI2NG.Value++;
                            }
                            else
                            {
                                WI2PENDING.Value++;
                            }
                            break;
                    }
                }
                TotalNG.Value++;
               
                
            }
            STT++;


        }
        public void innitproperty()
        {
            dataforlistview = new ObservableCollection<ResultMain>();

            TotalOK = new ObservableValue(0);
            TotalNG = new ObservableValue(0);
            TotalPending = new ObservableValue(0);

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

            Labels = new[] { "VP", "Nạp Gas", "WI1 W", "WI1 S", "IP", "DF", "TEMP", "IOT","WI2", "PAN", "CAM B", "CAM F" };
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
        public void innitlistview()
        {


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           


        }



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
            double with = 0.07;
            gView.Columns[0].Width = workingWidth * 0.16;
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
            gView.Columns[12].Width = workingWidth * with;
        }
    }

}
