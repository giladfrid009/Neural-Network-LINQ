using System;
using System.Collections.Generic;

namespace Neural_Network
{
    internal class Program
    {
        private static void Main()
        {
            Network n = new Network(new List<int> { 1, 7, 13, 5 });
            while (true)
            {
                var output = n.Output(new List<double> { 0.5 });
                n.Back_Propogate(new List<double> { 0.7, 0.5, 0.3, 0.1, 0 }, 0.4, 0.9);

                for (int i = 0; i < output.Count; i++)
                {
                    Console.WriteLine(output[i]);
                }
            }
        }
    }
}
