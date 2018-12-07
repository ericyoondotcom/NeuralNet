using System;
using System.Collections.Generic;
using System.Linq;
using dubble = System.Double;
namespace NeuralNetwork
{
    class MainClass
    {




        static double MAE(NeuralNetwork net){

            double error = 0;
            for (int i = 0; i < net.Tests.Length; i++){
                error += Math.Abs(net.Tests[i].Item2 - net.Compute(net.Tests[i].Item1)[0]);

            }
            return error;

        }

        static double Evolve(NeuralNetwork[] population, Random randy){

            foreach (var net in population)
            {
                net.Fitness = MAE(net);
            }
            Array.Sort(population, (a, b) => a.Fitness.CompareTo(b.Fitness));

            //Console.WriteLine(population[0].Fitness);
            for (int i = 1; i < population.Length; i++)
            {
                population[i].Mutate(0.30, randy);
            }
            return population[0].Fitness;
        }
        static double Crossover(NeuralNetwork[] population, Random randy)
        {

            foreach (var net in population)
            {
                net.Fitness = MAE(net);
            }
            Array.Sort(population, (a, b) => a.Fitness.CompareTo(b.Fitness));


            //Console.WriteLine(population[0].Fitness);

            for (int i = (int)(population.Length * 0.05); i < population.Length * 0.6; i++)
            {
                population[i].Crossover(population[randy.Next(0, (int)(population.Length * 0.05))], randy);
                population[i].Mutate(0.5, randy);
            }
            for (int i = (int)(population.Length * 0.6); i < population.Length; i++)
            {
                population[i].Randomize(randy);
            }
            return population[0].Fitness;
        }

        static double Backprop(NeuralNetwork net){
        
            foreach((dubble[], dubble) test in net.Tests){
                double[] outputs = net.Compute(test.Item1);

            }

            return 0;
        }

        public void CalculateErrors((dubble[], dubble) test, NeuralNetwork net){
            double expected = test.Item2;
            for (int i = 0; i < net.OutputLayer.Neurons.Length; i++)
            {
                Neuron n = net.OutputLayer.Neurons[i];
                double o = n.Output;

                double error = expected - o;
                net.OutputLayer.Neurons[i].PartialDerivative = error * net.Activation.derivative(o);
            }


            for (int i = net.Layers.Length - 2; i <= 0; i--){
                Layer currLayer = net.Layers[i];
                Layer nextLayer = net.Layers[i + 1];

                for (int j = 0; j < currLayer.Neurons.Length; j++){
                    Neuron currN = currLayer.Neurons[j];

                    double error = 0;

                    foreach(Neuron nextN in nextLayer.Neurons){
                        error += nextN.PartialDerivative * nextN.Weights[j];
                    }

                    currN.PartialDerivative = error * net.Activation.derivative(currN.Output);
                }
            }

        }
        public void CalculateUpdates((dubble[], dubble) test, NeuralNetwork net, double learningRate){
            dubble[] inputs = test.Item1;


            for (int i = 0; i < net.InputLayer.Neurons.Length; i++){
                Neuron n = net.InputLayer.Neurons[i];
                for (int j = 0; j < n.Weights.Length; i++){
                    n.WeightUpdates[j] = learningRate * n.PartialDerivative * inputs[j];
                }
                n.BiasUpdate += learningRate * n.PartialDerivative;
            }

            //TODO: Update stuff for hidden layers.

        }


        public static void Main(string[] args)
        {
            Random randy = new Random();//"shrek".GetHashCode());

            NeuralNetwork[] evolvePop = new NeuralNetwork[1000];
            NeuralNetwork[] crossoverPop = new NeuralNetwork[1000];

            for (int i = 0; i < evolvePop.Length; i++){
                evolvePop[i] = new NeuralNetwork(Activations.Sigmoid, 2, DataSets.XOR, 2, 1);
                evolvePop[i].Randomize(randy);
            }
            for (int i = 0; i < crossoverPop.Length; i++)
            {
                crossoverPop[i] = new NeuralNetwork(Activations.Sigmoid, 2, DataSets.XOR, 2, 1);
                crossoverPop[i].Randomize(randy);
            }


            while (true){
            
                double evolve = Evolve(evolvePop, randy);
                double cross = Crossover(crossoverPop, randy);

                Console.WriteLine(evolve - cross);
                if(evolve == 0){
                    Console.WriteLine("Evolve wins!");
                    break;
                }
                if(cross == 0){
                    Console.WriteLine("Cross wins!");
                    break;
                }


            }
        }
    }
}
