namespace CompressionApplication.DataCompressors
{
    public interface IDataCompressor
    {
        byte[] CompressData(byte[] uncompressedData);
        byte[] DecompressData(byte[] compressedData);
    }
}