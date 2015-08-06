using System;

namespace CompressionApplication.DataGenerators
{
    public class RandomDataGenerator : IDataGenerator
    {
        private readonly Random _random;

        public RandomDataGenerator()
        {
            _random = new Random((int)DateTime.Now.Ticks);
        }

        public byte[] GenerateArray(uint length)
        {
            if (length == 0) return new byte[0];
            var bytes = new byte[length];
            _random.NextBytes(bytes);
            return bytes;
        }
    }
}