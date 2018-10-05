using System;

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

            actual[0] = net.Compute(new double[] { 0, 0 });
            actual[1] = net.Compute(new double[] { 0, 1 });
            actual[2] = net.Compute(new double[] { 1, 0 });
            actual[3] = net.Compute(new double[] { 1, 1 });
            double error = 0;
            for (int i = 0; i < 4; i++){
                error += Math.Abs(expected[i] - actual[i]);

            }
            error /= 4;
            return error;

        }

        public static void Main(string[] args)
        {
            Random randy = new Random("shrek".GetHashCode());

            NeuralNetwork[] population = new NeuralNetwork[100000];

            NeuralNetwork net = new NeuralNetwork(Sigmoid, 2, 2, 1);
            net.Randomize(randy);

            Console.WriteLine($"0 0: {net.Compute(new double[] { 0, 0 })}");
            Console.WriteLine($"0 1: {net.Compute(new double[] { 0, 1 })}");
            Console.WriteLine($"1 0: {net.Compute(new double[] { 1, 0 })}");
            Console.WriteLine($"1 1: {net.Compute(new double[] { 1, 1 })}");
        }
    }
}
