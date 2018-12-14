using System;
namespace NeuralNetwork
{
    public class Neuron
    {
        public double Bias;
        public double[] Weights;
        public double Output;
        public double PartialDerivative;
        public double BiasUpdate;
        public double[] WeightUpdates;


        public Neuron(int inputs)
        {
            Weights = new double[inputs];
            Output = 0;
            Bias = 0;
            PartialDerivative = 0;
            BiasUpdate = 0;
            WeightUpdates = new double[inputs];
        }

        public void Randomize(Random randy){
            Bias = randy.NextDouble(-1, 1);

            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = randy.NextDouble(-1, 1);
            }
        }

        public double Compute(double[] inputs, ActivationFunc.Activation activationfn){
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
