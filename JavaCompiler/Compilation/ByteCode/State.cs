using System.Diagnostics;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilation.ByteCode
{
    public class State
    {
        /** The (types of the) contents of the machine stack. */
        private TypeStack stack;

        public State()
        {
            stack = new TypeStack();
        }

        public int StackSize { get { return stack.Count; } }
        public short MaxStackSize { get { return (short)stack.MaxStack; } }

        public State Clone()
        {
            return new State
            {
                stack = stack.Clone()
            };
        }

        public void Push(Type t)
        {
            stack.Push(t);
        }
        public Type Peek()
        {
            return stack.Peek();
        }
        public Type Pop1()
        {
            return stack.Pop1();
        }
        public Type Pop2()
        {
            return stack.Pop2();
        }
        public void Pop(int n)
        {
            stack.Pop(n);
        }
        public void Pop(Type t)
        {
            stack.Pop(t);
        }

        public Type GetStack(int i)
        {
            return stack[i];
        }

        public State Join(State other)
        {
            Debug.Assert(StackSize == other.StackSize);

            for (var i = 0; i < StackSize; )
            {
                var t = stack[i];
                var tother = other.stack[i];

                var result = t.FindCommonType(tother);

                var w = TypeCodeHelper.Width(result);

                stack[i] = result;

                if (w == 2) Debug.Assert(stack[i + 1] == null);
                i += w;
            }
            return this;
        }
    }
}
