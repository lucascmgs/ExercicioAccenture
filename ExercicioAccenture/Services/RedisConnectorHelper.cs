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
        private static ConnectionMultiplexer Redis = ConnectionMultiplexer.Connect("localhost");
        private static IDatabase DataBase = Redis.GetDatabase();

        public static void Initialize()
        {
            Redis = ConnectionMultiplexer.Connect("localhost");
            DataBase = Redis.GetDatabase();
        }

        public static string GetExchanges(string coin1, string coin2)
        {
            return DataBase.StringGet(coin1 + coin2);
        }

        public static void SetExchanges(string coin1, string coin2, ShowExchangesViewModel model)
        {
            DataBase.KeyExpire(coin1 + coin2, System.TimeSpan.FromSeconds(30));
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
