using UnityEditor;

namespace ScriptableObjectArchitecture.Editor.Generated
{
    [CustomEditor(typeof(AudioEventListener))]
    public class AudioEventListnerView : UnityEditor.Editor
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