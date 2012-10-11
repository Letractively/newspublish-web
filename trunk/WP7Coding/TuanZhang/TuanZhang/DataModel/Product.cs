using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace TuanZhang.DataModel
{
    /// <summary>
    /// 团购产品
    /// </summary>
    [Table]
    public class Product : INotifyPropertyChanged, INotifyPropertyChanging
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
        /// 自类别唯一标示符
        /// </summary>
        private string _guid;
        [Column]
        public string Guid
        {
            get { return _guid; }
            set
            {
                NotifyPropertyChanging("Guid");
                _guid = value;
                NotifyPropertyChanged("Guid");
            }
        }
        /// <summary>
        /// 站点ID
        /// </summary>
        [Column]
        internal int _webSiteId;
        private EntityRef<Site> _webSite;
        [Association(IsForeignKey = true, Storage = "_webSite", ThisKey = "_webSiteId", OtherKey = "Id")]
        public Site WebSite
        {
            get { return _webSite.Entity; }
            set
            {
                _webSite.Entity=value;
                if (value != null)
                    _webSiteId = value.Id;
            }
        }
        /// <summary>
        /// 城市ID
        /// </summary>
        [Column]
        internal int _cityId;
        private EntityRef<City> _productCity;
        [Association(IsForeignKey = true, Storage = "_productCity", ThisKey = "_cityId", OtherKey = "Id")]
        public City ProductCity
        {
            get { return _productCity.Entity; }
            set
            {
                _productCity.Entity = value;
                if (value != null)
                   _cityId = value.Id;
            }
        }
        /// <summary>
        /// 团购分类ID
        /// </summary>
        [Column]
        internal int _categoryId;
        private EntityRef<Category> _productCategory;
        [Association(IsForeignKey = true, Storage = "_productCategory", ThisKey = "_categoryId", OtherKey = "Id")]
        public Category ProductCategory
        {
            get { return _productCategory.Entity; }
            set 
            {
                _productCategory.Entity = value;
                if (value != null)
                   _categoryId = value.Id;
            }
        }
        /// <summary>
        /// 商品url
        /// </summary>
        private string _url;
        [Column]
        public string Url
        {
            get { return _url; }
            set
            {
                NotifyPropertyChanging("Url");
                _url = value;
                NotifyPropertyChanged("Url");
            }
        }
        /// <summary>
        /// 商品wapUrl
        /// </summary>
        private string _wapUrl;
        [Column]
        public string WapUrl
        {
            get { return _wapUrl; }
            set
            {
                NotifyPropertyChanging("WapUrl");
                _wapUrl = value;
                NotifyPropertyChanged("WapUrl"); 
            }
        }
        /// <summary>
        /// 商家的大众点评网ID
        /// </summary>
        private string _dpShopId;
        [Column]
        public string DpShopId
        {
            get { return _dpShopId; }
            set
            {
                NotifyPropertyChanging("DpShopId");
                _dpShopId = value;
                NotifyPropertyChanged("DpShopId"); 
            }
        }
        /// <summary>
        /// 商圈名称
        /// </summary>
        private string _range;
        [Column]
        public string Range
        {
            get { return _range; }
            set
            {
                NotifyPropertyChanging("Range");
                _range = value;
                NotifyPropertyChanged("Range"); 
            }
        }
        /// <summary>
        /// 商家的店面地址
        /// </summary>
        private string _address;
        [Column]
        public string Address
        {
            get { return _address; }
            set
            {
                NotifyPropertyChanging("Address");
                _address = value;
                NotifyPropertyChanged("Address"); 
            }
        }
        /// <summary>
        /// 商家地址经度
        /// </summary>
        private string _longitude;
        [Column]
        public string Longitude
        {
            get { return _longitude; }
            set
            {
                NotifyPropertyChanging("Longitude");
                _longitude = value;
                NotifyPropertyChanged("Longitude"); 
            }
        }
        /// <summary>
        /// 商家地址纬度
        /// </summary>
        private string _latitude;
        [Column]
        public string Latitude
        {
            get { return _latitude; }
            set
            {
                NotifyPropertyChanging("Latitude");
                _latitude = value;
                NotifyPropertyChanged("Latitude"); 
            }
        }
        /// <summary>
        /// 是否主打[1为主打，0为非主打]
        /// </summary>
        private bool _major;
        [Column]
        public bool Major
        {
            get { return _major; }
            set 
            {
                NotifyPropertyChanging("Major");
                _major = value;
                NotifyPropertyChanged("Major"); 
            }
        }
        /// <summary>
        /// 商品标题
        /// </summary>
        private string _title;
        [Column]
        public string Title
        {
            get { return _title; }
            set 
            {
                NotifyPropertyChanging("Title");
                _title = value;
                NotifyPropertyChanged("Title"); 
            }
        }
        /// <summary>
        /// 商品描述
        /// </summary>
        private string _detail;
        [Column]
        public string Detail
        {
            get { return _detail; }
            set
            {
                NotifyPropertyChanging("Detail");
                _detail = value;
                NotifyPropertyChanged("Detail"); 
            }
        }
        /// <summary>
        /// 商品小图片地址
        /// </summary>
        private string _smallImage;
        [Column]
        public string SmallImage
        {
            get { return _smallImage; }
            set 
            {
                NotifyPropertyChanging("SmallImage");
                _smallImage = value;
                NotifyPropertyChanged("SmallImage"); 
            }
        }
        /// <summary>
        /// 商品图片地址
        /// </summary>
        private string _image;
        [Column]
        public string Image
        {
            get { return _image; }
            set
            {
                NotifyPropertyChanging("Image");
                _image = value;
                NotifyPropertyChanged("Image"); 
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime _startTime;
        [Column]
        public DateTime StartTime
        {
            get { return _startTime; }
            set 
            {
                NotifyPropertyChanging("StartTime");
                _startTime = value;
                NotifyPropertyChanged("StartTime"); 
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime _endTime;
        [Column]
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                NotifyPropertyChanging("EndTime");
                _endTime = value;
                NotifyPropertyChanged("EndTime"); 
            }
        }
        /// <summary>
        /// 剩余时间
        /// </summary>
        private string _surplusTime;
        [Column]
        public string SurplusTime
        { 
            get 
            {
                TimeSpan ts = EndTime - DateTime.Now;
                return "剩余：" + ts.Days + "天" + ts.Hours + "小时" + ts.Minutes + "分钟";
            }
            set
            {
                _surplusTime = value;
            }
        }
        /// <summary>
        /// 商品原价
        /// </summary>
        private float _value;
        [Column]
        public float Value
        {
            get { return _value; }
            set 
            {
                NotifyPropertyChanging("Value");
                _value = value;
                NotifyPropertyChanged("Value"); 
            }
        }
        /// <summary>
        /// 现价
        /// </summary>
        private float _price;
        [Column]
        public float Price
        {
            get { return _price; }
            set
            {
                NotifyPropertyChanging("Price");
                _price = value;
                NotifyPropertyChanged("Price");
            }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        private float _rebate;
        [Column]
        public float Rebate
        {
            get { return _rebate; }
            set 
            {
                NotifyPropertyChanging("Rebate");
                _rebate = value;
                NotifyPropertyChanged("Rebate");
            }
        }
        /// <summary>
        /// 购买人数
        /// </summary>
        private string _bought;
        [Column]
        public string Bought
        {
            get { return _bought; }
            set
            {
                NotifyPropertyChanging("Bought");
                _bought = value;
                NotifyPropertyChanged("Bought");
            }
        }
        /// <summary>
        /// 商品提醒
        /// </summary>
        private string _tips;
        [Column]
        public string Tips
        {
            get { return _tips; }
            set
            {
                NotifyPropertyChanging("Tips");
                _tips = value;
                NotifyPropertyChanged("Tips");
            }
        }
        /// <summary>
        /// 交通信息
        /// </summary>
        private string _traffic;
        [Column]
        public string Traffic
        {
            get { return _traffic; }
            set { _traffic = value; }
        }
        /// <summary>
        /// 商家名称
        /// </summary>
        private string _seller;
        [Column]
        public string Seller
        {
            get { return _seller; }
            set 
            {
                NotifyPropertyChanging("Seller");
                _seller = value;
                NotifyPropertyChanged("Seller");
            }
        }
        /// <summary>
        /// 商家电话[多个用之间用|分割]
        /// </summary>
        private string _phone;
        [Column]
        public string Phone
        {
            get { return _phone; }
            set
            {
                NotifyPropertyChanging("Phone");
                _phone = value;
                NotifyPropertyChanged("Phone");
            }
        }
        /// <summary>
        /// 是否收藏
        /// </summary>
        private string _collect;
        [Column]
        public string Collect
        {
            get { return _collect; }
            set
            {
                NotifyPropertyChanging("Collect");
                _collect = value;
                NotifyPropertyChanged("Collect");
            }
        }
        /// <summary>
        /// 收藏状态图片
        /// </summary>
        private string _collectPic;
        [Column]
        public string CollectPic
        {
            get { return _collectPic; }
            set
            {
                NotifyPropertyChanging("CollectPic");
                _collectPic = value;
                NotifyPropertyChanged("CollectPic");
            }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        private DateTime _time;
        [Column]
        public DateTime Time
        {
            get { return _time; }
            set
            {
                NotifyPropertyChanging("Time");
                _time = value;
                NotifyPropertyChanged("Time");
            }
        }
        [Column(IsVersion = true)]
        private Binary _version;


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
