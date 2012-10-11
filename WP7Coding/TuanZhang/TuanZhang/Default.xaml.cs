using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.ComponentModel;
using System.Windows.Media;
using Microsoft.Phone.Net.NetworkInformation;
using System.Threading;

namespace TuanZhang
{
    public partial class Default : PhoneApplicationPage
    {
        public Default()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Default_Loaded);
            this.BackKeyPress += new EventHandler<CancelEventArgs>(Default_BackKeyPress);
        }
        /// <summary>
        /// 退出按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Default_BackKeyPress(object sender, CancelEventArgs e)
        {
            //如果是正打开城市选择框
            if (pp_cityselector.IsOpen)
            {
                pp_cityselector.Visibility = System.Windows.Visibility.Collapsed;
                pp_cityselector.IsOpen = false;
                ApplicationBar.IsVisible = true;
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Default_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.lb_local.ItemsSource == null)
            {
                this.lb_local.ItemsSource = App.ViewModel.LocalProducts;
                this.lb_collect.ItemsSource = App.ViewModel.CollectProducts;
                this.lb_search.ItemsSource = App.ViewModel.SearchProducts;
                grid_config.DataContext = App.ViewModel.Config;
                App.ViewModel.RefreshComplete += new ViewModel.ProductViewModel.RefreshDataEventHandler(ViewModel_RefreshComplete);
            } 
            if (App.ViewModel.Config.IsFirstOpenApp)
            {
                MessageBoxResult result = MessageBox.Show("首先很感谢您选择团长！程序第一次运行需要你选择一下归属地！", "温馨提示", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    App.ViewModel.Config.IsFirstOpenApp = false;
                    App.ViewModel.UpdateConfig(App.ViewModel.Config.Id, App.ViewModel.Config);

                    pp_cityselector.Visibility = System.Windows.Visibility.Visible;
                    pp_cityselector.IsOpen = true;
                    ApplicationBar.IsVisible = false;
                }
            }
            else
            {
                if (App.ViewModel.LocalProducts.Count == 0)
                    MessageBox.Show("当前城市还没有团购信息，请刷新获取！");
            }
        }
        /// <summary>
        /// 数据模板刷新完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="count"></param>
        void ViewModel_RefreshComplete(object sender, string count, string siteName, bool isOver)
        {
            if (isOver)
            {
                PragressShowOrHide(false);
            }
            Core.SystemTrayHelper.Instance.ShowMessage("新获取[" + siteName + "]" + count + "条信息！", 5);
        }
        /// <summary>
        /// 选择城市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCity(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            App.ViewModel.Config.CityId = int.Parse(tb.Tag.ToString());
            App.ViewModel.UpdateConfig(App.ViewModel.Config.Id, App.ViewModel.Config);//更新
            pp_cityselector.Visibility = System.Windows.Visibility.Collapsed;
            pp_cityselector.IsOpen = false;
            ApplicationBar.IsVisible = true;

            if (App.ViewModel.Config.IsAutoRefresh)
            {
                RefreshData();
            }
        }
        #region 分类导航部分
        private void img_food_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CategoryPage.xaml?category=food", UriKind.Relative));
        }

        private void img_play_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CategoryPage.xaml?category=play", UriKind.Relative));
        }

        private void img_life_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CategoryPage.xaml?category=life", UriKind.Relative));
        }

        private void img_buy_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CategoryPage.xaml?category=buy", UriKind.Relative));
        }

        private void img_hotel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CategoryPage.xaml?category=hotel", UriKind.Relative));
        }
        private void img_other_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CategoryPage.xaml?category=other", UriKind.Relative));
        }
        #endregion
        #region 配置界面部分
        /// <summary>
        /// 改变本地城市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_changelocation_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            pp_cityselector.Visibility = System.Windows.Visibility.Visible;
            pp_cityselector.IsOpen = true;
        }
        /// <summary>
        /// 显示条数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sd = (Slider)sender;
            if (tb_pagesize != null)
            {
                App.ViewModel.Config.PageSize = int.Parse(sd.Value.ToString("F0"));
                App.ViewModel.UpdateConfig(App.ViewModel.Config.Id, App.ViewModel.Config);
            }
        }
        /// <summary>
        /// 是否自动刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_autorefresh_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.IsChecked.Value)
                App.ViewModel.Config.IsAutoRefresh = true;
            else
                App.ViewModel.Config.IsAutoRefresh = false;
            App.ViewModel.UpdateConfig(App.ViewModel.Config.Id, App.ViewModel.Config);
        }
        /// <summary>
        /// 是否自动清理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_autoremove_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.IsChecked.Value)
                App.ViewModel.Config.IsAutoRemoveOutDateItems = true;
            else
                App.ViewModel.Config.IsAutoRemoveOutDateItems = false;
            App.ViewModel.UpdateConfig(App.ViewModel.Config.Id, App.ViewModel.Config);
        }
        #endregion
        /// <summary>
        /// 任务栏刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void appbar_reload_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            if (DeviceNetworkInformation.IsNetworkAvailable)
            {
                if (!DeviceNetworkInformation.IsWiFiEnabled)
                {
                    MessageBoxResult result = MessageBox.Show("当前网络非WiFi环境，是否继续刷新？", "提示", MessageBoxButton.OKCancel);
                    if (MessageBoxResult.Cancel == result) return;
                }
                Core.SystemTrayHelper.Instance.ShowMessage("数据量比较大，刷新时间长！", 5);
                PragressShowOrHide(true);
                App.ViewModel.RefreshData();
            }
            else
            {
                MessageBox.Show("当前网络不可用！");
            }
        }
        /// <summary>
        /// 进度条显示与隐藏
        /// </summary>
        public void PragressShowOrHide(bool flag)
        {
            if (flag)
            {
                pp_loading.Visibility = System.Windows.Visibility.Visible;
                pp_loading.IsOpen = true;
                customIndeterminateProgressBar.IsIndeterminate=true;
                customIndeterminateProgressBar.Visibility = Visibility.Visible;
            }
            else
            {
                customIndeterminateProgressBar.IsIndeterminate = false;
                customIndeterminateProgressBar.Visibility = Visibility.Collapsed;
                pp_loading.Visibility = System.Windows.Visibility.Collapsed;
                pp_loading.IsOpen = false;
            }
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
        /// 检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_search_Click(object sender, RoutedEventArgs e)
        {
            string keyWords = tb_keywords.Text;
            if (!string.IsNullOrEmpty(keyWords))
                App.ViewModel.SearchData(keyWords);
        }

    }
}