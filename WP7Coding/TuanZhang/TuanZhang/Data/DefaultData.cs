using System.Collections.Generic;
using TuanZhang.DataModel;

namespace TuanZhang.Data
{
    public class DefaultData
    {
        /// <summary>
        /// 默认站点数据
        /// </summary>
        /// <returns></returns>
        public List<Site> DefaultSite()
        {
            List<Site> siteList = new List<Site>();
            siteList.Add(new Site { Id = 1, Name = "拉手网", ApiUri = "http://open.client.lashou.com/api/detail/city/{0}/p/1/r/100", LogoImgSrc = "/Images/SiteLogo/logo-lashou.png", Remark = string.Empty });
            siteList.Add(new Site { Id = 2, Name = "美团网", ApiUri = "http://www.meituan.com/api/v2/{0}/deals", LogoImgSrc = "/Images/SiteLogo/logo-meituan.png", Remark = string.Empty });
            siteList.Add(new Site { Id = 3, Name = "糯米网", ApiUri = "http://www.nuomi.com/api/dailydeal?version=v1&city={0}", LogoImgSrc = "", Remark = string.Empty });
            siteList.Add(new Site { Id = 4, Name = "窝窝团", ApiUri = "http://www.55tuan.com/openAPI.do?city={0}", LogoImgSrc = "", Remark = string.Empty });
            return siteList;
        }
        /// <summary>
        /// 默认城市数据
        /// </summary>
        /// <returns></returns>
        public List<City> DefaultCity()
        {
            List<City> cityList = new List<City>();
            cityList.Add(new City { Id = 1, Name = "北京", PinYin = "beijing", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 2, Name = "上海", PinYin = "shanghai", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 3, Name = "广州", PinYin = "guangzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 4, Name = "深圳", PinYin = "shenzhen", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 5, Name = "天津", PinYin = "tianjin", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 6, Name = "西安", PinYin = "xian", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 7, Name = "福州", PinYin = "fuzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 8, Name = "重庆", PinYin = "chongqing", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 9, Name = "杭州", PinYin = "hangzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 10, Name = "宁波", PinYin = "ningbo", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 11, Name = "无锡", PinYin = "wuxi", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 12, Name = "南京", PinYin = "nanjing", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 13, Name = "合肥", PinYin = "hefei", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 14, Name = "武汉", PinYin = "wuhan", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 15, Name = "成都", PinYin = "chengdu", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 16, Name = "青岛", PinYin = "qingdao", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 17, Name = "厦门", PinYin = "xiamen", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 18, Name = "大连", PinYin = "dalian", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 19, Name = "沈阳", PinYin = "shenyang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 20, Name = "长沙", PinYin = "changsha", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 21, Name = "郑州", PinYin = "zhengzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 22, Name = "石家庄", PinYin = "shijiazhuang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 23, Name = "苏州", PinYin = "suzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 24, Name = "淄博", PinYin = "zibo", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 25, Name = "南通", PinYin = "nantong", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 26, Name = "南昌", PinYin = "nanchang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 27, Name = "常州", PinYin = "changzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 28, Name = "东莞", PinYin = "dongguan", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 29, Name = "佛山", PinYin = "foshan", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 30, Name = "桂林", PinYin = "guilin", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 31, Name = "海口", PinYin = "haikou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 32, Name = "济南", PinYin = "jinan", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 33, Name = "焦作", PinYin = "jiaozuo", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 34, Name = "锦州", PinYin = "jinzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 35, Name = "南宁", PinYin = "nanning", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 36, Name = "太原", PinYin = "taiyuan", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 37, Name = "芜湖", PinYin = "wuhu", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 38, Name = "烟台", PinYin = "yantai", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 39, Name = "哈尔滨", PinYin = "haerbin", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 40, Name = "廊坊", PinYin = "langfang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 41, Name = "贵阳", PinYin = "guiyang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 42, Name = "珠海", PinYin = "zhuhai", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 43, Name = "齐齐哈尔", PinYin = "qiqihaer", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 44, Name = "泉州", PinYin = "quanzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 45, Name = "温州", PinYin = "wenzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 46, Name = "中山", PinYin = "zhongshan", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 47, Name = "昆明", PinYin = "kunming", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 48, Name = "长春", PinYin = "changchun", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 49, Name = "徐州", PinYin = "xuzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 50, Name = "扬州", PinYin = "yangzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 51, Name = "唐山", PinYin = "tangshan", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 52, Name = "秦皇岛", PinYin = "qinhuangdao", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 53, Name = "邯郸", PinYin = "handan", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 54, Name = "运城", PinYin = "yuncheng", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 55, Name = "临汾", PinYin = "linfen", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 56, Name = "呼和浩特", PinYin = "huhehaote", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 57, Name = "包头", PinYin = "baotou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 58, Name = "鞍山", PinYin = "anshan", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 59, Name = "抚顺", PinYin = "fushun", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 60, Name = "吉林", PinYin = "jilin", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 61, Name = "连云港", PinYin = "lianyungang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 62, Name = "盐城", PinYin = "yancheng", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 63, Name = "镇江", PinYin = "zhenjiang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 64, Name = "泰州", PinYin = "taizhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 65, Name = "嘉兴", PinYin = "jiaxing", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 66, Name = "湖州", PinYin = "huzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 67, Name = "绍兴", PinYin = "shaoxing", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 68, Name = "金华", PinYin = "jinhua", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 69, Name = "台州", PinYin = "taizhoutz", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 70, Name = "东营", PinYin = "dongying", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 71, Name = "潍坊", PinYin = "weifang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 72, Name = "济宁", PinYin = "jining", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 73, Name = "泰安", PinYin = "taian", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 74, Name = "威海", PinYin = "weihai", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 75, Name = "临沂", PinYin = "linyi", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 76, Name = "聊城", PinYin = "liaocheng", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 77, Name = "洛阳", PinYin = "luoyang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 78, Name = "宜昌", PinYin = "yichang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 79, Name = "襄阳", PinYin = "xiangyang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 80, Name = "荆州", PinYin = "jingzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 81, Name = "衡阳", PinYin = "hengyang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 82, Name = "岳阳", PinYin = "yueyang", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 83, Name = "江门", PinYin = "jiangmen", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 84, Name = "惠州", PinYin = "huizhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 85, Name = "柳州", PinYin = "liuzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 86, Name = "遵义", PinYin = "zunyi", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 87, Name = "兰州", PinYin = "lanzhou", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 88, Name = "西宁", PinYin = "xining", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 89, Name = "昆山", PinYin = "kunshan", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 90, Name = "义乌", PinYin = "yiwu", PostCode = "", Remark = "", ImgSrc = "" });
            cityList.Add(new City { Id = 91, Name = "顺德", PinYin = "shunde", PostCode = "", Remark = "", ImgSrc = "" });
            return cityList;
        }
        /// <summary>
        /// 默认类别数据
        /// </summary>
        /// <returns></returns>
        public List<Category> DefaultCategory()
        {
            List<Category> categoryList = new List<Category>();
            categoryList.Add(new Category { Id = 1, Name = "餐饮美食", Fid = 0, Remark = string.Empty });
            categoryList.Add(new Category { Id = 2, Name = "休闲娱乐", Fid = 0, Remark = string.Empty });
            categoryList.Add(new Category { Id = 3, Name = "生活服务", Fid = 0, Remark = string.Empty });
            categoryList.Add(new Category { Id = 4, Name = "网上购物", Fid = 0, Remark = string.Empty });
            categoryList.Add(new Category { Id = 5, Name = "酒店旅游", Fid = 0, Remark = string.Empty });
            categoryList.Add(new Category { Id = 6, Name = "其他", Fid = 0, Remark = string.Empty });

            categoryList.Add(new Category { Id = 7, Name = "自助", Fid = 1, Remark = "自助餐" });
            categoryList.Add(new Category { Id = 8, Name = "双人套餐", Fid = 1, Remark = "双人饮食套餐" });
            categoryList.Add(new Category { Id = 9, Name = "火锅", Fid = 1, Remark = "火锅、羊蝎子" });
            categoryList.Add(new Category { Id = 10, Name = "麻辣香锅", Fid = 1, Remark = "麻辣香锅" });
            categoryList.Add(new Category { Id = 11, Name = "烧烤", Fid = 1, Remark = "烧烤、烤串、烤羊腿" });
            categoryList.Add(new Category { Id = 12, Name = "烤鱼", Fid = 1, Remark = "烤鱼" });
            categoryList.Add(new Category { Id = 13, Name = "快餐休闲", Fid = 1, Remark = "肯德基、麦当劳、咖啡厅、鲜果时光、冷饮" });
            categoryList.Add(new Category { Id = 14, Name = "日韩料理", Fid = 1, Remark = "日本料理、韩国料理" });
            categoryList.Add(new Category { Id = 15, Name = "西餐", Fid = 1, Remark = "西式餐点" });
            categoryList.Add(new Category { Id = 16, Name = "地方菜", Fid = 1, Remark = "北京菜，山东菜，四川菜，广东菜，淮扬菜，浙江菜，福建菜，湖北菜，徽菜，湖南菜，上海菜，天津菜，地方菜" });
            categoryList.Add(new Category { Id = 17, Name = "蛋糕", Fid = 1, Remark = "蛋糕、甜点" });

            categoryList.Add(new Category { Id = 18, Name = "电影", Fid = 2, Remark = "影院门票、电影卡" });
            categoryList.Add(new Category { Id = 19, Name = "KTV", Fid = 2, Remark = "KTV" });
            categoryList.Add(new Category { Id = 20, Name = "运动健身", Fid = 2, Remark = "健身中心、瑜伽、舞蹈、击剑" });
            categoryList.Add(new Category { Id = 21, Name = "游乐电玩", Fid = 2, Remark = "电玩城、桌游、真人CS、陶艺吧、动物园、海洋馆" });
            categoryList.Add(new Category { Id = 22, Name = "演出活动", Fid = 2, Remark = "话剧、演唱会、相声、展览、赛事" });
            categoryList.Add(new Category { Id = 23, Name = "洗浴", Fid = 2, Remark = "洗浴中心、会馆、会所、汗蒸、温泉、洗浴休闲、权金城、塞纳河" });

            categoryList.Add(new Category { Id = 24, Name = "美容美体", Fid = 3, Remark = "美容中心、减肥中心、产后瘦身、美甲店、美容美体" });
            categoryList.Add(new Category { Id = 25, Name = "写真", Fid = 3, Remark = "个人写真、孕妇写真" });
            categoryList.Add(new Category { Id = 26, Name = "美发", Fid = 3, Remark = "烫发、剪发、染发、造型" });
            categoryList.Add(new Category { Id = 27, Name = "婚纱摄影", Fid = 3, Remark = "婚纱摄影" });
            categoryList.Add(new Category { Id = 28, Name = "儿童摄影", Fid = 3, Remark = "儿童摄影" });
            categoryList.Add(new Category { Id = 29, Name = "口腔", Fid = 3, Remark = "洗牙、补牙、正畸、口腔科" });
            categoryList.Add(new Category { Id = 30, Name = "体检", Fid = 3, Remark = "体检机构、专科医院体检" });
            categoryList.Add(new Category { Id = 31, Name = "保健按摩", Fid = 3, Remark = "足疗、推拿、艾灸、保健按摩" });
            categoryList.Add(new Category { Id = 32, Name = "汽车养护", Fid = 3, Remark = "加油卡、洗车、保养" });

            categoryList.Add(new Category { Id = 33, Name = "服装", Fid = 4, Remark = "服装、睡衣、内衣、袜" });
            categoryList.Add(new Category { Id = 34, Name = "数码家电", Fid = 4, Remark = "数码、数码配件、手机、电脑、家用电器" });
            categoryList.Add(new Category { Id = 35, Name = "生活家居", Fid = 4, Remark = "家居用品、生活用品、五金用品" });
            categoryList.Add(new Category { Id = 36, Name = "化妆品", Fid = 4, Remark = "化妆品、彩妆、美颜工具、美颜保健品" });
            categoryList.Add(new Category { Id = 37, Name = "鞋靴", Fid = 4, Remark = "鞋、靴、拖鞋" });
            categoryList.Add(new Category { Id = 38, Name = "食品饮料", Fid = 4, Remark = "零食、食品、饮料、茶" });
            categoryList.Add(new Category { Id = 39, Name = "玩具", Fid = 4, Remark = "玩具、摆件、布偶、模型、成人玩具" });
            categoryList.Add(new Category { Id = 40, Name = "手表", Fid = 4, Remark = "手表" });
            categoryList.Add(new Category { Id = 41, Name = "饰品", Fid = 4, Remark = "饰品、珠宝、手套、围巾、皮带、墨镜、配饰" });
            categoryList.Add(new Category { Id = 42, Name = "箱包", Fid = 4, Remark = "拉杆箱、背包、皮包、钱包、箱包" });
            categoryList.Add(new Category { Id = 43, Name = "抽奖", Fid = 4, Remark = "抽奖" });
            categoryList.Add(new Category { Id = 44, Name = "母婴用品", Fid = 4, Remark = "婴儿奶粉、婴儿服饰、少儿玩具、防辐射衣、母婴用品" });

            categoryList.Add(new Category { Id = 45, Name = "酒店住宿", Fid = 5, Remark = "酒店、旅馆、快捷酒店、酒店代金券" });
            categoryList.Add(new Category { Id = 46, Name = "旅游", Fid = 5, Remark = "旅游团、自助游、近郊游、度假村、旅游代金券" });
            categoryList.Add(new Category { Id = 47, Name = "景点门票", Fid = 5, Remark = "景点门票、全国景点联票" });

            categoryList.Add(new Category { Id = 48, Name = "其他", Fid = 6, Remark = string.Empty });

            return categoryList;
        }
        /// <summary>
        /// 默认配置
        /// </summary>
        /// <returns></returns>
        public Config DefaultConfig()
        {
            Config conf = new Config { CityId=1,IsAutoRemoveOutDateItems=true,IsFirstOpenApp=true,PageSize=10,IsAutoRefresh=true};
            return conf;
        }
    }
}
