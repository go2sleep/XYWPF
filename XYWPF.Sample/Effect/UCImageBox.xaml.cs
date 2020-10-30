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
    /// UCImageBox.xaml 的交互逻辑
    /// </summary>
    public partial class UCImageBox : UserControl
    {
        public static readonly DependencyProperty DisplayImageProperty = DependencyProperty.Register("DisplayImage", typeof(ImageSource), typeof(UCImageBox), new PropertyMetadata(null));
        public ImageSource DisplayImage
        {
            get { return (ImageSource)GetValue(DisplayImageProperty); }
            set { SetValue(DisplayImageProperty, value); }
        }

        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register("DisplayText", typeof(String), typeof(UCImageBox), new PropertyMetadata(null));
        public String DisplayText
        {
            get { return (String)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        private Point lastMousePosition = new Point(0, 0);
        private EllipseGeometry myEllipseGeometry;
        private bool isMouseLeave = false;


        public UCImageBox()
        {
            InitializeComponent();

            myEllipseGeometry = new EllipseGeometry()
            {
                Center = new Point(0, 0),
                RadiusX = 0,
                RadiusY = 0,
            };
            CompositionTarget.Rendering += UpdateGeometry;
            this.PreviewMouseMove += UpdateLastMousePosition;
            this.MouseEnter += UCImageBox_MouseEnter;
            this.MouseLeave += UCImageBox_MouseLeave;
        }

        private void UCImageBox_MouseLeave(object sender, MouseEventArgs e)
        {
            isMouseLeave = true;
            DoubleAnimation scale = new DoubleAnimation();
            scale.From = 100;
            scale.To = 0;
            scale.Duration = new Duration(TimeSpan.FromMilliseconds(100));
            myEllipseGeometry.BeginAnimation(EllipseGeometry.RadiusXProperty, scale);
            myEllipseGeometry.BeginAnimation(EllipseGeometry.RadiusYProperty, scale);
        }

        private void UCImageBox_MouseEnter(object sender, MouseEventArgs e)
        {
            isMouseLeave = false;
            DoubleAnimation scale = new DoubleAnimation();
            scale.From = 0;
            scale.To = 100;
            scale.Duration = new Duration(TimeSpan.FromMilliseconds(100));
            myEllipseGeometry.BeginAnimation(EllipseGeometry.RadiusXProperty, scale);
            myEllipseGeometry.BeginAnimation(EllipseGeometry.RadiusYProperty, scale);
        }

        private void UpdateGeometry(object sender, EventArgs e)
        {
            if (isMouseLeave) return;
            myEllipseGeometry.Center = new Point(lastMousePosition.X, lastMousePosition.Y);
            this.GeometryImage.Clip = myEllipseGeometry;
        }

        private void UpdateLastMousePosition(object sender, MouseEventArgs e)
        {
            lastMousePosition = e.GetPosition(containerCanvas);
        }
    }
}
