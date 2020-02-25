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

namespace XYWPF.Sample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadBackgroundImages();
        }

        private void LoadBackgroundImages()
        {
            Dictionary<string, Brush> dictSkin = new Dictionary<string, Brush>();
            dictSkin.Add("Generic", new SolidColorBrush(Color.FromRgb(62, 140, 206)));
            dictSkin.Add("Red", new SolidColorBrush(Color.FromRgb(218, 83, 80)));
            dictSkin.Add("Green", new SolidColorBrush(Color.FromRgb(90, 185, 93)));

            foreach (var skin in dictSkin)
            {
                Border Boder = new Border()
                {
                    Width = 100,
                    Height = 60,
                    Background = skin.Value,
                    Margin = new Thickness(2)
                };

                Boder.Tag = skin.Key;
                Boder.MouseLeftButtonDown += new MouseButtonEventHandler(Theme_MouseLeftButtonDown);
                ImagePanel.Children.Add(Boder);
            }
        }

        private void Theme_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement eleSkin = sender as FrameworkElement;
            if (eleSkin != null && eleSkin.Tag != null)
            {
                var skinDictUri = new Uri($"pack://application:,,,/XYWPF.Skin;component/Themes/{eleSkin.Tag.ToString()}.xaml", UriKind.Absolute);                

                ResourceDictionary skinResource = new ResourceDictionary();
                skinResource.Source = skinDictUri;

                var mergedDicts = Resources.MergedDictionaries;
                mergedDicts.Clear();
                mergedDicts.Add(skinResource);
            }
        }
    }
}
