using System;
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

namespace TuanZhang
{
    public partial class CitySelector : PhoneApplicationPage
    {
        public CitySelector()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(CitySelector_Loaded);
        }

        void CitySelector_Loaded(object sender, RoutedEventArgs e)
        {
            string from = NavigationContext.QueryString["from"];
            longListSelector.ItemsSource = new Items();
        }
        /// <summary>
        /// 确定选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            string CityId = tb.Tag.ToString();
            Core.BllFun bf = new Core.BllFun();
            DataModel.Config config = bf.SelectConfig();
            config.CityId = CityId;
            bf.UpdateConfig(config.Id.ToString(), config);
            NavigationService.Navigate(new Uri("/Default.xaml", UriKind.Relative));
        }
    }
    /// <summary>
    /// 选项实体类
    /// </summary>
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        //获取名字的首个字符用来作为分组的依据
        public static string GetFirstNameKey(Item item)
        {
            char key;
            key = char.ToLower(item.Content[0]);
            if (key < 'a' || key > 'z')
            {
                key = '#';
            }
            return char.ToUpper(key).ToString();
        }
    }
    /// <summary>
    /// 组集合
    /// </summary>
    public class ItemInGroup : List<Item>
    {
        public ItemInGroup(string category)
        {
            Key = category;
        }
        //组的键
        public string Key { get; set; }
        //组是否有选项
        public bool HasItems { get { return Count > 0; } }
    }
    /// <summary>
    /// 总数据集合
    /// </summary>
    public class Items : List<ItemInGroup>
    {
        //索引
        private static readonly string Groups = "#|A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z";

        public Items()
        {
            //获取要绑定的数据源
            List<Item> items = new List<Item>();
            List<DataModel.City> cityList = new Core.BllFun().SelectCitys();
            cityList.ForEach(a =>
            {
                items.Add(new Item { Id = a.Id, Name = a.Name, Content = a.PinYin });
            });
            //组的字典列表
            Dictionary<string, ItemInGroup> groups = new Dictionary<string, ItemInGroup>();

            //初始化组列表，即用字母列表来分组
            foreach (string c in Groups.Split('|'))
            {
                ItemInGroup group = new ItemInGroup(c.ToString());
                //添加组数据到集合
                this.Add(group);
                groups[c.ToString()] = group;
            }

            //初始化选项列表，即按照选项所属的组来放进它属于的组里面
            foreach (Item item in items)
            {
                //添加选项数据到集合
                groups[Item.GetFirstNameKey(item)].Add(item);
            }
        }
    }
}