using System;
using System.Text;

namespace NeuralNet
{
    class MainClass
    {

        static Random randy = new Random();

        public static void Main(string[] args)
        {
            StringBuilder current = new StringBuilder();
            string target = "Hello, World!";

            Random randy = new Random();
            for (int i = 0; i < target.Length; i++) current.Append((char)randy.Next(32, 127));
            Console.WriteLine(current);
            Console.WriteLine(Fitness(current, target));

            int currentFitness = Fitness(current, target);
            int epoch = 0;
            while (currentFitness != 0){
                epoch++;
                StringBuilder newString = new StringBuilder(current.ToString());
                Mutate(newString);
                int newFitness = Fitness(newString, target);
                if(newFitness < currentFitness){
                    currentFitness = newFitness;
                    current = newString;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(current);
                }else{
                    Console.ResetColor();
                    Console.WriteLine(newString);
                }
            }
            Console.ResetColor();
            Console.WriteLine("Found solution in " + epoch.ToString() + " iterations");
        }

        static int Fitness(StringBuilder value, string target) => Fitness(value.ToString(), target);

        static int Fitness(string value, string target){
            int fitness = 0;
            for (int i = 0; i < value.Length; i++){
                fitness += Math.Abs((int)value[i] - (int)target[i]);
            }
            return fitness;
        }

        static void Mutate(StringBuilder current)
        {
            
            int idx = randy.Next(0, current.Length);
            int newChar = (int)current[idx] + (randy.Next(2) == 0 ? -1 : 1);
            if (newChar > 126) newChar = 126;
            if (newChar < 32) newChar = 32;
            current[idx] = (char)newChar;
        }
    }
}
