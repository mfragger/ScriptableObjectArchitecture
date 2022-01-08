using System;
using System.CodeDom.Compiler;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

namespace ScriptableObjectArchitecture.Editor
{
    public abstract class ObjectTaggerEditor<T0, T1> : UnityEditor.Editor where T0 : UnityEngine.Object where T1 : Tag<T0>
    {
        private ReorderableList reorderableList;

        private void OnEnable()
        {
            var tagger = (ObjectTagger<T0>)target;
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
                        EditorGUIUtility.singleLineHeight), element, typeof(T1));
                },
            };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawInspector();

            serializedObject.ApplyModifiedProperties();

            EditorUtility.SetDirty(target);
        }

        private void DrawInspector()
        {
            if (GUILayout.Button($"Create New {typeof(T1).Name}"))
            {
                CreateNewTag();
            }
            reorderableList.DoLayoutList();
        }

        private void CreateNewTag()
        {
            var asset = CreateInstance<T1>();
            string name = AssetDatabase.GenerateUniqueAssetPath($"Assets/S.Tests/New {typeof(T1).Name}.asset");
            AssetDatabase.CreateAsset(asset, name);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
            //ProjectWindowUtil.StartNameEditingIfProjectWindowExists(asset.GetInstanceID(),);
        }
    }
}
