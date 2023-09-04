using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF学习1.Core;
using WPF学习1.Model;

namespace WPF学习1.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> MessageModels { get; set; }
        private string _messageInfo { set; get; }
        public string MessageInfo
        {
            get => _messageInfo;
            set
            {
                _messageInfo = value;
                OnPropertyChange();
            }
        }
        private bool _autoScroll;

        public bool AutoScroll
        {
            get { return _autoScroll; }
            set { _autoScroll = value; OnPropertyChange(); }
        }
        OpenAIAPI api = new OpenAIAPI("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"); // shorthand  
        public BaseCommand SendCommand { set; get; }
        public MainWindowViewModel()
        {
            MessageModels = new ObservableCollection<MessageModel>();
            MessageModels.Add(new MessageModel() { ImageSource = "..\\images\\chat50.png", MessageInfo = "这是第一个测试；这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是" });
            MessageModels.Add(new MessageModel() { ImageSource = "..\\images\\chat50.png", MessageInfo = "这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试这是第一个测试；这是第一个测试" });
            MessageModels.Add(new MessageModel() { ImageSource = "..\\images\\chat50.png", MessageInfo = "这是第一个测试；这是第一个测试；这是第一个测试这是第一个测试；这是" });
            MessageModels.Add(new MessageModel() { ImageSource = "..\\images\\chat50.png", MessageInfo = "这是第一个测试；这是第一个测试；这是第一个测试这是第一个测试；这是" });
            MessageModels.Add(new MessageModel() { ImageSource = "..\\images\\chat50.png", MessageInfo = "这是第一个测试；这是第一个测试；这是第一个测试这是第一个测试；这是" });
            MessageModels.Add(new MessageModel() { ImageSource = "..\\images\\chat50.png", MessageInfo = "这是第一个测试；这是第一个测试；这是第一个测试这是第一个测试；这是" });
            MessageModels.Add(new MessageModel() { ImageSource = "..\\images\\chat50.png", MessageInfo = "这是第一个测试；这是第一个测试；这是第一个测试这是第一个测试；这是" });
            MessageModels.Add(new MessageModel() { ImageSource = "..\\images\\chat50.png", MessageInfo = "这是第一个测试；这是第一个测试；这是第一个测试这是第一个测试；这是" });

            SendCommand = new BaseCommand(async o =>
            {
                AutoScroll = false;
                MessageModels.Add(new MessageModel() { ImageSource = "..\\images\\chat50.png", MessageInfo = MessageInfo });
                
                AutoScroll = true;              
                var chat = api.Chat.CreateConversation();
                chat.AppendUserInput(MessageInfo);
                var responed= new MessageModel() { ImageSource = "..\\images\\chat50.png"};
                MessageModels.Add(responed);
                await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
                {
                    responed.MessageInfo += res;                  
                }                

            });

        }
    }
}
