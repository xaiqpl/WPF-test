using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestChartControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private ChartData _chartDataOrg;
        public ChartData FluCharDataOrg
        {
            get => _chartDataOrg;
            set => SetProperty(ref _chartDataOrg, value);
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Point> famFlu = new List<Point>();
            List<Point> hexFlu = new List<Point>();
            List<Point> roxFlu = new List<Point>();
            List<Point> cy5Flu = new List<Point>();
            for (int i = 0; i < 45; i++)
            {
                famFlu.Add(new Point(i+1,(float)i * 10 + 2000));
                hexFlu.Add(new Point(i + 1, (float)i * 10 + 1000));
                roxFlu.Add(new Point(i + 1, (float)i * 10 + 500));
               // cy5Flu.Add(new Point(i + 1, (float)i * 10 + 100));
            }
            FluCharDataOrg = new ChartData();
            int reqId = 221;
            FluCharDataOrg.AddLine(new LineData()
            {
                Key = reqId,
                Tag = "FAM",
                Points = new ObservableCollection<Point>(famFlu),
            });
            FluCharDataOrg.AddLine(new LineData()
            {
                Key = reqId,
                Tag = "HEX",
                Points = new ObservableCollection<Point>(hexFlu),
            });
            FluCharDataOrg.AddLine(new LineData()
            {
                Key = reqId,
                Tag = "ROX",
                Points = new ObservableCollection<Point>(roxFlu),
            });
            FluCharDataOrg.AddLine(new LineData()
            {
                Key = reqId,
                Tag = "CY5",
                Points = new ObservableCollection<Point>(cy5Flu),
            });
            var lindata = FluCharDataOrg.Lines.Where(r => r.Tag == "CY5").FirstOrDefault();
            Task.Run(async () =>
            {
                for (int i = 0; i < 45; i++)
                {
                    lindata.Points.Add(new Point(i + 1, i * 10 + 3000));
                    await Task.Delay(1000);
                }
            });
            
        }





        public event PropertyChangedEventHandler? PropertyChanged;      
        public bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        int id = 222;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Point> famFlu = new List<Point>();
            for (double i = 35; i < 85; i+=0.3)
            {
                famFlu.Add(new Point(i, (float)id * 10+ i* 100));
            }
            FluCharDataOrg.AddLine(new LineData()
            {
                Key = id++,
                Tag = "Fam",
                Points = new ObservableCollection<Point>(famFlu),
            });
        }
    }
  
}
