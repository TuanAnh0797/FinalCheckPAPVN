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
            loaddatadetail("abc");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(
                   (int)ActualWidth, (int)ActualHeight, 96, 96, PixelFormats.Pbgra32);

            renderTargetBitmap.Render(this);

            // Chuyển đổi hình ảnh thành mảng byte
            PngBitmapEncoder pngImage = new PngBitmapEncoder();
            pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            using (MemoryStream imageStream = new MemoryStream())
            {
                pngImage.Save(imageStream);
                byte[] imageBytes = imageStream.ToArray();

                // Lưu hình ảnh vào tệp
                string imagePath = "C:\\Users\\PC\\Desktop\\New folder (2)\\screenshot.png";
                File.WriteAllBytes(imagePath, imageBytes);

                MessageBox.Show($"Screenshot saved to: {imagePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)ActualWidth, (int)ActualHeight, 96, 96, System.Windows.Media.PixelFormats.Pbgra32);
            //renderTargetBitmap.Render(this);

            //// Convert the image to a byte array
            //PngBitmapEncoder pngImage = new PngBitmapEncoder();
            //pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            //using (MemoryStream imageStream = new MemoryStream())
            //{
            //    pngImage.Save(imageStream);
            //    byte[] imageBytes = imageStream.ToArray();

            //    // Create PDF and add the image
            //    PdfDocument document = new PdfDocument();
            //    PdfPage page = document.AddPage();
            //    XGraphics gfx = XGraphics.FromPdfPage(page);

            //    using (MemoryStream ms = new MemoryStream(imageBytes))
            //    {
            //        XImage image = XImage.FromStream(ms);
            //        gfx.DrawImage(image, 0, 0);
            //    }

            //    // Save the PDF to a file
            //    string pdfFilePath = "C:\\Users\\PC\\Desktop\\New folder (2)\\finaloutput.pdf";
            //    document.Save(pdfFilePath);

            //    // Open the PDF file
            //    System.Diagnostics.Process.Start(pdfFilePath);
            //}
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

    }
}
