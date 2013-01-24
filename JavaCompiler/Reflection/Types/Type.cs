using System;
using System.Linq;

namespace JavaCompiler.Reflection.Types
{
    public class Type
    {
        public Type()
        {
            Package = new Package();
        }

        public Package Package { get; set; }
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

        public virtual string GetDescriptor(bool shortDescriptor = false)
        {
            if (Primitive)
            {
                throw new NotImplementedException();
            }

            var arrayDimensions = new string(Enumerable.Range(0, ArrayDimensions).Select(x => '[').ToArray());

            var name = (Package != null ? Package.Name + "." : "") + Name;
            name = name.Replace('.', '/');

            if (shortDescriptor)
            {
                return name;
            }
            return arrayDimensions + "L" + name + ";";
        }

        public virtual Type Clone()
        {
            return new Type
            {
                ArrayDimensions = ArrayDimensions,
                Name = Name,
                Package = Package.Clone(),
                Synthetic = Synthetic
            };
        }
    }
}