namespace CompressionApplication.DataCompressors
{
    public class CopyDataCompressor : IDataCompressor
    {
        public byte[] CompressData(byte[] uncompressedData)
        {
            return (byte[])uncompressedData.Clone();
        }

        public byte[] DecompressData(byte[] compressedData)
        {
            return (byte[])compressedData.Clone();
        }
    }
}