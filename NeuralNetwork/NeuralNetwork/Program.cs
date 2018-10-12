using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    class MainClass
    {

        static double Sigmoid(double x){
            return 1 / (1 + Math.Pow(Math.E, -x));
        }

        static double MAE(NeuralNetwork net){
            double[] expected = { 0, 1, 1, 0 };
            double[] actual = new double[4];

            actual[0] = net.Compute(new double[] { 0, 0 })[0];
            actual[1] = net.Compute(new double[] { 0, 1 })[0];
            actual[2] = net.Compute(new double[] { 1, 0 })[0];
            actual[3] = net.Compute(new double[] { 1, 1 })[0];
            double error = 0;
            for (int i = 0; i < 4; i++){
                error += Math.Abs(expected[i] - actual[i]);

            }
            error /= 4;
            return error;

        }

        static void Evolve(NeuralNetwork[] population, Random randy){

            foreach (var net in population)
            {
                net.Fitness = MAE(net);
            }
            Array.Sort(population, (a, b) => a.Fitness.CompareTo(b.Fitness));
            Console.WriteLine(population[0].Fitness);
            for (int i = 1; i < population.Length; i++)
            {
                population[i].Mutate(population[i].Fitness, randy);
            }
        }
        static void Crossover(NeuralNetwork[] population, Random randy)
        {

            foreach (var net in population)
            {
                net.Fitness = MAE(net);
            }
            Array.Sort(population, (a, b) => a.Fitness.CompareTo(b.Fitness));
            Console.WriteLine(population[0].Fitness);
            for (int i = population.Length / 10; i < population.Length / 90; i++)
            {
                population[i].Crossover(population[randy.Next(0, population.Length / 10)], randy);
            }
            for (int i = population.Length / 90; i < population.Length; i++)
            {
                population[i].Mutate(1, randy);
            }
        }

        public static void Main(string[] args)
        {
            Random randy = new Random("shrek".GetHashCode());

            NeuralNetwork[] population = new NeuralNetwork[1000];

            for (int i = 0; i < population.Length; i++){
                population[i] = new NeuralNetwork(Sigmoid, 2, 2, 1);
                population[i].Randomize(randy);
            }


            while(true){


                Crossover(population, randy);


            }
        }
    }
}
