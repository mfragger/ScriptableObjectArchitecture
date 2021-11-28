using ScriptableObjectArchitecture.Serializables;
using System.Linq;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    //Variables
    public abstract class Variable<T> : ScriptableObject
    {
        public T Value;
    }
    public abstract class ConstantVariable<T> : ScriptableObject
    {
        [SerializeField]
        private T Value;
        public T GetValue()
        {
            return Value;
        }
    }

    //Collections
    public abstract class Collection<T> : ScriptableObject
    {
        public T[] Value;

    }
    public abstract class ConstantCollection<T> : ScriptableObject
    {
        [SerializeField]
        private new T[] Values;
        public T GetValue(int i)
        {
            return Values[i];
        }
        public T[] GetValueRange(int fromIndexInclusive, int toIndexInclusive)
        {
            return Values[fromIndexInclusive..(toIndexInclusive - 1)];
        }
        public T[] GetCollection()
        {
            return Values.ToArray<T>();
        }
        public T Find(T item)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                if (Values[i].Equals(item))
                    return Values[i];
            }
            return default;
        }
        public int GetLength()
        {
            return Values.Length;
        }
    }
}
