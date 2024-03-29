﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TuanZhang.UserControlSelector
{
    public partial class SiteSelector : UserControl
    {
        public SiteSelector()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SiteSelector_Loaded);
        }

        void SiteSelector_Loaded(object sender, RoutedEventArgs e)
        {
            this.lp_site.ItemsSource = new Data.DefaultData().DefaultSite();
        }
    }
}
