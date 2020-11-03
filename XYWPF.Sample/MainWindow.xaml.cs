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
using XYWPF.Sample.BrushDemo;
using XYWPF.Sample.Effect;

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

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WinBrush win = new WinBrush();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WinAlarmDemo win = new WinAlarmDemo();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WinLoading win = new WinLoading();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WinSearch win = new WinSearch();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            WinPartiCles win = new WinPartiCles();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            WinFlipPicture win = new WinFlipPicture();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Window win = new WinImageBox();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Window win = new WinTextDemo();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Window win = new WinUCImageBox();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Window win = new WinLoadingDemo();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Window win = new WinCardDemo();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Window win = new WinExpanderDemo();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Window win = new WinLineGradientBrush();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            Window win = new Effect._3DWave.Win3DParticleWave();
            win.Owner = this;
            win.Show();
        }
    }
}
