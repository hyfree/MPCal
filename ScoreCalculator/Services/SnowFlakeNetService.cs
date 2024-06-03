using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;
using System.Threading;

using ScoreCalculator.Utils;

using Snowflake.Core;

namespace ScoreCalculator.Services
{
    public class SnowFlakeNetService:IDistributedIdGenerator
    {
        private  static  IdWorker worker = null;
        
        // 定义私有构造函数，使外界不能创建该类实例
        public SnowFlakeNetService( )
        {
           
            if (worker == null)
            {
                worker = new IdWorker(1,1);
            }
        }
        public static IDistributedIdGenerator FactoryGeInstance()
        {
            IDistributedIdGenerator snowFlake = new SnowFlakeNetService();
            return snowFlake;
        }
        public IdWorker GeInstance()
        {
            if (worker==null)
            {
                lock (this)
                {
                    if (worker==null)
                    {
                        worker = new IdWorker(1,1);

                    }

                }

            }
           
            return worker;
        }
        /// <summary>
        /// 产生全局唯一的long类型ID
        /// </summary>
        /// <returns></returns>
        public long NextId()
        {
            Thread.Sleep(1);
            return GeInstance().NextId();
        }
        /// <summary>
        /// 生成全局唯一的hex字符串
        /// </summary>
        /// <returns></returns>
        public  string NextHexId()
        {
            return NextId().ToHex();
        }
    }
}
