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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XYWPF.Sample.Effect
{
    /// <summary>
    /// SearchTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class SearchTextBox : UserControl
    {
        public static readonly DependencyProperty IsSearchedProperty = DependencyProperty.Register("IsSearched", typeof(bool), typeof(SearchTextBox), new PropertyMetadata(null));
        public bool IsSearched
        {
            get { return (bool)GetValue(IsSearchedProperty); }
            set { SetValue(IsSearchedProperty, value); }
        }

        public SearchTextBox()
        {
            InitializeComponent();

            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextBox), new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }

        private void SearchImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            storyboard.Children.Clear();
            if (!IsSearched)
            {
                IsSearched = true;
                SetAnimation();
            }
            else
            {
                IsSearched = false;
                SetOppositeAnimation();
            }
        }

        #region 交互逻辑
        //整个动态效果由展开动态组和折叠动态组两部分组成，通过改变不同控件的Opacity、Margin、Width来达到最后的效果。
        private Storyboard storyboard = new Storyboard();

        private void SetAnimation()
        {
            DoubleAnimation DisappearAnimation = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromMilliseconds(500)));
            Storyboard.SetTarget(DisappearAnimation, this.SearchEllipse);
            Storyboard.SetTargetProperty(DisappearAnimation, new PropertyPath("Opacity"));

            ThicknessAnimation LoationAnimation = new ThicknessAnimation(new Thickness(250, 0, 0, 0), new Duration(TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(LoationAnimation, this.SearchImage);
            Storyboard.SetTargetProperty(LoationAnimation, new PropertyPath("Margin"));

            DoubleAnimation AppearAnimation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(AppearAnimation, this.SearchBorder);
            Storyboard.SetTargetProperty(AppearAnimation, new PropertyPath("Opacity"));

            DoubleAnimation StretchAnimation = new DoubleAnimation(0, this.Width, new Duration(TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(StretchAnimation, this.SearchBorder);
            Storyboard.SetTargetProperty(StretchAnimation, new PropertyPath("Width"));

            DoubleAnimation ScrollAnimation = new DoubleAnimation(0, 230, new Duration(TimeSpan.FromSeconds(2)));
            Storyboard.SetTarget(ScrollAnimation, this.SearchLine);
            Storyboard.SetTargetProperty(ScrollAnimation, new PropertyPath("Width"));

            storyboard.Children.Add(DisappearAnimation);
            storyboard.Children.Add(LoationAnimation);
            storyboard.Children.Add(AppearAnimation);
            storyboard.Children.Add(StretchAnimation);
            storyboard.Children.Add(ScrollAnimation);
            storyboard.Begin();
        }
        private void SetOppositeAnimation()
        {
            DoubleAnimation ScrollAnimation = new DoubleAnimation(230, 0, new Duration(TimeSpan.FromMilliseconds(500)));
            Storyboard.SetTarget(ScrollAnimation, this.SearchLine);
            Storyboard.SetTargetProperty(ScrollAnimation, new PropertyPath("Width"));

            DoubleAnimation StretchAnimation = new DoubleAnimation(this.Width, 0, new Duration(TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(StretchAnimation, this.SearchBorder);
            Storyboard.SetTargetProperty(StretchAnimation, new PropertyPath("Width"));

            DoubleAnimation AppearAnimation = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(AppearAnimation, this.SearchBorder);
            Storyboard.SetTargetProperty(AppearAnimation, new PropertyPath("Opacity"));

            ThicknessAnimation LoationAnimation = new ThicknessAnimation(new Thickness(0, 0, 0, 0), new Duration(TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(LoationAnimation, this.SearchImage);
            Storyboard.SetTargetProperty(LoationAnimation, new PropertyPath("Margin"));

            DoubleAnimation DisappearAnimation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(2)));
            Storyboard.SetTarget(DisappearAnimation, this.SearchEllipse);
            Storyboard.SetTargetProperty(DisappearAnimation, new PropertyPath("Opacity"));

            storyboard.Children.Add(ScrollAnimation);
            storyboard.Children.Add(StretchAnimation);
            storyboard.Children.Add(AppearAnimation);
            storyboard.Children.Add(LoationAnimation);
            storyboard.Children.Add(DisappearAnimation);
            storyboard.Begin();
        } 
        #endregion
    }
}
