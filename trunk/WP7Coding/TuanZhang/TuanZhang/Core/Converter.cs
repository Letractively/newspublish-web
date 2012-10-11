using System;
using System.Windows.Data;
using System.Collections.ObjectModel;
using TuanZhang.DataModel;

namespace TuanZhang.Core
{
    public class Converter
    {

    }
    /// <summary>
    /// 价格转换
    /// </summary>
    public class PriceConvert : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value + " RMB";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 购买人数转换
    /// </summary>
    public class BounghtConvert : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value + "人购买";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 剩余时间转换
    /// </summary>
    public class SurplusTimeConvert : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime st = DateTime.Now;
            DateTime ed = DateTime.Parse(value.ToString());
            TimeSpan ts = ed - st;
            return "剩余时间："+ts.Days+"天"+ts.Hours+"小时"+ts.Minutes+"分钟";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 是否收藏图片转换
    /// </summary>
    public class IsCollectConvert_Pic : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (bool.Parse(value.ToString()))
                return "/Images/33xStar.png";
            else
                return "/Images/30xStar_Gray.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 是否收藏文字转换
    /// </summary>
    public class IsCollectConvert_Text : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (bool.Parse(value.ToString()))
                return "已收藏";
            else
                return "未收藏";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 是否主打推荐
    /// </summary>
    public class MajorConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (bool.Parse(value.ToString()))
                return "/Images/456xBest.png";
            else
                return "/Images/30xBlack.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 浮点数转整数
    /// </summary>
    public class FloatToIntConvert : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return int.Parse(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 城市名称转换
    /// </summary>
    public class CityNameConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int cityId = int.Parse(value.ToString());
            ObservableCollection<DataModel.City> list = App.ViewModel.SelectCitys();
            string result = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == cityId)
                    return list[i].Name;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// json时间格式转换
    /// </summary>
    public static class JsonTimeConvert
    {
        public static DateTime ConvertTo(string jsonText)
        {
            DateTime dt = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            TimeSpan ts = new TimeSpan();
            long ltime = 0;
            ltime = long.Parse(jsonText + "0000000");
            ts = new TimeSpan(ltime + 288000000000);
            return dt.Add(ts);
        }
    }
    /// <summary>
    /// 商品类型定位
    /// </summary>
    public static class CategoryConvert
    {
        /// <summary>
        /// 从关键字库中提取类别
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int ConvertTo(string p)
        {
            ObservableCollection<DataModel.Category> list = App.ViewModel.SelectCategorys();
            int id = 6;
            foreach (Category cate in list)
            {
                if (cate.Name.IndexOf(p) > 0 || cate.Remark.IndexOf(p) > 0)
                    id = cate.Fid == 0 ? cate.Id : cate.Fid;
            }
            return id;
        }
        /// <summary>
        /// 从词句中过滤关键字
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int ConvertFrom(string p)
        {
            ObservableCollection<DataModel.Category> list = App.ViewModel.SelectCategorys();
            int id = 6;
            foreach (Category cate in list)
            {
                if (p.IndexOf(cate.Name) > 0 )
                    id = cate.Fid == 0 ? cate.Id : cate.Fid;
            }
            return id;
        }
    }
}
