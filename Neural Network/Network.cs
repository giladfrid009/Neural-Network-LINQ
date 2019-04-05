using Neural_Network.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Neural_Network
{
    internal class Network
    {
        public List<List<Neuron>> Neurons { get; private set; }

        public Network()
        {
            Neurons = new List<List<Neuron>>();
        }

        public Network(List<int> structure) : this()
        {
            Neurons.Add(new byte[structure[0]].Select(a => new Neuron()).ToList());

            for (int i = 1; i < structure.Count; i++)
            {
                Neurons.Add(new byte[structure[i]].Select(a => new Neuron(Neurons[i - 1])).ToList());
            }
        }

        public List<double> Output(List<double> input)
        {
            int i = 0;
            input.ForEach(a => Neurons[0][i++].Force_Value(a));

            Neurons.Skip(1).ToList().ForEach(a => a.ForEach(b => b.Calculate_value()));

            return Neurons[Neurons.Count - 1].Select(a => a.Value).ToList();
        }

        public void Back_Propogate(List<double> targets, double learning_rate, double momentum)
        {
            int i = 0;
            Neurons[Neurons.Count - 1].ForEach(a =>
            {
                a.Calculate_Gradient(targets[i++]);
                a.Calculate_Bias(learning_rate, momentum);
                a.Connections_Input.ForEach(c => c.Calculate_Weight(learning_rate, momentum));
            });


            (Neurons as IList<List<Neuron>>).Reverse().Skip(1).ToList().ForEach(a => a.ForEach(b =>
            {
                b.Calculate_Gradient();
                b.Calculate_Bias(learning_rate, momentum);
                b.Connections_Input.ForEach(c => c.Calculate_Weight(learning_rate, momentum));
            }));
        }
    }
}
