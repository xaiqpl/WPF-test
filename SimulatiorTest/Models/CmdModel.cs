using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatiorTest.Models
{
    public class CmdModel : ReactiveObject
    {
        [Reactive]
        public bool IsResponse { get; set; }
        [Reactive]
        public int CmdCode { get; set; }
        [Reactive]
        public ObservableCollection<ResponseCmd> ResponseCmdList { get; set; } = new ObservableCollection<ResponseCmd>();
        //{ 0xf02c, 0x4286, 0xa, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa, }
        //{ 0xF02D, 0x0AFC, 0xA, 0x1, 0x0, 0x2, 0x0, 0x3, 0xC8, 0x4, 0x1A6D, 0x5, 0x0, 0x6, 0x0, 0x7, 0x0, 0x8, 0x0, 0x9, 0x0, 0xA, 0x0, }
    }
    public class ResponseCmd : ReactiveObject
    {
        [Reactive]
        public int ResCmdCode { get; set; }
        [Reactive]
        public ObservableCollection<CmdParameter> Parameters { get; set; } = new ObservableCollection<CmdParameter>();
    }
    public class CmdParameter : ReactiveObject
    {
        [Reactive]
        public string ParamName { get; set; }
        [Reactive]
        public string ParamDes { get; set; }
        [Reactive]
        public string ParamValue { get; set; }
    }
}