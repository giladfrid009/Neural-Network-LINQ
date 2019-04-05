using Neural_Network.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neural_Network
{
    internal class Neuron
    {
        public double Value { get; private set; }
        public double Bias { get; private set; }
        public double Delta_Bias { get; private set; }
        public double Gradient { get; private set; }
        public List<Connection> Connections_Input { get; private set; }
        public List<Connection> Connections_Output { get; private set; }

        public Neuron()
        {
            Connections_Input = new List<Connection>();
            Connections_Output = new List<Connection>();
            Value = 0;
            Bias = 0;
            Delta_Bias = 0;
            Gradient = 0;
        }

        public Neuron(List<Neuron> input_neurons) : this()
        {
            Bias = new Random().NextDouble(-1, 1);

            foreach (Neuron n in input_neurons)
            {
                Connections_Input.Add(new Connection(n, this));
                n.Connections_Output.Add(new Connection(n, this));
            }
        }

        public void Force_Value(double value)
        {
            this.Value = value;
        }

        public void Calculate_value()
        {
            Value = sigmoid(Connections_Input.Sum(a => a.Input_Neuron.Value * a.Weight) + Bias);
        }

        public void Calculate_Gradient()
        {
            Gradient = Connections_Output.Sum(a => a.Output_Neuron.Gradient * a.Weight) * sigmoid_derivative();
        }

        public void Calculate_Gradient(double target)
        {
            Gradient = (target - Value) * sigmoid_derivative();
        }

        public void Calculate_Bias(double learning_rate, double momentum)
        {
            double old_delta = Delta_Bias;
            Delta_Bias = learning_rate * Gradient;
            Bias += Delta_Bias + momentum * old_delta;
        }

        private double sigmoid(double value)
        {
            return 1 / (1 + Math.Exp(-value));
        }

        private double sigmoid_derivative()
        {
            return Value * (1 - Value);
        }
    }
}
