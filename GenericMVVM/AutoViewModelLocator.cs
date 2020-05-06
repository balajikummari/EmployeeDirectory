using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows;

namespace GenericMVVM
{
    /// <summary>
    /// for View First Approach
    /// </summary>
    public static class AutoViewModelLocator {
        public static bool GetAutoAttachViewModel(DependencyObject obj) {
            return (bool) obj.GetValue(AutoAttachViewModelProperty);
        }

        public static void SetAutoAttachViewModel(DependencyObject obj, bool value) {
            obj.SetValue(AutoAttachViewModelProperty, value);
        }

        public static readonly DependencyProperty AutoAttachViewModelProperty =
            DependencyProperty.RegisterAttached("AutoAttachViewModel",
                typeof (bool), typeof (AutoViewModelLocator),
                new PropertyMetadata(false, AutoAttachViewModelChanged));

        private static void AutoAttachViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (DesignerProperties.GetIsInDesignMode(d)) {
                return;
            }
            Type viewType = d.GetType();
            string viewModelTypeName = viewType.FullName.Replace("View", "ViewModel");
            var assembliesForSearchingIn = AssemblySource.Instance;

            var allExportedTypes = new List<Type>();
            foreach (var assembly in assembliesForSearchingIn) {
                allExportedTypes.AddRange(assembly.GetExportedTypes());
            }
            Type viewModelType = allExportedTypes.Single(x => x.FullName == viewModelTypeName);
            object viewModel = IoC.GetInstance(viewModelType, null);
            ((FrameworkElement) d).DataContext = viewModel;
        }
    }
}