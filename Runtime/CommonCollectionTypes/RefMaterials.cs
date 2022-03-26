using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/Materials")]
    public class RefMaterials : RefCollection<Material, RefMaterials> { }
}
