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
    /// WinExpanderDemo.xaml 的交互逻辑
    /// </summary>
    public partial class WinExpanderDemo : Window
    {
        private List<ExpanderClass> itemList;

        public WinExpanderDemo()
        {
            InitializeComponent();

            itemList = new List<ExpanderClass>();
            itemList.Add(new ExpanderClass("1", "/Images/img1.jpg"));
            itemList.Add(new ExpanderClass("2", "/Images/img2.jpg"));
            itemList.Add(new ExpanderClass("3", "/Images/img3.jpg"));
            itemList.Add(new ExpanderClass("4", "/Images/img4.jpg"));
            itemList.Add(new ExpanderClass("5", "/Images/img5.jpg"));
            itemList.Add(new ExpanderClass("6", "/Images/img6.jpg"));
            this.ExpanderItemBox.ItemsSource = itemList;
        }
    }
}
