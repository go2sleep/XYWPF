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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XYWPF.Sample.Effect
{
    /// <summary>
    /// MyCardControlFront.xaml 的交互逻辑
    /// </summary>
    public partial class MyCardControlFront : UserControl
    {
        public static readonly DependencyProperty FrontTextProperty = DependencyProperty.Register("FrontText", typeof(string), typeof(MyCardControlFront), new PropertyMetadata(null));
        public string FrontText
        {
            get { return (string)GetValue(FrontTextProperty); }
            set { SetValue(FrontTextProperty, value); }
        }

        public MyCardControlFront()
        {
            InitializeComponent();
        }
    }
}
