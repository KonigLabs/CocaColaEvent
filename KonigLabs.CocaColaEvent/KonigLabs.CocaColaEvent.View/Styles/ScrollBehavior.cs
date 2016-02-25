using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace KonigLabs.CocaColaEvent.View.Styles
{
    public class TouchScrolling : Behavior<ScrollViewer>
    {
        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }

        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(TouchScrolling));

        static Dictionary<object, MouseCapture> _captures = new Dictionary<object, MouseCapture>();

        protected override void OnAttached()
        {
            IsEnabledChanged();
        }

        protected override void OnDetaching()
        {
        }

        public ScrollViewer ScrollViewer
        {
            get { return (ScrollViewer)GetValue(ScrollViewerProperty); }
            set { SetValue(ScrollViewerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScrollViewer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollViewerProperty =
            DependencyProperty.Register("ScrollViewer", typeof (ScrollViewer), typeof (TouchScrolling), null);



         void IsEnabledChanged()
        {
            var target = ScrollViewer as ScrollViewer;
            if (target == null) return;


                target.Loaded += target_Loaded;

                //target_Unloaded(target, new RoutedEventArgs());
            
        }

         void target_Unloaded(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Target Unloaded");

            var target = sender as ScrollViewer;
            if (target == null) return;

            _captures.Remove(sender);

            target.Loaded -= target_Loaded;
            target.Unloaded -= target_Unloaded;
            target.PreviewMouseLeftButtonDown -= target_PreviewMouseLeftButtonDown;
            target.PreviewMouseMove -= target_PreviewMouseMove;

            target.PreviewMouseLeftButtonUp -= target_PreviewMouseLeftButtonUp;
        }

         void target_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            _captures[sender] = new MouseCapture
            {
                VerticalOffset = target.HorizontalOffset,
                Point = e.GetPosition(target),
            };
        }

         void target_Loaded(object sender, RoutedEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            System.Diagnostics.Debug.WriteLine("Target Loaded");

            target.Unloaded += target_Unloaded;
            target.PreviewMouseLeftButtonDown += target_PreviewMouseLeftButtonDown;
            target.PreviewMouseMove += target_PreviewMouseMove;

            target.PreviewMouseLeftButtonUp += target_PreviewMouseLeftButtonUp;
        }

         void target_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            target.ReleaseMouseCapture();
        }

         void target_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (!_captures.ContainsKey(sender)) return;

            if (e.LeftButton != MouseButtonState.Pressed)
            {
                _captures.Remove(sender);
                return;
            }

            var target = sender as ScrollViewer;
            if (target == null) return;

            var capture = _captures[sender];

            var point = e.GetPosition(target);

            var dy = point.X - capture.Point.X;

             if (Math.Abs(dy) < 0.1)
                 return;
            if (Math.Abs(dy) > 20)
            {
                target.CaptureMouse();
            }

            target.ScrollToHorizontalOffset(capture.VerticalOffset - dy);
        }

        internal class MouseCapture
        {
            public Double VerticalOffset { get; set; }
            public Point Point { get; set; }
        }
    }
}
