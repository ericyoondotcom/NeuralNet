using System;
namespace NeuralNetwork
{
    public class NeuralNetwork
    {

        public Layer[] Layers;
        Func<double, double> Activation;
        public double Fitness { get; set; }

        public NeuralNetwork(Func<double, double> activation, int inputs, params int[] neuronsCount){
            Activation = activation;
            Layers = new Layer[neuronsCount.Length];
            Layers[0] = new Layer(neuronsCount[0], inputs);
        
            for (int i = 1; i < Layers.Length; i++){
                Layers[i] = new Layer(neuronsCount[i], Layers[i - 1].Neurons.Length);
            }

        }

        public void Randomize(Random randy){
            for (int i = 0; i < Layers.Length; i++)
            {
                Layers[i].Randomize(randy);
            }
        }

        public double[] Compute(double[] inputs){
            Layers[0].Compute(inputs, Activation);
            for (int i = 1; i < Layers.Length; i++){
                Layers[i].Compute(Layers[i - 1].Outputs, Activation);
            }
            return Layers[Layers.Length - 1].Outputs;
        }

        public void Mutate(double rate, Random randy){
            foreach (var layer in Layers)
            {
                foreach (var neuron in layer.Neurons)
                {
                    if(randy.NextDouble() < rate){
                        neuron.Bias += randy.NextDouble(-1, 1) * Fitness;
                    }

                    for (int i = 0; i < neuron.Weights.Length; i++){
                        if(randy.NextDouble() < rate){
                            neuron.Weights[i] += randy.NextDouble(-1, 1) * Fitness;
                        }
                    }
                }
            }
        }

        public void Crossover(NeuralNetwork other, Random randy)
        {
            for (int i = 0; i < Layers.Length; i++)
            {
                int greatWall = randy.Next(0, Layers[i].Neurons.Length);
                bool primary = randy.Next(2) == 1;
                for (int n = (primary ? greatWall : 0); n < (primary ? Layers[i].Neurons.Length : greatWall); n++)
                {
                    other.Layers[i].Neurons[n].Weights.CopyTo(Layers[i].Neurons[n].Weights, 0);
                    Layers[i].Neurons[n].Bias = other.Layers[i].Neurons[n].Bias;
                }
            }
        }

    }
}
