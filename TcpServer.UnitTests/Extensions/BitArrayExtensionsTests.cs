using System.Collections;
using TcpServer.Extensions;
using Xunit;

namespace TcpServer.UnitTests.Extensions
{
    public class BitArrayExtensionsTests
    {
        [Fact]
        public void CopySliceShouldReturnFirstElementOfBitArray()
        {
            const int copiedElementIndex = 0;
            const int newSize = 1;

            var bits = new BitArray(new []{true, false});
            var newBits = bits.CopySlice(copiedElementIndex, newSize);

            Assert.Equal(newSize, newBits.Length);
            Assert.Equal(bits[copiedElementIndex], newBits[copiedElementIndex]);
        }

        [Fact]
        public void CopySliceShouldReturnTheSameBitArray()
        {
            const int firstIndex = 0;
            const int newSize = 2;

            var bits = new BitArray(new[] { true, false });
            var newBits = bits.CopySlice(firstIndex, newSize);

            Assert.Equal(bits, newBits);
        }

        [Fact]
        public void ToBitStringShouldSucceed()
        {
            const string expectedString = "1001";
            var bits = new BitArray(new[] { true, false, false, true });
            var bitString = bits.ToBitString();

            Assert.Equal(expectedString, bitString);
        }

        [Fact]
        public void ToBitStringShouldReturnEmptyStringForEmptyBitArray()
        {
            var expectedString = string.Empty;
            var bits = new BitArray(new bool[]{});
            var bitString = bits.ToBitString();

            Assert.Equal(expectedString, bitString);
        }

        [Fact]
        public void ToIntShouldSucceed()
        {
            const int expectedNumber = 6;
            var bits = new BitArray(new [] { false, true, true, false });
            var resultNumber = bits.ToInt();

            Assert.Equal(expectedNumber, resultNumber);
        }
    }
}
