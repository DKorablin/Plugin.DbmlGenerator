using System;
using System.Windows.Forms;

namespace Plugin.DbmlGenerator
{
	internal class ListViewItemEx : ListViewItem
	{
		public ListViewItemEx(String text)
			: base(text) { }
		public override String ToString()
		{
			return base.Text;
		}
	}
}