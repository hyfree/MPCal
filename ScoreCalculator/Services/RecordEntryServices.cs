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
    public class RecordEntryServices
    {
        SQLLite3Context SQLLite3Context { get; set; }
        public RecordEntryServices()
        {
            SQLLite3Context = SQLLite3Context.Gen();
        }
        //在数据库中添加一个记录
        public void Add(RecordEntryEntity recordEntryEntity)
        {
            SQLLite3Context.RecordEntryEntity.Add(recordEntryEntity);
            SQLLite3Context.SaveChanges();
        }

        //在数据库中删除一个记录,根据id
        public void Delete(long id)
        {
            SQLLite3Context.RecordEntryEntity.Remove(SQLLite3Context.RecordEntryEntity.Find(id));
            SQLLite3Context.SaveChanges();
        }
        public bool Any(long id,string version)
        {
          return  SQLLite3Context.RecordEntryEntity.Any(b=>b.Id==id&& b.Version.Equals(version));
        }
        public bool AnyName(string name,string version)
        {
            return SQLLite3Context.RecordEntryEntity.Any(b => b.TestObjectName.Equals(name) && b.Version.Equals(version));
        }
        public void DeleteBulk(long projectId,string itemName,string version)
        {
            SQLLite3Context.RecordEntryEntity.RemoveRange(SQLLite3Context.RecordEntryEntity
                .Where(b=>b.ProjectId==projectId&&b.TestObjectName.Equals(itemName) && b.Version.Equals(version))
                );
            SQLLite3Context.SaveChanges();
        }


        //参数是一个记录数组，遍历这个数组，将每个记录添加到数据库中
        public void Add(IEnumerable<RecordEntryEntity> recordEntryEntities)
        {
            foreach (RecordEntryEntity recordEntryEntity in recordEntryEntities)
            {
                
               //根据id判断记录是否存在，如果存在就更新，不存在就添加
                if (SQLLite3Context.RecordEntryEntity.Any(r=>r.Id== recordEntryEntity.Id && r.Version.Equals(recordEntryEntity.Version)))
                {
                    SQLLite3Context.RecordEntryEntity.Update(recordEntryEntity);
                }
                else
                {
                    SQLLite3Context.RecordEntryEntity.Add(recordEntryEntity);
                }
            }
            SQLLite3Context.SaveChanges();
        }
        /// <summary>
        /// 将现有数据与数据库中的数据合并
        /// </summary>
        /// <param name="recordEntryEntities">现有数据</param>
        /// <param name="pojectId">项目id</param>
        /// <param name="securityDimensionEnum">安全层面</param>
        /// <param name="cePingZhiBiao">测评指标</param>
        public void MergingOfData(IEnumerable<RecordEntryEntity> recordEntryEntities,long pojectId,string version)
        {
            //根据项目id，安全层面，测评指标，查询数据库中的记录
            var recordEntryEntitiesInDB = SQLLite3Context.RecordEntryEntity.Where(r => r.ProjectId == pojectId && r.Version.Equals(version)).ToList();
            //遍历recordEntryEntitiesInDB，如果对应id如果在recordEntryEntities中不存在，就删除
            foreach (var recordEntryEntityInDB in recordEntryEntitiesInDB)
            {
                if (recordEntryEntities.Where(r => r.Id == recordEntryEntityInDB.Id).Count() == 0)
                {
                    Delete(recordEntryEntityInDB.Id);
                }
            }
            //调用add方法，将recordEntryEntities中的记录添加到数据库中
            Add(recordEntryEntities);
        }
        //根据项目id，安全层面，查询数据库中的记录
        public List<RecordEntryEntity> Query(long projectId, SecurityDimensionEnum securityDimensionEnum,string version)
        {
            return SQLLite3Context.RecordEntryEntity.Where(r => r.ProjectId == projectId && r.SecurityDimension == securityDimensionEnum && r.Version.Equals(version) ).ToList();
        }
        public List<RecordEntryEntity> Query(long projectId,string version)
        {
            return SQLLite3Context.RecordEntryEntity.Where(r => r.ProjectId == projectId&& r.Version.Equals(version)).ToList();
        }


    }
}
