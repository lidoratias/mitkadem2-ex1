using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private Func<double, double> mission;

        public event EventHandler<double> OnCalculate;

        public string Name  // read-write instance property
        { get; set; }
        public string Type  // read-write instance property
        {
            get
            {
                return "Single";
            }
        }

        public SingleMission(Func<double, double> func, string description)
        {
            mission = func;
            this.Name = description;
        }

        public SingleMission(string description)
        {
            this.Name = description;
        }

        public double Calculate(double value)
        {
            double res = mission(value);
            OnCalculate?.Invoke(this, res);
            return res;
        }
    }
}