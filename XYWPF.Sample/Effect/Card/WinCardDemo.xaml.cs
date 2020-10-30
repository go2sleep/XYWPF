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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace XYWPF.Sample.Effect
{
    /// <summary>
    /// WinCardDemo.xaml 的交互逻辑
    /// </summary>
    public partial class WinCardDemo : Window
    {
        private int Count = 10;
        private DispatcherTimer frameTimer;
        private int TimeValue = 0;
        private List<MyCardControl> cardList = new List<MyCardControl>();

        public WinCardDemo()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.bottomControl.BottomText = Count.ToString();

            for (int i = 1; i <= Count; i++)
            {
                var card = new MyCardControl();
                card.ShowValue = i;
                this.mainGrid.Children.Add(card);
                Canvas.SetZIndex(card, i);

                cardList.Add(card);
            }

            frameTimer = new DispatcherTimer();
            frameTimer.Tick += OnFrame;
            frameTimer.Interval = TimeSpan.FromSeconds(1);
            frameTimer.Start();
        }

        private void OnFrame(object sender, EventArgs e)
        {
            if (TimeValue >= Count)
            {
                if (frameTimer != null)
                    frameTimer.Stop();
                return;
            }

            if (TimeValue == Count - 1)
            {
                this.bottomControl.BottomText = 0.ToString();
            }

            //List<MyCardControl> cardList = GetChildObjects<MyCardControl>(this.mainGrid);

            foreach (var item in cardList)
            {
                if (item.ShowValue == Count - TimeValue)
                {
                    Canvas.SetZIndex(item, Count + TimeValue);

                    DoubleAnimation da = new DoubleAnimation();
                    da.Duration = new Duration(TimeSpan.FromSeconds(1));
                    da.To = 180d;
                    item.ShowValue--;
                    item.backControl.BackText = item.ShowValue.ToString();

                    AxisAngleRotation3D aar = item.FindName("MyAxisAngleRotation3D") as AxisAngleRotation3D;
                    if (aar != null)
                        aar.BeginAnimation(AxisAngleRotation3D.AngleProperty, da);

                    break;
                }
            }

            TimeValue++;
        }

    }
}
