using CompressionApplication.DataCompressors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompressionTests
{
    [TestClass]
    public class SimpleDataCompressorTests : DataCompressorTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Uut = new SimpleDataCompressor();
        }
    }
}