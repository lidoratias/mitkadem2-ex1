using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    //public delegate double MissionDelegate(double value);

    public class FunctionsContainer
    {
        private Dictionary<string, Func<double, double>> missions;

        public FunctionsContainer()
        {
            missions = new Dictionary<string, Func<double, double>>();
        }

        public Func<double, double> this[string key]
        {
            get
            {
                try
                {
                    return missions[key];
                }
                catch
                {
                    missions[key] = val => val;
                    return missions[key];
                }
            }
            set
            {
                missions[key] = value;
            }
        }
        public List<string> getAllMissions()
        {
            List<string> keyList = new List<string>(this.missions.Keys);
            return keyList;
        }
    }
}
