using Microsoft.EntityFrameworkCore;

using ScoreCalculator.DataBase;
using ScoreCalculator.Models.Data;
using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Services
{
    public class ProjectService
    {

        public CalculationTableData JiSuan(List<RecordEntryEntity> list, SecurityDimensionEnum securityDimensionEnum,SystemLevel systemLevel)
        {
            var data=from x in list
                     where x.SecurityDimension==securityDimensionEnum
                     select x;
            var ct=CalculationTableData.ReadData(securityDimensionEnum,systemLevel);
            foreach (var item in ct.Rules)
            {

            }
            return null;

        }
        SQLLite3Context SQLLite3Context { get; set; }
        public ProjectService()
        {
            SQLLite3Context = SQLLite3Context.Instance();
        }
        //在数据库中添加一个系统
        public void Add(ProjectEntity projectEntity)
        {
            SQLLite3Context.ProjectEntities.Add(projectEntity);
            SQLLite3Context.SaveChanges();
        }

        public void AddTestData()
        {

            ProjectEntity project = new ProjectEntity();
            project.ProjectName = "示例项目";
            project.Description = "描述此项目的信息";
            project.Provinces = "山东";
            project.City = "城市";
            project.Year = 2024;
            project.Level = SystemLevel.Level3;
            //2.将SystemEntity对象保存到数据库

            this.Add(project);
        }
        //在数据库中删除一个系统
        public void Delete(ProjectEntity projectEntity)
        {
            SQLLite3Context.ProjectEntities.Remove(projectEntity);
            SQLLite3Context.SaveChanges();
        }
        //在数据库中更新一个系统
        public void Update(ProjectEntity project)
        {
            SQLLite3Context.ProjectEntities.Update(project);
            SQLLite3Context.SaveChanges();
        }
        //判断数据库中是否有数据
        public bool IsEmpty()
        {
            return SQLLite3Context.ProjectEntities.Count() == 0;
        }
        //在数据库中查询所有系统
        public List<ProjectEntity> QueryAll()
        {
            if (IsEmpty())
            {
                return new List<ProjectEntity>();
            }
            return SQLLite3Context.ProjectEntities.Include(x=>x.TestedCompanyInformation).ToList();
        }
        //在数据库中查询一个系统

        public ProjectEntity QueryOne(int id)
        {
            return SQLLite3Context.ProjectEntities.Find(id);
        }
        //返回特定year的系统

        public List<ProjectEntity> QueryByYear(int year)
        {
            return SQLLite3Context.ProjectEntities.Where(s => s.Year == year).ToList();
        }


        /// <summary>
        /// 计算指标的测评单元分数
        /// </summary>
        /// <param name="list">记录数据集合</param>
        /// <param name="securityDimensionEnum">所在安全层面</param>
        /// <param name="zhibiaoStr">指标字符串</param>
        /// <returns></returns>
        public double? JiSuanZhiBiao(List<RecordEntryEntity> list, SecurityDimensionEnum securityDimensionEnum,string zhibiaoStr)
        {
            var data=(from x in list
                     where x.SecurityDimension==securityDimensionEnum && x.ZhiBiao.Equals(zhibiaoStr)
                     select x.Score).ToArray();
            if (data.Any())
            {
                var ave = data.Average();
                return ave;
            }
            return null;
           
        }

  


    }
}
