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
using System.Windows.Threading;

namespace XYWPF.Sample.Effect
{
    /// <summary>
    /// WinPartiCles.xaml 的交互逻辑
    /// </summary>
    public partial class WinPartiCles : Window
    {
        private readonly ParticleSystemManager _pm;
        private readonly Random _rand;
        private int _currentTick;
        private double _elapsed;
        private int _frameCount;
        private double _frameCountTime;
        private int _frameRate;
        private int _lastTick;
        private Point3D _spawnPoint;
        private double _totalElapsed;
        private DispatcherTimer _frameTimer;


        public WinPartiCles()
        {
            InitializeComponent();

            _frameTimer = new DispatcherTimer();
            _frameTimer.Tick += OnFrame;
            _frameTimer.Interval = TimeSpan.FromSeconds(1.0 / 60.0);
            _frameTimer.Start();

            _lastTick = Environment.TickCount;

            _pm = new ParticleSystemManager();

            WorldModels.Children.Add(_pm.CreateParticleSystem(1000, Colors.White));
            WorldModels.Children.Add(_pm.CreateParticleSystem(200, Colors.Red));
            WorldModels.Children.Add(_pm.CreateParticleSystem(200, Colors.Orange));
            WorldModels.Children.Add(_pm.CreateParticleSystem(200, Colors.Silver));

            _rand = new Random(GetHashCode());

            KeyDown += Window_KeyDown;
            Cursor = Cursors.None;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rdo = sender as RadioButton;
            if (rdo != null)
            {
                switch (rdo.Name)
                {
                    case "rdoSnowflake":
                        this.mainGrid.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/snowbg.jpg")));
                        break;
                    case "rdoNeonLights":
                        this.mainGrid.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/streetbg.jpg")));
                        break;
                    default:
                        this.mainGrid.Background = new SolidColorBrush(Colors.Black);
                        break;
                }
            }

            if (_frameTimer == null) return;
            _frameTimer.Stop();
            _pm.Dispose();
            _frameTimer.Start();
        }

        private void OnFrame(object sender, EventArgs e)
        {
            // Calculate frame time;
            _currentTick = Environment.TickCount;
            _elapsed = (_currentTick - _lastTick) / 1000.0;
            _totalElapsed += _elapsed;
            _lastTick = _currentTick;

            _frameCount++;
            _frameCountTime += _elapsed;
            if (_frameCountTime >= 1.0)
            {
                _frameCountTime -= 1.0;
                _frameRate = _frameCount;
                _frameCount = 0;
                FrameRateLabel.Content = "FPS: " + _frameRate + "  Particles: " + _pm.ActiveParticleCount;
            }

            _pm.Update((float)_elapsed);

            if (this.rdoSnowflake.IsChecked == true)
            {
                SnowflakeEffect();
            }
            else if (this.rdoNeonLights.IsChecked == true)
            {
                NeonLightsEffect();
            }
        }

        /// <summary>
        /// 雪花效果
        /// </summary>
        private void SnowflakeEffect()
        {
            _spawnPoint = new Point3D(0.0, 50,0.0);
            _pm.SpawnParticle(_spawnPoint, 10.0, Colors.White, _rand.NextDouble() * 6, 20 * _rand.NextDouble());
        }

        /// <summary>
        /// 霓虹效果
        /// </summary>
        private void NeonLightsEffect()
        {
            _spawnPoint = new Point3D(_rand.NextDouble() * this.ActualWidth, -_rand.NextDouble() * 30, 0.0);
            _pm.SpawnParticle(_spawnPoint, 0, Colors.Red, _rand.NextDouble() * 16, 20 * _rand.NextDouble());
            _spawnPoint = new Point3D(_rand.NextDouble() * this.ActualWidth, -_rand.NextDouble() * 30, 0.0);
            _pm.SpawnParticle(_spawnPoint, 0, Colors.Orange, _rand.NextDouble() * 16, 20 * _rand.NextDouble());
            _spawnPoint = new Point3D(_rand.NextDouble() * this.ActualWidth, -_rand.NextDouble() * 30, 0.0);
            _pm.SpawnParticle(_spawnPoint, 0, Colors.Silver, _rand.NextDouble() * 16, 20 * _rand.NextDouble());

            _spawnPoint = new Point3D(-_rand.NextDouble() * this.ActualWidth, -_rand.NextDouble() * 30, 0.0);
            _pm.SpawnParticle(_spawnPoint, 0, Colors.Red, _rand.NextDouble() * 16, 20 * _rand.NextDouble());
            _spawnPoint = new Point3D(-_rand.NextDouble() * this.ActualWidth, -_rand.NextDouble() * 30, 0.0);
            _pm.SpawnParticle(_spawnPoint, 0, Colors.Orange, _rand.NextDouble() * 16, 20 * _rand.NextDouble());
            _spawnPoint = new Point3D(-_rand.NextDouble() * this.ActualWidth, -_rand.NextDouble() * 30, 0.0);
            _pm.SpawnParticle(_spawnPoint, 0, Colors.Silver, _rand.NextDouble() * 16, 20 * _rand.NextDouble());

        }
    }
}
