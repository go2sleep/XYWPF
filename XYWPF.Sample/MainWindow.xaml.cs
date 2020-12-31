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

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            Window win = new WinAxisAngleRotation3D();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            Window win = new WinRollImages();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            Window win = new Effect.RollControl.WinRollControl();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            Window win = new Effect._3D.WinText3D();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            Window win = new Effect.Star.WinStar();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.Particles.WinParticle();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect._3D.Win3DEffect();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.ImageControl.WinImageShow();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.WinLightEffect();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.Menu.WinRoundMenu();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.TextEffect.WinTextEffect();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_25(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect._3D.WinParticle3D();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_26(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.WinGlitchDemo();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_27(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect._3D.Win3DTriangle();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_28(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect._3D.WinSphereMesh();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_29(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.ParticleDNA.WinParticleDNA();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.RoundMenu.WinRoundMenuDemo();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_31(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.Water.WinWaterDemo();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_32(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.ImageShow.WinDisplayImage();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_33(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.Photo.WinPhotoDemo();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_34(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.WinImage2D();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_35(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.GridEffect.WinGridPhoto();
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_36(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Animation.WindowAnimation();
            win.Owner = this;
            win.Show();
        }
    }
}
