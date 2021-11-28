using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    public static class CreateScripts
    {
        private const string emptyClassTemplate = "EmptyClass.cs.txt";
        private const string assetsFolder = "Assets/ScriptableObjectArchitecture/Editor/ScriptTemplate";
        private const string packagesFolder = "Packages/com.mfragger.scriptableobjectarchitecture/Editor/ScriptTemplate";
        private const string SOReferencedBehaviour = "NewBehaviourScript.cs.txt";

        [MenuItem(itemName: "Assets/Create/SOArchitecture/C# SO Referenced Script", isValidateFunction: false, priority: 51)]
        public static void CreateClassFromTemplate()
        {
            string asset = AssetDatabase.AssetPathToGUID($"{packagesFolder}/{SOReferencedBehaviour}");

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                !string.IsNullOrWhiteSpace(asset) ? AssetDatabase.GUIDToAssetPath(asset) : AssetDatabase.GUIDToAssetPath(AssetDatabase.AssetPathToGUID($"{assetsFolder}/{SOReferencedBehaviour}")),
                "SOReferencedBehaviour.cs");
        }
    }
}
