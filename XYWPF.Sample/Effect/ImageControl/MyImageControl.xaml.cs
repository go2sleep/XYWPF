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

namespace XYWPF.Sample.Effect.ImageControl
{
    /// <summary>
    /// MyImageControl.xaml 的交互逻辑
    /// </summary>
    public partial class MyImageControl : UserControl
    {
        public static readonly DependencyProperty DisplayImageProperty = DependencyProperty.Register("DisplayImage", typeof(ImageSource), typeof(MyImageControl), new PropertyMetadata(null));
        public ImageSource DisplayImage
        {
            get { return (ImageSource)GetValue(DisplayImageProperty); }
            set { SetValue(DisplayImageProperty, value); }
        }

        public static readonly DependencyProperty DisplayTitleProperty = DependencyProperty.Register("DisplayTitle", typeof(String), typeof(MyImageControl), new PropertyMetadata(null));
        public String DisplayTitle
        {
            get { return (String)GetValue(DisplayTitleProperty); }
            set { SetValue(DisplayTitleProperty, value); }
        }
        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register("DisplayText", typeof(String), typeof(MyImageControl), new PropertyMetadata(null));
        public String DisplayText
        {
            get { return (String)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly DependencyProperty DisplayTypeProperty = DependencyProperty.Register("DisplayType", typeof(PathType), typeof(MyImageControl), new PropertyMetadata(null));
        public PathType DisplayType
        {
            get { return (PathType)GetValue(DisplayTypeProperty); }
            set { SetValue(DisplayTypeProperty, value); }
        }

        private Geometry pathDataStar = Geometry.Parse("M16.001007,0L20.944,10.533997 32,12.223022 23.998993,20.421997 25.889008,32 16.001007,26.533997 6.1109924,32 8,20.421997 0,12.223022 11.057007,10.533997z");
        private Geometry pathDataHeart = Geometry.Parse("M422.45632,125.20915 C418.27568,119.65336 415.69303,116.32575 410.44736,115.5011 403.82165,114.45949 394.83355,117.84632 392.5817,125.62254 391.18575,130.44311 395.55251,137.13882 398.43689,140.18778 407.89516,150.18575 420.49974,154.91914 422.4579,154.87627 424.45773,154.83249 436.87047,150.18567 446.4789,140.31116 448.67513,138.05411 453.6045,130.66448 452.5781,125.72209 451.58334,120.9321 443.87041,113.50199 434.71238,115.84723 432.02709,116.5349 427.1227,118.04227,422.45632,125.20915");
        private Storyboard storyboard = new Storyboard();

        public MyImageControl()
        {
            InitializeComponent();

            this.Loaded += MyImageControl_Loaded;
        }

        private void MyImageControl_Loaded(object sender, RoutedEventArgs e)
        {
            switch (DisplayType)
            {
                case PathType.Star:
                    this.UCPath.Data = pathDataStar;
                    break;
                case PathType.Heart:
                    this.UCPath.Data = pathDataHeart;
                    break;
                case PathType.RoundedRectangle:
                    this.UCPath.Data = new RectangleGeometry(new Rect(new Size(this.ActualWidth - 10, this.ActualHeight - 10)), 50, 50);
                    break;
                default:
                    this.UCPath.Data = new RectangleGeometry(new Rect(new Size(this.ActualWidth - 10, this.ActualHeight - 10)), 50, 50);
                    break;
            }
        }

        private void ImgBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            storyboard.Children.Clear();

            DoubleAnimation WidthAnimation = new DoubleAnimation(this.ActualWidth - 10, new Duration(TimeSpan.FromMilliseconds(200)));
            Storyboard.SetTarget(WidthAnimation, this.textGrid);
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width"));

            DoubleAnimation HeightAnimation = new DoubleAnimation(this.ActualHeight - 10, new Duration(TimeSpan.FromMilliseconds(200)));
            Storyboard.SetTarget(HeightAnimation, this.textGrid);
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height"));

            DoubleAnimation OpacityAnimation = new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(500)));
            Storyboard.SetTarget(OpacityAnimation, this.textPanel);
            Storyboard.SetTargetProperty(OpacityAnimation, new PropertyPath("Opacity"));

            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Children.Add(OpacityAnimation);
            storyboard.Begin();
        }

        private void ImgBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            storyboard.Children.Clear();

            DoubleAnimation OpacityAnimation = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(200)));
            Storyboard.SetTarget(OpacityAnimation, this.textPanel);
            Storyboard.SetTargetProperty(OpacityAnimation, new PropertyPath("Opacity"));

            DoubleAnimation WidthAnimation = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(500)));
            Storyboard.SetTarget(WidthAnimation, this.textGrid);
            Storyboard.SetTargetProperty(WidthAnimation, new PropertyPath("Width"));

            DoubleAnimation HeightAnimation = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(500)));
            Storyboard.SetTarget(HeightAnimation, this.textGrid);
            Storyboard.SetTargetProperty(HeightAnimation, new PropertyPath("Height"));

            storyboard.Children.Add(OpacityAnimation);
            storyboard.Children.Add(WidthAnimation);
            storyboard.Children.Add(HeightAnimation);
            storyboard.Begin();
        }
    }

    public enum PathType
    {
        Star,
        Heart,
        RoundedRectangle
    }
}
