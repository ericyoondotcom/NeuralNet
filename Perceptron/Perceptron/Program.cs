using System;

namespace Perceptron
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Perceptron add = new Perceptron();
            Random rando = new Random();
            var tests = new(int x, int y, int result)[50];
            for (int i = 0; i < tests.Length; i++){
                int x = rando.Next(10);
                int y = rando.Next(10);

                tests[i] = (x, y, x + y);
            }
            while(true){
                double error = 0;

                foreach (var test in tests){
                    error += Math.Abs((test.result - add.Run(test.x, test.y)) / (test.result == 0 ? 1 : test.result));

                }

                Perceptron newPerceptron = add.DeepCopy();
                newPerceptron.Mutate(.5);
                double newError = 0;
				foreach (var test in tests)
				{
                    newError += Math.Abs((test.result - newPerceptron.Run(test.x, test.y)) / (test.result == 0 ? 1 : test.result));
				}
                if (newError < error)
                {
                    if (newError == 0)
                    {
                        Console.WriteLine("Finished!");
                        return;
                    }
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Error: {error}, New Error: {newError}, Diff: {error - newError}, Perceptron: {add}, New Perceptron: {newPerceptron}");
                    Console.ResetColor();
                    add = newPerceptron;
                }else{
                    //Console.WriteLine($"Error: {error}, New Error: {newError}, Diff: {error - newError}, Perceptron: {add}, New Perceptron: {newPerceptron}");
                }

            }
        }
    }
}
