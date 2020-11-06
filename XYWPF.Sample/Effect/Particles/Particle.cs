using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace XYWPF.Sample.Effect.Particles
{
    public class Particle
    {
        /// <summary>
        /// 初始半径
        /// </summary>
        public double DefaultRadius;

        // <summary>
        /// 形状
        /// </summary>
        public Ellipse Shape;
        /// <summary>
        /// 坐标
        /// </summary>
        public Point Position;
        /// <summary>
        /// 速度
        /// </summary>
        public Vector Velocity;
    }
}
