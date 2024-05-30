using ScoreCalculator.Models.Data;
using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.ViewModel
{
    public class TableOfScores:ViewModelBase
    {
       public Dictionary<SecurityDimensionEnum, CalculationTableData> Data { get; set; }
       public SystemInfoEntity SystemInfoEntity { get; set; }

        public double _Score;

        public double Score
        {
            get { return _Score; }
            set { SetProperty(ref _Score, value); }
        }
        private TestStatus _TestStatus;
        public TestStatus TestStatus
        {
            get { return _TestStatus; }
            set { SetProperty(ref _TestStatus, value); }
        }



        public TableOfScores(SystemInfoEntity systemInfoEntity) 
        {
            this.SystemInfoEntity = systemInfoEntity;
        }
        public void LoadData(SystemLevel systemLevel)
        {
            Data = CalculationTableData.ReadAllData(systemLevel);
        }


        public void LoadRecordEntryEntitys(List<RecordEntryEntity> list)
        {
            foreach (var sc in Data.Keys) 
            {
                
                var ct=Data[sc];
                foreach (var rule in ct.Rules)
                {
                    foreach (var item in list)
                    {
                        if (item.SecurityDimension==sc&&item.ZhiBiao.ToLower().Equals(rule.TestObject.ToLower()))
                        {
                            rule.RecordEntryEntitys.Add(item);
                        }
                    }   
                }
            }

        }
        public void DeleteItem(RecordEntryEntity recordEntryEntity)
        {
            var ct = this.Data[recordEntryEntity.SecurityDimension];
            var rule=ct.Rules.Find(b=>b.TestObject.Equals(recordEntryEntity.ZhiBiao));

            rule.RecordEntryEntitys.Remove(recordEntryEntity);

            RecordEntryServices recordEntryServices = new RecordEntryServices();
            if (recordEntryServices.Any(recordEntryEntity.Id))
            {
                recordEntryServices.Delete(recordEntryEntity.Id);
            }
        }
        /// <summary>
        /// 根据名称批量删除测试记录
        /// </summary>
        /// <param name="recordEntryEntity"></param>
        public void BulkDeleteItemByName(RecordEntryEntity recordEntryEntity)
        {

            foreach (var sc in Data.Keys) { 
                var ct=Data[sc];
                foreach (var rule in ct.Rules) {
                    if (rule.RecordEntryEntitys.Any(b=>b.Id==recordEntryEntity.Id))
                    {
                        rule.RecordEntryEntitys.Remove(recordEntryEntity);
                    }
                }
            }
            RecordEntryServices recordEntryServices = new RecordEntryServices();
            if (recordEntryServices.AnyName(recordEntryEntity.TestObjectName))
            {
                recordEntryServices.DeleteBulk(this.SystemInfoEntity.Id, recordEntryEntity.TestObjectName);
            }
        }

        public ZhiBiaoItem FindRuleByName(SecurityDimensionEnum securityDimensionEnum,string name)
        {
            var ct=this.Data[securityDimensionEnum];
            return ct.findRuleByName(name);

        }
        public CalculationTableData FindCengMian(SecurityDimensionEnum securityDimensionEnum)
        {
            return this.Data[securityDimensionEnum];
        }

        public void Add(RecordEntryEntity recordEntryEntity)
        {
            var ct = this.Data[recordEntryEntity.SecurityDimension];
            ct.Add(recordEntryEntity);
        }
        public void UpdateScore()
        {
            foreach (var sc in Data.Keys) {
                var ct = this.Data[sc];
                ct.UpdateScore(this.SystemInfoEntity.GetSystemLevel());
            }
            //计算总分
        }
        public int GetCounterByTestStatus(TestStatus testStatus)
        {
            int counter = 0;
            foreach (var key in this.Data.Keys)
            {
                counter += this.Data[key].GetCounterByTestStatus(testStatus);
            }
            return counter;
        }
        public int GetCounterByExposures(Exposures exposures)
        {
            int counter = 0;
            foreach (var key in this.Data.Keys)
            {
                counter += this.Data[key].GetCounterByExposures(exposures);
            }
            return counter;
        }

        public void SaveData()
        {
            var list=new List<RecordEntryEntity>();
            foreach (var sc in Data.Keys) 
            {
                var ct=Data[sc];
                foreach (var rule in ct.Rules) {

                    if (rule.RecordEntryEntitys.Any())
                    {
                        list.AddRange(rule.RecordEntryEntitys);
                    }
                }
            }

            RecordEntryServices recordEntryServices = new RecordEntryServices();
            recordEntryServices.MergingOfData(list, this.SystemInfoEntity.Id);
        }
    }
}
