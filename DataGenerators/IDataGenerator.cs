namespace CompressionApplication.DataGenerators
{
    public interface IDataGenerator
    {
        byte[] GenerateArray(uint length);
    }
}