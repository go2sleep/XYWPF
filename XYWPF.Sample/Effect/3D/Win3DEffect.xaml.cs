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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace XYWPF.Sample.Effect._3D
{
    /// <summary>
    /// Win3DEffect.xaml 的交互逻辑
    /// </summary>
    public partial class Win3DEffect : Window
    {
        private Point pointBefore;

        public Win3DEffect()
        {
            InitializeComponent();
        }

        private void MyViewport3D_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pointBefore = e.GetPosition(this);
        }

        private void MyViewport3D_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point pointAfter = e.GetPosition(this);
                var moveX = pointAfter.X - pointBefore.X;
                var moveY = pointAfter.Y - pointBefore.Y;
                Vector3D axis = new Vector3D(moveX, moveY, 1);
                AxisAngleRotation3D aar = this.FindName("myRotate") as AxisAngleRotation3D;
                aar.Axis = axis;
                aar.Angle = moveX;
            }
        }
    }
}
