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

            Console.WriteLine("Copying Compressor:");
            var compressionRatio = randomRunner.Run(1);
            PrintResult(compressionRatio);
            compressionRatio = randomRunner.Run(100);
            PrintResult(compressionRatio);
            compressionRatio = randomRunner.Run(10000);
            PrintResult(compressionRatio);
            compressionRatio = randomRunner.Run(1000000);
            PrintResult(compressionRatio);
            Console.WriteLine();

            var simpleRunner = new CompressionRunner(randomGenerator, new SimpleDataCompressor());

            Console.WriteLine("Simple (non)Compressor:");
            compressionRatio = simpleRunner.Run(1);
            PrintResult(compressionRatio);
            compressionRatio = simpleRunner.Run(10);
            PrintResult(compressionRatio);
            compressionRatio = simpleRunner.Run(100);
            PrintResult(compressionRatio);
            compressionRatio = simpleRunner.Run(1000);
            PrintResult(compressionRatio);
            Console.WriteLine();

            var lessSimpleRunner = new CompressionRunner(randomGenerator, new LessSimpleDataCompressor());

            Console.WriteLine("LessSimple (non)Compressor:");
            compressionRatio = lessSimpleRunner.Run(1);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunner.Run(10);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunner.Run(100);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunner.Run(1000);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunner.Run(10000);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunner.Run(100000);
            PrintResult(compressionRatio);
            Console.WriteLine();

            var lessSimpleRunnerWithMaxDuplication = new CompressionRunner(new AllOnesGenerator(), new LessSimpleDataCompressor());

            Console.WriteLine("LessSimple (non)Compressor:");
            compressionRatio = lessSimpleRunnerWithMaxDuplication.Run(1);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunnerWithMaxDuplication.Run(10);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunnerWithMaxDuplication.Run(100);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunnerWithMaxDuplication.Run(1000);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunnerWithMaxDuplication.Run(10000);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunnerWithMaxDuplication.Run(100000);
            PrintResult(compressionRatio);
            Console.WriteLine();

            var lessSimpleRunnerWithDuplication = new CompressionRunner(new SixteenDataGenerator(), new LessSimpleDataCompressor());

            Console.WriteLine("LessSimple (non)Compressor:");
            compressionRatio = lessSimpleRunnerWithDuplication.Run(1);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunnerWithDuplication.Run(10);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunnerWithDuplication.Run(100);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunnerWithDuplication.Run(1000);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunnerWithDuplication.Run(10000);
            PrintResult(compressionRatio);
            compressionRatio = lessSimpleRunnerWithDuplication.Run(100000);
            PrintResult(compressionRatio);
            Console.WriteLine();

            Console.ReadLine();
        }

        static void PrintResult(double compressionRatio)
        {
            Console.WriteLine("Compression Ratio: " + (compressionRatio * 100) + "%");
        }
    }
}
