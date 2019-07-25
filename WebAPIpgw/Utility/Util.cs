using System;
using System.Configuration;

namespace WebAPIpgw.Utility
{
    public class Util
    {
        public static int GetDelay()
        {
            return Random.Next(Configuration.GetDelayMin(),
                                 Configuration.GetDelayMax());
        }

        private static readonly Random Random = new Random();
    }

    public static class Configuration
    {
       private static int _delayMin = int.MaxValue;
       private static int _delayMax = int.MaxValue;

        public static int GetGetKeyValInt(string key)
        {
            bool b = int.TryParse(ConfigurationManager.AppSettings[key], out var j);
            if (b)
                return j;
            return 0;
        }

        public static int GetDelayMin()
        {
            if (_delayMin == int.MaxValue)
                _delayMin = GetGetKeyValInt("DelayMin");
            return _delayMin;
        }

        public static int GetDelayMax()
        {
            if ( _delayMax == int.MaxValue )
                _delayMax = GetGetKeyValInt("DelayMax");
            return _delayMax;
        }

        public static string GetGetKeyVal(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


    }
}