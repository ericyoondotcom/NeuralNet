using System;
namespace NeuralNetwork
{
    public class Layer
    {
        public Neuron[] Neurons;
        public double[] Outputs;

        public Layer(int neuronCount, int inputs)
        {
            Neurons = new Neuron[neuronCount];
            for (int i = 0; i < neuronCount; i++)
            {
                Neurons[i] = new Neuron(inputs);

            }
        }
        public void Randomize(Random randy){
            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i].Randomize(randy);
            }
        }

        public double[] Compute(double[] inputs, Func<double, double> activation){
            double[] outputs = new double[Neurons.Length];
            for (int i = 0; i < Neurons.Length; i++){
                outputs[i] = Neurons[i].Compute(inputs, activation);
            }
            Outputs = outputs;
            return outputs;
        }
    }
}
