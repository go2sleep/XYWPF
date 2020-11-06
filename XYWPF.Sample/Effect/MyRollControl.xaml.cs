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

namespace XYWPF.Sample.Effect
{
    /// <summary>
    /// MyRollControl.xaml 的交互逻辑
    /// </summary>
    public partial class MyRollControl : UserControl
    {
        public MyRollControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否开始滚动
        /// </summary>
        public bool isBegin = false;

        /// <summary>
        /// 本轮剩余滚动数
        /// </summary>
        public int rollNum = 0;

        private List<BitmapImage> _ls_images;
        /// <summary>
        /// 滚动图片组
        /// </summary>
        public List<BitmapImage> ls_images
        {
            set
            {
                if (rollNum > 0)
                {
                    // 本轮滚动未结束
                }
                else
                {
                    // 开始新的一轮滚动
                    _ls_images = value;
                    rollNum = _ls_images.Count();
                }
            }
            get { return _ls_images; }
        }

        private int n_index = 0;// 滚动索引

        /// <summary>
        /// 启动
        /// </summary>
        public void Begin()
        {
            if (!isBegin)
            {
                isBegin = true;

                this.ResetStory();
                this.controlFront.GetHorizontalFlip();
            }
        }

        /// <summary>
        /// 初始化图片
        /// </summary>
        void ResetStory()
        {
            if (this.ls_images.Count > 0)
            {
                this.controlFront.ShowImage = this.ls_images[this.n_index++ % this.ls_images.Count];
                this.controlBack.ShowImage = this.ls_images[this.n_index % this.ls_images.Count];
            }
        }

        private void mainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.controlFront.storyboard.Children.Count > 0)
            {
                if (this.controlBack.storyboard.Children.Count <= 0)
                {
                    Canvas.SetZIndex(this.controlFront, 0);
                    this.controlFront.storyboard.Begin();
                    this.controlBack.GetHorizontalFlip();
                    rollNum--;
                    this.ResetStory();
                }
            }
            else if (this.controlFront.storyboard.Children.Count <= 0)
            {
                if (this.controlBack.storyboard.Children.Count > 0)
                {
                    this.controlBack.storyboard.Begin();

                    rollNum--;
                    this.ResetStory();
                    Canvas.SetZIndex(this.controlFront, -1);
                    this.controlFront.GetHorizontalFlip();
                }
            }
        }

    }
}
