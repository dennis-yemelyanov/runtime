﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;
using Xunit;

namespace System.Runtime.Intrinsics.Tests.Vectors
{
    public sealed class Vector128Tests
    {
        [Fact]
        public unsafe void Vector128ByteExtractMostSignificantBitsTest()
        {
            Vector128<byte> vector = Vector128.Create(
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80
            );

            uint result = Vector128.ExtractMostSignificantBits(vector);
            Assert.Equal(0b10101010_10101010u, result);
        }

        [Fact]
        public unsafe void Vector128DoubleExtractMostSignificantBitsTest()
        {
            Vector128<double> vector = Vector128.Create(
                +1.0,
                -0.0
            );

            uint result = Vector128.ExtractMostSignificantBits(vector);
            Assert.Equal(0b10u, result);
        }

        [Fact]
        public unsafe void Vector128Int16ExtractMostSignificantBitsTest()
        {
            Vector128<short> vector = Vector128.Create(
                0x0001,
                0x8000,
                0x0001,
                0x8000,
                0x0001,
                0x8000,
                0x0001,
                0x8000
            ).AsInt16();

            uint result = Vector128.ExtractMostSignificantBits(vector);
            Assert.Equal(0b10101010u, result);
        }

        [Fact]
        public unsafe void Vector128Int32ExtractMostSignificantBitsTest()
        {
            Vector128<int> vector = Vector128.Create(
                0x00000001U,
                0x80000000U,
                0x00000001U,
                0x80000000U
            ).AsInt32();

            uint result = Vector128.ExtractMostSignificantBits(vector);
            Assert.Equal(0b1010u, result);
        }

        [Fact]
        public unsafe void Vector128Int64ExtractMostSignificantBitsTest()
        {
            Vector128<long> vector = Vector128.Create(
                0x0000000000000001UL,
                0x8000000000000000UL
            ).AsInt64();

            uint result = Vector128.ExtractMostSignificantBits(vector);
            Assert.Equal(0b10u, result);
        }

        [Fact]
        public unsafe void Vector128NIntExtractMostSignificantBitsTest()
        {
            if (Environment.Is64BitProcess)
            {
                Vector128<nint> vector = Vector128.Create(
                    0x0000000000000001UL,
                    0x8000000000000000UL
                ).AsNInt();

                uint result = Vector128.ExtractMostSignificantBits(vector);
                Assert.Equal(0b10u, result);
            }
            else
            {
                Vector128<nint> vector = Vector128.Create(
                    0x00000001U,
                    0x80000000U,
                    0x00000001U,
                    0x80000000U
                ).AsNInt();

                uint result = Vector128.ExtractMostSignificantBits(vector);
                Assert.Equal(0b1010u, result);
            }
        }

        [Fact]
        public unsafe void Vector128NUIntExtractMostSignificantBitsTest()
        {
            if (Environment.Is64BitProcess)
            {
                Vector128<nuint> vector = Vector128.Create(
                    0x0000000000000001UL,
                    0x8000000000000000UL
                ).AsNUInt();

                uint result = Vector128.ExtractMostSignificantBits(vector);
                Assert.Equal(0b10u, result);
            }
            else
            {
                Vector128<nuint> vector = Vector128.Create(
                    0x00000001U,
                    0x80000000U,
                    0x00000001U,
                    0x80000000U
                ).AsNUInt();

                uint result = Vector128.ExtractMostSignificantBits(vector);
                Assert.Equal(0b1010u, result);
            }
        }

        [Fact]
        public unsafe void Vector128SByteExtractMostSignificantBitsTest()
        {
            Vector128<sbyte> vector = Vector128.Create(
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80,
                0x01,
                0x80
            ).AsSByte();

            uint result = Vector128.ExtractMostSignificantBits(vector);
            Assert.Equal(0b10101010_10101010u, result);
        }

        [Fact]
        public unsafe void Vector128SingleExtractMostSignificantBitsTest()
        {
            Vector128<float> vector = Vector128.Create(
                +1.0f,
                -0.0f,
                +1.0f,
                -0.0f
            );

            uint result = Vector128.ExtractMostSignificantBits(vector);
            Assert.Equal(0b1010u, result);
        }

        [Fact]
        public unsafe void Vector128UInt16ExtractMostSignificantBitsTest()
        {
            Vector128<ushort> vector = Vector128.Create(
                0x0001,
                0x8000,
                0x0001,
                0x8000,
                0x0001,
                0x8000,
                0x0001,
                0x8000
            );

            uint result = Vector128.ExtractMostSignificantBits(vector);
            Assert.Equal(0b10101010u, result);
        }

        [Fact]
        public unsafe void Vector128UInt32ExtractMostSignificantBitsTest()
        {
            Vector128<uint> vector = Vector128.Create(
                0x00000001U,
                0x80000000U,
                0x00000001U,
                0x80000000U
            );

            uint result = Vector128.ExtractMostSignificantBits(vector);
            Assert.Equal(0b1010u, result);
        }

        [Fact]
        public unsafe void Vector128UInt64ExtractMostSignificantBitsTest()
        {
            Vector128<ulong> vector = Vector128.Create(
                0x0000000000000001UL,
                0x8000000000000000UL
            );

            uint result = Vector128.ExtractMostSignificantBits(vector);
            Assert.Equal(0b10u, result);
        }

        [Fact]
        public unsafe void Vector128ByteLoadTest()
        {
            byte* value = stackalloc byte[16] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
            };

            Vector128<byte> vector = Vector128.Load(value);

            for (int index = 0; index < Vector128<byte>.Count; index++)
            {
                Assert.Equal((byte)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128DoubleLoadTest()
        {
            double* value = stackalloc double[2] {
                0,
                1,
            };

            Vector128<double> vector = Vector128.Load(value);

            for (int index = 0; index < Vector128<double>.Count; index++)
            {
                Assert.Equal((double)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128Int16LoadTest()
        {
            short* value = stackalloc short[8] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
            };

            Vector128<short> vector = Vector128.Load(value);

            for (int index = 0; index < Vector128<short>.Count; index++)
            {
                Assert.Equal((short)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128Int32LoadTest()
        {
            int* value = stackalloc int[4] {
                0,
                1,
                2,
                3,
            };

            Vector128<int> vector = Vector128.Load(value);

            for (int index = 0; index < Vector128<int>.Count; index++)
            {
                Assert.Equal((int)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128Int64LoadTest()
        {
            long* value = stackalloc long[2] {
                0,
                1,
            };

            Vector128<long> vector = Vector128.Load(value);

            for (int index = 0; index < Vector128<long>.Count; index++)
            {
                Assert.Equal((long)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128NIntLoadTest()
        {
            if (Environment.Is64BitProcess)
            {
                nint* value = stackalloc nint[2] {
                    0,
                    1,
                };

                Vector128<nint> vector = Vector128.Load(value);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)index, vector.GetElement(index));
                }
            }
            else
            {
                nint* value = stackalloc nint[4] {
                    0,
                    1,
                    2,
                    3,
                };

                Vector128<nint> vector = Vector128.Load(value);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)index, vector.GetElement(index));
                }
            }
        }

        [Fact]
        public unsafe void Vector128NUIntLoadTest()
        {
            if (Environment.Is64BitProcess)
            {
                nuint* value = stackalloc nuint[2] {
                    0,
                    1,
                };

                Vector128<nuint> vector = Vector128.Load(value);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)index, vector.GetElement(index));
                }
            }
            else
            {
                nuint* value = stackalloc nuint[4] {
                    0,
                    1,
                    2,
                    3,
                };

                Vector128<nuint> vector = Vector128.Load(value);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)index, vector.GetElement(index));
                }
            }
        }

        [Fact]
        public unsafe void Vector128SByteLoadTest()
        {
            sbyte* value = stackalloc sbyte[16] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
            };

            Vector128<sbyte> vector = Vector128.Load(value);

            for (int index = 0; index < Vector128<sbyte>.Count; index++)
            {
                Assert.Equal((sbyte)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128SingleLoadTest()
        {
            float* value = stackalloc float[4] {
                0,
                1,
                2,
                3,
            };

            Vector128<float> vector = Vector128.Load(value);

            for (int index = 0; index < Vector128<float>.Count; index++)
            {
                Assert.Equal((float)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128UInt16LoadTest()
        {
            ushort* value = stackalloc ushort[8] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
            };

            Vector128<ushort> vector = Vector128.Load(value);

            for (int index = 0; index < Vector128<ushort>.Count; index++)
            {
                Assert.Equal((ushort)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128UInt32LoadTest()
        {
            uint* value = stackalloc uint[4] {
                0,
                1,
                2,
                3,
            };

            Vector128<uint> vector = Vector128.Load(value);

            for (int index = 0; index < Vector128<uint>.Count; index++)
            {
                Assert.Equal((uint)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128UInt64LoadTest()
        {
            ulong* value = stackalloc ulong[2] {
                0,
                1,
            };

            Vector128<ulong> vector = Vector128.Load(value);

            for (int index = 0; index < Vector128<ulong>.Count; index++)
            {
                Assert.Equal((ulong)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128ByteLoadAlignedTest()
        {
            byte* value = null;

            try
            {
                value = (byte*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;
                value[8] = 8;
                value[9] = 9;
                value[10] = 10;
                value[11] = 11;
                value[12] = 12;
                value[13] = 13;
                value[14] = 14;
                value[15] = 15;

                Vector128<byte> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<byte>.Count; index++)
                {
                    Assert.Equal((byte)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128DoubleLoadAlignedTest()
        {
            double* value = null;

            try
            {
                value = (double*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128<double> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<double>.Count; index++)
                {
                    Assert.Equal((double)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int16LoadAlignedTest()
        {
            short* value = null;

            try
            {
                value = (short*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;

                Vector128<short> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<short>.Count; index++)
                {
                    Assert.Equal((short)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int32LoadAlignedTest()
        {
            int* value = null;

            try
            {
                value = (int*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128<int> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<int>.Count; index++)
                {
                    Assert.Equal((int)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int64LoadAlignedTest()
        {
            long* value = null;

            try
            {
                value = (long*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128<long> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<long>.Count; index++)
                {
                    Assert.Equal((long)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128NIntLoadAlignedTest()
        {
            nint* value = null;

            try
            {
                value = (nint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                if (Environment.Is64BitProcess)
                {
                    value[0] = 0;
                    value[1] = 1;
                }
                else
                {
                    value[0] = 0;
                    value[1] = 1;
                    value[2] = 2;
                    value[3] = 3;
                }

                Vector128<nint> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128NUIntLoadAlignedTest()
        {
            nuint* value = null;

            try
            {
                value = (nuint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                if (Environment.Is64BitProcess)
                {
                    value[0] = 0;
                    value[1] = 1;
                }
                else
                {
                    value[0] = 0;
                    value[1] = 1;
                    value[2] = 2;
                    value[3] = 3;
                }

                Vector128<nuint> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128SByteLoadAlignedTest()
        {
            sbyte* value = null;

            try
            {
                value = (sbyte*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;
                value[8] = 8;
                value[9] = 9;
                value[10] = 10;
                value[11] = 11;
                value[12] = 12;
                value[13] = 13;
                value[14] = 14;
                value[15] = 15;

                Vector128<sbyte> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<sbyte>.Count; index++)
                {
                    Assert.Equal((sbyte)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128SingleLoadAlignedTest()
        {
            float* value = null;

            try
            {
                value = (float*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128<float> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<float>.Count; index++)
                {
                    Assert.Equal((float)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt16LoadAlignedTest()
        {
            ushort* value = null;

            try
            {
                value = (ushort*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;

                Vector128<ushort> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<ushort>.Count; index++)
                {
                    Assert.Equal((ushort)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt32LoadAlignedTest()
        {
            uint* value = null;

            try
            {
                value = (uint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128<uint> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<uint>.Count; index++)
                {
                    Assert.Equal((uint)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt64LoadAlignedTest()
        {
            ulong* value = null;

            try
            {
                value = (ulong*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128<ulong> vector = Vector128.LoadAligned(value);

                for (int index = 0; index < Vector128<ulong>.Count; index++)
                {
                    Assert.Equal((ulong)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128ByteLoadAlignedNonTemporalTest()
        {
            byte* value = null;

            try
            {
                value = (byte*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;
                value[8] = 8;
                value[9] = 9;
                value[10] = 10;
                value[11] = 11;
                value[12] = 12;
                value[13] = 13;
                value[14] = 14;
                value[15] = 15;

                Vector128<byte> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<byte>.Count; index++)
                {
                    Assert.Equal((byte)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128DoubleLoadAlignedNonTemporalTest()
        {
            double* value = null;

            try
            {
                value = (double*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128<double> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<double>.Count; index++)
                {
                    Assert.Equal((double)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int16LoadAlignedNonTemporalTest()
        {
            short* value = null;

            try
            {
                value = (short*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;

                Vector128<short> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<short>.Count; index++)
                {
                    Assert.Equal((short)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int32LoadAlignedNonTemporalTest()
        {
            int* value = null;

            try
            {
                value = (int*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128<int> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<int>.Count; index++)
                {
                    Assert.Equal((int)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int64LoadAlignedNonTemporalTest()
        {
            long* value = null;

            try
            {
                value = (long*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128<long> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<long>.Count; index++)
                {
                    Assert.Equal((long)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128NIntLoadAlignedNonTemporalTest()
        {
            nint* value = null;

            try
            {
                value = (nint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                if (Environment.Is64BitProcess)
                {
                    value[0] = 0;
                    value[1] = 1;
                }
                else
                {
                    value[0] = 0;
                    value[1] = 1;
                    value[2] = 2;
                    value[3] = 3;
                }

                Vector128<nint> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128NUIntLoadAlignedNonTemporalTest()
        {
            nuint* value = null;

            try
            {
                value = (nuint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                if (Environment.Is64BitProcess)
                {
                    value[0] = 0;
                    value[1] = 1;
                }
                else
                {
                    value[0] = 0;
                    value[1] = 1;
                    value[2] = 2;
                    value[3] = 3;
                }

                Vector128<nuint> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128SByteLoadAlignedNonTemporalTest()
        {
            sbyte* value = null;

            try
            {
                value = (sbyte*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;
                value[8] = 8;
                value[9] = 9;
                value[10] = 10;
                value[11] = 11;
                value[12] = 12;
                value[13] = 13;
                value[14] = 14;
                value[15] = 15;

                Vector128<sbyte> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<sbyte>.Count; index++)
                {
                    Assert.Equal((sbyte)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128SingleLoadAlignedNonTemporalTest()
        {
            float* value = null;

            try
            {
                value = (float*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128<float> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<float>.Count; index++)
                {
                    Assert.Equal((float)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt16LoadAlignedNonTemporalTest()
        {
            ushort* value = null;

            try
            {
                value = (ushort*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;

                Vector128<ushort> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<ushort>.Count; index++)
                {
                    Assert.Equal((ushort)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt32LoadAlignedNonTemporalTest()
        {
            uint* value = null;

            try
            {
                value = (uint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128<uint> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<uint>.Count; index++)
                {
                    Assert.Equal((uint)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt64LoadAlignedNonTemporalTest()
        {
            ulong* value = null;

            try
            {
                value = (ulong*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128<ulong> vector = Vector128.LoadAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<ulong>.Count; index++)
                {
                    Assert.Equal((ulong)index, vector.GetElement(index));
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128ByteLoadUnsafeTest()
        {
            byte* value = stackalloc byte[16] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
            };

            Vector128<byte> vector = Vector128.LoadUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<byte>.Count; index++)
            {
                Assert.Equal((byte)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128DoubleLoadUnsafeTest()
        {
            double* value = stackalloc double[2] {
                0,
                1,
            };

            Vector128<double> vector = Vector128.LoadUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<double>.Count; index++)
            {
                Assert.Equal((double)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128Int16LoadUnsafeTest()
        {
            short* value = stackalloc short[8] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
            };

            Vector128<short> vector = Vector128.LoadUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<short>.Count; index++)
            {
                Assert.Equal((short)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128Int32LoadUnsafeTest()
        {
            int* value = stackalloc int[4] {
                0,
                1,
                2,
                3,
            };

            Vector128<int> vector = Vector128.LoadUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<int>.Count; index++)
            {
                Assert.Equal((int)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128Int64LoadUnsafeTest()
        {
            long* value = stackalloc long[2] {
                0,
                1,
            };

            Vector128<long> vector = Vector128.LoadUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<long>.Count; index++)
            {
                Assert.Equal((long)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128NIntLoadUnsafeTest()
        {
            if (Environment.Is64BitProcess)
            {
                nint* value = stackalloc nint[2] {
                    0,
                    1,
                };

                Vector128<nint> vector = Vector128.LoadUnsafe(ref value[0]);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)index, vector.GetElement(index));
                }
            }
            else
            {
                nint* value = stackalloc nint[4] {
                    0,
                    1,
                    2,
                    3,
                };

                Vector128<nint> vector = Vector128.LoadUnsafe(ref value[0]);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)index, vector.GetElement(index));
                }
            }
        }

        [Fact]
        public unsafe void Vector128NUIntLoadUnsafeTest()
        {
            if (Environment.Is64BitProcess)
            {
                nuint* value = stackalloc nuint[2] {
                    0,
                    1,
                };

                Vector128<nuint> vector = Vector128.LoadUnsafe(ref value[0]);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)index, vector.GetElement(index));
                }
            }
            else
            {
                nuint* value = stackalloc nuint[4] {
                    0,
                    1,
                    2,
                    3,
                };

                Vector128<nuint> vector = Vector128.LoadUnsafe(ref value[0]);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)index, vector.GetElement(index));
                }
            }
        }

        [Fact]
        public unsafe void Vector128SByteLoadUnsafeTest()
        {
            sbyte* value = stackalloc sbyte[16] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
            };

            Vector128<sbyte> vector = Vector128.LoadUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<sbyte>.Count; index++)
            {
                Assert.Equal((sbyte)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128SingleLoadUnsafeTest()
        {
            float* value = stackalloc float[4] {
                0,
                1,
                2,
                3,
            };

            Vector128<float> vector = Vector128.LoadUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<float>.Count; index++)
            {
                Assert.Equal((float)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128UInt16LoadUnsafeTest()
        {
            ushort* value = stackalloc ushort[8] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
            };

            Vector128<ushort> vector = Vector128.LoadUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<ushort>.Count; index++)
            {
                Assert.Equal((ushort)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128UInt32LoadUnsafeTest()
        {
            uint* value = stackalloc uint[4] {
                0,
                1,
                2,
                3,
            };

            Vector128<uint> vector = Vector128.LoadUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<uint>.Count; index++)
            {
                Assert.Equal((uint)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128UInt64LoadUnsafeTest()
        {
            ulong* value = stackalloc ulong[2] {
                0,
                1,
            };

            Vector128<ulong> vector = Vector128.LoadUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<ulong>.Count; index++)
            {
                Assert.Equal((ulong)index, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128ByteLoadUnsafeIndexTest()
        {
            byte* value = stackalloc byte[16 + 1] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
                16,
            };

            Vector128<byte> vector = Vector128.LoadUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<byte>.Count; index++)
            {
                Assert.Equal((byte)(index + 1), vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128DoubleLoadUnsafeIndexTest()
        {
            double* value = stackalloc double[2 + 1] {
                0,
                1,
                2,
            };

            Vector128<double> vector = Vector128.LoadUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<double>.Count; index++)
            {
                Assert.Equal((double)(index + 1), vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128Int16LoadUnsafeIndexTest()
        {
            short* value = stackalloc short[8 + 1] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
            };

            Vector128<short> vector = Vector128.LoadUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<short>.Count; index++)
            {
                Assert.Equal((short)(index + 1), vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128Int32LoadUnsafeIndexTest()
        {
            int* value = stackalloc int[4 + 1] {
                0,
                1,
                2,
                3,
                4,
            };

            Vector128<int> vector = Vector128.LoadUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<int>.Count; index++)
            {
                Assert.Equal((int)(index + 1), vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128Int64LoadUnsafeIndexTest()
        {
            long* value = stackalloc long[2 + 1] {
                0,
                1,
                2,
            };

            Vector128<long> vector = Vector128.LoadUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<long>.Count; index++)
            {
                Assert.Equal((long)(index + 1), vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128NIntLoadUnsafeIndexTest()
        {
            if (Environment.Is64BitProcess)
            {
                nint* value = stackalloc nint[2 + 1] {
                    0,
                    1,
                    2,
                };

                Vector128<nint> vector = Vector128.LoadUnsafe(ref value[0], 1);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)(index + 1), vector.GetElement(index));
                }
            }
            else
            {
                nint* value = stackalloc nint[4 + 1] {
                    0,
                    1,
                    2,
                    3,
                    4,
                };

                Vector128<nint> vector = Vector128.LoadUnsafe(ref value[0], 1);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)(index + 1), vector.GetElement(index));
                }
            }
        }

        [Fact]
        public unsafe void Vector128NUIntLoadUnsafeIndexTest()
        {
            if (Environment.Is64BitProcess)
            {
                nuint* value = stackalloc nuint[2 + 1] {
                    0,
                    1,
                    2,
                };

                Vector128<nuint> vector = Vector128.LoadUnsafe(ref value[0], 1);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)(index + 1), vector.GetElement(index));
                }
            }
            else
            {
                nuint* value = stackalloc nuint[4 + 1] {
                    0,
                    1,
                    2,
                    3,
                    4,
                };

                Vector128<nuint> vector = Vector128.LoadUnsafe(ref value[0], 1);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)(index + 1), vector.GetElement(index));
                }
            }
        }

        [Fact]
        public unsafe void Vector128SByteLoadUnsafeIndexTest()
        {
            sbyte* value = stackalloc sbyte[16 + 1] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
                16,
            };

            Vector128<sbyte> vector = Vector128.LoadUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<sbyte>.Count; index++)
            {
                Assert.Equal((sbyte)(index + 1), vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128SingleLoadUnsafeIndexTest()
        {
            float* value = stackalloc float[4 + 1] {
                0,
                1,
                2,
                3,
                4,
            };

            Vector128<float> vector = Vector128.LoadUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<float>.Count; index++)
            {
                Assert.Equal((float)(index + 1), vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128UInt16LoadUnsafeIndexTest()
        {
            ushort* value = stackalloc ushort[8 + 1] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
            };

            Vector128<ushort> vector = Vector128.LoadUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<ushort>.Count; index++)
            {
                Assert.Equal((ushort)(index + 1), vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128UInt32LoadUnsafeIndexTest()
        {
            uint* value = stackalloc uint[4 + 1] {
                0,
                1,
                2,
                3,
                4,
            };

            Vector128<uint> vector = Vector128.LoadUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<uint>.Count; index++)
            {
                Assert.Equal((uint)(index + 1), vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128UInt64LoadUnsafeIndexTest()
        {
            ulong* value = stackalloc ulong[2 + 1] {
                0,
                1,
                2,
            };

            Vector128<ulong> vector = Vector128.LoadUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<ulong>.Count; index++)
            {
                Assert.Equal((ulong)(index + 1), vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128ByteShiftLeftTest()
        {
            Vector128<byte> vector = Vector128.Create((byte)0x01);
            vector = Vector128.ShiftLeft(vector, 4);

            for (int index = 0; index < Vector128<byte>.Count; index++)
            {
                Assert.Equal((byte)0x10, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128Int16ShiftLeftTest()
        {
            Vector128<short> vector = Vector128.Create((short)0x01);
            vector = Vector128.ShiftLeft(vector, 4);

            for (int index = 0; index < Vector128<short>.Count; index++)
            {
                Assert.Equal((short)0x10, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128Int32ShiftLeftTest()
        {
            Vector128<int> vector = Vector128.Create((int)0x01);
            vector = Vector128.ShiftLeft(vector, 4);

            for (int index = 0; index < Vector128<int>.Count; index++)
            {
                Assert.Equal((int)0x10, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128Int64ShiftLeftTest()
        {
            Vector128<long> vector = Vector128.Create((long)0x01);
            vector = Vector128.ShiftLeft(vector, 4);

            for (int index = 0; index < Vector128<long>.Count; index++)
            {
                Assert.Equal((long)0x10, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128NIntShiftLeftTest()
        {
            Vector128<nint> vector = Vector128.Create((nint)0x01);
            vector = Vector128.ShiftLeft(vector, 4);

            for (int index = 0; index < Vector128<nint>.Count; index++)
            {
                Assert.Equal((nint)0x10, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128NUIntShiftLeftTest()
        {
            Vector128<nuint> vector = Vector128.Create((nuint)0x01);
            vector = Vector128.ShiftLeft(vector, 4);

            for (int index = 0; index < Vector128<nuint>.Count; index++)
            {
                Assert.Equal((nuint)0x10, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128SByteShiftLeftTest()
        {
            Vector128<sbyte> vector = Vector128.Create((sbyte)0x01);
            vector = Vector128.ShiftLeft(vector, 4);

            for (int index = 0; index < Vector128<sbyte>.Count; index++)
            {
                Assert.Equal((sbyte)0x10, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128UInt16ShiftLeftTest()
        {
            Vector128<ushort> vector = Vector128.Create((ushort)0x01);
            vector = Vector128.ShiftLeft(vector, 4);

            for (int index = 0; index < Vector128<ushort>.Count; index++)
            {
                Assert.Equal((ushort)0x10, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128UInt32ShiftLeftTest()
        {
            Vector128<uint> vector = Vector128.Create((uint)0x01);
            vector = Vector128.ShiftLeft(vector, 4);

            for (int index = 0; index < Vector128<uint>.Count; index++)
            {
                Assert.Equal((uint)0x10, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128UInt64ShiftLeftTest()
        {
            Vector128<ulong> vector = Vector128.Create((ulong)0x01);
            vector = Vector128.ShiftLeft(vector, 4);

            for (int index = 0; index < Vector128<ulong>.Count; index++)
            {
                Assert.Equal((ulong)0x10, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128Int16ShiftRightArithmeticTest()
        {
            Vector128<short> vector = Vector128.Create(unchecked((short)0x8000));
            vector = Vector128.ShiftRightArithmetic(vector, 4);

            for (int index = 0; index < Vector128<short>.Count; index++)
            {
                Assert.Equal(unchecked((short)0xF800), vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128Int32ShiftRightArithmeticTest()
        {
            Vector128<int> vector = Vector128.Create(unchecked((int)0x80000000));
            vector = Vector128.ShiftRightArithmetic(vector, 4);

            for (int index = 0; index < Vector128<int>.Count; index++)
            {
                Assert.Equal(unchecked((int)0xF8000000), vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128Int64ShiftRightArithmeticTest()
        {
            Vector128<long> vector = Vector128.Create(unchecked((long)0x8000000000000000));
            vector = Vector128.ShiftRightArithmetic(vector, 4);

            for (int index = 0; index < Vector128<long>.Count; index++)
            {
                Assert.Equal(unchecked((long)0xF800000000000000), vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128NIntShiftRightArithmeticTest()
        {
            if (Environment.Is64BitProcess)
            {
                Vector128<nint> vector = Vector128.Create(unchecked((nint)0x8000000000000000));
                vector = Vector128.ShiftRightArithmetic(vector, 4);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal(unchecked((nint)0xF800000000000000), vector.GetElement(index));
                }
            }
            else
            {
                Vector128<nint> vector = Vector128.Create(unchecked((nint)0x80000000));
                vector = Vector128.ShiftRightArithmetic(vector, 4);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal(unchecked((nint)0xF8000000), vector.GetElement(index));
                }
            }
        }

        [Fact]
        public void Vector128SByteShiftRightArithmeticTest()
        {
            Vector128<sbyte> vector = Vector128.Create(unchecked((sbyte)0x80));
            vector = Vector128.ShiftRightArithmetic(vector, 4);

            for (int index = 0; index < Vector128<sbyte>.Count; index++)
            {
                Assert.Equal(unchecked((sbyte)0xF8), vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128ByteShiftRightLogicalTest()
        {
            Vector128<byte> vector = Vector128.Create((byte)0x80);
            vector = Vector128.ShiftRightLogical(vector, 4);

            for (int index = 0; index < Vector128<byte>.Count; index++)
            {
                Assert.Equal((byte)0x08, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128Int16ShiftRightLogicalTest()
        {
            Vector128<short> vector = Vector128.Create(unchecked((short)0x8000));
            vector = Vector128.ShiftRightLogical(vector, 4);

            for (int index = 0; index < Vector128<short>.Count; index++)
            {
                Assert.Equal((short)0x0800, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128Int32ShiftRightLogicalTest()
        {
            Vector128<int> vector = Vector128.Create(unchecked((int)0x80000000));
            vector = Vector128.ShiftRightLogical(vector, 4);

            for (int index = 0; index < Vector128<int>.Count; index++)
            {
                Assert.Equal((int)0x08000000, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128Int64ShiftRightLogicalTest()
        {
            Vector128<long> vector = Vector128.Create(unchecked((long)0x8000000000000000));
            vector = Vector128.ShiftRightLogical(vector, 4);

            for (int index = 0; index < Vector128<long>.Count; index++)
            {
                Assert.Equal((long)0x0800000000000000, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128NIntShiftRightLogicalTest()
        {
            if (Environment.Is64BitProcess)
            {
                Vector128<nint> vector = Vector128.Create(unchecked((nint)0x8000000000000000));
                vector = Vector128.ShiftRightLogical(vector, 4);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal(unchecked((nint)0x0800000000000000), vector.GetElement(index));
                }
            }
            else
            {
                Vector128<nint> vector = Vector128.Create(unchecked((nint)0x80000000));
                vector = Vector128.ShiftRightLogical(vector, 4);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal(unchecked((nint)0x08000000), vector.GetElement(index));
                }
            }
        }

        [Fact]
        public void Vector128NUIntShiftRightLogicalTest()
        {
            if (Environment.Is64BitProcess)
            {
                Vector128<nuint> vector = Vector128.Create(unchecked((nuint)0x8000000000000000));
                vector = Vector128.ShiftRightLogical(vector, 4);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal(unchecked((nuint)0x0800000000000000), vector.GetElement(index));
                }
            }
            else
            {
                Vector128<nuint> vector = Vector128.Create(unchecked((nuint)0x80000000));
                vector = Vector128.ShiftRightLogical(vector, 4);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal(unchecked((nuint)0x08000000), vector.GetElement(index));
                }
            }
        }

        [Fact]
        public void Vector128SByteShiftRightLogicalTest()
        {
            Vector128<sbyte> vector = Vector128.Create(unchecked((sbyte)0x80));
            vector = Vector128.ShiftRightLogical(vector, 4);

            for (int index = 0; index < Vector128<sbyte>.Count; index++)
            {
                Assert.Equal((sbyte)0x08, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128UInt16ShiftRightLogicalTest()
        {
            Vector128<ushort> vector = Vector128.Create(unchecked((ushort)0x8000));
            vector = Vector128.ShiftRightLogical(vector, 4);

            for (int index = 0; index < Vector128<ushort>.Count; index++)
            {
                Assert.Equal((ushort)0x0800, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128UInt32ShiftRightLogicalTest()
        {
            Vector128<uint> vector = Vector128.Create(0x80000000);
            vector = Vector128.ShiftRightLogical(vector, 4);

            for (int index = 0; index < Vector128<uint>.Count; index++)
            {
                Assert.Equal((uint)0x08000000, vector.GetElement(index));
            }
        }

        [Fact]
        public void Vector128UInt64ShiftRightLogicalTest()
        {
            Vector128<ulong> vector = Vector128.Create(0x8000000000000000);
            vector = Vector128.ShiftRightLogical(vector, 4);

            for (int index = 0; index < Vector128<ulong>.Count; index++)
            {
                Assert.Equal((ulong)0x0800000000000000, vector.GetElement(index));
            }
        }

        [Fact]
        public unsafe void Vector128ByteStoreTest()
        {
            byte* value = stackalloc byte[16] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
            };

            Vector128.Create((byte)0x1).Store(value);

            for (int index = 0; index < Vector128<byte>.Count; index++)
            {
                Assert.Equal((byte)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128DoubleStoreTest()
        {
            double* value = stackalloc double[2] {
                0,
                1,
            };

            Vector128.Create((double)0x1).Store(value);

            for (int index = 0; index < Vector128<double>.Count; index++)
            {
                Assert.Equal((double)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128Int16StoreTest()
        {
            short* value = stackalloc short[8] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
            };

            Vector128.Create((short)0x1).Store(value);

            for (int index = 0; index < Vector128<short>.Count; index++)
            {
                Assert.Equal((short)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128Int32StoreTest()
        {
            int* value = stackalloc int[4] {
                0,
                1,
                2,
                3,
            };

            Vector128.Create((int)0x1).Store(value);

            for (int index = 0; index < Vector128<int>.Count; index++)
            {
                Assert.Equal((int)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128Int64StoreTest()
        {
            long* value = stackalloc long[2] {
                0,
                1,
            };

            Vector128.Create((long)0x1).Store(value);

            for (int index = 0; index < Vector128<long>.Count; index++)
            {
                Assert.Equal((long)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128NIntStoreTest()
        {
            if (Environment.Is64BitProcess)
            {
                nint* value = stackalloc nint[2] {
                    0,
                    1,
                };

                Vector128.Create((nint)0x1).Store(value);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)0x1, value[index]);
                }
            }
            else
            {
                nint* value = stackalloc nint[4] {
                    0,
                    1,
                    2,
                    3,
                };

                Vector128.Create((nint)0x1).Store(value);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)0x1, value[index]);
                }
            }
        }

        [Fact]
        public unsafe void Vector128NUIntStoreTest()
        {
            if (Environment.Is64BitProcess)
            {
                nuint* value = stackalloc nuint[2] {
                    0,
                    1,
                };

                Vector128.Create((nuint)0x1).Store(value);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)0x1, value[index]);
                }
            }
            else
            {
                nuint* value = stackalloc nuint[4] {
                    0,
                    1,
                    2,
                    3,
                };

                Vector128.Create((nuint)0x1).Store(value);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)0x1, value[index]);
                }
            }
        }

        [Fact]
        public unsafe void Vector128SByteStoreTest()
        {
            sbyte* value = stackalloc sbyte[16] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
            };

            Vector128.Create((sbyte)0x1).Store(value);

            for (int index = 0; index < Vector128<sbyte>.Count; index++)
            {
                Assert.Equal((sbyte)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128SingleStoreTest()
        {
            float* value = stackalloc float[4] {
                0,
                1,
                2,
                3,
            };

            Vector128.Create((float)0x1).Store(value);

            for (int index = 0; index < Vector128<float>.Count; index++)
            {
                Assert.Equal((float)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128UInt16StoreTest()
        {
            ushort* value = stackalloc ushort[8] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
            };

            Vector128.Create((ushort)0x1).Store(value);

            for (int index = 0; index < Vector128<ushort>.Count; index++)
            {
                Assert.Equal((ushort)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128UInt32StoreTest()
        {
            uint* value = stackalloc uint[4] {
                0,
                1,
                2,
                3,
            };

            Vector128.Create((uint)0x1).Store(value);

            for (int index = 0; index < Vector128<uint>.Count; index++)
            {
                Assert.Equal((uint)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128UInt64StoreTest()
        {
            ulong* value = stackalloc ulong[2] {
                0,
                1,
            };

            Vector128.Create((ulong)0x1).Store(value);

            for (int index = 0; index < Vector128<ulong>.Count; index++)
            {
                Assert.Equal((ulong)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128ByteStoreAlignedTest()
        {
            byte* value = null;

            try
            {
                value = (byte*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;
                value[8] = 8;
                value[9] = 9;
                value[10] = 10;
                value[11] = 11;
                value[12] = 12;
                value[13] = 13;
                value[14] = 14;
                value[15] = 15;

                Vector128.Create((byte)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<byte>.Count; index++)
                {
                    Assert.Equal((byte)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128DoubleStoreAlignedTest()
        {
            double* value = null;

            try
            {
                value = (double*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128.Create((double)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<double>.Count; index++)
                {
                    Assert.Equal((double)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int16StoreAlignedTest()
        {
            short* value = null;

            try
            {
                value = (short*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;

                Vector128.Create((short)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<short>.Count; index++)
                {
                    Assert.Equal((short)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int32StoreAlignedTest()
        {
            int* value = null;

            try
            {
                value = (int*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128.Create((int)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<int>.Count; index++)
                {
                    Assert.Equal((int)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int64StoreAlignedTest()
        {
            long* value = null;

            try
            {
                value = (long*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128.Create((long)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<long>.Count; index++)
                {
                    Assert.Equal((long)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128NIntStoreAlignedTest()
        {
            nint* value = null;

            try
            {
                value = (nint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                if (Environment.Is64BitProcess)
                {
                    value[0] = 0;
                    value[1] = 1;
                }
                else
                {
                    value[0] = 0;
                    value[1] = 1;
                    value[2] = 2;
                    value[3] = 3;
                }

                Vector128.Create((nint)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128NUIntStoreAlignedTest()
        {
            nuint* value = null;

            try
            {
                value = (nuint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                if (Environment.Is64BitProcess)
                {
                    value[0] = 0;
                    value[1] = 1;
                }
                else
                {
                    value[0] = 0;
                    value[1] = 1;
                    value[2] = 2;
                    value[3] = 3;
                }

                Vector128.Create((nuint)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128SByteStoreAlignedTest()
        {
            sbyte* value = null;

            try
            {
                value = (sbyte*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;
                value[8] = 8;
                value[9] = 9;
                value[10] = 10;
                value[11] = 11;
                value[12] = 12;
                value[13] = 13;
                value[14] = 14;
                value[15] = 15;

                Vector128.Create((sbyte)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<sbyte>.Count; index++)
                {
                    Assert.Equal((sbyte)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128SingleStoreAlignedTest()
        {
            float* value = null;

            try
            {
                value = (float*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128.Create((float)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<float>.Count; index++)
                {
                    Assert.Equal((float)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt16StoreAlignedTest()
        {
            ushort* value = null;

            try
            {
                value = (ushort*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;

                Vector128.Create((ushort)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<ushort>.Count; index++)
                {
                    Assert.Equal((ushort)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt32StoreAlignedTest()
        {
            uint* value = null;

            try
            {
                value = (uint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128.Create((uint)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<uint>.Count; index++)
                {
                    Assert.Equal((uint)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt64StoreAlignedTest()
        {
            ulong* value = null;

            try
            {
                value = (ulong*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128.Create((ulong)0x1).StoreAligned(value);

                for (int index = 0; index < Vector128<ulong>.Count; index++)
                {
                    Assert.Equal((ulong)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128ByteStoreAlignedNonTemporalTest()
        {
            byte* value = null;

            try
            {
                value = (byte*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;
                value[8] = 8;
                value[9] = 9;
                value[10] = 10;
                value[11] = 11;
                value[12] = 12;
                value[13] = 13;
                value[14] = 14;
                value[15] = 15;

                Vector128.Create((byte)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<byte>.Count; index++)
                {
                    Assert.Equal((byte)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128DoubleStoreAlignedNonTemporalTest()
        {
            double* value = null;

            try
            {
                value = (double*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128.Create((double)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<double>.Count; index++)
                {
                    Assert.Equal((double)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int16StoreAlignedNonTemporalTest()
        {
            short* value = null;

            try
            {
                value = (short*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;

                Vector128.Create((short)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<short>.Count; index++)
                {
                    Assert.Equal((short)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int32StoreAlignedNonTemporalTest()
        {
            int* value = null;

            try
            {
                value = (int*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128.Create((int)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<int>.Count; index++)
                {
                    Assert.Equal((int)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128Int64StoreAlignedNonTemporalTest()
        {
            long* value = null;

            try
            {
                value = (long*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128.Create((long)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<long>.Count; index++)
                {
                    Assert.Equal((long)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128NIntStoreAlignedNonTemporalTest()
        {
            nint* value = null;

            try
            {
                value = (nint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                if (Environment.Is64BitProcess)
                {
                    value[0] = 0;
                    value[1] = 1;
                }
                else
                {
                    value[0] = 0;
                    value[1] = 1;
                    value[2] = 2;
                    value[3] = 3;
                }

                Vector128.Create((nint)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128NUIntStoreAlignedNonTemporalTest()
        {
            nuint* value = null;

            try
            {
                value = (nuint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                if (Environment.Is64BitProcess)
                {
                    value[0] = 0;
                    value[1] = 1;
                }
                else
                {
                    value[0] = 0;
                    value[1] = 1;
                    value[2] = 2;
                    value[3] = 3;
                }

                Vector128.Create((nuint)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128SByteStoreAlignedNonTemporalTest()
        {
            sbyte* value = null;

            try
            {
                value = (sbyte*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;
                value[8] = 8;
                value[9] = 9;
                value[10] = 10;
                value[11] = 11;
                value[12] = 12;
                value[13] = 13;
                value[14] = 14;
                value[15] = 15;

                Vector128.Create((sbyte)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<sbyte>.Count; index++)
                {
                    Assert.Equal((sbyte)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128SingleStoreAlignedNonTemporalTest()
        {
            float* value = null;

            try
            {
                value = (float*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128.Create((float)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<float>.Count; index++)
                {
                    Assert.Equal((float)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt16StoreAlignedNonTemporalTest()
        {
            ushort* value = null;

            try
            {
                value = (ushort*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;
                value[4] = 4;
                value[5] = 5;
                value[6] = 6;
                value[7] = 7;

                Vector128.Create((ushort)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<ushort>.Count; index++)
                {
                    Assert.Equal((ushort)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt32StoreAlignedNonTemporalTest()
        {
            uint* value = null;

            try
            {
                value = (uint*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;
                value[2] = 2;
                value[3] = 3;

                Vector128.Create((uint)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<uint>.Count; index++)
                {
                    Assert.Equal((uint)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128UInt64StoreAlignedNonTemporalTest()
        {
            ulong* value = null;

            try
            {
                value = (ulong*)NativeMemory.AlignedAlloc(byteCount: 16, alignment: 16);

                value[0] = 0;
                value[1] = 1;

                Vector128.Create((ulong)0x1).StoreAlignedNonTemporal(value);

                for (int index = 0; index < Vector128<ulong>.Count; index++)
                {
                    Assert.Equal((ulong)0x1, value[index]);
                }
            }
            finally
            {
                NativeMemory.AlignedFree(value);
            }
        }

        [Fact]
        public unsafe void Vector128ByteStoreUnsafeTest()
        {
            byte* value = stackalloc byte[16] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
            };

            Vector128.Create((byte)0x1).StoreUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<byte>.Count; index++)
            {
                Assert.Equal((byte)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128DoubleStoreUnsafeTest()
        {
            double* value = stackalloc double[2] {
                0,
                1,
            };

            Vector128.Create((double)0x1).StoreUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<double>.Count; index++)
            {
                Assert.Equal((double)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128Int16StoreUnsafeTest()
        {
            short* value = stackalloc short[8] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
            };

            Vector128.Create((short)0x1).StoreUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<short>.Count; index++)
            {
                Assert.Equal((short)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128Int32StoreUnsafeTest()
        {
            int* value = stackalloc int[4] {
                0,
                1,
                2,
                3,
            };

            Vector128.Create((int)0x1).StoreUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<int>.Count; index++)
            {
                Assert.Equal((int)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128Int64StoreUnsafeTest()
        {
            long* value = stackalloc long[2] {
                0,
                1,
            };

            Vector128.Create((long)0x1).StoreUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<long>.Count; index++)
            {
                Assert.Equal((long)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128NIntStoreUnsafeTest()
        {
            if (Environment.Is64BitProcess)
            {
                nint* value = stackalloc nint[2] {
                    0,
                    1,
                };

                Vector128.Create((nint)0x1).StoreUnsafe(ref value[0]);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)0x1, value[index]);
                }
            }
            else
            {
                nint* value = stackalloc nint[4] {
                    0,
                    1,
                    2,
                    3,
                };

                Vector128.Create((nint)0x1).StoreUnsafe(ref value[0]);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)0x1, value[index]);
                }
            }
        }

        [Fact]
        public unsafe void Vector128NUIntStoreUnsafeTest()
        {
            if (Environment.Is64BitProcess)
            {
                nuint* value = stackalloc nuint[2] {
                    0,
                    1,
                };

                Vector128.Create((nuint)0x1).StoreUnsafe(ref value[0]);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)0x1, value[index]);
                }
            }
            else
            {
                nuint* value = stackalloc nuint[4] {
                    0,
                    1,
                    2,
                    3,
                };

                Vector128.Create((nuint)0x1).StoreUnsafe(ref value[0]);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)0x1, value[index]);
                }
            }
        }

        [Fact]
        public unsafe void Vector128SByteStoreUnsafeTest()
        {
            sbyte* value = stackalloc sbyte[16] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
            };

            Vector128.Create((sbyte)0x1).StoreUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<sbyte>.Count; index++)
            {
                Assert.Equal((sbyte)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128SingleStoreUnsafeTest()
        {
            float* value = stackalloc float[4] {
                0,
                1,
                2,
                3,
            };

            Vector128.Create((float)0x1).StoreUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<float>.Count; index++)
            {
                Assert.Equal((float)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128UInt16StoreUnsafeTest()
        {
            ushort* value = stackalloc ushort[8] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
            };

            Vector128.Create((ushort)0x1).StoreUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<ushort>.Count; index++)
            {
                Assert.Equal((ushort)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128UInt32StoreUnsafeTest()
        {
            uint* value = stackalloc uint[4] {
                0,
                1,
                2,
                3,
            };

            Vector128.Create((uint)0x1).StoreUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<uint>.Count; index++)
            {
                Assert.Equal((uint)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128UInt64StoreUnsafeTest()
        {
            ulong* value = stackalloc ulong[2] {
                0,
                1,
            };

            Vector128.Create((ulong)0x1).StoreUnsafe(ref value[0]);

            for (int index = 0; index < Vector128<ulong>.Count; index++)
            {
                Assert.Equal((ulong)0x1, value[index]);
            }
        }

        [Fact]
        public unsafe void Vector128ByteStoreUnsafeIndexTest()
        {
            byte* value = stackalloc byte[16 + 1] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
                16,
            };

            Vector128.Create((byte)0x1).StoreUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<byte>.Count; index++)
            {
                Assert.Equal((byte)0x1, value[index + 1]);
            }
        }

        [Fact]
        public unsafe void Vector128DoubleStoreUnsafeIndexTest()
        {
            double* value = stackalloc double[2 + 1] {
                0,
                1,
                2,
            };

            Vector128.Create((double)0x1).StoreUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<double>.Count; index++)
            {
                Assert.Equal((double)0x1, value[index + 1]);
            }
        }

        [Fact]
        public unsafe void Vector128Int16StoreUnsafeIndexTest()
        {
            short* value = stackalloc short[8 + 1] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
            };

            Vector128.Create((short)0x1).StoreUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<short>.Count; index++)
            {
                Assert.Equal((short)0x1, value[index + 1]);
            }
        }

        [Fact]
        public unsafe void Vector128Int32StoreUnsafeIndexTest()
        {
            int* value = stackalloc int[4 + 1] {
                0,
                1,
                2,
                3,
                4,
            };

            Vector128.Create((int)0x1).StoreUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<int>.Count; index++)
            {
                Assert.Equal((int)0x1, value[index + 1]);
            }
        }

        [Fact]
        public unsafe void Vector128Int64StoreUnsafeIndexTest()
        {
            long* value = stackalloc long[2 + 1] {
                0,
                1,
                2,
            };

            Vector128.Create((long)0x1).StoreUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<long>.Count; index++)
            {
                Assert.Equal((long)0x1, value[index + 1]);
            }
        }

        [Fact]
        public unsafe void Vector128NIntStoreUnsafeIndexTest()
        {
            if (Environment.Is64BitProcess)
            {
                nint* value = stackalloc nint[2 + 1] {
                    0,
                    1,
                    2,
                };

                Vector128.Create((nint)0x1).StoreUnsafe(ref value[0], 1);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)0x1, value[index + 1]);
                }
            }
            else
            {
                nint* value = stackalloc nint[4 + 1] {
                    0,
                    1,
                    2,
                    3,
                    4,
                };

                Vector128.Create((nint)0x1).StoreUnsafe(ref value[0], 1);

                for (int index = 0; index < Vector128<nint>.Count; index++)
                {
                    Assert.Equal((nint)0x1, value[index + 1]);
                }
            }
        }

        [Fact]
        public unsafe void Vector128NUIntStoreUnsafeIndexTest()
        {
            if (Environment.Is64BitProcess)
            {
                nuint* value = stackalloc nuint[2 + 1] {
                    0,
                    1,
                    2,
                };

                Vector128.Create((nuint)0x1).StoreUnsafe(ref value[0], 1);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)0x1, value[index + 1]);
                }
            }
            else
            {
                nuint* value = stackalloc nuint[4 + 1] {
                    0,
                    1,
                    2,
                    3,
                    4,
                };

                Vector128.Create((nuint)0x1).StoreUnsafe(ref value[0], 1);

                for (int index = 0; index < Vector128<nuint>.Count; index++)
                {
                    Assert.Equal((nuint)0x1, value[index + 1]);
                }
            }
        }

        [Fact]
        public unsafe void Vector128SByteStoreUnsafeIndexTest()
        {
            sbyte* value = stackalloc sbyte[16 + 1] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
                16,
            };

            Vector128.Create((sbyte)0x1).StoreUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<sbyte>.Count; index++)
            {
                Assert.Equal((sbyte)0x1, value[index + 1]);
            }
        }

        [Fact]
        public unsafe void Vector128SingleStoreUnsafeIndexTest()
        {
            float* value = stackalloc float[4 + 1] {
                0,
                1,
                2,
                3,
                4,
            };

            Vector128.Create((float)0x1).StoreUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<float>.Count; index++)
            {
                Assert.Equal((float)0x1, value[index + 1]);
            }
        }

        [Fact]
        public unsafe void Vector128UInt16StoreUnsafeIndexTest()
        {
            ushort* value = stackalloc ushort[8 + 1] {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
            };

            Vector128.Create((ushort)0x1).StoreUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<ushort>.Count; index++)
            {
                Assert.Equal((ushort)0x1, value[index + 1]);
            }
        }

        [Fact]
        public unsafe void Vector128UInt32StoreUnsafeIndexTest()
        {
            uint* value = stackalloc uint[4 + 1] {
                0,
                1,
                2,
                3,
                4,
            };

            Vector128.Create((uint)0x1).StoreUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<uint>.Count; index++)
            {
                Assert.Equal((uint)0x1, value[index + 1]);
            }
        }

        [Fact]
        public unsafe void Vector128UInt64StoreUnsafeIndexTest()
        {
            ulong* value = stackalloc ulong[2 + 1] {
                0,
                1,
                2,
            };

            Vector128.Create((ulong)0x1).StoreUnsafe(ref value[0], 1);

            for (int index = 0; index < Vector128<ulong>.Count; index++)
            {
                Assert.Equal((ulong)0x1, value[index + 1]);
            }
        }

        [Fact]
        public void Vector128ByteSumTest()
        {
            Vector128<byte> vector = Vector128.Create((byte)0x01);
            Assert.Equal((byte)16, Vector128.Sum(vector));
        }

        [Fact]
        public void Vector128DoubleSumTest()
        {
            Vector128<double> vector = Vector128.Create((double)0x01);
            Assert.Equal(2.0, Vector128.Sum(vector));
        }

        [Fact]
        public void Vector128Int16SumTest()
        {
            Vector128<short> vector = Vector128.Create((short)0x01);
            Assert.Equal((short)8, Vector128.Sum(vector));
        }

        [Fact]
        public void Vector128Int32SumTest()
        {
            Vector128<int> vector = Vector128.Create((int)0x01);
            Assert.Equal((int)4, Vector128.Sum(vector));
        }

        [Fact]
        public void Vector128Int64SumTest()
        {
            Vector128<long> vector = Vector128.Create((long)0x01);
            Assert.Equal((long)2, Vector128.Sum(vector));
        }

        [Fact]
        [ActiveIssue("https://github.com/dotnet/runtime/issues/63746", TestPlatforms.tvOS)]
        public void Vector128NIntSumTest()
        {
            Vector128<nint> vector = Vector128.Create((nint)0x01);

            if (Environment.Is64BitProcess)
            {
                Assert.Equal((nint)2, Vector128.Sum(vector));
            }
            else
            {
                Assert.Equal((nint)4, Vector128.Sum(vector));
            }
        }

        [Fact]
        [ActiveIssue("https://github.com/dotnet/runtime/issues/63746", TestPlatforms.tvOS)]
        public void Vector128NUIntSumTest()
        {
            Vector128<nuint> vector = Vector128.Create((nuint)0x01);

            if (Environment.Is64BitProcess)
            {
                Assert.Equal((nuint)2, Vector128.Sum(vector));
            }
            else
            {
                Assert.Equal((nuint)4, Vector128.Sum(vector));
            }
        }

        [Fact]
        public void Vector128SByteSumTest()
        {
            Vector128<sbyte> vector = Vector128.Create((sbyte)0x01);
            Assert.Equal((sbyte)16, Vector128.Sum(vector));
        }

        [Fact]
        public void Vector128SingleSumTest()
        {
            Vector128<float> vector = Vector128.Create((float)0x01);
            Assert.Equal(4.0f, Vector128.Sum(vector));
        }

        [Fact]
        public void Vector128UInt16SumTest()
        {
            Vector128<ushort> vector = Vector128.Create((ushort)0x01);
            Assert.Equal((ushort)8, Vector128.Sum(vector));
        }

        [Fact]
        public void Vector128UInt32SumTest()
        {
            Vector128<uint> vector = Vector128.Create((uint)0x01);
            Assert.Equal((uint)4, Vector128.Sum(vector));
        }

        [Fact]
        public void Vector128UInt64SumTest()
        {
            Vector128<ulong> vector = Vector128.Create((ulong)0x01);
            Assert.Equal((ulong)2, Vector128.Sum(vector));
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1)]
        [InlineData(0, 1, 2, 3, 4, 5, 6, 7, 8)]
        [InlineData(50, 430, int.MaxValue, int.MinValue)]
        public void Vector128Int32IndexerTest(params int[] values)
        {
            var vector = Vector128.Create(values);

            Assert.Equal(vector[0], values[0]);
            Assert.Equal(vector[1], values[1]);
            Assert.Equal(vector[2], values[2]);
            Assert.Equal(vector[3], values[3]);
        }

        [Theory]
        [InlineData(0L, 0L)]
        [InlineData(1L, 1L)]
        [InlineData(0L, 1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L)]
        [InlineData(50L, 430L, long.MaxValue, long.MinValue)]
        public void Vector128Int64IndexerTest(params long[] values)
        {
            var vector = Vector128.Create(values);

            Assert.Equal(vector[0], values[0]);
            Assert.Equal(vector[1], values[1]);
        }
    }
}
