using System;
namespace Perceptron
{
    public class Perceptron
    {
        

        public Random randy = new Random();
        public double dendriteA;
        public double dendriteB;

        public Perceptron(){
            dendriteA = randy.NextDouble();
            dendriteB = randy.NextDouble();
        }

        public Perceptron(double dendriteA, double dendriteB){
            this.dendriteA = dendriteA;
            this.dendriteB = dendriteB;
        }

        public double Run(double x, double y){
            return x * dendriteA + y * dendriteB;
        }

        public void Mutate(double rate){
            if(randy.NextDouble() < rate){
                dendriteA += randy.NextDouble() * (randy.Next(2) == 0 ? -1 : 1);
            }
			if (randy.NextDouble() < rate)
			{
				dendriteB += randy.NextDouble() * (randy.Next(2) == 0 ? -1 : 1);
			}
        }

        public Perceptron DeepCopy(){
            return new Perceptron(dendriteA, dendriteB);
        }

    }
}
