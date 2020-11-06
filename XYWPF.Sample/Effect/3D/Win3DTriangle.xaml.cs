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

namespace XYWPF.Sample.Effect._3D
{
    /// <summary>
    /// Win3DTriangle.xaml 的交互逻辑
    /// </summary>
    public partial class Win3DTriangle : Window
    {
        private TriangleSystem ts;
        public Win3DTriangle()
        {
            InitializeComponent();

            ts = new TriangleSystem(this.mainCanvas);
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        /// <summary>
        /// 帧渲染事件
        /// </summary>
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            ts.Update();
        }
    }
}
