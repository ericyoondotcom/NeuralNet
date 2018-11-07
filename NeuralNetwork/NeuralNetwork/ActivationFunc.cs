using System;
namespace NeuralNetwork
{
    public class ActivationFunc
    {
        public delegate double Activation(double x);
        public delegate double Derivative(double x);

        public Activation activation;
        public Derivative derivative;

        public ActivationFunc(Activation activation, Derivative derivative)
        {
            this.activation = activation;
            this.derivative = derivative;
        }
    }
}
