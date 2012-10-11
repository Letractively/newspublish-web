using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace TuanZhang.DataModel
{
    /// <summary>
    /// 团购分类
    /// </summary>
    [Table]
    public class Category : INotifyPropertyChanged, INotifyPropertyChanging 
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
        /// 父ID
        /// </summary>
        private int _fid;
        [Column(DbType = "INT NOT NULL")]
        public int Fid
        {
            get { return _fid; }
            set
            {
                NotifyPropertyChanging("Fid");
                _fid = value;
                NotifyPropertyChanged("Fid");
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
        [Association(Storage = "_todos", OtherKey = "_categoryId", ThisKey = "Id")]
        public EntitySet<Product> ToDos
        {
            get { return _todos; }
            set { _todos.Assign(value); }
        }
        public Category()
        {
            _todos = new EntitySet<Product>(new Action<Product>(Add_ToDo), new Action<Product>(Delete_ToDo));
        }
        private void Add_ToDo(Product product)
        {
            product.ProductCategory = this;
        }
        private void Delete_ToDo(Product product)
        {
            product.ProductCategory = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangingEventHandler PropertyChanging;
        private void NotifyPropertyChanging(string propertyName)
        { 
            if(PropertyChanging!=null)
                PropertyChanging(this,new PropertyChangingEventArgs(propertyName));
        }
    }
}
