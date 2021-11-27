using UnityEditor;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(GameObjectEventListener))]
    public class GameObjectEventListenerInspector : UnityEditor.Editor
    {
        SerializedProperty intB;
        SerializedProperty intA;

        void OnEnable()
        {
            intB = serializedObject.FindProperty("Response");
            intA = serializedObject.FindProperty("GameEvent");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(intA);
            EditorGUILayout.PropertyField(intB);
            serializedObject.ApplyModifiedProperties();
        }
    }
}