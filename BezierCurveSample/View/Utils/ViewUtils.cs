using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BezierCurveSample.View.Utils
{
    public static class ViewUtils
    {
        public static bool AnyParent(DependencyObject item, Func<DependencyObject, bool> condition)
        {
            if (item == null)
                return false;

            var logicalParent = LogicalTreeHelper.GetParent(item);
            var visualParent = VisualTreeHelper.GetParent(item);

            return condition(item) || AnyParent(visualParent, condition);
        }

        public static DependencyObject GetParent(DependencyObject item, Func<DependencyObject, bool> condition)
        {
            if (item == null)
                return null;

            var logicalParent = LogicalTreeHelper.GetParent(item);
            var visualParent = VisualTreeHelper.GetParent(item);

            return condition(item) ? item : GetParent(visualParent, condition);
        }

        public static DependencyObject GetVisualChild(DependencyObject item, Func<DependencyObject, bool> condition)
        {
            if (item == null)
                return null;

            var q = new Queue<DependencyObject>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(item); i++)
            {
                var t = VisualTreeHelper.GetChild(item, i);
                if (condition(t))
                    return t;
                q.Enqueue(t);
            }

            while (q.Count > 0)
            {
                var subchild = q.Dequeue();
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(subchild); i++)
                {
                    var t = VisualTreeHelper.GetChild(subchild, i);
                    if (condition(t))
                        return t;
                    q.Enqueue(t);
                }
            }
            return null;
        }

        public static DependencyObject GetLogicalChild(DependencyObject item, Func<DependencyObject, bool> condition)
        {
            if (item == null)
                return null;

            var q = new Queue<DependencyObject>();
            foreach (var w in LogicalTreeHelper.GetChildren(item))
            {
                var t = w as DependencyObject;
                if (condition(t))
                    return t;
                q.Enqueue(t);
            }

            while (q.Count > 0)
            {
                var subchild = q.Dequeue();
                foreach (var w in LogicalTreeHelper.GetChildren(subchild))
                {
                    var t = w as DependencyObject;
                    if (condition(t))
                        return t;
                    q.Enqueue(t);
                }
            }
            return null;
        }
    }
}
