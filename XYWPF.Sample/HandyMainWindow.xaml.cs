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
using XYWPF.Sample.BrushDemo;
using XYWPF.Sample.Effect;

namespace XYWPF.Sample
{
    /// <summary>
    /// HandyMainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HandyMainWindow : HandyControl.Controls.GlowWindow
    {
        public HandyMainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window win = new WinBrush();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window win = new WinAlarmDemo();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window win = new WinLoading();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window win = new WinSearch();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window win = new WinPartiCles();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Window win = new WinFlipPicture();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Window win = new WinImageBox();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Window win = new WinTextDemo();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Window win = new WinUCImageBox();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Window win = new WinLoadingDemo();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Window win = new WinLineGradientBrush();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            Window win = new Effect._3DWave.Win3DParticleWave();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            Window win = new WinAxisAngleRotation3D();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            Window win = new WinRollImages();
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Owner = this;
            win.Show();
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            Window win = new Effect.RollControl.WinRollControl();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            Window win = new Effect._3D.WinText3D();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.WinLightEffect();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_27(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect._3D.Win3DTriangle();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_28(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect._3D.WinSphereMesh();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_29(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.ParticleDNA.WinParticleDNA();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.RoundMenu.WinRoundMenuDemo();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_31(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.Water.WinWaterDemo();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_32(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.ImageShow.WinDisplayImage();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_33(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.Photo.WinPhotoDemo();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_34(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.WinImage2D();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_35(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Effect.GridEffect.WinGridPhoto();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }

        private void Button_Click_36(object sender, RoutedEventArgs e)
        {
            Window win = new XYWPF.Sample.Animation.WindowAnimation();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }
    }
}
