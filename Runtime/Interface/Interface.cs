using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture.Interface
{
    public class Interface : ScriptableObject
    {
        private List<IInterface> interfaces = new();

        public interface IInterface
        {
            void Invoke();
        }

        public void Invoke()
        {
            var count = interfaces.Count;
            for (int i = 0; i < count; i++)
            {
                interfaces[i].Invoke();
            }
        }

        public void SetCallback(IInterface @interface)
        {
            interfaces.Add(@interface);
        }

        public void UnsetCallback(IInterface @interface)
        {
            interfaces.Remove(@interface);
        }
    }
}
