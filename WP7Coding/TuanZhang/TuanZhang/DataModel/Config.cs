using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace TuanZhang.DataModel
{
    /// <summary>
    /// 系统配置
    /// </summary>
    [Table]
    public class Config:INotifyPropertyChanged,INotifyPropertyChanging
    {
        private int _id;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get { return _id; }
            set
            {
                NotifyPropertyChanging("Id");
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }
        /// <summary>
        /// 是否第一次打开App
        /// </summary>
        private bool isFirstOpenApp;
        [Column]
        public bool IsFirstOpenApp
        {
            get { return isFirstOpenApp; }
            set
            {
                NotifyPropertyChanging("IsFirstOpenApp");
                isFirstOpenApp = value;
                NotifyPropertyChanged("IsFirstOpenApp");
            }
        }
        /// <summary>
        /// 默认城市
        /// </summary>
        private int cityId;
        [Column]
        public int CityId
        {
            get { return cityId; }
            set
            {
                NotifyPropertyChanging("CityId");
                cityId = value;
                NotifyPropertyChanged("CityId");
            }
        }
        /// <summary>
        /// 页面条数大小
        /// </summary>
        private int pageSize;
        [Column]
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                NotifyPropertyChanging("PageSize");
                pageSize = value;
                NotifyPropertyChanged("PageSize");
            }
        }
        /// <summary>
        /// 是否自动移除过期团购
        /// </summary>
        private bool isAutoRemoveOutDateItems;
        [Column]
        public bool IsAutoRemoveOutDateItems
        {
            get { return isAutoRemoveOutDateItems; }
            set 
            {
                NotifyPropertyChanging("IsAutoRemoveOutDateItems");
                isAutoRemoveOutDateItems = value;
                NotifyPropertyChanged("IsAutoRemoveOutDateItems");
            }
        }
        /// <summary>
        /// 是否自动刷新数据
        /// </summary>
        private bool isAutoRefresh;
        [Column]
        public bool IsAutoRefresh
        {
            get { return isAutoRefresh; }
            set
            {
                NotifyPropertyChanging("IsAutoRefresh");
                isAutoRefresh = value;
                NotifyPropertyChanged("IsAutoRefresh");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangingEventHandler PropertyChanging;
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
