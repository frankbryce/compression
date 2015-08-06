using CompressionApplication.DataCompressors;
using CompressionApplication.DataGenerators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompressionTests
{
    public abstract class DataCompressorTests
    {
        protected IDataCompressor Uut;

        private void verifyArrays(byte[] uncompressedData, byte[] newUncompressedData)
        {
            Assert.AreEqual(uncompressedData.Length, newUncompressedData.Length);
            for (var idx = 0; idx < uncompressedData.Length; idx++)
            {
                Assert.AreEqual(uncompressedData[idx], newUncompressedData[idx]);
            }
        }

        [TestMethod]
        public virtual void IdentityTest()
        {
            var uncompressedData = new byte[] { 123 };
            var compressedData = Uut.CompressData(uncompressedData);
            var newUncompressedData = Uut.DecompressData(compressedData);
            verifyArrays(uncompressedData, newUncompressedData);
        }

        [TestMethod]
        public virtual void RandomArrayTest()
        {
            const uint arrayLength = 100;
            var uncompressedData = (new RandomDataGenerator()).GenerateArray(arrayLength);
            var compressedData = Uut.CompressData(uncompressedData);
            var newUncompressedData = Uut.DecompressData(compressedData);
            verifyArrays(uncompressedData, newUncompressedData);
        }

        [TestMethod]
        public virtual void RandomArray256Test()
        {
            const uint arrayLength = 256;
            var uncompressedData = (new RandomDataGenerator()).GenerateArray(arrayLength);
            var compressedData = Uut.CompressData(uncompressedData);
            var newUncompressedData = Uut.DecompressData(compressedData);
            verifyArrays(uncompressedData, newUncompressedData);
        }

        [TestMethod]
        public virtual void RandomArray16KbTest()
        {
            const uint arrayLength = 16*1024;
            var uncompressedData = (new RandomDataGenerator()).GenerateArray(arrayLength);
            var compressedData = Uut.CompressData(uncompressedData);
            var newUncompressedData = Uut.DecompressData(compressedData);
            verifyArrays(uncompressedData, newUncompressedData);
        }

        [TestMethod]
        public virtual void RandomArray1MbTest()
        {
            const uint arrayLength = 1024 * 1024; // 1MB
            var uncompressedData = (new RandomDataGenerator()).GenerateArray(arrayLength);
            var compressedData = Uut.CompressData(uncompressedData);
            var newUncompressedData = Uut.DecompressData(compressedData);
            verifyArrays(uncompressedData, newUncompressedData);
        }
    }
}