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
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace DataBinder
{
    public class Recording
    {
        public Recording() { }
        public Recording(string artistName, string cdName, DateTime release)
        {
            Artist = artistName;
            Name = cdName;
            ReleaseDate = release;
        }
        public string Artist { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public override string ToString()
        {
            return Name + "by" + Artist + ",Released:" + ReleaseDate.ToShortDateString();
        }
    }
    public partial class MainPage : PhoneApplicationPage
    {
        public ObservableCollection<Recording> MyMusic = new ObservableCollection<Recording>();
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            MyMusic.Add(new Recording("Chris Sells", "Chris Sells Live", new DateTime(2008, 2, 5)));
            MyMusic.Add(new Recording("bhris Sells", "bhris Sells Live", new DateTime(2009, 2, 5)));
            MyMusic.Add(new Recording("dhris Sells", "dhris Sells Live", new DateTime(2007, 2, 5)));

            LayoutRoot.DataContext = new CollectionViewSource { Source = MyMusic };




        }
    }
}