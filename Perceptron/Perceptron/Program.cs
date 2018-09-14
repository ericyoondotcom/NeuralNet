using System;

namespace Perceptron
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Perceptron add = new Perceptron();


            while(true){
                double error = Math.Abs(3 - add.Run(1, 2));
                Perceptron old = add;
                add.Mutate(.5);
                double newError = Math.Abs(3 - add.Run(1, 2));
                if(error < newError){
                    
                }

            }
        }
    }
}
