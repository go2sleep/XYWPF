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

namespace XYWPF.Sample.Effect.TextEffect
{
    /// <summary>
    /// WinTextEffect.xaml 的交互逻辑
    /// </summary>
    public partial class WinTextEffect : Window
    {
        private ParticleSystem ps;

        public WinTextEffect()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Geometry g = CreateTextPath("H E L L O", new Point(this.cvs_particleContainer.Margin.Left, this.cvs_particleContainer.Margin.Top), new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal), 200);
            ps = new ParticleSystem(g, 25, 350, this.cvs_particleContainer);
        }

        /// <summary>
        /// 创建文本路径
        /// </summary>
        /// <param name="word">文本字符串</param>
        /// <param name="point">显示位置</param>
        /// <param name="typeface">字体信息</param>
        /// <param name="fontSize">字体大小</param>
        /// <returns></returns>
        private Geometry CreateTextPath(string word, Point point, Typeface typeface, int fontSize)
        {
            FormattedText text = new FormattedText(word, new System.Globalization.CultureInfo("en-US"), FlowDirection.LeftToRight, typeface, fontSize, Brushes.Black);
            Geometry g = text.BuildGeometry(point);
            PathGeometry path = g.GetFlattenedPathGeometry();
            return path;
        }
    }
}
