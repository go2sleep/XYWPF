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
using System.Windows.Threading;

namespace XYWPF.Sample.Effect._3DWave
{
    /// <summary>
    /// Win3DParticleWave.xaml 的交互逻辑
    /// </summary>
    public partial class Win3DParticleWave : Window
    {
        private readonly ParticleSystem _ps;
        private DispatcherTimer _frameTimer;

        public Win3DParticleWave()
        {
            InitializeComponent();

            _frameTimer = new DispatcherTimer();
            _frameTimer.Tick += OnFrame;
            _frameTimer.Interval = TimeSpan.FromSeconds(1.0 / 60.0);
            _frameTimer.Start();

            _ps = new ParticleSystem(50, 50, Colors.White, 30);

            WorldModels.Children.Add(_ps.ParticleModel);

            _ps.SpawnParticle(30);

            KeyDown += Window_KeyDown;
            Cursor = Cursors.None;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void OnFrame(object sender, EventArgs e)
        {
            _ps.Update();
        }
    }
}
