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
using System.Data.Linq;

namespace TuanZhang.DataModel
{
    /// <summary>
    /// 基础数据库
    /// </summary>
    public class DataBase : DataContext
    {
        public DataBase(string connStr)
            : base(connStr)
        { }

        public Table<Site> T_Site;
        public Table<City> T_City;
        public Table<Category> T_Category;
        public Table<Product> T_Product;
        public Table<Config> T_Config;
    }
}
