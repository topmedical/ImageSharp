﻿// <copyright file="BigEndianBitConverter.ToTypeTests.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Tests.IO
{
    using System;
    using ImageSharp.IO;
    using Xunit;

    /// <summary>
    /// The <see cref="BigEndianBitConverter"/> tests.
    /// </summary>
    public class BigEndianBitConverterTests
    {
        [Fact]
        public void CopyToWithNullBufferThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.BigEndianConverter.ToBoolean(null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.BigEndianConverter.ToInt16(null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.BigEndianConverter.ToUInt16(null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.BigEndianConverter.ToInt32(null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.BigEndianConverter.ToUInt32(null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.BigEndianConverter.ToInt64(null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.BigEndianConverter.ToUInt64(null, 0));
        }

        [Fact]
        public void CopyToWithIndexTooBigThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToBoolean(new byte[1], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToInt16(new byte[2], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToUInt16(new byte[2], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToInt32(new byte[4], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToUInt32(new byte[4], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToInt64(new byte[8], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToUInt64(new byte[8], 1));
        }

        [Fact]
        public void CopyToWithBufferTooSmallThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToBoolean(new byte[0], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToInt16(new byte[1], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToUInt16(new byte[1], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToInt32(new byte[3], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToUInt32(new byte[3], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToInt64(new byte[7], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.BigEndianConverter.ToUInt64(new byte[7], 0));
        }

        /// <summary>
        /// Tests that passing a <see cref="bool"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void ToBoolean()
        {
            Assert.Equal(false, EndianBitConverter.BigEndianConverter.ToBoolean(new byte[] { 0 }, 0));
            Assert.Equal(true, EndianBitConverter.BigEndianConverter.ToBoolean(new byte[] { 1 }, 0));
            Assert.Equal(true, EndianBitConverter.BigEndianConverter.ToBoolean(new byte[] { 42 }, 0));
        }

        /// <summary>
        /// Tests that passing a <see cref="short"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void ToInt16()
        {
            Assert.Equal((short)0, EndianBitConverter.BigEndianConverter.ToInt16(new byte[] { 0, 0 }, 0));
            Assert.Equal((short)1, EndianBitConverter.BigEndianConverter.ToInt16(new byte[] { 0, 1 }, 0));
            Assert.Equal((short)256, EndianBitConverter.BigEndianConverter.ToInt16(new byte[] { 1, 0 }, 0));
            Assert.Equal((short)-1, EndianBitConverter.BigEndianConverter.ToInt16(new byte[] { 255, 255 }, 0));
            Assert.Equal((short)257, EndianBitConverter.BigEndianConverter.ToInt16(new byte[] { 1, 1 }, 0));
        }

        /// <summary>
        /// Tests that passing a <see cref="ushort"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void ToUInt16()
        {
            Assert.Equal((ushort)0, EndianBitConverter.BigEndianConverter.ToUInt16(new byte[] { 0, 0 }, 0));
            Assert.Equal((ushort)1, EndianBitConverter.BigEndianConverter.ToUInt16(new byte[] { 0, 1 }, 0));
            Assert.Equal((ushort)256, EndianBitConverter.BigEndianConverter.ToUInt16(new byte[] { 1, 0 }, 0));
            Assert.Equal(ushort.MaxValue, EndianBitConverter.BigEndianConverter.ToUInt16(new byte[] { 255, 255 }, 0));
            Assert.Equal((ushort)257, EndianBitConverter.BigEndianConverter.ToUInt16(new byte[] { 1, 1 }, 0));
        }

        /// <summary>
        /// Tests that passing a <see cref="int"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void ToInt32()
        {
            Assert.Equal(0, EndianBitConverter.BigEndianConverter.ToInt32(new byte[] { 0, 0, 0, 0 }, 0));
            Assert.Equal(1, EndianBitConverter.BigEndianConverter.ToInt32(new byte[] { 0, 0, 0, 1 }, 0));
            Assert.Equal(256, EndianBitConverter.BigEndianConverter.ToInt32(new byte[] { 0, 0, 1, 0 }, 0));
            Assert.Equal(65536, EndianBitConverter.BigEndianConverter.ToInt32(new byte[] { 0, 1, 0, 0 }, 0));
            Assert.Equal(16777216, EndianBitConverter.BigEndianConverter.ToInt32(new byte[] { 1, 0, 0, 0 }, 0));
            Assert.Equal(-1, EndianBitConverter.BigEndianConverter.ToInt32(new byte[] { 255, 255, 255, 255 }, 0));
            Assert.Equal(257, EndianBitConverter.BigEndianConverter.ToInt32(new byte[] { 0, 0, 1, 1 }, 0));
        }

        /// <summary>
        /// Tests that passing a <see cref="uint"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void ToUInt32()
        {
            Assert.Equal((uint)0, EndianBitConverter.BigEndianConverter.ToUInt32(new byte[] { 0, 0, 0, 0 }, 0));
            Assert.Equal((uint)1, EndianBitConverter.BigEndianConverter.ToUInt32(new byte[] { 0, 0, 0, 1 }, 0));
            Assert.Equal((uint)256, EndianBitConverter.BigEndianConverter.ToUInt32(new byte[] { 0, 0, 1, 0 }, 0));
            Assert.Equal((uint)65536, EndianBitConverter.BigEndianConverter.ToUInt32(new byte[] { 0, 1, 0, 0 }, 0));
            Assert.Equal((uint)16777216, EndianBitConverter.BigEndianConverter.ToUInt32(new byte[] { 1, 0, 0, 0 }, 0));
            Assert.Equal(uint.MaxValue, EndianBitConverter.BigEndianConverter.ToUInt32(new byte[] { 255, 255, 255, 255 }, 0));
            Assert.Equal((uint)257, EndianBitConverter.BigEndianConverter.ToUInt32(new byte[] { 0, 0, 1, 1 }, 0));
        }

        /// <summary>
        /// Tests that passing a <see cref="long"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void ToInt64()
        {
            Assert.Equal(0L, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0));
            Assert.Equal(1L, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 }, 0));
            Assert.Equal(256L, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 0, 0, 0, 0, 0, 0, 1, 0 }, 0));
            Assert.Equal(65536L, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 0, 0, 0, 0, 0, 1, 0, 0 }, 0));
            Assert.Equal(16777216L, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 }, 0));
            Assert.Equal(4294967296L, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 }, 0));
            Assert.Equal(1099511627776L, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 0, 0, 1, 0, 0, 0, 0, 0 }, 0));
            Assert.Equal(1099511627776L * 256, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 0, 1, 0, 0, 0, 0, 0, 0 }, 0));
            Assert.Equal(1099511627776L * 256 * 256, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 0));
            Assert.Equal(-1L, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 255, 255, 255, 255, 255, 255, 255, 255 }, 0));
            Assert.Equal(257L, EndianBitConverter.BigEndianConverter.ToInt64(new byte[] { 0, 0, 0, 0, 0, 0, 1, 1 }, 0));
        }

        /// <summary>
        /// Tests that passing a <see cref="ulong"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void GetBytesULong()
        {
            Assert.Equal(0UL, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0));
            Assert.Equal(1UL, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 }, 0));
            Assert.Equal(256UL, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 0, 0, 0, 0, 0, 0, 1, 0 }, 0));
            Assert.Equal(65536UL, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 0, 0, 0, 0, 0, 1, 0, 0 }, 0));
            Assert.Equal(16777216UL, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 }, 0));
            Assert.Equal(4294967296UL, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 }, 0));
            Assert.Equal(1099511627776UL, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 0, 0, 1, 0, 0, 0, 0, 0 }, 0));
            Assert.Equal(1099511627776UL * 256, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 0, 1, 0, 0, 0, 0, 0, 0 }, 0));
            Assert.Equal(1099511627776UL * 256 * 256, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 }, 0));
            Assert.Equal(ulong.MaxValue, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 255, 255, 255, 255, 255, 255, 255, 255 }, 0));
            Assert.Equal(257UL, EndianBitConverter.BigEndianConverter.ToUInt64(new byte[] { 0, 0, 0, 0, 0, 0, 1, 1 }, 0));
        }
    }
}