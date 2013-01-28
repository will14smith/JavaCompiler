using System;
using System.Runtime.InteropServices;

namespace JavaCompiler.Jbt.Tree
{
    internal static unsafe class Memory
    {
        public static void* Alloc<T>(int elementCount) where T : struct
        {
            var newSizeInBytes = Marshal.SizeOf(typeof(T)) * elementCount;
            var newArrayPointer = (byte*)Marshal.AllocHGlobal(newSizeInBytes).ToPointer();

            for (var i = 0; i < newSizeInBytes; i++)
                *(newArrayPointer + i) = 0;

            return newArrayPointer;
        }
        public static void* Alloc(Type t, int elementCount)
        {
            var newSizeInBytes = Marshal.SizeOf(t) * elementCount;
            var newArrayPointer = (byte*)Marshal.AllocHGlobal(newSizeInBytes).ToPointer();

            for (var i = 0; i < newSizeInBytes; i++)
                *(newArrayPointer + i) = 0;

            return newArrayPointer;
        }

        public static void Free(void* pointerToUnmanagedMemory)
        {
            Marshal.FreeHGlobal(new IntPtr(pointerToUnmanagedMemory));
        }

        public static void* Resize<T>(void* oldPointer, int newElementCount) where T : struct
        {
            return (Marshal.ReAllocHGlobal(new IntPtr(oldPointer), new IntPtr(Marshal.SizeOf(typeof(T)) * newElementCount))).ToPointer();
        }

        public static void** AllocVoid(int elementCount)
        {
            var newSizeInBytes = Marshal.SizeOf(typeof(void*)) * elementCount;
            var newArrayPointer = (byte*)Marshal.AllocHGlobal(newSizeInBytes).ToPointer();

            for (var i = 0; i < newSizeInBytes; i++)
                *(newArrayPointer + i) = 0;

            return (void**) newArrayPointer;
        }
    }
}
