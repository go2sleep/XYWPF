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

namespace XYWPF.Sample.Effect.ParticleDNA
{
    /// <summary>
    /// WinParticleDNA.xaml 的交互逻辑
    /// </summary>
    public partial class WinParticleDNA : Window
    {
        private ParticleSystem ps;

        public WinParticleDNA()
        {
            InitializeComponent();


            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ps = new ParticleSystem(this.cvs_particleContainer);
            //注册帧动画
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        /// <summary>
        /// 帧渲染事件
        /// </summary>
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            ps.Update();
        }
    }
}
