using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Tag", fileName = "New Tag Name")]
    public class Tag : ScriptableObject
    {
        public List<GameObject> Tagged;
        public void Add(GameObject callerObject)
        {
            Tagged.Add(callerObject);
        }
        public void Remove(GameObject callerObject)
        {
            Tagged.Remove(callerObject);
        }
    }
}
