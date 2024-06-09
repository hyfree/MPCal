using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Data
{
    public class MyConfig
    {
        public string BaseTemplateDir { get; set; } = "";

       private static MyConfig instance;

        public   MyConfig Read()
        {
            if (instance == null)
            {

                lock (this)
                {
                    if (instance==null)
                    {
                        var json = File.ReadAllText("Data\\Config.json");
                      instance = JsonSerializer.Deserialize<MyConfig>(json);

                    }

                }
            }
          
            return instance;
        }

        public static  MyConfig GetMyConfig()
        {
            MyConfig config = new MyConfig();
            return config.Read();
        }
    }
}
