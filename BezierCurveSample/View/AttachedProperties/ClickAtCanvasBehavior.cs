using BezierCurveSample.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BezierCurveSample.View.AttachedProperties
{
    public class ClickAtCanvasBehavior
    {
        public static ICommand GetClickAtCanvas(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ClickAtCanvasProperty);
        }

        public static void SetClickAtCanvas(DependencyObject obj, int value)
        {
            obj.SetValue(ClickAtCanvasProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClickAtCanvasProperty =
            DependencyProperty.RegisterAttached("ClickAtCanvas", typeof(ICommand), typeof(ClickAtCanvasBehavior), new PropertyMetadata(null, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var frameworkElement = dependencyObject as FrameworkElement;
            if (frameworkElement == null)
                return;

            var canvas = frameworkElement as Canvas;

            if (canvas == null)
                return;

            var mousePosition = Mouse.GetPosition(canvas);

            var newCommand = dependencyPropertyChangedEventArgs.NewValue as ICommand;
            var oldCommand = dependencyPropertyChangedEventArgs.OldValue as ICommand;
            if (newCommand != null)
            {
                RoutedEventHandler onMouseDown = (e, __) =>
                {
                    mousePosition = Mouse.GetPosition(canvas);
                    var point = new PointViewModel((float)mousePosition.X, (float)mousePosition.Y);
                    if (newCommand.CanExecute(point))
                    {
                        newCommand.Execute(point);
                    }
                };
                canvas.AddHandler(Mouse.MouseDownEvent, onMouseDown, true);
            }
            if (oldCommand != null)
            {
                oldCommand = null;
            }
        }
    }
}
