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

namespace XYWPF.Sample.Effect.Ctrl
{
    /// <summary>
    /// CircularSectorControl.xaml 的交互逻辑
    /// </summary>
    public partial class CircularSectorControl : UserControl
    {
        public static readonly DependencyProperty DisplayImageProperty = DependencyProperty.Register("DisplayImage", typeof(ImageSource), typeof(CircularSectorControl), new PropertyMetadata(null));
        public ImageSource DisplayImage
        {
            get { return (ImageSource)GetValue(DisplayImageProperty); }
            set { SetValue(DisplayImageProperty, value); }
        }

        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(SolidColorBrush), typeof(CircularSectorControl), new PropertyMetadata(null));
        public SolidColorBrush BackgroundColor
        {
            get { return (SolidColorBrush)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public CircularSectorControl()
        {
            InitializeComponent();
        }

        private void MainGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.sectorPath.Fill = new SolidColorBrush(Color.FromRgb(246, 111, 111));
        }

        private void MainGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            this.sectorPath.Fill = BackgroundColor;
        }
    }
}
