using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CompressionApplication.DataCompressors
{
    public class LessSimpleDataCompressor : IDataCompressor
    {
        public byte[] CompressData(byte[] uncompressedData)
        {
            // TODO: find out how many bits it takes to represent the data

            var heatList = new List<Pair<byte, uint>>(256);

            for (uint idx = 0; idx < 256; idx++)
            {
                heatList.Add(new Pair<byte, uint>((byte) idx, 0));
            }

            foreach (var d in uncompressedData)
            {
                heatList[d].Second++;
            }

            heatList.Sort((a, b) => (int)(b.Second - a.Second));
            while(heatList[heatList.Count-1].Second==0) heatList.RemoveAt(heatList.Count-1);

            var compressedData = new List<byte>();
            compressedData.Add((byte) (heatList.Count-1));
            compressedData.AddRange(heatList.Select(x => x.First).ToList());

            var bitsPerHeatmapIdx = heatList.Count==1 ? 1 : (int) Math.Ceiling(Math.Log(heatList.Count, 2));
            var bitArray = new BitArray(uncompressedData.Length * bitsPerHeatmapIdx);
            var bitsAdded = 0;
            for (var i=0; i < uncompressedData.Length; i++)
            {
                var d = uncompressedData[i];
                for (byte idx = 0; idx < heatList.Count; idx++)
                {
                    if (heatList[idx].First != d) continue;
                    //compressedData.Add(idx);
                    for (var bitIdx = 0; bitIdx < bitsPerHeatmapIdx; bitIdx++)
                    {
                        bitArray[bitsAdded + bitIdx] = (idx >> bitIdx) % 2 == 1;
                    }
                    bitsAdded+=bitsPerHeatmapIdx;
                    break;
                }
            }

            var byteArray = new byte[(int) Math.Ceiling(bitsPerHeatmapIdx * uncompressedData.Length / 8.0)];
            bitArray.CopyTo(byteArray, 0);
            compressedData.Add((byte) ((8 - (bitArray.Length % 8)) % 8));
            compressedData.AddRange(byteArray);

            return compressedData.ToArray();
        }

        public byte[] DecompressData(byte[] compressedData)
        {
            if (compressedData.Length == 0) return new byte[0];

            var len = compressedData[0] + 1;
            var bitsPerHeatmapIdx = len == 1 ? 1 : (int)Math.Ceiling(Math.Log(len, 2));
            var decompressedData = new List<byte>();

            var compressedDataAfterHeatmap = compressedData.Skip(len + 2).ToArray();
            var bitsToLopOff = compressedData[len + 1];
            var bitArray = new BitArray(compressedDataAfterHeatmap);
            var lengthOfBitArray = (bitArray.Length - bitsToLopOff)/bitsPerHeatmapIdx;

            for (var idx = 0; idx < lengthOfBitArray; idx++)
            {
                // get idx in heatmap
                var heatmapIdx = 0;
                for (var bitIdx = 0; bitIdx < bitsPerHeatmapIdx; bitIdx++)
                {
                    heatmapIdx += (bitArray[idx * bitsPerHeatmapIdx + bitIdx] ? 1 << bitIdx : 0);
                }

                decompressedData.Add(compressedData[heatmapIdx + 1]);
            }

            return decompressedData.ToArray();
        }

        private class Pair<T1, T2>
        {
            public Pair(T1 first, T2 second)
            {
                First = first;
                Second = second;
            }
            public T1 First { get; set; }
            public T2 Second { get; set; }
        }
    }
}