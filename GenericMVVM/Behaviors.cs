using System.Windows;

namespace GenericMVVM
{
    /// <summary>
    /// Attached Behaviours
    /// </summary>
    public static class Behaviors {
        public static string GetLoadedEventHandlerName(DependencyObject obj) {
            return (string) obj.GetValue(LoadedEventHandlerNameProperty);
        }

        public static void SetLoadedEventHandlerName(DependencyObject obj, string value) {
            obj.SetValue(LoadedEventHandlerNameProperty, value);
        }

        public static readonly DependencyProperty LoadedEventHandlerNameProperty =
            DependencyProperty.RegisterAttached("LoadedEventHandlerName",
                typeof (string), typeof (Behaviors), new PropertyMetadata(null, OnLoadedMethodNameChanged));

        private static void OnLoadedMethodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            FrameworkElement element = d as FrameworkElement;
            if (element != null) {
                element.Loaded += (s, e2) => {
                    var viewModel = element.DataContext;
                    if (viewModel == null) {
                        return;
                    }
                    var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                    if (methodInfo != null) {
                        methodInfo.Invoke(viewModel, null);
                    }
                };
            }
        }
    }
}