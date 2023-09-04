using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Models;

namespace Wallet.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<NavModel> NavCollection { set; get; }=new ObservableCollection<NavModel>();
        public NavModel CountModel { get; set; }

        public NavModel ExitModel { get; set; }
        public MainViewModel() 
        {
            NavCollection.Add(new NavModel() { Icon = "\ue851", Title = "钱包" });
            NavCollection.Add(new NavModel() { Icon = "\ue633", Title = "通知" });
            NavCollection.Add(new NavModel() { Icon = "\ue63a", Title = "存款" });
            NavCollection.Add(new NavModel() { Icon = "\ue810", Title = "记录" });
            NavCollection.Add(new NavModel() { Icon = "\uec3b", Title = "消息" });
            NavCollection.Add(new NavModel() { Icon = "\ue619", Title = "监控" });
            NavCollection.Add(new NavModel() { Icon = "\ue6a0", Title = "我的" });

            CountModel = new NavModel() { Icon = "\ue6a0", Title = "账号" };
            ExitModel = new NavModel() { Icon = "\ue62e", Title = "退出" };
        }
    }
}
