using System;
using CompressionApplication.DataCompressors;
using CompressionApplication.DataGenerators;

namespace CompressionApplication
{
    class Program
    {
        static void Main()
        {
            var randomGenerator = new RandomDataGenerator();

            var randomRunner = new CompressionRunner(randomGenerator, new CopyDataCompressor());
            Console.WriteLine("Copying \"Compressor\":");
            RunWithRunner(randomRunner);

            var simpleRunner = new CompressionRunner(randomGenerator, new SimpleDataCompressor());
            Console.WriteLine("Simple (non)Compressor:");
            RunWithRunner(simpleRunner);

            var lessSimpleRunner = new CompressionRunner(randomGenerator, new LessSimpleDataCompressor());
            Console.WriteLine("LessSimple Compressor with randomness:");
            RunWithRunner(lessSimpleRunner);

            var lessSimpleRunnerWithMaxDuplication = new CompressionRunner(new AllOnesGenerator(), new LessSimpleDataCompressor());
            Console.WriteLine("LessSimple Compressor maximum duplication:");
            RunWithRunner(lessSimpleRunnerWithMaxDuplication);

            var lessSimpleRunnerWithDuplication = new CompressionRunner(new SixteenDataGenerator(), new LessSimpleDataCompressor());
            Console.WriteLine("LessSimple Compressor some duplication:");
            RunWithRunner(lessSimpleRunnerWithDuplication);

            Console.ReadLine();
        }

        static void RunWithRunner(CompressionRunner runner)
        {
            var sizes = new uint[] {1, 10, 100, 1000, 10000, 100000, 1000000};
            foreach (var size in sizes)
            {
                var compressionRatio = runner.Run(size);
                PrintResult(compressionRatio, size);
            }

            Console.WriteLine();
        }

        static void PrintResult(double compressionRatio, uint size)
        {
            Console.WriteLine("Compression Ratio (" + size + " uncompressed bytes): {0:0.00}%", (compressionRatio * 100));
        }
    }
}
