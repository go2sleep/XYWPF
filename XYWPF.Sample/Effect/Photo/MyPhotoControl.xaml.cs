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

namespace XYWPF.Sample.Effect.Photo
{
    /// <summary>
    /// MyPhotoControl.xaml 的交互逻辑
    /// </summary>
    public partial class MyPhotoControl : UserControl
    {
        public static readonly DependencyProperty PuzzleImageProperty = DependencyProperty.Register("PuzzleImage", typeof(BitmapImage), typeof(MyPhotoControl), new PropertyMetadata(null));
        public BitmapImage PuzzleImage
        {
            get { return (BitmapImage)GetValue(PuzzleImageProperty); }
            set { SetValue(PuzzleImageProperty, value); }
        }

        public static readonly DependencyProperty BackgroundImageProperty = DependencyProperty.Register("BackgroundImage", typeof(BitmapSource), typeof(MyPhotoControl), new PropertyMetadata(null));
        public BitmapSource BackgroundImage
        {
            get { return (BitmapSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        public Point StartPoint;//起始位置
        public Point StopPoint;//终止位置
        private Storyboard storyboard = new Storyboard();
        private DependencyProperty[] propertyChain;//动作设置属性

        public MyPhotoControl(int angle)
        {
            InitializeComponent();

            this.RenderTransform = new RotateTransform(angle);
            propertyChain = new DependencyProperty[]
            {
                Grid.RenderTransformProperty,
                RotateTransform.AngleProperty
            };
        }

        /// <summary>
        /// 设置底图展示动画
        /// </summary>
        public void ShowAnimation()
        {
            storyboard.Children.Clear();
            //消失出现动作
            DoubleAnimation disappear = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromMilliseconds(1000)));
            Storyboard.SetTarget(disappear, this.myBorder);
            Storyboard.SetTargetProperty(disappear, new PropertyPath("Opacity"));
            storyboard.Children.Add(disappear);
            DoubleAnimation show = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromMilliseconds(1000)));
            Storyboard.SetTarget(show, this.bgImage);
            Storyboard.SetTargetProperty(show, new PropertyPath("Opacity"));
            storyboard.Children.Add(show);
            //移位动作
            DoubleAnimation moveX = new DoubleAnimation(this.StopPoint.X, this.StartPoint.X, new Duration(TimeSpan.FromMilliseconds(1000)));
            Storyboard.SetTarget(moveX, this);
            Storyboard.SetTargetProperty(moveX, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(moveX);
            DoubleAnimation moveY = new DoubleAnimation(this.StopPoint.Y, this.StartPoint.Y, new Duration(TimeSpan.FromMilliseconds(1000)));
            Storyboard.SetTarget(moveY, this);
            Storyboard.SetTargetProperty(moveY, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(moveY);
            //旋转动作
            DoubleAnimation rotate = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(1000)));
            Storyboard.SetTarget(rotate, this);
            Storyboard.SetTargetProperty(rotate, new PropertyPath("(0).(1)", propertyChain));
            storyboard.Children.Add(rotate);
            storyboard.Begin();
        }

        /// <summary>
        /// 设置底图消失动画
        /// </summary>
        public void DisappearAnimation(int angle)
        {
            storyboard.Children.Clear();
            //消失出现动作
            DoubleAnimation disappear = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromMilliseconds(1000)));
            Storyboard.SetTarget(disappear, this.bgImage);
            Storyboard.SetTargetProperty(disappear, new PropertyPath("Opacity"));
            storyboard.Children.Add(disappear);
            DoubleAnimation show = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromMilliseconds(1000)));
            Storyboard.SetTarget(show, this.myBorder);
            Storyboard.SetTargetProperty(show, new PropertyPath("Opacity"));
            storyboard.Children.Add(show);
            //移位动作
            DoubleAnimation moveX = new DoubleAnimation(this.StartPoint.X, this.StopPoint.X, new Duration(TimeSpan.FromMilliseconds(1000)));
            Storyboard.SetTarget(moveX, this);
            Storyboard.SetTargetProperty(moveX, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(moveX);
            DoubleAnimation moveY = new DoubleAnimation(this.StartPoint.Y, this.StopPoint.Y, new Duration(TimeSpan.FromMilliseconds(1000)));
            Storyboard.SetTarget(moveY, this);
            Storyboard.SetTargetProperty(moveY, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(moveY);
            //旋转动作
            DoubleAnimation rotate = new DoubleAnimation(angle, new Duration(TimeSpan.FromMilliseconds(1000)));
            Storyboard.SetTarget(rotate, this);
            Storyboard.SetTargetProperty(rotate, new PropertyPath("(0).(1)", propertyChain));
            storyboard.Children.Add(rotate);
            storyboard.Begin();
        }
    }
}
