using ScoreCalculator.DataBase;
using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Services
{
    public class KnowledgeEntityServices
    {
        SQLLite3Context SQLLite3Context { get; set; }
        public KnowledgeEntityServices()
        {
            SQLLite3Context = SQLLite3Context.Instance();
        }
        //在数据库中添加一个记录
        public void Add(KnowledgeEntity knowledgeEntity)
        {
           
            SQLLite3Context.KnowledgeEntity.Add(knowledgeEntity);
            SQLLite3Context.SaveChanges();
        }
        public void Save(KnowledgeEntity knowledgeEntity)
        {
           Delete(knowledgeEntity.Id);
           Add(knowledgeEntity);
        }
        public List<KnowledgeEntity> GetALL()
        {
            var list=  SQLLite3Context.KnowledgeEntity.ToList<KnowledgeEntity>();
            return list;
        }
        public List<KnowledgeEntity> GetALLOBS()
        {
            var list = SQLLite3Context.KnowledgeEntity.ToList<KnowledgeEntity>();
            return list;
        }
        //在数据库中删除一个记录,根据id
        public void Delete(long id)
        {
            SQLLite3Context.KnowledgeEntity.Where(x => x.Id == id).DeleteFromQuery();

            SQLLite3Context.SaveChanges();
        }
        public bool Any(long id)
        {
          return  SQLLite3Context.KnowledgeEntity.Any(b=>b.Id==id);
        }
        public bool AnyName(string name)
        {
            return SQLLite3Context.KnowledgeEntity.Any(b => b.Title.Equals(name) );
        }
        //public void DeleteBulk(long projectId,string itemName,string version)
        //{
        //    SQLLite3Context.RecordEntryEntity.RemoveRange(SQLLite3Context.RecordEntryEntity
        //        .Where(b=>b.ProjectId==projectId&&b.TestObjectName.Equals(itemName) && b.Version.Equals(version))
        //        );
        //    SQLLite3Context.SaveChanges();
        //}


        //参数是一个记录数组，遍历这个数组，将每个记录添加到数据库中
        public void Add(IEnumerable<KnowledgeEntity> knowledgeEntityes)
        {
            foreach (KnowledgeEntity item in knowledgeEntityes)
            {
                
               //根据id判断记录是否存在，如果存在就更新，不存在就添加
                if (SQLLite3Context.KnowledgeEntity.Any(r=>r.Id== item.Id ))
                {
                    Delete(item.Id);
                    SQLLite3Context.KnowledgeEntity.Add(item);
                }
                else
                {
                    SQLLite3Context.KnowledgeEntity.Add(item);
                }
            }
            SQLLite3Context.SaveChanges();
        }
        /// <summary>
        /// 将现有数据与数据库中的数据合并
        /// </summary>
        /// <param name="data">现有数据</param>
        /// <param name="pojectId">项目id</param>
        /// <param name="securityDimensionEnum">安全层面</param>
        /// <param name="cePingZhiBiao">测评指标</param>
        public void MergingOfData(IEnumerable<KnowledgeEntity> data)
        {
            //根据项目id，安全层面，测评指标，查询数据库中的记录
            var allData = SQLLite3Context.KnowledgeEntity.ToList();
            //遍历recordEntryEntitiesInDB，如果对应id如果在recordEntryEntities中不存在，就删除
            foreach (var item in allData)
            {
                if (data.Where(r => r.Id == item.Id).Count() == 0)
                {
                    Delete(item.Id);
                }
            }
            //调用add方法，将recordEntryEntities中的记录添加到数据库中
            Add(data);
        }
        //根据项目id，安全层面，查询数据库中的记录
        public List<KnowledgeEntity> Query(SecurityDimensionEnum securityDimensionEnum)
        {
            return SQLLite3Context.KnowledgeEntity.Where(r =>  r.SecurityDimensionEnum == securityDimensionEnum  ).ToList();
        }
     

    }
}
