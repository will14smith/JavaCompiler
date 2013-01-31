namespace JavaCompiler.Compilation.ByteCode
{
    public class Chain
    {
        /** The position of the jump instruction.
         */
        public int PC { get; private set; }

        /** The machine state after the jump instruction.
         *  Invariant: all elements of a chain list have the same stacksize
         *  and compatible stack and register contents.
         */
        public State State { get; private set; }

        /** The next jump in the list.
         */
        public Chain Next { get; private set; }

        /** Construct a chain from its jump position, stacksize, previous
         *  chain, and machine state.
         */
        public Chain(int pc, Chain next, State state)
        {
            PC = pc;
            Next = next;
            State = state;
        }
    }
}
