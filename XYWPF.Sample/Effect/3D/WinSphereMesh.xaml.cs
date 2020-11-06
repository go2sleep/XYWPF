using System;
using System.Collections.Generic;
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
using XYWPF.CoreLib.Helper;

namespace XYWPF.Sample.Effect._3D
{
    /// <summary>
    /// WinSphereMesh.xaml 的交互逻辑
    /// </summary>
    public partial class WinSphereMesh : Window
    {
        private Point lastMousePosition = new Point(0, 0);
        private bool isMouseLeave = false;
        private System.Drawing.Bitmap myImageBitmap;
        private double zoom;

        public WinSphereMesh()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetBitmapImage();
            CompositionTarget.Rendering += Update;
        }

        /// <summary>
        /// 获取底图图源和缩放率
        /// </summary>
        private void GetBitmapImage()
        {
            myImageBitmap = ImageHelper.ImageSourceToBitmap(this.myImage.Source);
            if (myImageBitmap != null)
                zoom = myImageBitmap.Width / this.myImage.ActualWidth;
        }

        private void Update(object sender, EventArgs e)
        {
            if (isMouseLeave) return;
            // 根据鼠标位置计算放大镜位置坐标
            double left = this.lastMousePosition.X - this.ViewportZm.Width / 2;
            double top = this.lastMousePosition.Y - this.ViewportZm.Height / 2;
            this.ViewportZm.Margin = new Thickness(left, top, 0, 0);
            //根据缩放率进行裁剪
            this.myImageBrush.ImageSource = ImageHelper.BitmapToBitmapImage(ImageHelper.ClipBitmap(myImageBitmap, new System.Drawing.Rectangle((int)(left * zoom), (int)(top * zoom), (int)(this.ViewportZm.Width * zoom), (int)(this.ViewportZm.Height * zoom))), System.Drawing.Imaging.ImageFormat.Png);
        }

        private void MyImage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            lastMousePosition = e.GetPosition(this.myImage);
        }

        private void MyImage_MouseLeave(object sender, MouseEventArgs e)
        {
            isMouseLeave = true;
        }

        private void MyImage_MouseEnter(object sender, MouseEventArgs e)
        {
            isMouseLeave = false;
        }

    }
}
