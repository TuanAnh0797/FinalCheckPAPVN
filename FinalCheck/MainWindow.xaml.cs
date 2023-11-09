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

namespace FinalCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer time1 = new DispatcherTimer();
        public Func<double, string> Formatter { get; set; }
        public ObservableCollection<ListErrorFileCheck> myListErrorFileCheck { set; get; }
        public SeriesCollection mydata1 { set; get; }
        public SeriesCollection mydata2 { set; get; }
        public SeriesCollection mydata3 { set; get; }

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

        public ObservableValue TotalOK { get; set; }

        public ObservableValue TotalNG { get; set; }
       

        public string[] Labels { get; set; }



        public MainWindow()
        {
           
            InitializeComponent();
            DataContext = this;
            time1.Interval = TimeSpan.FromSeconds(2);
            
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
        private void Time1_Tick(object sender, EventArgs e)
        {
            
             int values = rd.Next(1, 8);
            int values2 = rd2.Next(0, 10);
            if (values2 > 3)
            {
                switch (values)
                {
                    case 1:
                        Condition1OK.Value++;
                        break;
                    case 2:
                        Condition2OK.Value++;
                        break;
                    case 3:
                        Condition3OK.Value++;
                        break;
                    case 4:
                        Condition4OK.Value++;
                        break;
                    case 5:
                        Condition5OK.Value++;
                        break;
                    case 6:
                        Condition6OK.Value++;
                        break;
                    case 7:
                        Condition7OK.Value++;
                        break;
                    case 8:
                        Condition8OK.Value++;
                        break;
                }
            }
            else
            {
                switch (values)
                {
                    case 1:
                        Condition1NG.Value++;
                        break;
                    case 2:
                        Condition2NG.Value++;
                        break;
                    case 3:
                        Condition3NG.Value++;
                        break;
                    case 4:
                        Condition4NG.Value++;
                        break;
                    case 5:
                        Condition5NG.Value++;
                        break;
                    case 6:
                        Condition6NG.Value++;
                        break;
                    case 7:
                        Condition7NG.Value++;
                        break;
                    case 8:
                        Condition8NG.Value++;
                        break;
                }
            }

            TotalOK.Value = Condition1OK.Value + Condition2OK.Value + Condition3OK.Value + Condition4OK.Value + Condition5OK.Value + Condition6OK.Value + Condition7OK.Value + Condition8OK.Value;
            TotalNG.Value = Condition1NG.Value + Condition2NG.Value + Condition3NG.Value + Condition4NG.Value + Condition5NG.Value + Condition6NG.Value + Condition7NG.Value + Condition8NG.Value;
            //randomcalue(Condition1OK, Condition1NG, rd);
            //randomcalue(Condition2OK, Condition2NG, new Random());
            //randomcalue(Condition3OK, Condition3NG, new Random());
            //randomcalue(Condition4OK, Condition4NG, new Random());
            //randomcalue(Condition5OK, Condition5NG, new Random());
            //randomcalue(Condition6OK, Condition6NG, new Random());
            //randomcalue(Condition7OK, Condition7NG, new Random());
            //randomcalue(Condition8OK, Condition8NG, new Random());

        }
        public void innitproperty()
        {
            myListErrorFileCheck = new ObservableCollection<ListErrorFileCheck>();

            TotalOK = new ObservableValue(0);
            TotalNG = new ObservableValue(0);

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
        }
        
        public void innitStackedbarchart()
        {
            

            mydata1 = new SeriesCollection()
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<ObservableValue> { Condition1OK, Condition2OK, Condition3OK, Condition4OK, Condition5OK, Condition6OK, Condition7OK, Condition8OK},
                    StackMode = StackMode.Values,
                     DataLabels = true
                },
                new StackedColumnSeries
                {
                     Values = new ChartValues<ObservableValue> { Condition1NG, Condition2NG, Condition3NG, Condition4NG, Condition5NG, Condition6NG, Condition7NG, Condition8NG},
                    StackMode = StackMode.Values,
                     DataLabels = true

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
                   Title = "OK"

                },
                new PieSeries
                {
                     Values = new ChartValues<ObservableValue> { TotalNG },
                     LabelPoint = PointLabel,
                      DataLabels= true,
                     Title = "NG"

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
            Labels = new[] { "Condition1", "Condition2", "Condition3", "Condition4", "Condition5", "Condition6", "Condition7", "Condition8" };
            Formatter = value => value.ToString();
        }
        public void innitlistview()
        {
            string timecheck = DateTime.Now.ToString();
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA1", DateCreate = timecheck, DateModify = "NG", FileName = "OK", FilePath = "OK", Statuscheck = "NG" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA2", DateCreate = timecheck, DateModify = "NG", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHAG", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA1", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA2", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHAG", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "Pending" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA1", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA2", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHAG", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA1", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA2", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHAG", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA1", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA2", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHAG", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA1", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA2", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHAG", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "NG" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA1", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA2", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHAG", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA1", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA2", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHAG", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA1", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA2", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHAG", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA1", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHA2", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });
            myListErrorFileCheck.Add(new ListErrorFileCheck() { NameModel = "NR-ABCGAHSGDHAGDHAG", DateCreate = timecheck, DateModify = "OK", FileName = "OK", FilePath = "OK", Statuscheck = "OK" });

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
    }

}
