using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF学习1.Core;

namespace WPF学习1.Model
{
    public class MessageModel : ObservableObject
    {
        private string _messageInfo;
        private string _imageSource;

        public string MessageInfo { get => _messageInfo; set { _messageInfo = value; OnPropertyChange(); } }
        public string ImageSource { get => _imageSource; set { _imageSource = value; OnPropertyChange(); } }

    }
}
