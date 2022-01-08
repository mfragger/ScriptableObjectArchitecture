using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(GameObjectTagger), true)]
    public class GameObjectTaggerEditor : ObjectTaggerEditor<GameObject, GameObjectTag> { }
}
