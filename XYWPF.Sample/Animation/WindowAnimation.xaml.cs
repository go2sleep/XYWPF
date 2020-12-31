using FluidKit.Controls;
using FluidKit.Helpers;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace XYWPF.Sample.Animation
{
    /// <summary>
    /// WindowAnimation.xaml 的交互逻辑
    /// </summary>
    public partial class WindowAnimation : Window
    {
        private WindowState preWindowState = WindowState.Normal;
        public WindowAnimation()
        {
            InitializeComponent();

            InitAnimation();

            this.Loaded += WindowAnimation_Loaded;
            this.StateChanged += WindowAnimation_StateChanged;
        }

        private void WindowAnimation_StateChanged(object sender, EventArgs e)
        {
            if(preWindowState == WindowState.Minimized)
            {
                PlayNormalAnimation();
            }

            preWindowState = this.WindowState;
        }

        private void WindowAnimation_Loaded(object sender, RoutedEventArgs e)
        {
            PlayLoadAnimation();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            PlayMinAnimation();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            PlayCloseAnimation();
        }

        private Viewport3D _viewport;
        private GeometryModel3D _slidingScreen;
        private const int SidePoints = 25;
        private void PlayLoadAnimation()
        {
            animationContainer.Children.Clear();

            Storyboard storyboard = CreatetAnimation(GenieEffectType.OutOfLamp);

            storyboard.Completed += (sender, e) =>
            {
                animationContainer.Visibility = Visibility.Hidden;
                transitionContrainer.Visibility = Visibility.Visible;
            };

            storyboard.Begin(animationContainer);
        }

        private void PlayCloseAnimation()
        {
            animationContainer.Children.Clear();

            Storyboard storyboard = CreatetAnimation(GenieEffectType.IntoLamp);

            storyboard.Completed += (sender, e) =>
            {
                this.Close();
            };

            storyboard.Begin(animationContainer);
        }

        private void PlayMinAnimation()
        {
            animationContainer.Children.Clear();

            Storyboard storyboard = CreatetAnimation(GenieEffectType.IntoLamp);

            storyboard.Completed += (sender, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };

            storyboard.Begin(animationContainer);
        }

        private void PlayNormalAnimation()
        {
            animationContainer.Children.Clear();

            Storyboard storyboard = CreatetAnimation(GenieEffectType.OutOfLamp);

            storyboard.Completed += (sender, e) =>
            {
                animationContainer.Visibility = Visibility.Hidden;
                transitionContrainer.Visibility = Visibility.Visible;
            };

            storyboard.Begin(animationContainer);
        }

        private NameScope GetNameScope()
        {
            NameScope scope = new NameScope();
            NameScope.SetNameScope(animationContainer, scope);
            return scope;
        }

        private static Brush CreateBrush(FrameworkElement elt)
        {
            VisualBrush brush = new VisualBrush(elt);
            brush.Viewbox = new Rect(0, 0, elt.ActualWidth, elt.ActualHeight);
            brush.ViewboxUnits = BrushMappingMode.Absolute;
            return brush;
        }

        private void InitAnimation()
        {
            _viewport = Application.LoadComponent(new Uri("/FluidKit;component/Controls/Transition/Genie/Genie.xaml", UriKind.Relative)) as Viewport3D;
            _slidingScreen = _viewport.FindName("SlidingScreen") as GeometryModel3D;

            NameScope.GetNameScope(_viewport).UnregisterName("SlidingScreen");
            GetNameScope().RegisterName("SlidingScreen", _slidingScreen);
        }

        private Storyboard CreatetAnimation(GenieEffectType effectType)
        {
            double aspect = transitionContrainer.ActualWidth / transitionContrainer.ActualHeight;

            MeshGeometry3D mesh = MeshCreator.CreateMesh(SidePoints, SidePoints);
            mesh.Positions = new RectangularMeshFiller().FillMesh(SidePoints, SidePoints, aspect);
            _slidingScreen.Geometry = mesh;
            _slidingScreen.Material = new DiffuseMaterial(CreateBrush(contentContrainer));
            PerspectiveCamera camera = _viewport.Camera as PerspectiveCamera;
            double angle = camera.FieldOfView / 2;
            double cameraZPos = (aspect / 2) / Math.Tan(angle * Math.PI / 180);
            camera.Position = new Point3D(0, 0, cameraZPos);

            Storyboard storyboard = (_viewport.Resources["GenieAnim"] as Storyboard).Clone();
            GenieAnimation anim = storyboard.Children[0] as GenieAnimation;
            anim.Duration = new Duration(TimeSpan.FromSeconds(1));
            anim.EffectType = effectType;
            anim.AspectRatio = aspect;

            animationContainer.Children.Add(_viewport);
            animationContainer.Visibility = Visibility.Visible;
            transitionContrainer.Visibility = Visibility.Hidden;

            return storyboard;
        }
    }
}
