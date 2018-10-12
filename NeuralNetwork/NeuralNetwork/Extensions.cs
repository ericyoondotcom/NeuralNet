using System;
namespace NeuralNetwork
{
    public static class Extensions
    {
        public static double NextDouble(this Random randy, double min, double max){
            return randy.NextDouble() * (max - min) + min;
        }
    }
}
