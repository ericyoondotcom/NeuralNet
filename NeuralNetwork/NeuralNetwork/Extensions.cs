using System;
namespace NeuralNetwork
{
    public static class Extensions
    {
        static double NextDouble(this Random randy, double min, double max){
            return randy.NextDouble() * (max - min) + min;
        }
    }
}
