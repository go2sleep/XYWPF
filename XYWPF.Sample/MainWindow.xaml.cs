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
            Dictionary<string, string> dictSkin = new Dictionary<string, string>();
            dictSkin.Add("Generic", "pack://application:,,,/XYWPF.Skin;component/Images/Generic/MainWindowBackground.jpg");
            dictSkin.Add("Theme1", "pack://application:,,,/XYWPF.Skin;component/Images/Theme1/MainWindowBackground.jpg");

            foreach (var skin in dictSkin)
            {
                Image imgTheme = new Image()
                {
                    Width = 100,
                    Stretch = Stretch.Fill,
                    Height = 60,
                    Margin = new Thickness(2)
                };

                imgTheme.Name = System.IO.Path.GetFileNameWithoutExtension(skin.Value);
                imgTheme.Tag = skin.Key;
                imgTheme.Source = new BitmapImage(new Uri(skin.Value, UriKind.Absolute));
                imgTheme.MouseLeftButtonDown += new MouseButtonEventHandler(imgTheme_MouseLeftButtonDown);
                ImagePanel.Children.Add(imgTheme);
            }
        }

        private void imgTheme_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (image != null && image.Source != null)
            {
                var skinDictUri = new Uri($"pack://application:,,,/XYWPF.Skin;component/Themes/{image.Tag.ToString()}.xaml", UriKind.Absolute);                

                ResourceDictionary skinResource = new ResourceDictionary();
                skinResource.Source = skinDictUri;

                var mergedDicts = Resources.MergedDictionaries;
                mergedDicts.Clear();
                mergedDicts.Add(skinResource);
            }
        }
    }
}
