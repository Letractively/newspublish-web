using System.IO.IsolatedStorage;

namespace TuanZhang.Core
{
    public class AppSetting
    {
        IsolatedStorageSettings settings;
        /// <summary>
        /// 初配置
        /// </summary>
        public AppSetting()
        {
            settings = IsolatedStorageSettings.ApplicationSettings;
        }
        /// <summary>
        /// 初始化配置项
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public bool Initialize()
        {
            DataModel.Config config = new Data.DefaultData().DefaultConfig();
            bool valueChanged=true;
            valueChanged = valueChanged && AddOrUpdateValue("CityId", config.CityId);
            valueChanged = valueChanged && AddOrUpdateValue("IsAutoRemoveOutDateItems", config.IsAutoRemoveOutDateItems);
            valueChanged = valueChanged && AddOrUpdateValue("IsFirstOpenApp", config.IsFirstOpenApp);
            valueChanged = valueChanged && AddOrUpdateValue("PageSize", config.PageSize);
            if (valueChanged) Save();
            return valueChanged;
        }
        /// <summary>
        /// 添加或更新配置项
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string key, object value)
        {
            bool valueChanged = false;
            if (settings.Contains(key))
            {
                if (settings[key] != value)
                {
                    settings[key] = value;
                    valueChanged = true;
                }
            }
            else
            {
                settings.Add(key, value);
                valueChanged = true;
            }
            if (valueChanged) Save();
            return valueChanged;
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string GetValueOrDefault(string key)
        {
            string value = null;
            if (settings.Contains(key))
            {
                value = settings[key].ToString();
            }
            return value; 
        }
        /// <summary>
        /// 保存值
        /// </summary>
        public void Save()
        {
            settings.Save();
        }
        ///// <summary>
        ///// 本地设定
        ///// </summary>
        //public DataModel.City LocalCitySetting
        //{
        //    get
        //    {
        //        return GetValueOrDefault<DataModel.City>(LocalCityKeyName,new DataModel.City());
        //    }
        //    set
        //    {
        //        if (AddOrUpdateValue(LocalCityKeyName, value))
        //            Save();
        //    }
        //}
        ///// <summary>
        ///// 页面加载数目设定
        ///// </summary>
        //public int PageSizeSetting
        //{
        //    get
        //    {
        //        return GetValueOrDefault<int>(PageSizeKeyName,0);
        //    }
        //    set
        //    {
        //        if (AddOrUpdateValue(PageSizeKeyName, value))
        //            Save();
        //    }
        //}
    }
}
