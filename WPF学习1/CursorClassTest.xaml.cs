using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF学习1.ViewModel;

namespace WPF学习1
{
    /// <summary>
    /// CursorClassTest.xaml 的交互逻辑
    /// </summary>
    public partial class CursorClassTest : Window
    {
        public CursorClassTest()
        {
            InitializeComponent();
            this.DataContext = new CursorClassTestVM();
        }
    }
}
