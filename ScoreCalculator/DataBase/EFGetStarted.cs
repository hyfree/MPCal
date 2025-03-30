using Microsoft.EntityFrameworkCore;
using ScoreCalculator.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;

namespace ScoreCalculator.DataBase
{
    public class SQLLite3Context : DbContext
    {
        static SQLLite3Context sqlite;
        public static SQLLite3Context Instance()
        {
            //优化下面代码
            //if (sqlite == null)
            //{
            //    sqlite = new SQLLite3Context();
            //}
            //return sqlite;
            return new SQLLite3Context();

        }
        public string dbPath { get; set; } = AppDataPaths.GetDefault().LocalAppData +"\\gm.db";

        public bool IsExists()
        {
            return File.Exists(dbPath);
        }


        public DbSet<SystemInfoEntity> SystemInfoEntity { get; set; }
        public DbSet<RecordEntryEntity> RecordEntryEntity { get; set; }
        public DbSet<KnowledgeEntity> KnowledgeEntity { get; set; }
        public DbSet<ProjectEntity> ProjectEntities { get; set; }
        public DbSet<TestedCompanyInformationEntity> TestedCompanyInformationEntity { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var file = Path.Combine(dbPath);
            file = Path.GetFullPath(file);
            options.UseSqlite($"Data Source={file}");
            //options.UseMySql("Server=localhost;Database=ct_threeview;charset=utf8;uid=root;pwd=0b85232f9ebda56fc8a1f54f74383aF8a4055e570bb36cbb5;port=3506;",ServerVersion.Parse("8.0"),null);
        }


    }


}
