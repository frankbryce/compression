using System;
using System.Collections.Generic;

namespace CompressionApplication.DataGenerators
{
    public class SixteenDataGenerator : IDataGenerator
    {
        private readonly Random _random;

        public SixteenDataGenerator()
        {
            _random = new Random((int)DateTime.Now.Ticks);
        }

        public byte[] GenerateArray(uint length)
        {
            var bytes = new List<byte>();
            for (var idx = 0; idx < length; idx++)
            {
                bytes.Add((byte) _random.Next(16));
            }
            return bytes.ToArray();
        }
    }
}