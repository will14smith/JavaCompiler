﻿namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class MultiplicativeNode : BinaryNode
    {
        #region Nested type: MultiplicativeDivideNode

        public class MultiplicativeDivideNode : MultiplicativeNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " / " + RightChild + ")";
            }
        }

        #endregion

        #region Nested type: MultiplicativeModNode

        public class MultiplicativeModNode : MultiplicativeNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " % " + RightChild + ")";
            }
        }

        #endregion

        #region Nested type: MultiplicativeMultiplyNode

        public class MultiplicativeMultiplyNode : MultiplicativeNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " * " + RightChild + ")";
            }
        }

        #endregion
    }
}