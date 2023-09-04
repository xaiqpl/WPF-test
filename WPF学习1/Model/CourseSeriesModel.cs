using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF学习1.Model
{
    public class CourseSeriesModel
    {
        public string CourseName { set; get; }
        public ObservableCollection<SeriesModel> SeriesList { set; get; }

        public bool IsShowSkeleton { set; get; }
    }
    public class SeriesModel
    {
        public string SeriesName { set; get; }
        public int CurrentValue { set; get; }

        public bool IsGrowing { set; get; }

        public int  ChangeRate{ set; get;}
    }
}
