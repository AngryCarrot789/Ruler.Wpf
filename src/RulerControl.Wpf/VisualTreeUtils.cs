using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows;

namespace RulerControl.Wpf {
    public static class VisualTreeUtils {
        public static DependencyObject GetParent(DependencyObject source) {
            if (source is Visual || source is Visual3D) {
                return VisualTreeHelper.GetParent(source);
            }
            else if (source is FrameworkContentElement fce) {
                return fce.Parent;
            }
            else {
                return null;
            }
        }

        public static T FindVisualParent<T>(DependencyObject obj, bool includeSelf = true) where T : DependencyObject {
            if (obj == null || (includeSelf && obj is T)) {
                return (T) obj;
            }

            do {
                obj = GetParent(obj);
            } while (obj != null && !(obj is T));

            return (T) obj;
        }
    }
}