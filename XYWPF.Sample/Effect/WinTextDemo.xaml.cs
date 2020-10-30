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

namespace XYWPF.Sample.Effect
{
    /// <summary>
    /// WinTextDemo.xaml 的交互逻辑
    /// </summary>
    public partial class WinTextDemo : Window
    {
        public WinTextDemo()
        {
            InitializeComponent();

            CompositionTarget.Rendering += UpdateEllipse;
        }

        private void UpdateEllipse(object sender, EventArgs e)
        {
            this.GeometryText.Clip = this.MyEllipseGeometry;
        }
    }
}
