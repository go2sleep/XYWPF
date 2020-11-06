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
using System.Windows.Shapes;

namespace XYWPF.Sample.Effect.Particles
{
    /// <summary>
    /// WinParticle.xaml 的交互逻辑
    /// </summary>
    public partial class WinParticle : Window
    {
        private ParticleSystem ps;
        private Point pMouse = new Point(9999, 9999);

        public WinParticle()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ps = new ParticleSystem(15, 1000, 10, 100, 150, this.cvs_particleContainer, this.grid_lineContainer);
            //注册帧动画
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        /// <summary>
        /// 帧渲染事件
        /// </summary>
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            ps.ParticleRoamUpdate(pMouse);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            pMouse = e.GetPosition(this.cvs_particleContainer);
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            pMouse = new Point(9999, 9999);
        }
    }
}
