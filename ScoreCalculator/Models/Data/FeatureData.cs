using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Data
{
    public class FeatureData
    {
        public static List<string> GetFeatureData(SecurityDimensionEnum security)
        {
            switch (security)
            {
                case SecurityDimensionEnum.WuLi:
                    return Wuli();
                   
                case SecurityDimensionEnum.WangLuo:
                    return WangLuo();
                  
                case SecurityDimensionEnum.SheBei:
                    return SheBei();
                    
                case SecurityDimensionEnum.YingYong:
                    return YingYong();
                    
                case SecurityDimensionEnum.GuanLi:
                    return Guanli();
                    
                case SecurityDimensionEnum.RenYuan:
                    return RenYuan();
                    
                case SecurityDimensionEnum.JianShe:
                    return JianSHe();
                   
                case SecurityDimensionEnum.YingJi:
                    return YingJi();
                    
                default:
                    return null;
            }

        }
        public static List<string> Wuli()
        {
            List<string> list = new List<string>();

            list.Add("普通门禁");
            list.Add("普通视频");
            list.Add("国密电子门禁系统");
            list.Add("国密视频监控系统");
            list.Add("Other");
            return list;
        }

        public static List<string> SheBei()
        {
            List<string> list = new List<string>();

            list.Add("服务器");
            list.Add("数据库");
            list.Add("堡垒机");
            list.Add("整机密码设备");
            list.Add("Other");
            return list;
        }
        public static List<string> WangLuo()
        {
            List<string> list = new List<string>();

            list.Add("HTTP");
            list.Add("HTTPS");
            list.Add("IPSec");
            list.Add("GMTLS");
            list.Add("GMIPsec");
            list.Add("Other");

            return list;
        }
        public static List<string> YingYong()
        {
            List<string> list = new List<string>();

            list.Add("用户名口令");
            list.Add("智能密码钥匙登录");
            list.Add("动态令牌登录");
            list.Add("访问控制");
            list.Add("身份鉴别数据");
            list.Add("重要业务数据");

            return list;
        }
        public static List<string> Guanli()
        {
            List<string> list = new List<string>();

            list.Add("Other");

            return list;
        }
        public static List<string> RenYuan()
        {
            List<string> list = new List<string>();

            list.Add("Other");

            return list;
        }
        public static List<string> JianSHe()
        {
            List<string> list = new List<string>();

            list.Add("Other");

            return list;
        }
        public static List<string> YingJi()
        {
            List<string> list = new List<string>();
            list.Add("Other");
            return list;
        }
    }
}