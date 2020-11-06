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

namespace XYWPF.Sample.Effect.Menu
{
    /// <summary>
    /// WinRoundMenu.xaml 的交互逻辑
    /// </summary>
    public partial class WinRoundMenu : Window
    {
        public WinRoundMenu()
        {
            InitializeComponent();

            this.roundMenu.ShowClickEvent += RoundMenu_ShowClickEvent;
        }

        private void RoundMenu_ShowClickEvent(bool isShow)
        {
            if (isShow)
                this.Background = new SolidColorBrush(Color.FromRgb(255, 128, 79));
            else
                this.Background = new SolidColorBrush(Color.FromRgb(246, 192, 109));
        }
    }
}
