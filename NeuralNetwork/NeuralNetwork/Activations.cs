using System;
namespace NeuralNetwork
{
    public static class Activations
    {
        static double SigmoidActivation(double x)
        {
            return 1 / (1 + Math.Pow(Math.E, -x));
        }

        static double SigmoidDerivative(double x){
            return x * (1 - x);
        }

        static double BinaryStepActivation(double x)
        {
            return x < 0 ? 0 : 1;
        }

        public static ActivationFunc Sigmoid = new ActivationFunc(SigmoidActivation, SigmoidDerivative);
    }
}
