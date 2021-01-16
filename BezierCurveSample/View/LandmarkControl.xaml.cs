using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BezierCurveSample.View.Utils;
using Point = BezierCurveSample.Common.Geometry.Point;

namespace BezierCurveSample.View
{
    /// <summary>
    /// Interaction logic for LandmarkControl.xaml
    /// </summary>
    public partial class LandmarkControl : UserControl
    {
        #region Points

        public IEnumerable Points
        {
            get { return (IEnumerable)GetValue(PointsProperty); }
            set { SetValue(PointsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Points. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.Register("Points", typeof(IEnumerable),
            typeof(LandmarkControl), new PropertyMetadata(null, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject,
        DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var landmarkControl = dependencyObject as LandmarkControl;
            if (landmarkControl == null)
                return;

            if (dependencyPropertyChangedEventArgs.NewValue is INotifyCollectionChanged)
            {
                (dependencyPropertyChangedEventArgs.NewValue as
                INotifyCollectionChanged).CollectionChanged += landmarkControl.OnPointCollectionChanged;
                landmarkControl.RegisterCollectionItemPropertyChanged
                (dependencyPropertyChangedEventArgs.NewValue as IEnumerable);
            }

            if (dependencyPropertyChangedEventArgs.OldValue is INotifyCollectionChanged)
            {
                (dependencyPropertyChangedEventArgs.OldValue as
                INotifyCollectionChanged).CollectionChanged -= landmarkControl.OnPointCollectionChanged;
                landmarkControl.UnRegisterCollectionItemPropertyChanged
                (dependencyPropertyChangedEventArgs.OldValue as IEnumerable);
            }

            if (dependencyPropertyChangedEventArgs.NewValue != null)
                landmarkControl.SetPathData();
        }

        #endregion

        #region PathColor

        public Brush PathColor
        {
            get { return (Brush)GetValue(PathColorProperty); }
            set { SetValue(PathColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PathColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathColorProperty =
            DependencyProperty.Register("PathColor", typeof(Brush), typeof(LandmarkControl),
                                        new PropertyMetadata(Brushes.Black));

        #endregion

        #region IsClosedCurve

        public static readonly DependencyProperty IsClosedCurveProperty =
            DependencyProperty.Register("IsClosedCurve", typeof(bool), typeof(LandmarkControl),
                                        new PropertyMetadata(default(bool), OnIsClosedCurveChanged));

        private static void OnIsClosedCurveChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var landmarkControl = dependencyObject as LandmarkControl;
            if (landmarkControl == null)
                return;
            landmarkControl.SetPathData();
        }

        public bool IsClosedCurve
        {
            get { return (bool)GetValue(IsClosedCurveProperty); }
            set { SetValue(IsClosedCurveProperty, value); }
        }

        #endregion


        public LandmarkControl()
        {
            InitializeComponent();
        }

        private System.Windows.Point ConvertToVisualPoint(Point p)
        {
            return new System.Windows.Point(p.X, p.Y);
        }

        void SetPathData()
        {
            if (Points == null) return;
            var points = new List<Point>();

            foreach (var point in Points)
            {
                var pointProperties = point.GetType().GetProperties();
                if (pointProperties.All(p => p.Name != "X") ||
                pointProperties.All(p => p.Name != "Y"))
                    continue;
                var x = (float)point.GetType().GetProperty("X").GetValue(point, new object[] { });
                var y = (float)point.GetType().GetProperty("Y").GetValue(point, new object[] { });
                points.Add(new Point(x, y));
            }

            if (points.Count <= 1)
                return;

            var myPathFigure = new PathFigure { StartPoint = ConvertToVisualPoint(points.FirstOrDefault()) };


            var myPathSegmentCollection = new PathSegmentCollection();

            var beizerSegments = Interpolation.InterpolatePointWithBeizerCurves(points, IsClosedCurve);

            if (beizerSegments == null || beizerSegments.Count < 1)
            {
                //Add a line segment <this is generic for more than one line>
                foreach (var point in points.GetRange(1, points.Count - 1))
                {

                    var myLineSegment = new LineSegment { Point = ConvertToVisualPoint(point) };
                    myPathSegmentCollection.Add(myLineSegment);
                }
            }
            else
            {
                foreach (var beizerCurveSegment in beizerSegments)
                {
                    var segment = new BezierSegment
                    {
                        Point1 = ConvertToVisualPoint(beizerCurveSegment.FirstControlPoint),
                        Point2 = ConvertToVisualPoint(beizerCurveSegment.SecondControlPoint),
                        Point3 = ConvertToVisualPoint(beizerCurveSegment.EndPoint)
                    };
                    myPathSegmentCollection.Add(segment);
                }
            }


            myPathFigure.Segments = myPathSegmentCollection;

            var myPathFigureCollection = new PathFigureCollection { myPathFigure };

            var myPathGeometry = new PathGeometry { Figures = myPathFigureCollection };

            path.Data = myPathGeometry;
        }

        private void RegisterCollectionItemPropertyChanged(IEnumerable collection)
        {
            if (collection == null)
                return;
            foreach (INotifyPropertyChanged point in collection)
                point.PropertyChanged += OnPointPropertyChanged;
        }

        private void UnRegisterCollectionItemPropertyChanged(IEnumerable collection)
        {
            if (collection == null)
                return;
            foreach (INotifyPropertyChanged point in collection)
                point.PropertyChanged -= OnPointPropertyChanged;
        }

        private void OnPointCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RegisterCollectionItemPropertyChanged(e.NewItems);

            UnRegisterCollectionItemPropertyChanged(e.OldItems);

            SetPathData();
        }

        private void OnPointPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "X" || e.PropertyName == "Y")
                SetPathData();
        }
    }
}
