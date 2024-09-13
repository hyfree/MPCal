using ScoreCalculator.DataBase;
using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Services
{
    /// <summary>
    /// 测试系统服务
    /// </summary>
    public class SystemInfoService
    {
        SQLLite3Context SQLLite3Context { get; set; }
        public SystemInfoService()
        {
            SQLLite3Context= SQLLite3Context.Instance();
        }
        //在数据库中添加一个系统
        public void Add(SystemInfoEntity systemEntity)
        {
            SQLLite3Context.SystemInfoEntity.Add(systemEntity);
            SQLLite3Context.SaveChanges();
        }

        public void AddTestData()
        {

            SystemInfoEntity systemEntity = new SystemInfoEntity();
            systemEntity.Name = "示例系统";
            systemEntity.Description = "示例系统信息";
            systemEntity.Provinces = "山东";
            systemEntity.City = "城市";
            systemEntity.Year = 2024;
            systemEntity.Level = SystemLevel.Level3;
            //2.将SystemEntity对象保存到数据库
            
            this.Add(systemEntity);
        }
        //在数据库中删除一个系统
        public void Delete(SystemInfoEntity systemEntity)
        {
            SQLLite3Context.SystemInfoEntity.Remove(systemEntity);
            SQLLite3Context.SaveChanges();
        }
        //在数据库中更新一个系统
        public void Update(SystemInfoEntity systemEntity)
        {
            SQLLite3Context.SystemInfoEntity.Update(systemEntity);
            SQLLite3Context.SaveChanges();
        }
        //判断数据库中是否有数据
        public bool IsEmpty()
        {
            return SQLLite3Context.SystemInfoEntity.Count() == 0;
        }
        //在数据库中查询所有系统
        public List<SystemInfoEntity> QueryAll()
        {
            if (IsEmpty())
            {
                return new List<SystemInfoEntity>();

            }
            return SQLLite3Context.SystemInfoEntity.ToList();
        }
        //在数据库中查询一个系统

        public SystemInfoEntity QueryOne(int id)
        {
            return SQLLite3Context.SystemInfoEntity.Find(id);
        }
        //返回特定year的系统
      
        public List<SystemInfoEntity> QueryByYear(int year)
        {
            return SQLLite3Context.SystemInfoEntity.Where(s => s.Year == year).ToList();
        }
        
    }
}