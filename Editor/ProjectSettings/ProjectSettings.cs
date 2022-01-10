using Newtonsoft.Json.Serialization;
using Sirenix.OdinInspector.Editor.TypeSearch;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace ScriptableObjectArchitecture.Editor
{
    internal sealed class ProjectSettings : ScriptableObject
    {
        [HideInInspector]
        public const string default_path = "Assets/ScriptableObjectArchitecture_Settings.asset";

        [HideInInspector]
        public static GUID GUID;

        private string pathForEditor;

        private string pathForCSSO;

        [SerializeField]
        internal string pathForScriptableObject;

        internal static ProjectSettings GetOrCreateSettings()
        {
            string path = GetPathToSettings();

            var settings = AssetDatabase.LoadAssetAtPath<ProjectSettings>(path);
            if (settings == null)
            {
                settings = CreateInstance<ProjectSettings>();
                AssetDatabase.CreateAsset(settings, default_path);
                GUID = AssetDatabase.GUIDFromAssetPath(default_path);
                AssetDatabase.SaveAssets();
            }
            return settings;
        }

        internal static SerializedObject GetSerializedSettings()
        {
            return new SerializedObject(GetOrCreateSettings());
        }

        private static string GetPathToSettings()
        {
            string path;
            if (!GUID.Empty())
            {
                path = AssetDatabase.GUIDToAssetPath(GUID);
            }
            else
            {
                path = default_path;
            }

            return path;
        }
    }

    public static class CustomProjectSettings
    {

        private const string UXML = "Packages/com.mfragger.scriptableobjectarchitecture/Editor/ProjectSettings/ProjectSettings.uxml";

        ////for testing
        //private const string Asset_UXML = "Assets/ScriptableObjectArchitecture/Editor/ProjectSettings/ProjectSettings.uxml";

        [SettingsProvider]
        public static SettingsProvider CreateCustomProjectSettings()
        {
            return new SettingsProvider("Project/Scriptable Object Architecture", SettingsScope.Project)
            {
                activateHandler = (searchContext, rootElement) =>
                {
                    var settings = ProjectSettings.GetSerializedSettings();

                    //VisualTreeAsset uiAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(UXML);
                    //rootElement = uiAsset.CloneTree();

                    //rootElement.Bind(settings);

                    // rootElement is a VisualElement. If you add any children to it, the OnGUI function
                    // isn't called because the SettingsProvider uses the UIElements drawing framework.
                    var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/ScriptableObjectArchitecture/Editor/ProjectSettings/ProjectSettings.uss");
                    rootElement.styleSheets.Add(styleSheet);
                    var title = new Label()
                    {
                        text = "Custom UI Elements"
                    };

                    title.AddToClassList("title");
                    rootElement.Add(title);

                    var properties = new VisualElement()
                    {
                        style =
                    {
                        flexDirection = FlexDirection.Column
                    }
                    };
                    properties.AddToClassList("property-list");
                    rootElement.Add(properties);

                    properties.Add(new PropertyField(settings.FindProperty("m_SomeString")));
                    properties.Add(new PropertyField(settings.FindProperty("m_Number")));

                    rootElement.Bind(settings);
                }
            };
        }
    }
}
