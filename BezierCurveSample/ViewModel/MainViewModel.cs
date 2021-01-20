using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Rulyotano.Math;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Rulyotano.Math.Geometry;

namespace BezierCurveSample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }
        }

        #region Title

        private string _Title = "Interpolate 2D points, usign Bezier curves in WPF";
        private const string TitleName = "Title";

        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    RaisePropertyChanged(TitleName);
                }
            }
        }

        #endregion

        #region Points

        private ObservableCollection<PointViewModel> _Points;

        public ObservableCollection<PointViewModel> Points
        {
            get { return _Points ?? (_Points = GetAllPoints()); }
        }

        private ObservableCollection<PointViewModel> GetAllPoints()
        {
            var toRet = new ObservableCollection<PointViewModel>();

            //TODO: Add initials the items
            toRet.Add(new PointViewModel(173, 42));
            toRet.Add(new PointViewModel(5, 1));
            toRet.Add(new PointViewModel(64, 84));
            toRet.Add(new PointViewModel(210, 64));
            toRet.Add(new PointViewModel(191, 90));
            toRet.Add(new PointViewModel(241, 206));
            toRet.Add(new PointViewModel(31, 138));
            toRet.Add(new PointViewModel(338, 112));
            toRet.Add(new PointViewModel(310, 33));

            toRet.CollectionChanged += OnPointsCollectionChanged;

            return toRet;
        }

        private void OnPointsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("PathText");
            if (e.NewItems != null)
            {
            }
            if (e.OldItems != null)
            {
            }
        }

        #endregion

        #region IsClosedCurve

        private bool _IsClosedCurve;
        private const string IsClosedCurveName = "IsClosedCurve";

        public bool IsClosedCurve
        {
            get { return _IsClosedCurve; }
            set
            {
                if (_IsClosedCurve != value)
                {
                    _IsClosedCurve = value;
                    RaisePropertyChanged(IsClosedCurveName);
                }
            }
        }

        #endregion

        #region AddPoints

        private bool _addPoints;
        private const string AddPointsName = "AddPoints";

        public bool AddPoints
        {
            get { return _addPoints; }
            set
            {
                if (_addPoints != value)
                {
                    _addPoints = value;
                    RaisePropertyChanged(AddPointsName);
                }
            }
        }

        #endregion

        #region CanvasClickCommand

        private RelayCommand<PointViewModel> _canvasClickCommand;
        public RelayCommand<PointViewModel> CanvasClickCommand
        {
            get => _canvasClickCommand ?? new RelayCommand<PointViewModel>((t) =>
                {
                    var newPoint = new Point(t.X, t.Y);
                    var newPointModel = new PointViewModel(t.X, t.Y);
                    var pointsList = Points.Select(it => new Point(it.X, it.Y));
                    var insertIndex = Helpers.BestPlaceToInsert(newPoint, pointsList.ToList());
                    if (insertIndex == Points.Count)
                    {
                        Points.Add(newPointModel);
                        return;
                    }
                    Points.Insert(insertIndex, newPointModel);
                }, (t) => AddPoints);
        }

        #endregion

        #region PathText

        public string PathText
        {
            get
            {
                var interpolationSegments = Interpolation.PointsToBezierCurves(Points.Select(it => new Point(it.X, it.Y)).ToList(), false);
                return interpolationSegments.BezierToPath();
            }
        }

        #endregion
    }

}
