using System.Collections.Generic;
using System.Linq;

namespace Neural_Network
{
    public class Data_Set
    {
        public List<double> Inputs { get; private set; }
        public List<double> Targets { get; private set; }

        public Data_Set(List<double> inputs, List<double> targets)
        {
            this.Inputs = new List<double>(inputs);
            this.Targets = new List<double>(targets);
        }
    }
}
