using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Services;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.DTO
{
    public  class ProjectData
    {
        public ObservableCollection<RecordEntryEntity> guanLiZhiDuItems { get; set; }//管理制度
        public ObservableCollection<RecordEntryEntity> renYuanGuanLiItems { get; set; }//人员管理
        public ObservableCollection<RecordEntryEntity> jianSheYunXingItems { get; set; }//建设运行
        public ObservableCollection<RecordEntryEntity> yingJiChuZhiItems { get; set; }//应急处置

        public Dictionary<string, ObservableCollection<RecordEntryEntity>> jiShuMianItems { get; set; }//技术面

        public string toJson()
        {
            var json=System.Text.Json.JsonSerializer.Serialize(this);
            return json;
        }
        public static ProjectData fromJson(string json)
        {
            var projectData=System.Text.Json.JsonSerializer.Deserialize<ProjectData>(json);
            return projectData;

        }
     
       

    }
}
