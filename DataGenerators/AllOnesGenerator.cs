namespace CompressionApplication.DataGenerators
{
    public class AllOnesGenerator : IDataGenerator
    {
        public byte[] GenerateArray(uint length)
        {
            var byteArray = new byte[length];
            for (var idx = 0; idx < length; idx++)
            {
                byteArray[idx] = 1;
            }
            return byteArray;
        }
    }
}