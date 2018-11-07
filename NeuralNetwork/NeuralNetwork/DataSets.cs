using System;
using dubble = System.Double;
namespace NeuralNetwork
{
    public static class DataSets
    {

        public static (dubble[], dubble)[] XOR = new(dubble[], dubble)[] { (new dubble[] { 0, 0 }, 0), (new dubble[] { 0, 1 }, 1), (new dubble[] { 1, 0 }, 1), (new dubble[] { 1, 1 }, 0) };
    }
}
