using SciChart.Charting.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF学习1.Model;

namespace WPF学习1.Core
{
    public class CourserDataTemplateSelector: System.Windows.Controls.DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { set; get; }
        public DataTemplate SkeletonTemplate { set; get; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
             
            if((item is CourseSeriesModel itemModel))
            {
                if (itemModel.IsShowSkeleton)
                {
                    return SkeletonTemplate;
                }
            }
            return DefaultTemplate;

        }
    }
}
