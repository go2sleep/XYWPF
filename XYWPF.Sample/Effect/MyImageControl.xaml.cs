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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XYWPF.Sample.Effect
{
    /// <summary>
    /// MyImageControl.xaml 的交互逻辑
    /// </summary>
    public partial class MyImageControl : UserControl
    {
        public static readonly DependencyProperty ShowImageProperty = DependencyProperty.Register("ShowImage", typeof(BitmapImage), typeof(MyImageControl), new PropertyMetadata(null));
        public BitmapImage ShowImage
        {
            get { return (BitmapImage)GetValue(ShowImageProperty); }
            set { SetValue(ShowImageProperty, value); }
        }

        public Storyboard storyboard = new Storyboard();
        private const int FlipCount = 5;
        BitmapSource[] bitmap = new BitmapSource[FlipCount];
        Image[] images = new Image[FlipCount];

        public MyImageControl()
        {
            InitializeComponent();
        }

        public void GetHorizontalFlip()
        {
            int partImgWidth = (int)this.ShowImage.PixelWidth;
            int partImgHeight = (int)(this.ShowImage.PixelHeight / FlipCount);
            for (int i = 0; i < FlipCount; i++)
            {
                bitmap[i] = GetPartImage(this.ShowImage, 0, i * partImgHeight, partImgWidth, partImgHeight);

                images[i] = new Image()
                {
                    Width = partImgWidth,
                    Height = partImgHeight,
                    Source = bitmap[i],
                };

                Canvas.SetTop(images[i], i * partImgHeight);
                this.mainCanvas.Children.Add(images[i]);

                DoubleAnimation da = new DoubleAnimation(0, (int)this.ShowImage.PixelWidth, new Duration(TimeSpan.FromMilliseconds((i + 1) * 250)), FillBehavior.HoldEnd);
                storyboard.Children.Add(da);
                Storyboard.SetTarget(da, images[i]);
                Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.Left)"));
            }

            storyboard.FillBehavior = FillBehavior.HoldEnd;
            storyboard.Completed += new EventHandler(Storyboard_Completed);
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            this.mainCanvas.Children.Clear();
            storyboard.Children.Clear();
        }

        private BitmapSource GetPartImage(BitmapImage img, int XCoordinate, int YCoordinate, int Width, int Height)
        {
            return new CroppedBitmap(img, new Int32Rect(XCoordinate, YCoordinate, Width, Height));
        }
    }
}
