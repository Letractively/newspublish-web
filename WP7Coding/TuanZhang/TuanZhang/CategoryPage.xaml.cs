using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;

namespace TuanZhang
{
    public partial class CategoryPage : PhoneApplicationPage
    {
        public CategoryPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(CategoryPage_Loaded);
        }
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CategoryPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationContext.QueryString.Count > 0)
            {
                string catrgory = NavigationContext.QueryString["category"];
                switch (catrgory)
                {
                    case "food": pi.SelectedIndex = 0;
                        break;
                    case "play": pi.SelectedIndex = 1;
                        break;
                    case "life": pi.SelectedIndex = 2;
                        break;
                    case "buy": pi.SelectedIndex = 3;
                        break;
                    case "hotel": pi.SelectedIndex = 4;
                        break;
                    case "other": pi.SelectedIndex = 5;
                        break;
                    default: break;
                }
                NavigationContext.QueryString.Clear();
            }
            GC.Collect();
        }
        /// <summary>
        /// 点击列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_local_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            FrameworkElement feSource = e.OriginalSource as FrameworkElement;
            string name = feSource.Name;
            switch (feSource.Name)
            {
                //查看详情
                case "tb_title":
                    NavigationService.Navigate(new Uri("/ProductDetail.xaml?id=" + feSource.Tag, UriKind.Relative));
                    break;
                //查看详情
                case "img_product":
                    NavigationService.Navigate(new Uri("/ProductDetail.xaml?id=" + feSource.Tag, UriKind.Relative));
                    break;
                //收藏
                case "tb_collect":
                    App.ViewModel.SetCollectProduct(feSource.Tag.ToString());
                    break;
                default: break;
            }
        }
        /// <summary>
        /// 列表改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pivot piv = (Pivot)sender;
            switch (piv.SelectedIndex)
            {
                case 0: if (lb_food.ItemsSource == null)
                    {
                        App.ViewModel.LoadCateData();   //加载vm数据
                        this.lb_food.ItemsSource = App.ViewModel.FoodProducts;
                        lb_food.Visibility = Visibility.Visible;
                    }
                    break;
                case 1:
                    if (lb_play.ItemsSource == null)
                    {
                        this.lb_play.ItemsSource = App.ViewModel.PlayProducts;
                        lb_play.Visibility = Visibility.Visible;
                    }
                    break;
                case 2: if (lb_life.ItemsSource == null)
                    {
                        this.lb_life.ItemsSource = App.ViewModel.LifeProducts;
                        lb_life.Visibility = Visibility.Visible;
                    }
                    break;
                case 3:
                    if (lb_buy.ItemsSource == null)
                    {
                        this.lb_buy.ItemsSource = App.ViewModel.BuyProducts;
                        lb_buy.Visibility = Visibility.Visible;
                    }
                    break;
                case 4: if (lb_hotel.ItemsSource == null)
                    {
                        this.lb_hotel.ItemsSource = App.ViewModel.HotelProducts;
                        lb_hotel.Visibility = Visibility.Visible;
                    }
                    break;
                case 5:
                    if (lb_other.ItemsSource == null)
                    {
                        this.lb_other.ItemsSource = App.ViewModel.OtherProducts;
                        lb_other.Visibility = Visibility.Visible;
                    }
                    break;
            }
            GC.Collect();
        }
    }
}