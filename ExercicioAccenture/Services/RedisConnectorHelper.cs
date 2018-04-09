using ExercicioAccenture.ViewModels;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioAccenture.Services
{
    public static class RedisConnectorHelper
    {
        private static ConnectionMultiplexer Redis;
        private static IDatabase DataBase;

        public static void Initialize()
        {
            Redis = ConnectionMultiplexer.Connect("localhost");
            DataBase = Redis.GetDatabase();
        }

        public static string GetExchanges(string coin1, string coin2)
        {
            string result = DataBase.StringGet(coin1 + coin2);
            if (!CheckKeys(coin1, coin2))
            {
                throw new Exception("In-cache values deprecated");
            }
            return result;
        }

        public static void SetExchanges(string coin1, string coin2, ShowExchangesViewModel model)
        {
            DataBase.StringSet(coin1 + coin2, model.Serialize());
            DataBase.KeyExpire(coin1 + coin2, System.TimeSpan.FromSeconds(60 - (DateTime.Now.Second - model.RequestTime.Second)));
        }

        public static bool CheckKeys(string coin1, string coin2)
        {
            if(DataBase.KeyExists(coin1 + coin2))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
