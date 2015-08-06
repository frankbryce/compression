using System.Collections.Generic;
using System.Linq;

namespace CompressionApplication.DataCompressors
{
    public class SimpleDataCompressor : IDataCompressor
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

            foreach (var d in uncompressedData)
            {
                for (byte idx = 0; idx < heatList.Count; idx++)
                {
                    if (heatList[idx].First != d) continue;
                    compressedData.Add(idx);
                    break;
                }
            }

            return compressedData.ToArray();
        }

        public byte[] DecompressData(byte[] compressedData)
        {
            if (compressedData.Length == 0) return new byte[0];

            var len = compressedData[0]+1;
            var decompressedData = new List<byte>();

            for (var idx = len + 1; idx < compressedData.Length; idx++)
            {
                decompressedData.Add(compressedData[compressedData[idx]+1]);
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