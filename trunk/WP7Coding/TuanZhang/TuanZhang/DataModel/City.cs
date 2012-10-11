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
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.ComponentModel;

namespace TuanZhang.DataModel
{
    /// <summary>
    /// 团购城市
    /// </summary>
    [Table]
    public class City : INotifyPropertyChanged, INotifyPropertyChanging 
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
        /// 区号
        /// </summary>
        private string _postCode;
        [Column]
        public string PostCode
        {
            get { return _postCode; }
            set
            {
                NotifyPropertyChanging("PostCode");
                _postCode = value;
                NotifyPropertyChanged("PostCode"); 
            }
        }
        /// <summary>
        /// 拼音
        /// </summary>
        private string _pinYin;
        [Column]
        public string PinYin
        {
            get { return _pinYin; }
            set
            {
                NotifyPropertyChanging("PinYin");
                _pinYin = value;
                NotifyPropertyChanged("PinYin");
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        private string _name;
        [Column]
        public string Name
        {
            get { return _name; }
            set
            {
                NotifyPropertyChanging("Name");
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
        /// <summary>
        /// 代表图片地址
        /// </summary>
        private string _imgSrc;
        [Column]
        public string ImgSrc
        {
            get { return _imgSrc; }
            set
            {
                NotifyPropertyChanging("ImgSrc");
                _imgSrc = value;
                NotifyPropertyChanged("ImgSrc");
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        private string _remark;
        [Column]
        public string Remark
        {
            get { return _remark; }
            set
            {
                NotifyPropertyChanging("Remark");
                _remark = value;
                NotifyPropertyChanged("Remark");
            }
        }
        [Column(IsVersion = true)]
        private Binary _version;

        private EntitySet<Product> _todos;
        [Association(Storage = "_todos", OtherKey = "_cityId", ThisKey = "Id")]
        public EntitySet<Product> ToDos
        {
            get { return _todos; }
            set { _todos.Assign(value); }
        }
        public City()
        {
            _todos = new EntitySet<Product>(new Action<Product>(Add_ToDo), new Action<Product>(Delete_ToDo));
        }
        private void Add_ToDo(Product product)
        {
            product.ProductCity = this;
        }
        private void Delete_ToDo(Product product)
        {
            product.ProductCity = null;
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
