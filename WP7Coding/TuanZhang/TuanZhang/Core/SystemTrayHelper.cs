using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Controls;
using System.Windows.Threading;

namespace TuanZhang.Core
{
    public class SystemTrayHelper
    {
        private ProgressIndicator _mangoIndicator;
        private PhoneApplicationPage _currentPage;
        private static SystemTrayHelper _in;
        public static SystemTrayHelper Instance
        {
            get
            {
                if (_in == null)
                {
                    _in = new SystemTrayHelper();
                }
                return _in;
            }
        }
        public SystemTrayHelper()
        { 
        
        }
        public void Initialize(PhoneApplicationFrame frame)
        {
            _mangoIndicator = new ProgressIndicator();
            frame.Navigated += new System.Windows.Navigation.NavigatedEventHandler(frame_Navigated);
        }

        void frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var pp = e.Content as PhoneApplicationPage;
            _currentPage = pp;
            if (pp != null)
            {
                this._mangoIndicator.IsVisible = true;
                
                pp.SetValue(SystemTray.ProgressIndicatorProperty, _mangoIndicator);
                pp.SetValue(SystemTray.OpacityProperty, 0.9);
                pp.SetValue(SystemTray.BackgroundColorProperty, Color.FromArgb(0,4,174,218));
                pp.SetValue(SystemTray.ForegroundColorProperty, Color.FromArgb(0, 255, 255, 255));
            }
        }
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="content"></param>
        /// <param name="second"></param>
        public void ShowMessage(string content, int second)
        {
            this._mangoIndicator.Text = content;
            this._mangoIndicator.IsVisible = true;
            SystemTray.IsVisible = true;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(second);
            timer.Tick += (sender, e) =>
                {
                    this._mangoIndicator.Text = string.Empty;
                    this._mangoIndicator.IsVisible = false;
                    SystemTray.IsVisible = false;
                    timer.Stop();
                };
            timer.Start();
        }
    }
}
