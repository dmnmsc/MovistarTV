// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using System.Runtime.InteropServices;

namespace IpTviewr.Native
{
    public static class NativeUtils
    {
        public static byte[] StructToBytes<T>(T structure) where T : struct
        {
            var gcHandle = new GCHandle();

            var bytes = new byte[Marshal.SizeOf(typeof(T))];
            try
            {
                gcHandle = GCHandle.Alloc(structure, GCHandleType.Pinned);
                Marshal.Copy(gcHandle.AddrOfPinnedObject(), bytes, 0, bytes.Length);

                return bytes;
            }
            finally
            {
                if (gcHandle.IsAllocated) gcHandle.Free();
            } // finally
        } // StructToBytes
    } // static class NativeUtils
} // namespace
