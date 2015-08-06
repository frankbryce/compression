using CompressionApplication.DataCompressors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompressionTests
{
    [TestClass]
    public class CopyDataCompressorTests : DataCompressorTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Uut = new CopyDataCompressor();
        }
    }
}
