using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private List<Func<double, double>> missions = new List<Func<double, double>>();

        public string Name  // read-write instance property
        { get; set; }
        public string Type  // read-write instance property
        {
            get
            {
                return "Composed";
            }
        }

        public event EventHandler<double> OnCalculate;

        public ComposedMission(string name)
        {
            this.Name = name;
        }

        public ComposedMission(Func<double, double> mission, string description)
        {
            this.Name = description;
            this.Add(mission);
        }

        public ComposedMission Add(Func<double, double> mission)
        {
            missions.Add(mission);        
            return this;
        }

        public double Calculate(double value)
        {
            double res = value;
            foreach (var m in missions)
            {
                res = m(res);
            }
            OnCalculate?.Invoke(this, res);  // invokes the event if it's not NULL
            return res;  // return res
        }
    }
}