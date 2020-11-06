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
using System.Windows.Navigation;
using System.Windows.Shapes;
using XYWPF.CoreLib.Helper;

namespace XYWPF.Sample.Effect.Photo
{
    /// <summary>
    /// PuzzleEffectControl.xaml 的交互逻辑
    /// </summary>
    public partial class PuzzleEffectControl : UserControl
    {
        private BitmapImage ShowImage;//要展示的主图
        private int ShowImageWidth = 300;//照片宽
        private int ShowImageHeight = 300;//照片高
        private double zoom = 0;//照片缩放率
        private const int HorizontalCount = 3;//横向裁剪数量
        private const int VerticalCount = 3;//纵向裁剪数量
        private BitmapSource[,] bitmap = new BitmapSource[HorizontalCount, VerticalCount];
        private MyPhotoControl[,] photos = new MyPhotoControl[HorizontalCount, VerticalCount];
        private List<BitmapImage> listPhoto = new List<BitmapImage>();//照片列表
        private Random random = new Random();
        private bool IsShowImage = false;
        public PuzzleEffectControl()
        {
            InitializeComponent();
            this.Loaded += PuzzleEffectControl_Loaded;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        private void PuzzleEffectControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetListPhoto();
            InitPhotoWall();
        }

        /// <summary>
        /// 获取照片墙图片列表
        /// </summary>
        private void GetListPhoto()
        {
            List<string> listAdv = ImageHelper.GetUserImages(AppDomain.CurrentDomain.BaseDirectory + "Images");
            foreach (string a in listAdv)
            {
                BitmapImage img = new BitmapImage(new Uri(a));
                listPhoto.Add(img);
            }
        }

        /// <summary>
        /// 初始化照片墙
        /// </summary>
        private void InitPhotoWall()
        {
            if (this.listPhoto.Count != HorizontalCount * VerticalCount) return;
            int count = 0;
            int partBgWidth = (int)((this.mainCanvas.ActualWidth / HorizontalCount - ShowImageWidth / HorizontalCount) / 2);
            int partBgHeight = (int)((this.mainCanvas.ActualHeight / VerticalCount - ShowImageHeight / VerticalCount) / 2);
            for (int i = 0; i < HorizontalCount; i++)
            {
                for (int j = 0; j < VerticalCount; j++)
                {
                    photos[i, j] = new MyPhotoControl(random.Next(-15, 15))
                    {
                        Width = ShowImageWidth / HorizontalCount,
                        Height = ShowImageHeight / VerticalCount,
                        PuzzleImage = listPhoto[count],
                        StopPoint = new Point(i * (this.mainCanvas.ActualWidth / HorizontalCount) + partBgWidth, j * (this.mainCanvas.ActualHeight / VerticalCount) + partBgHeight),
                    };
                    photos[i, j].MouseLeftButtonDown += MyPhotoControl_MouseLeftButtonDown;
                    Canvas.SetLeft(photos[i, j], i * (this.mainCanvas.ActualWidth / HorizontalCount) + partBgWidth);
                    Canvas.SetTop(photos[i, j], j * (this.mainCanvas.ActualHeight / VerticalCount) + partBgHeight);
                    this.mainCanvas.Children.Add(photos[i, j]);
                    count++;
                }
            }
        }

        private void MyPhotoControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsShowImage)
            {
                UnInitShowPhoto();
            }
            else
            {
                MyPhotoControl myPhoto = sender as MyPhotoControl;
                ShowImage = myPhoto.PuzzleImage;
                zoom = ShowImage.PixelWidth / ShowImageWidth * 1.0;
                InitShowPhoto();
            }
        }

        /// <summary>
        /// 裁剪并初始化添加Photo控件
        /// </summary>
        public void InitShowPhoto()
        {
            if (ShowImage == null) return;
            int partImgWidth = ShowImageWidth / HorizontalCount;
            int partImgHeight = ShowImageHeight / VerticalCount;
            for (int i = 0; i < HorizontalCount; i++)
            {
                for (int j = 0; j < VerticalCount; j++)
                {
                    bitmap[i, j] = ImageHelper.GetPartImage(this.ShowImage, (int)(i * partImgWidth * zoom), (int)(j * partImgHeight * zoom), (int)(partImgWidth * zoom), (int)(partImgHeight * zoom));
                    photos[i, j].BackgroundImage = bitmap[i, j];
                    photos[i, j].StartPoint = new Point((this.mainCanvas.ActualWidth - ShowImageWidth) / 2 + i * partImgWidth, (this.mainCanvas.ActualHeight - ShowImageHeight) / 2 + j * partImgHeight);
                    photos[i, j].ShowAnimation();
                }
            }
            IsShowImage = true;
        }
        /// <summary>
        /// 隐藏Photo控件
        /// </summary>
        public void UnInitShowPhoto()
        {
            for (int i = 0; i < HorizontalCount; i++)
            {
                for (int j = 0; j < VerticalCount; j++)
                {
                    photos[i, j].DisappearAnimation(random.Next(-15, 15));
                }
            }
            IsShowImage = false;


        }
    }
}
