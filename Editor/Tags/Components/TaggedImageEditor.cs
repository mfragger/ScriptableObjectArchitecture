using ScriptableObjectArchitecture.Tags.Components.UI;
using UnityEditor;
using UnityEditor.UI;
using UnityEditorInternal;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(TaggedImage), true)]
    public class TaggedImageEditor : ImageEditor
    {
        private ReorderableList reorderableList;

        protected override void OnEnable()
        {
            base.OnEnable();
            SetUpReorderableList();
        }

        private void SetUpReorderableList()
        {
            reorderableList = new ReorderableList(
                            serializedObject,
                            serializedObject.FindProperty("Tags"))
            {
                displayAdd = true,
                displayRemove = true,
                drawHeaderCallback = rect => EditorGUI.LabelField(rect, "Tags"),

                drawElementCallback = (rect, index, isActive, isFocused) =>
                {
                    if (index > reorderableList.serializedProperty.arraySize - 1) return;

                    var element = reorderableList.serializedProperty.GetArrayElementAtIndex(index);

                    EditorGUI.ObjectField(new Rect(
                        rect.x, rect.y,
                        rect.width,
                        EditorGUIUtility.singleLineHeight), element, typeof(ImageTag));
                },
            };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawInspector();

            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();

            EditorUtility.SetDirty(target);
        }

        private void DrawInspector()
        {
            if (GUILayout.Button($"Create New {typeof(ImageTag).Name}"))
            {
                CreateNewTag();
            }
            reorderableList.DoLayoutList();
        }
        private void CreateNewTag()
        {
            var asset = CreateInstance<ImageTag>();
            string path = ProjectSettings.GetOrCreateSettings().pathForScriptableObject != string.Empty ? ProjectSettings.GetOrCreateSettings().pathForScriptableObject : "Assets";
            path = path[^1] == '/' ? path : $"{path}/";
            string name = AssetDatabase.GenerateUniqueAssetPath($"{path}New {typeof(ImageTag).Name}.asset");
            AssetDatabase.CreateAsset(asset, name);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}
