using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UI.CustomControls
{
    public class WaterMarkTextBox:TextBox
    {
        static WaterMarkTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WaterMarkTextBox), new System.Windows.PropertyMetadata(typeof(WaterMarkTextBox))); 
        }


        public string WaterMark
        {
            get { return (string)GetValue(WaterMarkProperty); }
            set { SetValue(WaterMarkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaterMark.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaterMarkProperty =
            DependencyProperty.Register("WaterMark", typeof(string), typeof(WaterMarkTextBox), new PropertyMetadata("int put Password"));



        public VerticalAlignment WaterMarkVertical
        {
            get { return (VerticalAlignment)GetValue(WaterMarkVerticalProperty); }
            set { SetValue(WaterMarkVerticalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaterMarkVertical.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaterMarkVerticalProperty =
            DependencyProperty.Register("WaterMarkVertical", typeof(VerticalAlignment), typeof(WaterMarkTextBox), new PropertyMetadata(
               ));




    }
}
