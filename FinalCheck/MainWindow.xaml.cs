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

namespace FinalCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        DispatcherTimer time1 = new DispatcherTimer();
        public Func<double, string> Formatter { get; set; }
        public ObservableCollection<ListErrorFileCheck> myListErrorFileCheck { set; get; }


        public SeriesCollection mydata1 { set; get; }
        public SeriesCollection mydata2 { set; get; }
        public SeriesCollection mydata3 { set; get; }

        public SeriesCollection mydata4 { set; get; }

        public Func<ChartPoint, string> PointLabel { get; set; }
        public ObservableValue Condition1OK { get; set; }
        public ObservableValue Condition2OK { get; set; }
        public ObservableValue Condition3OK { get; set; }
        public ObservableValue Condition4OK { get; set; }
        public ObservableValue Condition5OK { get; set; }
        public ObservableValue Condition6OK { get; set; }
        public ObservableValue Condition7OK { get; set; }
        public ObservableValue Condition8OK { get; set; }

        public ObservableValue Condition1NG { get; set; }
        public ObservableValue Condition2NG { get; set; }
        public ObservableValue Condition3NG { get; set; }
        public ObservableValue Condition4NG { get; set; }
        public ObservableValue Condition5NG { get; set; }
        public ObservableValue Condition6NG { get; set; }
        public ObservableValue Condition7NG { get; set; }
        public ObservableValue Condition8NG { get; set; }


        public ObservableValue Condition1Pending { get; set; }
        public ObservableValue Condition2Pending { get; set; }
        public ObservableValue Condition3Pending { get; set; }
        public ObservableValue Condition4Pending { get; set; }
        public ObservableValue Condition5Pending { get; set; }
        public ObservableValue Condition6Pending { get; set; }
        public ObservableValue Condition7Pending { get; set; }
        public ObservableValue Condition8Pending { get; set; }

        public ObservableValue TotalOK { get; set; }

        public ObservableValue TotalNG { get; set; }

        public ObservableValue TotalPending { get; set; }


        public string[] Labels { get; set; }

        private string curentdata;

        public string CurentData
        {
            get { return curentdata; }
            set
            {
                if (curentdata != value)
                {
                    curentdata = value;
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
            CurentData = "";
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void Time1_Tick(object sender, EventArgs e)
        {
            index++;
            
            int values2 = rd2.Next(0,10);
            string timecheck = DateTime.Now.ToString();

            if (values2 < 8 )
            {
                myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = $"ABCDEFGHIK{index}", DateCreate = timecheck, DateModify = "NG", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
                CurentData = $"ABCDEFGHIK{index}";
                gr_header.Background = new SolidColorBrush(Colors.Green);
                Condition1OK.Value++;
                Condition2OK.Value++;
                Condition3OK.Value++;
                Condition4OK.Value++;
                Condition5OK.Value++;
                Condition6OK.Value++;
                Condition7OK.Value++;
                Condition8OK.Value++;
                TotalOK.Value++;
            }
            else 
            {
                myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = $"ABCDEFGHIK{index}", DateCreate = timecheck, DateModify = "NG", FileName = "OK", FilePath = "OK", Statuscheck = "NG" });
                CurentData = $"ABCDEFGHIK{index}";
                gr_header.Background = new SolidColorBrush(Colors.Red);
                for (int i = 0; i < 8; i++)
                {
                    int values = rd.Next(0, 20);
                    switch (i)
                    {
                        case 0:
                            if (values < 3)
                            {
                                Condition1OK.Value++;
                            }
                            else if (values < 12)
                            {
                                Condition1NG.Value++;
                            }
                            else
                            {
                                Condition1Pending.Value++;
                            }
                            break;
                        case 1:
                            if (values < 3)
                            {
                                Condition2OK.Value++;
                            }
                            else if (values < 12)
                            {
                                Condition2NG.Value++;
                            }
                            else
                            {
                                Condition2Pending.Value++;
                            }
                            break;
                        case 2:
                            if (values < 3)
                            {
                                Condition3OK.Value++;
                            }
                            else if (values < 12)
                            {
                                Condition3NG.Value++;
                            }
                            else
                            {
                                Condition3Pending.Value++;
                            }
                            break;
                        case 3:
                            if (values < 3)
                            {
                                Condition4OK.Value++;
                            }
                            else if (values < 12)
                            {
                                Condition4NG.Value++;
                            }
                            else
                            {
                                Condition4Pending.Value++;
                            }
                            break;
                        case 4:
                            if (values < 3)
                            {
                                Condition5OK.Value++;
                            }
                            else if (values < 12)
                            {
                                Condition5NG.Value++;
                            }
                            else
                            {
                                Condition5Pending.Value++;
                            }
                            break;
                        case 5:
                            if (values < 3)
                            {
                                Condition6OK.Value++;
                            }
                            else if (values < 12)
                            {
                                Condition6NG.Value++;
                            }
                            else
                            {
                                Condition6Pending.Value++;
                            }
                            break;
                        case 6:
                            if (values < 3)
                            {
                                Condition7OK.Value++;
                            }
                            else if (values < 12)
                            {
                                Condition7NG.Value++;
                            }
                            else
                            {
                                Condition7Pending.Value++;
                            }
                            break;
                        case 7:
                            if (values < 3)
                            {
                                Condition8OK.Value++;
                            }
                            else if (values < 12)
                            {
                                Condition8NG.Value++;
                            }
                            else
                            {
                                Condition8Pending.Value++;
                            }
                            break;
                    }
                }
                TotalNG.Value++;
                
            }
          
        }
        public void innitproperty()
        {
            myListErrorFileCheck = new ObservableCollection<ListErrorFileCheck>();

            TotalOK = new ObservableValue(0);
            TotalNG = new ObservableValue(0);
            TotalPending = new ObservableValue(0);

            Condition1OK = new ObservableValue(0);
            Condition2OK = new ObservableValue(0);
            Condition3OK = new ObservableValue(0);
            Condition4OK = new ObservableValue(0);
            Condition5OK = new ObservableValue(0);
            Condition6OK = new ObservableValue(0);
            Condition7OK = new ObservableValue(0);
            Condition8OK = new ObservableValue(0);


            Condition1NG = new ObservableValue(0);
            Condition2NG = new ObservableValue(0);
            Condition3NG = new ObservableValue(0);
            Condition4NG = new ObservableValue(0);
            Condition5NG = new ObservableValue(0);
            Condition6NG = new ObservableValue(0);
            Condition7NG = new ObservableValue(0);
            Condition8NG = new ObservableValue(0);


            Condition1Pending = new ObservableValue(0);
            Condition2Pending = new ObservableValue(0);
            Condition3Pending = new ObservableValue(0);
            Condition4Pending = new ObservableValue(0);
            Condition5Pending = new ObservableValue(0);
            Condition6Pending = new ObservableValue(0);
            Condition7Pending = new ObservableValue(0);
            Condition8Pending = new ObservableValue(0);
        }
        
        public void innitStackedbarchart()
        {
            

            mydata1 = new SeriesCollection()
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<ObservableValue> { Condition1OK, Condition2OK, Condition3OK, Condition4OK, Condition5OK, Condition6OK, Condition7OK, Condition8OK},
                    StackMode = StackMode.Values,
                     DataLabels = true,
                     Fill =new SolidColorBrush(Colors.Blue)
                },
                 new StackedColumnSeries
                {
                    Values = new ChartValues<ObservableValue> { Condition1Pending, Condition2Pending, Condition3Pending, Condition4Pending, Condition5Pending, Condition6Pending, Condition7Pending, Condition8Pending},
                    StackMode = StackMode.Values,
                     DataLabels = true,
                     Fill =new SolidColorBrush(Colors.Orange)
                },
                 new StackedColumnSeries
                {
                     Values = new ChartValues<ObservableValue> { Condition1NG, Condition2NG, Condition3NG, Condition4NG, Condition5NG, Condition6NG, Condition7NG, Condition8NG},
                        StackMode = StackMode.Values,
                     DataLabels = true,
                      Fill =new SolidColorBrush(Colors.Red)
                }

            };
            Labels = new[] { "Condition1", "Condition2", "Condition3", "Condition4", "Condition5", "Condition6", "Condition7", "Condition8" };

        }

        public void innitpiechart()
        {
            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            mydata2 = new SeriesCollection()
            {
                new PieSeries
                {
                   Values = new ChartValues<ObservableValue> { TotalOK },
                   LabelPoint = PointLabel,
                   DataLabels= true,
                   Title = "OK",
                   Fill = new SolidColorBrush(Colors.Blue)

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
            mydata3 = new SeriesCollection()
            {
                new RowSeries
                {
                     Values = new ChartValues<ObservableValue> { Condition1NG, Condition2NG, Condition3NG, Condition4NG, Condition5NG, Condition6NG, Condition7NG, Condition8NG},
                     DataLabels = true,
                     Fill = new SolidColorBrush(Colors.Red)

                }

            };
            mydata4 = new SeriesCollection()
            {
                new RowSeries
                {
                     Values = new ChartValues<ObservableValue> { Condition1Pending, Condition2Pending, Condition3Pending, Condition4Pending, Condition5Pending, Condition6Pending, Condition7Pending, Condition8Pending},
                     DataLabels = true,
                     Fill = new SolidColorBrush(Colors.Orange)

                }

            };
            Labels = new[] { "Condition1", "Condition2", "Condition3", "Condition4", "Condition5", "Condition6", "Condition7", "Condition8" };
            Formatter = value => value.ToString();
        }
        public void innitlistview()
        {


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           


        }



        private void lv1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListErrorFileCheck dt = (ListErrorFileCheck)lv1.SelectedItem;
            //MessageBox.Show(dt.ToString());
            DataDetail p = new DataDetail();
            p.ShowDialog();
            
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btn_open.IsChecked == true)
            {
                btn_open.IsChecked = false;
            }
        }

        private void dtg_history_Selected(object sender, RoutedEventArgs e)
        {
            //ListErrorFileCheck dt = (ListErrorFileCheck)dtg_history.SelectedItem;
            //MessageBox.Show(dt.ToString());

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
        }

        private void btn_History_Click(object sender, RoutedEventArgs e)
        {
            if (btn_open.IsChecked == true)
            {
                btn_open.IsChecked = false;
            }
        }
    }

}
