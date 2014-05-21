using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;

namespace BezierCurveSample.ViewModel
{
    public class MainViewModel:ViewModelBase
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
            toRet.Add(new PointViewModel(3,3));
            toRet.Add(new PointViewModel(5,1));
            toRet.Add(new PointViewModel(17,50));
            toRet.Add(new PointViewModel(45,9));
            toRet.Add(new PointViewModel(34,33));
            toRet.Add(new PointViewModel(70,68));
            toRet.Add(new PointViewModel(8,23));
            toRet.Add(new PointViewModel(60,100));
            toRet.Add(new PointViewModel(14,34));

            toRet.CollectionChanged += OnPointsCollectionChanged;

            return toRet;
        }

        private void OnPointsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
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
    }
    
}
