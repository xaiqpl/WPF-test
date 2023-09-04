using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Models
{
    public class NavModel
    {
		private string _icon;

		public string Icon
		{
			get { return _icon; }
			set { _icon = value; }
		}
		private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}


	}
}
