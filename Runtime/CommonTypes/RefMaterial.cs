using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Variable/Reference/Material")]
    public class RefMaterial : Variable<Material, RefMaterial> { }
}
