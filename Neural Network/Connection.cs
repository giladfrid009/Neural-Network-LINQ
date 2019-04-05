using Neural_Network.Extensions;
using System;

namespace Neural_Network
{
    internal class Connection
    {
        public double Weight { get; private set; }
        public double Delta_Weight { get; private set; }
        public Neuron Input_Neuron { get; set; }
        public Neuron Output_Neuron { get; set; }

        public Connection(Neuron input_neuron, Neuron output_neuron)
        {
            Input_Neuron = input_neuron;
            Output_Neuron = output_neuron;
            Weight = new Random().NextDouble(-1, 1);
            Delta_Weight = 0;
        }

        public void Calculate_Weight(double learning_rate, double momentum)
        {
            double old_delta = Delta_Weight;
            Delta_Weight = Output_Neuron.Gradient * learning_rate * Output_Neuron.Value;
            Weight += Delta_Weight + momentum * old_delta;
        }
    }
}
