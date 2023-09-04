using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Specialized;
using System.Windows.Media;

namespace WPF学习1.Core
{
    // 定义一个附加属性类
    public class ListViewBehavior
    {
        // 获取附加属性的值
        public static bool GetAutoScrollToBottom(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToBottomProperty);
        }

        // 设置附加属性的值
        public static void SetAutoScrollToBottom(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToBottomProperty, value);
        }

        // 注册附加属性
        public static readonly DependencyProperty AutoScrollToBottomProperty =
            DependencyProperty.RegisterAttached("AutoScrollToBottom", typeof(bool), typeof(ListViewBehavior), new PropertyMetadata(false, (o, e) =>
            {
                var listView = o as ListView;
                if (listView == null)
                {
                    return;
                }
                if ((bool)e.NewValue)
                {
                    // 找到ListView的最后一个item
                    var lastItem = listView.Items[listView.Items.Count - 1];

                    // 滚动到最后一个item
                    listView.ScrollIntoView(lastItem);
                }
               
            }));

        // 附加属性值为真时，绑定ListView控件的SelectionChanged事件
        private static void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            if (listView == null)
            {
                return;
            }
            listView.UpdateLayout();
            listView.ScrollIntoView(listView.SelectedItem);
        }
    }

}
