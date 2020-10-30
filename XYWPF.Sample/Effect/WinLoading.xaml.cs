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
using System.Windows.Shapes;

namespace XYWPF.Sample.Effect
{
    /// <summary>
    /// WinLoading.xaml 的交互逻辑
    /// </summary>
    public partial class WinLoading : Window
    {
        private Storyboard LoadingBarBoard = new Storyboard();
        private DoubleAnimation LoadingAnimation = new DoubleAnimation();
        private int DurationTime = 3;

        public WinLoading()
        {
            InitializeComponent();

            this.Loaded += (sender, e) =>
            {
                Init();
            };
        }

        private void Init()
        {
            LoadingAnimation.From = -this.loadingBar.ActualWidth;
            LoadingAnimation.To = this.mainCanvas.ActualWidth / 2;
            LoadingAnimation.RepeatBehavior = RepeatBehavior.Forever;
            LoadingAnimation.Duration = TimeSpan.FromSeconds(DurationTime);
            LoadingAnimation.FillBehavior = FillBehavior.Stop;
            Storyboard.SetTargetName(LoadingAnimation, "loadingBar");
            Storyboard.SetTargetProperty(LoadingAnimation, new PropertyPath(Canvas.LeftProperty));
            LoadingBarBoard.Children.Add(LoadingAnimation);
            LoadingBarBoard.Begin(this);
        }
    }
}
