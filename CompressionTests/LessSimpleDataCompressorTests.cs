using CompressionApplication.DataCompressors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompressionTests
{
    [TestClass]
    public class LessSimpleDataCompressorTests : DataCompressorTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Uut = new LessSimpleDataCompressor();
        }
    }
}