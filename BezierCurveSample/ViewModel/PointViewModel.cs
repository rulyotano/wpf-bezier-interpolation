using Rulyotano.Math;
using GalaSoft.MvvmLight;

namespace BezierCurveSample.ViewModel
{
    public class PointViewModel : ViewModelBase
    {

        public PointViewModel(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        #region X

        private float x;

        public float X
        {
            get { return x; }
            set
            {
                if (Numeric.FloatEquals(x, value)) return;
                x = value;
                RaisePropertyChanged("X");
            }
        }

        #endregion

        #region Y

        private float y;

        public float Y
        {
            get { return y; }
            set
            {
                if (Numeric.FloatEquals(y, value)) return;
                y = value;
                RaisePropertyChanged("Y");
            }
        }

        #endregion
    }
}
