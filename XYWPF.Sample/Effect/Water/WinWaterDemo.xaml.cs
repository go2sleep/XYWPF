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
using System.Windows.Threading;

namespace XYWPF.Sample.Effect.Water
{
    /// <summary>
    /// WinWaterDemo.xaml 的交互逻辑
    /// </summary>
    public partial class WinWaterDemo : Window
    {
        WaterEffect water;
        Random random;
        DispatcherTimer timer;

        public WinWaterDemo()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            water = new WaterEffect((int)back.RenderSize.Width, (int)back.RenderSize.Height);
            back.Effect = water;
            random = new Random();
            timer = new DispatcherTimer();
            timer.Tick += OnFrame;
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Start();
        }

        private void OnFrame(object sender, EventArgs e)
        {
            DropWater(new Point(random.Next(0, (int)back.RenderSize.Width), random.Next(0, (int)back.RenderSize.Height)));
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            DropWater(Mouse.GetPosition(back));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DropWater(Mouse.GetPosition(back));
        }

        private void DropWater(Point p)
        {
            p.X /= back.RenderSize.Width;
            p.Y /= back.RenderSize.Height;
            if (p.X >= 0 && p.X <= 1 && p.Y >= 0 && p.Y <= 1)
            {
                water.Drop((float)p.X, (float)p.Y);
            }
        }
    }
}
