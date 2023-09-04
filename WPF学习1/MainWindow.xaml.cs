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
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenAI_API;
using WPF学习1.ViewModel;

namespace WPF学习1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ChromiumWebBrowser browser1;
        //ChromiumWebBrowser browser2;
        // 创建一个OpenAIClient对象，需要提供api密钥和部署名称
      

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            //CefSettings settings = new CefSettings();
            //settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\\CEF\\";
            //settings.PersistSessionCookies = true;
            //settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36 Edg/97.0.1072.55";
            //CefSharp.Cef.Initialize(settings);

            //browser1 = new ChromiumWebBrowser();
            //browser1.Address = "www.bing.com/chat";
            //BrowerHost1.Children.Add(browser1);

            //browser2 = new ChromiumWebBrowser();
            //browser2.Address = "https://poe.com/";
            //BrowerHost2.Children.Add(browser2);

        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //// 获取用户在第一个文本框中输入的内容
            //string input = textInput.Text.Trim();
            //resopned.AppendText(input);
            //resopned.AppendText("\r\n");
            //var chat = api.Chat.CreateConversation();
            //chat.AppendUserInput(input);

            //await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
            //{
            //    resopned.AppendText(res);
            //    resopned.ScrollToEnd();
            //}
            //resopned.AppendText("\r\n");
            //resopned.ScrollToEnd();
            //AddColoredText("这个是一个测试");
        }

        // 定义一个扩展方法，给AppendText方法添加一个颜色参数      
        private void AddColoredText(string text)
        {
            //var run = new Run(text);
            //run.Foreground= System.Windows.Media.Brushes.White;
            //run.FontSize = 20;

            //run.Background = System.Windows.Media.Brushes.Purple;
            //resopned1.Document.Blocks.Add(new Paragraph(run));
            //run.Text = text + text;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinSize_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonMaxSize_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.MainWindow.WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
           System.Windows.Application.Current.Shutdown();
        }       
    }

}
