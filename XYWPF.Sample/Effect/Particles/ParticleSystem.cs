using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace XYWPF.Sample.Effect.Particles
{
    public class ParticleSystem
    {
        /// <summary>
        /// 粒子个数
        /// </summary>
        private int particleCount = 100;

        /// <summary>
        /// 粒子最小尺寸
        /// </summary>
        private static int sizeMin = 5;

        /// <summary>
        /// 粒子最大尺寸
        /// </summary>
        private int sizeMax = 20;

        /// <summary>
        /// 粒子运动速度
        /// </summary>
        private int speed = 10;

        /// <summary>
        /// 划线的阈值
        /// </summary>
        private int lineThreshold = 100;

        /// <summary>
        /// 鼠标范围半径
        /// </summary>
        private static int mouseRadius = 50;

        /// <summary>
        /// 随机数
        /// </summary>
        private Random random;

        /// <summary>
        /// 粒子列表
        /// </summary>
        private List<Particle> particles;

        /// <summary>
        /// 粒子容器
        /// </summary>
        private Canvas containerParticles;

        /// <summary>
        /// 线段容器
        /// </summary>
        private Grid containerLine;

        /// <summary>
        /// 鼠标滚动后粒子最大尺寸
        /// </summary>
        private int radiusMax = 20;


        public ParticleSystem(int _maxRadius, int _particleCount, int _speed, int _lineThreshold, int _mouseRadius, Canvas _containerParticles, Grid _containerLine)
        {
            particleCount = _particleCount;
            speed = _speed;
            sizeMax = _maxRadius;
            lineThreshold = _lineThreshold;
            mouseRadius = _mouseRadius;
            containerLine = _containerLine;
            containerParticles = _containerParticles;
            random = new Random();
            particles = new List<Particle>();
            SpawnParticle();
        }

        /// <summary>
        /// 初始化粒子
        /// </summary>
        private void SpawnParticle()
        {
            //清空粒子队列
            particles.Clear();
            containerLine.Children.Clear();
            containerParticles.Children.Clear();

            //生成粒子
            for (int i = 0; i < particleCount; i++)
            {
                //double size = random.Next(sizeMin, sizeMax + 1);
                //Particle p = new Particle
                //{
                //    Shape = new Ellipse
                //    {
                //        Width = size,
                //        Height = size,
                //        Stretch = System.Windows.Media.Stretch.Fill,
                //        Fill = new SolidColorBrush(Color.FromArgb(125, 255, 255, 255)),
                //    },
                //    Position = new Point(random.Next(0, (int)containerParticles.ActualWidth), random.Next(0, (int)containerParticles.ActualHeight)),
                //    Velocity = new Vector(random.Next(-speed, speed) * 0.1, random.Next(-speed, speed) * 0.1),
                //    ParticleLines = new Dictionary<Particle, Line>()
                //};
                //particles.Add(p);

                double size = random.Next(sizeMin, sizeMax + 1);
                Particle p = new Particle
                {
                    DefaultRadius = size,
                    Shape = new Ellipse
                    {
                        Width = size,
                        Height = size,
                        Stretch = System.Windows.Media.Stretch.Fill,
                        Fill = GetRandomColorBursh(),
                        Opacity = random.NextDouble(),
                    },
                    Position = new Point(random.Next(0, (int)containerParticles.ActualWidth), random.Next(0, (int)containerParticles.ActualHeight)),
                    Velocity = new Vector(random.Next(-speed, speed) * 0.01, random.Next(-speed, speed) * 0.01),
                };
                SetParticleOpacityAnimation(p.Shape);
                particles.Add(p);
                Canvas.SetLeft(p.Shape, p.Position.X);
                Canvas.SetTop(p.Shape, p.Position.Y);
                containerParticles.Children.Add(p.Shape);
            }
        }

        /// <summary>
        /// 粒子漫游动画
        /// </summary>
        public void ParticleRoamUpdate(Point mp)
        {
            foreach (Particle p in particles)
            {
                p.Position.X = p.Position.X + p.Velocity.X;
                p.Position.Y = p.Position.Y + p.Velocity.Y;

                if (p.Position.X < p.Shape.Width)
                    p.Position.X = p.Shape.Width;
                if (p.Position.Y < p.Shape.Height)
                    p.Position.Y = p.Shape.Height;
                if (p.Position.X > containerParticles.ActualWidth - p.Shape.Width)
                    p.Position.X = containerParticles.ActualWidth - p.Shape.Width;
                if (p.Position.Y > containerParticles.ActualHeight - p.Shape.Height)
                    p.Position.Y = containerParticles.ActualHeight - p.Shape.Height;

                //速度为0判断
                if (p.Velocity.X == 0) p.Velocity.X = random.Next(-speed, speed) * 0.01;
                if (p.Velocity.Y == 0) p.Velocity.Y = random.Next(-speed, speed) * 0.01;
                //if (p.Velocity.X == 0) p.Velocity.X = random.Next(-speed, speed) * 0.1;
                //if (p.Velocity.Y == 0) p.Velocity.Y = random.Next(-speed, speed) * 0.1;

                //是否和墙壁碰撞
                if ((p.Position.X <= p.Shape.Width) || (p.Position.X >= containerParticles.ActualWidth - p.Shape.Width))
                    p.Velocity.X = -p.Velocity.X;
                if ((p.Position.Y <= p.Shape.Height) || (p.Position.Y >= containerParticles.ActualHeight - p.Shape.Height))
                    p.Velocity.Y = -p.Velocity.Y;

                //鼠标移动改变粒子位置
                //求点到圆心的距离
                //double c = Math.Pow(Math.Pow(mp.X - p.Position.X, 2) + Math.Pow(mp.Y - p.Position.Y, 2), 0.5);
                //if (c < mouseRadius)
                //{
                //    p.Position.X = mp.X - ((mp.X - p.Position.X) * mouseRadius / c);
                //    p.Position.Y = (p.Position.Y - mp.Y) * mouseRadius / c + mp.Y;
                //}
                double c = Math.Pow(Math.Pow(mp.X - p.Position.X, 2) + Math.Pow(mp.Y - p.Position.Y, 2), 0.5);
                if (c < mouseRadius)
                {
                    p.Shape.Opacity = 1;
                    p.Shape.Width = p.Shape.Height = radiusMax;
                }
                else
                {
                    p.Shape.Width = p.Shape.Height = p.DefaultRadius;
                }

                Canvas.SetLeft(p.Shape, p.Position.X);
                Canvas.SetTop(p.Shape, p.Position.Y);
            }
        }

        /// <summary>
        /// 设置粒子透明度动画
        /// </summary>
        private void SetParticleOpacityAnimation(Ellipse p)
        {
            Storyboard sb = new Storyboard();
            //动画完成事件 再次设置此动画
            sb.Completed += (S, E) =>
            {
                SetParticleOpacityAnimation(p);
            };
            DoubleAnimation da = new DoubleAnimation(random.NextDouble(), 0, new Duration(TimeSpan.FromMilliseconds(random.Next(2000, 5000))));
            Storyboard.SetTarget(da, p);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
            sb.Children.Add(da);
            sb.Begin();
        }

        /// <summary>
        /// 获取随机颜色画刷
        /// </summary>
        private SolidColorBrush GetRandomColorBursh()
        {
            byte r = (byte)random.Next(128, 256);
            byte g = (byte)random.Next(128, 256);
            byte b = (byte)random.Next(128, 256);
            return new SolidColorBrush(Color.FromArgb(255, r, g, b));
        }
    }
}
