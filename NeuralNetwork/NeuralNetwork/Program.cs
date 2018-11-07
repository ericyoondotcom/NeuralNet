using System;
using System.Collections.Generic;
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
