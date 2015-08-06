using System;
using CompressionApplication.DataCompressors;
using CompressionApplication.DataGenerators;

namespace CompressionApplication
{
    public class CompressionRunner
    {
        private readonly IDataGenerator _dataGenerator;
        private readonly IDataCompressor _dataCompressor;

        public CompressionRunner(IDataGenerator dataGenerator,
            IDataCompressor dataCompressor)
        {
            _dataGenerator = dataGenerator;
            _dataCompressor = dataCompressor;
        }

        /// <summary>
        /// </summary>
        /// <param name="dataLength">The length of the data to be compressed and decompressed</param>
        /// <exception cref="Exception">decompressed data doesn't match original data</exception>
        /// <returns></returns>
        public double Run(uint dataLength)
        {
            var uncompressedData = _dataGenerator.GenerateArray(dataLength);
            var compressedData = _dataCompressor.CompressData(uncompressedData);
            var decompressedData = _dataCompressor.DecompressData(compressedData);

            if (decompressedData.Length != uncompressedData.Length) throw new Exception("decompressed data doesn't match original data");
            for (var idx = 0; idx < uncompressedData.Length; idx++)
            {
                if (decompressedData[idx] != uncompressedData[idx]) throw new Exception("decompressed data doesn't match original data");
            }

            return 1.0 - compressedData.Length / (double)uncompressedData.Length;
        }
    }
}