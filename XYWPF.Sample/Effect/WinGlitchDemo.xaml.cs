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
    /// WinGlitchDemo.xaml 的交互逻辑
    /// </summary>
    public partial class WinGlitchDemo : Window
    {
        public WinGlitchDemo()
        {
            InitializeComponent();

            CompositionTarget.Rendering += UpdateGeometry;
        }

        private void UpdateGeometry(object sender, EventArgs e)
        {
            this.myBgImage.Clip = this.myRectangleGeometry3;
            this.myGeometryImage1.Clip = this.myRectangleGeometry1;
            this.myGeometryImage2.Clip = this.myRectangleGeometry2;
            this.myText2.Clip = this.myTextRectangleGeometry;
        }
    }
}
