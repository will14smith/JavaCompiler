using System;
using System.Linq;

namespace JavaCompiler.Reflection.Types
{
    public class Type
    {
        public virtual string Name { get; set; }
        public int ArrayDimensions { get; set; }

        public virtual bool Primitive
        {
            get { return false; }
        }

        public bool Synthetic { get; set; }

        public virtual bool IsAssignableTo(Type c)
        {
            return false;
        }

        public bool CanAssignTo(Type c)
        {
            return c.IsAssignableTo(this);
        }

        public virtual string GetDescriptor()
        {
            if (Primitive)
            {
                throw new NotImplementedException();
            }

            var arrayDimensions = new string(Enumerable.Range(0, ArrayDimensions).Select(x => '[').ToArray());

            return arrayDimensions + "L" + Name + ";";
        }
    }
}