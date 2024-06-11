using Microsoft.EntityFrameworkCore;
using ScoreCalculator.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.DataBase
{
    public class SQLLite3Context : DbContext
    {
        static SQLLite3Context sqlite;
        public static SQLLite3Context Gen()
        {
            //优化下面代码
            if (sqlite == null)
            {
                sqlite = new SQLLite3Context();
            }
            return sqlite;

        }
        public string dbPath { get; set; } = "gm.db";


        public DbSet<SystemInfoEntity> SystemInfoEntity { get; set; }
        public DbSet<RecordEntryEntity> RecordEntryEntity { get; set; }
        public DbSet<KnowledgeEntity> KnowledgeEntity { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var file = Path.Combine(dbPath);
            file = Path.GetFullPath(file);
            options.UseSqlite($"Data Source={file}");
        }


    }


}
