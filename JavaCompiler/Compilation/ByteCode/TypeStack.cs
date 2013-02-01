using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilation.ByteCode
{
    class TypeStack : StackList<Type>
    {
        public int MaxStack { get; internal set; }

        public override void Push(Type type)
        {
            switch (TypeCodeHelper.TypeCode(type))
            {
                case ItemTypeCode.Void:
                    return;
                case ItemTypeCode.Byte:
                case ItemTypeCode.Char:
                case ItemTypeCode.Short:
                    //TODO: case ItemTypeCode.Boolean:
                    type = PrimativeTypes.Int;
                    break;
            }

            base.Push(type);

            switch (TypeCodeHelper.Width(type))
            {
                case 1:
                    break;
                case 2:
                    base.Push(null);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            if (Count > MaxStack)
                MaxStack = Count;
        }

        public Type Pop1()
        {
            var result = Pop();

            Debug.Assert(result != null && TypeCodeHelper.Width(result) == 1);

            return result;
        }
        public Type Pop2()
        {
            var result = Pop();

            Debug.Assert(Pop() == null && result != null && TypeCodeHelper.Width(result) == 2);

            return result;
        }

        public void Pop(int n)
        {
            while (n > 0)
            {
                Pop();

                n--;
            }
        }

        public void Pop(Type type)
        {
            Pop(TypeCodeHelper.Width(type));
        }

        private Stack<Type[]> stackScope = new Stack<Type[]>();
        public void PushScope()
        {
            var newArray = array.Clone() as Type[];

            stackScope.Push(newArray);
            version++;
        }
        public void PopScope()
        {
            var oldArray = stackScope.Pop();

            Clear();

            array = oldArray;
            version++;
        }

        public TypeStack Clone()
        {
            var stack = new TypeStack
            {
                array = (Type[])array.Clone(),
                MaxStack = MaxStack,
                stackScope = new Stack<Type[]>(stackScope.Reverse()),
                version = version,
                Count = Count
            };
            return stack;
        }

        public Type Peek(int i)
        {
            return Count - i < 0 ? null : array[Count - i];
        }
    }
}
