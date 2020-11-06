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

namespace XYWPF.Sample.Effect.ImageShow
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
        public bool isDisappear = true;
        private const int HorizontalCount = 4;//横向裁剪数量
        private const int VerticalCount = 3;//纵向裁剪数量
        private BitmapSource[,] bitmap = new BitmapSource[HorizontalCount, VerticalCount];
        private Image[,] images = new Image[HorizontalCount, VerticalCount];
        private List<Image> imageList = new List<Image>();//用来动态随机展示
        private Random random = new Random();

        public MyImageControl()
        {
            InitializeComponent();

            storyboard.Completed += Storyboard_Completed;
        }

        /// <summary>
        /// 裁剪图片
        /// </summary>
        public void GetFlipImage()
        {
            if (this.ShowImage == null)
            {
                isDisappear = true;
                return;
            }
            int partImgWidth = (int)(this.ShowImage.PixelWidth / HorizontalCount);
            int partImgHeight = (int)(this.ShowImage.PixelHeight / VerticalCount);
            for (int i = 0; i < HorizontalCount; i++)
            {
                for (int j = 0; j < VerticalCount; j++)
                {
                    bitmap[i, j] = GetPartImage(this.ShowImage, i * partImgWidth, j * partImgHeight, partImgWidth, partImgHeight);
                    images[i, j] = new Image()
                    {
                        Width = partImgWidth,
                        Height = partImgHeight,
                        Source = bitmap[i, j],
                    };

                    Canvas.SetLeft(images[i, j], i * partImgWidth);
                    Canvas.SetTop(images[i, j], j * partImgHeight);
                    this.mainCanvas.Children.Add(images[i, j]);
                    imageList.Add(images[i, j]);
                }
            }
            isDisappear = false;
            ShowAnimation();
        }

        /// <summary>
        /// 设置动画
        /// </summary>
        public void ShowAnimation()
        {
            List<Image> imgList = imageList.OrderBy(f => Guid.NewGuid()).ToList();//将图片列表打乱顺序
            foreach (Image img in imgList)
            {
                DoubleAnimation da = new DoubleAnimation(random.NextDouble(), 0, new Duration(TimeSpan.FromMilliseconds(random.Next(100, 1000))));
                Storyboard.SetTarget(da, img);
                Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
                storyboard.Children.Add(da);
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            this.mainCanvas.Children.Clear();
            storyboard.Children.Clear();
            isDisappear = true;
        }

        private BitmapSource GetPartImage(BitmapImage img, int XCoordinate, int YCoordinate, int Width, int Height)
        {
            return new CroppedBitmap(img, new Int32Rect(XCoordinate, YCoordinate, Width, Height));
        }
    }
}
