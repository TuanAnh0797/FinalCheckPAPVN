using FinalCheck.DataBase;
using FinalCheck.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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
using System.Windows.Controls.Primitives;

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
            try
            {
                loaddatasql();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public void loaddatasql()
        {
            DbConnect dbc = new DbConnect();
            DataTable dt = dbc.StoreFillDT("GetConfigConnectPlc", CommandType.StoredProcedure);
            DataTable dt1 = dbc.StoreFillDT("GetConfigCheckFinal", CommandType.StoredProcedure);
            if (dt.Rows.Count > 0 && dt.Rows[0]["IpAddress"] != DBNull.Value)
            {
                txb_ip.Text = dt.Rows[0]["IpAddress"].ToString();
                txb_port.Text = dt.Rows[0]["PortNumber"].ToString();
                //
                txb_trigercabi.Text = dt.Rows[0]["NameDeviceTrigerReadCabi"].ToString();
                txb_datacabi.Text = dt.Rows[0]["NameDeviceDataCabi"].ToString();
                txb_UserConfirm.Text= dt.Rows[0]["NameDeviceDataPerson"].ToString();
                txb_ContentError.Text = dt.Rows[0]["NameDeviceDataReason"].ToString();
                //
               txb_result.Text = dt.Rows[0]["NameDeviceSendResult"].ToString();
                //
                txb_alive.Text = dt.Rows[0]["AliveBit"].ToString();
                txb_trigerError.Text = dt.Rows[0]["NameDeviceTrigerReadError"].ToString();
                txb_ConfirmFinish.Text = dt.Rows[0]["NameDeviceSendConfirm"].ToString();
            }
            else
            {
                throw (new Exception("Không tìm thấy dữ liệu ConfigConnectPLC. Xem datatable: ConfigConnectionPlc"));
            }
            if (dt1.Rows.Count > 0 && dt1.Rows[0]["VP"] != DBNull.Value)
            {
                //
                btn_VP.IsChecked = dt1.Rows[0]["VP"].ToString() == "1" ? true : false;
                //
                btn_gas.IsChecked = dt1.Rows[0]["GAS"].ToString() == "1" ? true : false;
                //
                btn_WI1WITH.IsChecked = dt1.Rows[0]["WI1WITH"].ToString() == "1" ? true : false;
                //
                btn_WI1START.IsChecked = dt1.Rows[0]["WI1START"].ToString() == "1" ? true : false;
                //
                btn_IP.IsChecked = dt1.Rows[0]["IP"].ToString() == "1" ? true : false;
                //
                btn_DF.IsChecked = dt1.Rows[0]["DF"].ToString() == "1" ? true : false;
                //
                btn_TEMP.IsChecked = dt1.Rows[0]["TEMP"].ToString() == "1" ? true : false;
                //
                btn_IOT.IsChecked = dt1.Rows[0]["IOT"].ToString() == "1" ? true : false;
                //
                btn_WI2.IsChecked = dt1.Rows[0]["WI2"].ToString() == "1" ? true : false;
                //
                btn_PAN.IsChecked = dt1.Rows[0]["PAN"].ToString() == "1" ? true : false;
                //
                btn_CAMBACK.IsChecked = dt1.Rows[0]["CAMBACK"].ToString() == "1" ? true : false;
                //
                btn_CAMFRONT.IsChecked = dt1.Rows[0]["CAMFRONT"].ToString() == "1" ? true : false;

            }
            else
            {
                throw (new Exception("Không tìm thấy dữ liệu ConfigConnectionCheckFinal. Xem datatable: ConfigConnectionCheckFinal"));
            }


        }
        public void Updatedatasql()
        {
            DbConnect dbc = new DbConnect();
            dbc.exnonquery("UpdateConfigConnectPlc", CommandType.StoredProcedure,
                txb_ip.Text,
                txb_port.Text,
                txb_trigercabi.Text,
                 txb_datacabi.Text,
                 txb_UserConfirm.Text,
                 txb_ContentError.Text,
                 txb_result.Text,
                 txb_alive.Text,
                 txb_ConfirmFinish.Text,
                  txb_trigerError.Text,
                  btn_VP.IsChecked,
                btn_gas.IsChecked,
               btn_WI1WITH.IsChecked,
                btn_WI1START.IsChecked,
                 btn_IP.IsChecked,
                 btn_DF.IsChecked,
                 btn_TEMP.IsChecked,
                 btn_IOT.IsChecked,
                    btn_WI2.IsChecked,
                 btn_PAN.IsChecked,
                 btn_CAMBACK.IsChecked,
                 btn_CAMFRONT.IsChecked
                );
           
        }
        private void MyControlBarTA_Closed(object sender, EventArgs e)
        {
            confirmcloseform?.Invoke();
        }

        private async void btn_testconnect_Click(object sender, RoutedEventArgs e)
        {
            PLC Plc = new PLC();
            try
            {
                using (TcpClient tcpclient = new TcpClient())
                {
                    CancellationTokenSource PlcCancellationToken = new CancellationTokenSource();
                    Task connectTask = tcpclient.ConnectAsync(IPAddress.Parse(txb_ip.Text), int.Parse(txb_port.Text));
                    if (await Task.WhenAny(connectTask, Task.Delay(5000, PlcCancellationToken.Token)) != connectTask)
                    {
                        PlcCancellationToken.Cancel();
                        throw new TimeoutException("Error timed out Open Connection .");
                    }
                    await connectTask;
                    tcpclient.Close();
                    MessageBox.Show("Connect Success");
                }
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
           

        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Updatedatasql();
                loaddatasql();
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
       
    }
}
