using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF学习1.Core;
using WPF学习1.Model;

namespace WPF学习1.ViewModel
{
    public class CursorClassTestVM : ObservableObject

    {

        public ObservableCollection<CourseSeriesModel> CourseSeriesList { set; get; } = new ObservableCollection<CourseSeriesModel>();

        public CursorClassTestVM()
        {
            InitParams();

        }

        private void InitParams()
        {
            CourseSeriesList.Clear();
            for (int i = 0; i < 10; i++)
            {
                CourseSeriesList.Add(new CourseSeriesModel() { IsShowSkeleton = true });
            }
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(4000);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    CourseSeriesList.Clear();
                    CourseSeriesList.Add(new CourseSeriesModel
                    {
                        CourseName = "C#高级数据",
                        SeriesList = new ObservableCollection<SeriesModel>{
                new SeriesModel{SeriesName="云课堂",CurrentValue=161,IsGrowing=true, ChangeRate=75} ,
                new SeriesModel{SeriesName="B占",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="C占",CurrentValue=161,IsGrowing=true, ChangeRate=75},
                new SeriesModel{SeriesName="Dsdf",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="F多少度",CurrentValue=161,IsGrowing=true, ChangeRate=75}}
                    });

                    CourseSeriesList.Add(new CourseSeriesModel
                    {
                        CourseName = "Java高级数据",
                        SeriesList = new ObservableCollection<SeriesModel>{
                new SeriesModel{SeriesName="云课堂",CurrentValue=161,IsGrowing=true, ChangeRate=75} ,
                new SeriesModel{SeriesName="B占",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="C占",CurrentValue=161,IsGrowing=true, ChangeRate=75},
                new SeriesModel{SeriesName="Dsdf",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="F多少度",CurrentValue=161,IsGrowing=true, ChangeRate=75}}
                    });

                    CourseSeriesList.Add(new CourseSeriesModel
                    {
                        CourseName = "C++高级数据",
                        SeriesList = new ObservableCollection<SeriesModel>{
                new SeriesModel{SeriesName="云课堂",CurrentValue=161,IsGrowing=true, ChangeRate=75} ,
                new SeriesModel{SeriesName="B占",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="C占",CurrentValue=161,IsGrowing=true, ChangeRate=75},
                new SeriesModel{SeriesName="Dsdf",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="F多少度",CurrentValue=161,IsGrowing=true, ChangeRate=75}}
                    });

                    CourseSeriesList.Add(new CourseSeriesModel
                    {
                        CourseName = "C高级数据",
                        SeriesList = new ObservableCollection<SeriesModel>{
                new SeriesModel{SeriesName="云课堂",CurrentValue=161,IsGrowing=true, ChangeRate=75} ,
                new SeriesModel{SeriesName="B占",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="C占",CurrentValue=161,IsGrowing=true, ChangeRate=75},
                new SeriesModel{SeriesName="Dsdf",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="F多少度",CurrentValue=161,IsGrowing=true, ChangeRate=75}}
                    });

                    CourseSeriesList.Add(new CourseSeriesModel
                    {
                        CourseName = "Ardunio高级数据",
                        SeriesList = new ObservableCollection<SeriesModel>{
                new SeriesModel{SeriesName="云课堂",CurrentValue=161,IsGrowing=true, ChangeRate=75} ,
                new SeriesModel{SeriesName="B占",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="C占",CurrentValue=161,IsGrowing=true, ChangeRate=75},
                new SeriesModel{SeriesName="Dsdf",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="F多少度",CurrentValue=161,IsGrowing=true, ChangeRate=75}}
                    });


                    CourseSeriesList.Add(new CourseSeriesModel
                    {
                        CourseName = "Go高级数据",
                        SeriesList = new ObservableCollection<SeriesModel>{
                new SeriesModel{SeriesName="云课堂",CurrentValue=161,IsGrowing=true, ChangeRate=75} ,
                new SeriesModel{SeriesName="B占",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="C占",CurrentValue=161,IsGrowing=true, ChangeRate=75},
                new SeriesModel{SeriesName="Dsdf",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="F多少度",CurrentValue=161,IsGrowing=true, ChangeRate=75}}
                    });

                    CourseSeriesList.Add(new CourseSeriesModel
                    {
                        CourseName = "Python高级数据",
                        SeriesList = new ObservableCollection<SeriesModel>{
                new SeriesModel{SeriesName="云课堂",CurrentValue=161,IsGrowing=true, ChangeRate=75} ,
                new SeriesModel{SeriesName="B占",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="C占",CurrentValue=161,IsGrowing=true, ChangeRate=75},
                new SeriesModel{SeriesName="Dsdf",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="F多少度",CurrentValue=161,IsGrowing=true, ChangeRate=75}}
                    });

                    CourseSeriesList.Add(new CourseSeriesModel
                    {
                        CourseName = "Php高级数据",
                        SeriesList = new ObservableCollection<SeriesModel>{
                new SeriesModel{SeriesName="云课堂",CurrentValue=161,IsGrowing=true, ChangeRate=75} ,
                new SeriesModel{SeriesName="B占",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="C占",CurrentValue=161,IsGrowing=true, ChangeRate=75},
                new SeriesModel{SeriesName="Dsdf",CurrentValue=161,IsGrowing=false, ChangeRate=75},
                new SeriesModel{SeriesName="F多少度",CurrentValue=161,IsGrowing=true, ChangeRate=75}}
                    });
                });

            });

        }
    }
}
