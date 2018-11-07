using System;
namespace NeuralNetwork
{
    public class Neuron
    {
        public double Bias;
        public double[] Weights;
        public double Output;

        public Neuron(int inputs)
        {
            Weights = new double[inputs];
         
        }

        public void Randomize(Random randy){
            Bias = randy.NextDouble(-1, 1);

            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = randy.NextDouble(-1, 1);
            }
        }

        public double Compute(double[] inputs, Func<double, double> activationfn){
            double output = 0;
            for (int i = 0; i < Weights.Length; i++)
            {
                output += Weights[i] * inputs[i];
            }

            output += Bias;

            Output = activationfn(output);
            return Output;

        }

    }
}
